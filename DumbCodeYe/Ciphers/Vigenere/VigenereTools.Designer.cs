
namespace DumbCodeYe.Ciphers.Vigenere
{
    partial class VigenereTools
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
            this.coincidencesBtn = new System.Windows.Forms.Button();
            this.patternsBtn = new System.Windows.Forms.Button();
            this.suspectedKeyLength = new System.Windows.Forms.NumericUpDown();
            this.resultsBtn = new System.Windows.Forms.Button();
            this.bruteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.suspectedKeyLength)).BeginInit();
            this.SuspendLayout();
            // 
            // coincidencesBtn
            // 
            this.coincidencesBtn.Location = new System.Drawing.Point(12, 12);
            this.coincidencesBtn.Name = "coincidencesBtn";
            this.coincidencesBtn.Size = new System.Drawing.Size(229, 37);
            this.coincidencesBtn.TabIndex = 0;
            this.coincidencesBtn.Text = "GET COINCIDENCES";
            this.coincidencesBtn.UseVisualStyleBackColor = true;
            this.coincidencesBtn.Click += new System.EventHandler(this.coincidencesBtn_Click);
            // 
            // patternsBtn
            // 
            this.patternsBtn.Location = new System.Drawing.Point(12, 54);
            this.patternsBtn.Name = "patternsBtn";
            this.patternsBtn.Size = new System.Drawing.Size(229, 37);
            this.patternsBtn.TabIndex = 1;
            this.patternsBtn.Text = "GET PATTERNS";
            this.patternsBtn.UseVisualStyleBackColor = true;
            this.patternsBtn.Click += new System.EventHandler(this.patternsBtn_Click);
            // 
            // suspectedKeyLength
            // 
            this.suspectedKeyLength.Location = new System.Drawing.Point(12, 97);
            this.suspectedKeyLength.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.suspectedKeyLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.suspectedKeyLength.Name = "suspectedKeyLength";
            this.suspectedKeyLength.Size = new System.Drawing.Size(229, 20);
            this.suspectedKeyLength.TabIndex = 2;
            this.suspectedKeyLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // resultsBtn
            // 
            this.resultsBtn.Location = new System.Drawing.Point(12, 123);
            this.resultsBtn.Name = "resultsBtn";
            this.resultsBtn.Size = new System.Drawing.Size(229, 37);
            this.resultsBtn.TabIndex = 3;
            this.resultsBtn.Text = "GET RESULTS";
            this.resultsBtn.UseVisualStyleBackColor = true;
            this.resultsBtn.Click += new System.EventHandler(this.resultsBtn_Click);
            // 
            // bruteBtn
            // 
            this.bruteBtn.Location = new System.Drawing.Point(12, 166);
            this.bruteBtn.Name = "bruteBtn";
            this.bruteBtn.Size = new System.Drawing.Size(229, 37);
            this.bruteBtn.TabIndex = 4;
            this.bruteBtn.Text = "BRUTE RESULTS";
            this.bruteBtn.UseVisualStyleBackColor = true;
            this.bruteBtn.Click += new System.EventHandler(this.bruteBtn_Click);
            // 
            // VigenereTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 213);
            this.Controls.Add(this.bruteBtn);
            this.Controls.Add(this.resultsBtn);
            this.Controls.Add(this.suspectedKeyLength);
            this.Controls.Add(this.patternsBtn);
            this.Controls.Add(this.coincidencesBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VigenereTools";
            this.Text = "VigenereTools";
            ((System.ComponentModel.ISupportInitialize)(this.suspectedKeyLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button coincidencesBtn;
        private System.Windows.Forms.Button patternsBtn;
        private System.Windows.Forms.NumericUpDown suspectedKeyLength;
        private System.Windows.Forms.Button resultsBtn;
        private System.Windows.Forms.Button bruteBtn;
    }
}