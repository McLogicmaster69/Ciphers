
namespace DumbCodeYe
{
    partial class Coincidences
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
            this.shiftedText = new System.Windows.Forms.TextBox();
            this.coincidencesText = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // shiftedText
            // 
            this.shiftedText.AcceptsReturn = true;
            this.shiftedText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftedText.Location = new System.Drawing.Point(12, 12);
            this.shiftedText.Multiline = true;
            this.shiftedText.Name = "shiftedText";
            this.shiftedText.ReadOnly = true;
            this.shiftedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shiftedText.Size = new System.Drawing.Size(704, 426);
            this.shiftedText.TabIndex = 0;
            // 
            // coincidencesText
            // 
            this.coincidencesText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coincidencesText.FormattingEnabled = true;
            this.coincidencesText.Location = new System.Drawing.Point(722, 12);
            this.coincidencesText.Name = "coincidencesText";
            this.coincidencesText.Size = new System.Drawing.Size(66, 420);
            this.coincidencesText.TabIndex = 2;
            // 
            // Coincidences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.coincidencesText);
            this.Controls.Add(this.shiftedText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Coincidences";
            this.Text = "Coincidences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shiftedText;
        private System.Windows.Forms.ListBox coincidencesText;
    }
}