
namespace DumbCodeYe.Ciphers.Substitution
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
            this.patternsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patternsList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternsList.FormattingEnabled = true;
            this.patternsList.ItemHeight = 20;
            this.patternsList.Location = new System.Drawing.Point(18, 18);
            this.patternsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.patternsList.Name = "patternsList";
            this.patternsList.Size = new System.Drawing.Size(349, 564);
            this.patternsList.TabIndex = 0;
            this.patternsList.DoubleClick += new System.EventHandler(this.patternsList_DoubleClick);
            // 
            // SubstitutePatternAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 608);
            this.Controls.Add(this.patternsList);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubstitutePatternAnalysis";
            this.Text = "SubstitutePatternAnalysis";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox patternsList;
    }
}