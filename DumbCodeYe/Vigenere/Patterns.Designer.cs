
namespace DumbCodeYe
{
    partial class Patterns
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
            this.patternList = new System.Windows.Forms.ListBox();
            this.patternLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patternList
            // 
            this.patternList.FormattingEnabled = true;
            this.patternList.Location = new System.Drawing.Point(12, 31);
            this.patternList.Name = "patternList";
            this.patternList.Size = new System.Drawing.Size(776, 407);
            this.patternList.TabIndex = 0;
            // 
            // patternLbl
            // 
            this.patternLbl.AutoSize = true;
            this.patternLbl.Location = new System.Drawing.Point(13, 13);
            this.patternLbl.Name = "patternLbl";
            this.patternLbl.Size = new System.Drawing.Size(547, 13);
            this.patternLbl.TabIndex = 1;
            this.patternLbl.Text = "PAT  -  02  03  04  05  06  07  08  09  10  11  12  13  14  15  16  17  18  19  2" +
    "0  -  SPA";
            // 
            // Patterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.patternLbl);
            this.Controls.Add(this.patternList);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Patterns";
            this.Text = "Patterns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox patternList;
        private System.Windows.Forms.Label patternLbl;
    }
}