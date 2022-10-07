
namespace DumbCodeYe
{
    partial class CrackOptions
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
            this.twoWords = new System.Windows.Forms.CheckedListBox();
            this.threeWords = new System.Windows.Forms.CheckedListBox();
            this.fourWords = new System.Windows.Forms.CheckedListBox();
            this.oneWords = new System.Windows.Forms.CheckedListBox();
            this.commonLetters = new System.Windows.Forms.NumericUpDown();
            this.commonLbl = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.oneWordOrder = new System.Windows.Forms.NumericUpDown();
            this.twoWordOrder = new System.Windows.Forms.NumericUpDown();
            this.threeWordOrder = new System.Windows.Forms.NumericUpDown();
            this.fourWordOrder = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.commonLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneWordOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoWordOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeWordOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourWordOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // twoWords
            // 
            this.twoWords.FormattingEnabled = true;
            this.twoWords.Items.AddRange(new object[] {
            "be",
            "to",
            "of",
            "in",
            "it",
            "on",
            "he",
            "as",
            "do",
            "at",
            "by",
            "we",
            "or",
            "an"});
            this.twoWords.Location = new System.Drawing.Point(113, 12);
            this.twoWords.Name = "twoWords";
            this.twoWords.Size = new System.Drawing.Size(95, 409);
            this.twoWords.TabIndex = 0;
            // 
            // threeWords
            // 
            this.threeWords.FormattingEnabled = true;
            this.threeWords.Items.AddRange(new object[] {
            "the",
            "and",
            "for",
            "not",
            "you",
            "but",
            "his",
            "say",
            "her",
            "she",
            "one",
            "all"});
            this.threeWords.Location = new System.Drawing.Point(214, 12);
            this.threeWords.Name = "threeWords";
            this.threeWords.Size = new System.Drawing.Size(95, 409);
            this.threeWords.TabIndex = 1;
            // 
            // fourWords
            // 
            this.fourWords.FormattingEnabled = true;
            this.fourWords.Items.AddRange(new object[] {
            "that",
            "have",
            "with",
            "this",
            "from",
            "they",
            "will"});
            this.fourWords.Location = new System.Drawing.Point(315, 12);
            this.fourWords.Name = "fourWords";
            this.fourWords.Size = new System.Drawing.Size(95, 409);
            this.fourWords.TabIndex = 2;
            // 
            // oneWords
            // 
            this.oneWords.FormattingEnabled = true;
            this.oneWords.Items.AddRange(new object[] {
            "i",
            "a"});
            this.oneWords.Location = new System.Drawing.Point(12, 12);
            this.oneWords.Name = "oneWords";
            this.oneWords.Size = new System.Drawing.Size(95, 409);
            this.oneWords.TabIndex = 3;
            // 
            // commonLetters
            // 
            this.commonLetters.Location = new System.Drawing.Point(416, 30);
            this.commonLetters.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.commonLetters.Name = "commonLetters";
            this.commonLetters.Size = new System.Drawing.Size(139, 20);
            this.commonLetters.TabIndex = 4;
            this.commonLetters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // commonLbl
            // 
            this.commonLbl.Location = new System.Drawing.Point(416, 12);
            this.commonLbl.Name = "commonLbl";
            this.commonLbl.Size = new System.Drawing.Size(139, 15);
            this.commonLbl.TabIndex = 5;
            this.commonLbl.Text = "Number of common letters";
            this.commonLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(416, 406);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(139, 41);
            this.applyBtn.TabIndex = 6;
            this.applyBtn.Text = "APPLY";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // oneWordOrder
            // 
            this.oneWordOrder.Location = new System.Drawing.Point(12, 427);
            this.oneWordOrder.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.oneWordOrder.Name = "oneWordOrder";
            this.oneWordOrder.Size = new System.Drawing.Size(95, 20);
            this.oneWordOrder.TabIndex = 7;
            // 
            // twoWordOrder
            // 
            this.twoWordOrder.Location = new System.Drawing.Point(113, 427);
            this.twoWordOrder.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.twoWordOrder.Name = "twoWordOrder";
            this.twoWordOrder.Size = new System.Drawing.Size(95, 20);
            this.twoWordOrder.TabIndex = 8;
            this.twoWordOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // threeWordOrder
            // 
            this.threeWordOrder.Location = new System.Drawing.Point(214, 427);
            this.threeWordOrder.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.threeWordOrder.Name = "threeWordOrder";
            this.threeWordOrder.Size = new System.Drawing.Size(95, 20);
            this.threeWordOrder.TabIndex = 9;
            this.threeWordOrder.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // fourWordOrder
            // 
            this.fourWordOrder.Location = new System.Drawing.Point(315, 427);
            this.fourWordOrder.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.fourWordOrder.Name = "fourWordOrder";
            this.fourWordOrder.Size = new System.Drawing.Size(95, 20);
            this.fourWordOrder.TabIndex = 10;
            this.fourWordOrder.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // CrackOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.fourWordOrder);
            this.Controls.Add(this.threeWordOrder);
            this.Controls.Add(this.twoWordOrder);
            this.Controls.Add(this.oneWordOrder);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.commonLbl);
            this.Controls.Add(this.commonLetters);
            this.Controls.Add(this.oneWords);
            this.Controls.Add(this.fourWords);
            this.Controls.Add(this.threeWords);
            this.Controls.Add(this.twoWords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CrackOptions";
            this.Text = "CrackOptions";
            ((System.ComponentModel.ISupportInitialize)(this.commonLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneWordOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoWordOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeWordOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourWordOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox twoWords;
        private System.Windows.Forms.CheckedListBox threeWords;
        private System.Windows.Forms.CheckedListBox fourWords;
        private System.Windows.Forms.CheckedListBox oneWords;
        private System.Windows.Forms.NumericUpDown commonLetters;
        private System.Windows.Forms.Label commonLbl;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.NumericUpDown oneWordOrder;
        private System.Windows.Forms.NumericUpDown twoWordOrder;
        private System.Windows.Forms.NumericUpDown threeWordOrder;
        private System.Windows.Forms.NumericUpDown fourWordOrder;
    }
}