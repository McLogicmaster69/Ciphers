
namespace DumbCodeYe.Substitution
{
    partial class WordFrequencyFrm
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
            this.textOut = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textOut
            // 
            this.textOut.AutoSize = true;
            this.textOut.Location = new System.Drawing.Point(12, 9);
            this.textOut.Name = "textOut";
            this.textOut.Size = new System.Drawing.Size(35, 13);
            this.textOut.TabIndex = 0;
            this.textOut.Text = "label1";
            // 
            // WordFrequencyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(288, 569);
            this.Controls.Add(this.textOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WordFrequencyFrm";
            this.Text = "WordFrequency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textOut;
    }
}