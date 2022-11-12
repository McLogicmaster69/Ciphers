
namespace DumbCodeYe.Playfair
{
    partial class PlayfairSelection
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
            this.grid5Btn = new System.Windows.Forms.Button();
            this.grid6Btn = new System.Windows.Forms.Button();
            this.verticalRule = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.horizontalRule = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modeRule = new System.Windows.Forms.ComboBox();
            this.iterationNum = new System.Windows.Forms.NumericUpDown();
            this.keyLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.iterationNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyLength)).BeginInit();
            this.SuspendLayout();
            // 
            // grid5Btn
            // 
            this.grid5Btn.Location = new System.Drawing.Point(12, 146);
            this.grid5Btn.Name = "grid5Btn";
            this.grid5Btn.Size = new System.Drawing.Size(232, 31);
            this.grid5Btn.TabIndex = 0;
            this.grid5Btn.Text = "5X5 GRID";
            this.grid5Btn.UseVisualStyleBackColor = true;
            this.grid5Btn.Click += new System.EventHandler(this.grid5Btn_Click);
            // 
            // grid6Btn
            // 
            this.grid6Btn.Location = new System.Drawing.Point(12, 183);
            this.grid6Btn.Name = "grid6Btn";
            this.grid6Btn.Size = new System.Drawing.Size(232, 31);
            this.grid6Btn.TabIndex = 1;
            this.grid6Btn.Text = "6X6 GRID";
            this.grid6Btn.UseVisualStyleBackColor = true;
            this.grid6Btn.Click += new System.EventHandler(this.grid6Btn_Click);
            // 
            // verticalRule
            // 
            this.verticalRule.FormattingEnabled = true;
            this.verticalRule.Items.AddRange(new object[] {
            "VERTICAL UP",
            "VERTICAL DOWN",
            "HORIZONTAL RIGHT",
            "HORIZONTAL LEFT"});
            this.verticalRule.Location = new System.Drawing.Point(101, 12);
            this.verticalRule.MaxDropDownItems = 2;
            this.verticalRule.Name = "verticalRule";
            this.verticalRule.Size = new System.Drawing.Size(143, 21);
            this.verticalRule.TabIndex = 2;
            this.verticalRule.Text = "HORIZONTAL LEFT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ROW RULE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "COLUMN RULE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horizontalRule
            // 
            this.horizontalRule.FormattingEnabled = true;
            this.horizontalRule.Items.AddRange(new object[] {
            "VERTICAL UP",
            "VERTICAL DOWN",
            "HORIZONTAL RIGHT",
            "HORIZONTAL LEFT"});
            this.horizontalRule.Location = new System.Drawing.Point(101, 39);
            this.horizontalRule.MaxDropDownItems = 2;
            this.horizontalRule.Name = "horizontalRule";
            this.horizontalRule.Size = new System.Drawing.Size(143, 21);
            this.horizontalRule.TabIndex = 4;
            this.horizontalRule.Text = "VERTICAL UP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MODE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modeRule
            // 
            this.modeRule.FormattingEnabled = true;
            this.modeRule.Items.AddRange(new object[] {
            "START",
            "CURRENT LETTER"});
            this.modeRule.Location = new System.Drawing.Point(101, 66);
            this.modeRule.MaxDropDownItems = 2;
            this.modeRule.Name = "modeRule";
            this.modeRule.Size = new System.Drawing.Size(143, 21);
            this.modeRule.TabIndex = 6;
            this.modeRule.Text = "START";
            // 
            // iterationNum
            // 
            this.iterationNum.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.iterationNum.Location = new System.Drawing.Point(12, 93);
            this.iterationNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iterationNum.Name = "iterationNum";
            this.iterationNum.Size = new System.Drawing.Size(232, 20);
            this.iterationNum.TabIndex = 8;
            this.iterationNum.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // keyLength
            // 
            this.keyLength.Location = new System.Drawing.Point(12, 119);
            this.keyLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.keyLength.Name = "keyLength";
            this.keyLength.Size = new System.Drawing.Size(232, 20);
            this.keyLength.TabIndex = 9;
            this.keyLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // PlayfairSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 226);
            this.Controls.Add(this.keyLength);
            this.Controls.Add(this.iterationNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modeRule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.horizontalRule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verticalRule);
            this.Controls.Add(this.grid6Btn);
            this.Controls.Add(this.grid5Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayfairSelection";
            this.Load += new System.EventHandler(this.PlayfairSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iterationNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button grid5Btn;
        private System.Windows.Forms.Button grid6Btn;
        private System.Windows.Forms.ComboBox verticalRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox horizontalRule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox modeRule;
        private System.Windows.Forms.NumericUpDown iterationNum;
        private System.Windows.Forms.NumericUpDown keyLength;
    }
}