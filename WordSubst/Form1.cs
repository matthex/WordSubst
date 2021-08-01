using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordSubst
{
    public partial class Form1 : Form
    {
        HashSet<String> templateFields;
        String selectedTemplatePath;

        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.SettingChanging += new System.Configuration.SettingChangingEventHandler(SettingChanging);

            if (!(Properties.Settings.Default.selectedTemplatePath.Equals("")) && File.Exists(Properties.Settings.Default.selectedTemplatePath))
            {
                this.selectedTemplatePath = Properties.Settings.Default.selectedTemplatePath;
                templatePathLabel.Text = Path.GetFileNameWithoutExtension(this.selectedTemplatePath);
                getTemplateFields();
                populateSubstPanel(this.templateFields);
            }
        }

        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }

        private void template_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Word Documents|*.docx";
            if (!Properties.Settings.Default.selectedTemplatePath.Equals(""))
            {
                fileDlg.InitialDirectory = Path.GetDirectoryName(this.selectedTemplatePath);
            }
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                this.selectedTemplatePath = fileDlg.FileName;
                Properties.Settings.Default.selectedTemplatePath = fileDlg.FileName;
                Properties.Settings.Default.Save();
            }
        }

        void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if(e.SettingName.Equals(GetPropertyName(() => Properties.Settings.Default.selectedTemplatePath)))
            {
                this.selectedTemplatePath = e.NewValue.ToString();
                templatePathLabel.Text = Path.GetFileNameWithoutExtension(e.NewValue.ToString());
            }
            getTemplateFields();
            populateSubstPanel(this.templateFields);
        }

        void getTemplateFields()
        {
            HashSet<String> templateFields = new HashSet<String>();

            Regex pattern = new Regex("@@@((.)*?)###", RegexOptions.Compiled);

            //TODO: Excpetion handling: file in use
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(this.selectedTemplatePath, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                MatchCollection matches = pattern.Matches(docText);
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        templateFields.Add(match.Groups[1].Value);
                    }
                }
            }

            this.templateFields = templateFields;
        }

        void populateSubstPanel(HashSet<string> templateFields)
        {
            substPanel.Controls.Clear();

            int i = 1;
            foreach (String templateField in templateFields)
            {
                Label label = new Label();
                label.Text = templateField;
                label.Name = templateField + "Label";
                label.Size = new Size(150, 20);
                label.Location = new Point(10, i * 25);

                TextBox textbox = new TextBox();
                textbox.Name = templateField + "Textbox";
                textbox.Size = new Size(250, 90);
                textbox.Location = new Point(160, i * 25 - 2);

                substPanel.Controls.Add(label);
                substPanel.Controls.Add(textbox);
                i++;
            }
        }

        private void generateDoc(object sender, EventArgs e)
        {
            String newFilePath = Path.GetDirectoryName(this.selectedTemplatePath) + "/" + "New" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + Path.GetFileNameWithoutExtension(this.selectedTemplatePath) + Path.GetExtension(this.selectedTemplatePath);
            File.Copy(this.selectedTemplatePath, newFilePath);
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(newFilePath, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                foreach (String templateField in this.templateFields)
                {
                    string newValue = ((TextBox)substPanel.Controls.Find(templateField + "Textbox", true)[0]).Text;
                    Regex pattern = new Regex("@@@" + templateField + "###", RegexOptions.Compiled);
                    docText = pattern.Replace(docText, newValue);
                }

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = "WINWORD.EXE";
            //startInfo.Arguments = newFilePath;
            //Process.Start(startInfo);
        }
    }
}
