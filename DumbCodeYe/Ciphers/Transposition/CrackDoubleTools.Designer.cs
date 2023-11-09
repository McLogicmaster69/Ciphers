
namespace DumbCodeYe.Ciphers.Transposition
{
    partial class CrackDoubleTools
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
            this.firstPassList = new System.Windows.Forms.CheckedListBox();
            this.firstPassLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.secondPassList = new System.Windows.Forms.CheckedListBox();
            this.calculationLbl = new System.Windows.Forms.Label();
            this.calculationList = new System.Windows.Forms.CheckedListBox();
            this.TestFactors = new System.Windows.Forms.TextBox();
            this.KnownText = new System.Windows.Forms.TextBox();
            this.doubleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPassList
            // 
            this.firstPassList.FormattingEnabled = true;
            this.firstPassList.Items.AddRange(new object[] {
            "BASIC KEYWORD",
            "COLUMNAR",
            "ROW COLUMNAR",
            "ROUTE",
            "RAILFENCE",
            "SCYLATE",
            "REVERSE"});
            this.firstPassList.Location = new System.Drawing.Point(12, 41);
            this.firstPassList.Name = "firstPassList";
            this.firstPassList.Size = new System.Drawing.Size(129, 109);
            this.firstPassList.TabIndex = 1;
            // 
            // firstPassLbl
            // 
            this.firstPassLbl.Location = new System.Drawing.Point(12, 9);
            this.firstPassLbl.Name = "firstPassLbl";
            this.firstPassLbl.Size = new System.Drawing.Size(129, 29);
            this.firstPassLbl.TabIndex = 2;
            this.firstPassLbl.Text = "FIRST PASS";
            this.firstPassLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "SECOND PASS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondPassList
            // 
            this.secondPassList.FormattingEnabled = true;
            this.secondPassList.Items.AddRange(new object[] {
            "BASIC KEYWORD",
            "COLUMNAR",
            "ROW COLUMNAR",
            "ROUTE",
            "RAILFENCE",
            "SCYLATE",
            "REVERSE"});
            this.secondPassList.Location = new System.Drawing.Point(147, 41);
            this.secondPassList.Name = "secondPassList";
            this.secondPassList.Size = new System.Drawing.Size(129, 109);
            this.secondPassList.TabIndex = 3;
            // 
            // calculationLbl
            // 
            this.calculationLbl.Location = new System.Drawing.Point(282, 9);
            this.calculationLbl.Name = "calculationLbl";
            this.calculationLbl.Size = new System.Drawing.Size(129, 29);
            this.calculationLbl.TabIndex = 6;
            this.calculationLbl.Text = "CALCULATION";
            this.calculationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calculationList
            // 
            this.calculationList.FormattingEnabled = true;
            this.calculationList.Items.AddRange(new object[] {
            "VALID BIGRAMS",
            "KNOWN START",
            "KNOWN END"});
            this.calculationList.Location = new System.Drawing.Point(282, 41);
            this.calculationList.Name = "calculationList";
            this.calculationList.Size = new System.Drawing.Size(129, 109);
            this.calculationList.TabIndex = 5;
            // 
            // TestFactors
            // 
            this.TestFactors.Location = new System.Drawing.Point(417, 67);
            this.TestFactors.Name = "TestFactors";
            this.TestFactors.Size = new System.Drawing.Size(229, 20);
            this.TestFactors.TabIndex = 35;
            // 
            // KnownText
            // 
            this.KnownText.Location = new System.Drawing.Point(417, 41);
            this.KnownText.Name = "KnownText";
            this.KnownText.Size = new System.Drawing.Size(229, 20);
            this.KnownText.TabIndex = 34;
            // 
            // doubleBtn
            // 
            this.doubleBtn.Location = new System.Drawing.Point(417, 93);
            this.doubleBtn.Name = "doubleBtn";
            this.doubleBtn.Size = new System.Drawing.Size(229, 34);
            this.doubleBtn.TabIndex = 33;
            this.doubleBtn.Text = "CRACK DOUBLE";
            this.doubleBtn.UseVisualStyleBackColor = true;
            this.doubleBtn.Click += new System.EventHandler(this.doubleBtn_Click);
            // 
            // CrackDoubleTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 158);
            this.Controls.Add(this.TestFactors);
            this.Controls.Add(this.KnownText);
            this.Controls.Add(this.doubleBtn);
            this.Controls.Add(this.calculationLbl);
            this.Controls.Add(this.calculationList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondPassList);
            this.Controls.Add(this.firstPassLbl);
            this.Controls.Add(this.firstPassList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CrackDoubleTools";
            this.Text = "CrackDoubleTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox firstPassList;
        private System.Windows.Forms.Label firstPassLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox secondPassList;
        private System.Windows.Forms.Label calculationLbl;
        private System.Windows.Forms.CheckedListBox calculationList;
        private System.Windows.Forms.TextBox TestFactors;
        private System.Windows.Forms.TextBox KnownText;
        private System.Windows.Forms.Button doubleBtn;
    }
}