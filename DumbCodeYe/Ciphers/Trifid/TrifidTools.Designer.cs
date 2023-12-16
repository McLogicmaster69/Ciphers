
namespace DumbCodeYe.Ciphers.Trifid
{
    partial class TrifidTools
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
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.CrackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keywordTxt
            // 
            this.keywordTxt.Location = new System.Drawing.Point(12, 12);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(285, 20);
            this.keywordTxt.TabIndex = 0;
            // 
            // CrackBtn
            // 
            this.CrackBtn.Location = new System.Drawing.Point(12, 38);
            this.CrackBtn.Name = "CrackBtn";
            this.CrackBtn.Size = new System.Drawing.Size(285, 35);
            this.CrackBtn.TabIndex = 1;
            this.CrackBtn.Text = "CRACK";
            this.CrackBtn.UseVisualStyleBackColor = true;
            this.CrackBtn.Click += new System.EventHandler(this.CrackBtn_Click);
            // 
            // TrifidTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 85);
            this.Controls.Add(this.CrackBtn);
            this.Controls.Add(this.keywordTxt);
            this.Name = "TrifidTools";
            this.Text = "TrifidTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Button CrackBtn;
    }
}