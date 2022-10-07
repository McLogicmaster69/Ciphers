
namespace DumbCodeYe
{
    partial class SubsitutePatterns
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
            this.runBtn = new System.Windows.Forms.Button();
            this.patternLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.patternLength)).BeginInit();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(12, 38);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(183, 44);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "GET PATTERNS";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // patternLength
            // 
            this.patternLength.Location = new System.Drawing.Point(12, 12);
            this.patternLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.patternLength.Name = "patternLength";
            this.patternLength.Size = new System.Drawing.Size(183, 20);
            this.patternLength.TabIndex = 1;
            this.patternLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // SubsitutePatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 94);
            this.Controls.Add(this.patternLength);
            this.Controls.Add(this.runBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SubsitutePatterns";
            this.Text = "SubsitutePatterns";
            ((System.ComponentModel.ISupportInitialize)(this.patternLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.NumericUpDown patternLength;
    }
}