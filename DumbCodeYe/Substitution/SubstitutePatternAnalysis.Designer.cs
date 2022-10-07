
namespace DumbCodeYe
{
    partial class SubstitutePatternAnalysis
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
            this.patternsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // patternsList
            // 
            this.patternsList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternsList.FormattingEnabled = true;
            this.patternsList.Location = new System.Drawing.Point(12, 12);
            this.patternsList.Name = "patternsList";
            this.patternsList.Size = new System.Drawing.Size(234, 368);
            this.patternsList.TabIndex = 0;
            // 
            // SubstitutePatternAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 395);
            this.Controls.Add(this.patternsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SubstitutePatternAnalysis";
            this.Text = "SubstitutePatternAnalysis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox patternsList;
    }
}