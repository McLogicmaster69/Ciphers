
namespace DumbCodeYe
{
    partial class TextOutputFrm
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
            this.textOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textOut
            // 
            this.textOut.AcceptsReturn = true;
            this.textOut.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOut.Location = new System.Drawing.Point(12, 12);
            this.textOut.Multiline = true;
            this.textOut.Name = "textOut";
            this.textOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOut.Size = new System.Drawing.Size(833, 426);
            this.textOut.TabIndex = 0;
            this.textOut.WordWrap = false;
            // 
            // TextOutputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.textOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TextOutputFrm";
            this.Text = "TextOutput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textOut;
    }
}