using System.IO;
namespace WordSubst
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.templateLabel = new System.Windows.Forms.Label();
            this.templatePathLabel = new System.Windows.Forms.Label();
            this.substPanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateLabel.Location = new System.Drawing.Point(13, 13);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(59, 13);
            this.templateLabel.TabIndex = 0;
            this.templateLabel.Text = "Template";
            this.templateLabel.Click += new System.EventHandler(this.template_Click);
            // 
            // templatePathLabel
            // 
            this.templatePathLabel.AutoSize = true;
            this.templatePathLabel.Location = new System.Drawing.Point(78, 13);
            this.templatePathLabel.Name = "templatePathLabel";
            this.templatePathLabel.Size = new System.Drawing.Size(113, 13);
            this.templatePathLabel.TabIndex = 1;
            this.templatePathLabel.Text = "No templated selected";
            this.templatePathLabel.Click += new System.EventHandler(this.template_Click);
            // 
            // substPanel
            // 
            this.substPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.substPanel.AutoScroll = true;
            this.substPanel.Location = new System.Drawing.Point(12, 29);
            this.substPanel.Name = "substPanel";
            this.substPanel.Size = new System.Drawing.Size(430, 191);
            this.substPanel.TabIndex = 2;
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(182, 226);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateDoc);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 261);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.substPanel);
            this.Controls.Add(this.templatePathLabel);
            this.Controls.Add(this.templateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "WordSubst";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label templateLabel;
        private System.Windows.Forms.Label templatePathLabel;
        private System.Windows.Forms.Panel substPanel;
        private System.Windows.Forms.Button generateButton;
    }
}

