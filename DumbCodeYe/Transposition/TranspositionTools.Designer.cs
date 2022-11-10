
namespace DumbCodeYe.Transposition
{
    partial class TranspositionTools
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
            this.rowColumnBtn = new System.Windows.Forms.Button();
            this.rowColumnarBtn = new System.Windows.Forms.Button();
            this.expectedBtn = new System.Windows.Forms.Button();
            this.maxColumns = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.railsNum = new System.Windows.Forms.NumericUpDown();
            this.railfenceBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.basicKeywordBtn = new System.Windows.Forms.Button();
            this.columnsNum = new System.Windows.Forms.NumericUpDown();
            this.factorsBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.scytaleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.railsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNum)).BeginInit();
            this.SuspendLayout();
            // 
            // rowColumnBtn
            // 
            this.rowColumnBtn.Location = new System.Drawing.Point(9, 144);
            this.rowColumnBtn.Name = "rowColumnBtn";
            this.rowColumnBtn.Size = new System.Drawing.Size(229, 34);
            this.rowColumnBtn.TabIndex = 0;
            this.rowColumnBtn.Text = "ROW COLUMN METHOD";
            this.rowColumnBtn.UseVisualStyleBackColor = true;
            this.rowColumnBtn.Click += new System.EventHandler(this.rowColumnBtn_Click);
            // 
            // rowColumnarBtn
            // 
            this.rowColumnarBtn.Location = new System.Drawing.Point(9, 223);
            this.rowColumnarBtn.Name = "rowColumnarBtn";
            this.rowColumnarBtn.Size = new System.Drawing.Size(229, 34);
            this.rowColumnarBtn.TabIndex = 2;
            this.rowColumnarBtn.Text = "ROW COLUMNAR METHOD";
            this.rowColumnarBtn.UseVisualStyleBackColor = true;
            this.rowColumnarBtn.Click += new System.EventHandler(this.rowColumnarBtn_Click);
            // 
            // expectedBtn
            // 
            this.expectedBtn.Location = new System.Drawing.Point(9, 263);
            this.expectedBtn.Name = "expectedBtn";
            this.expectedBtn.Size = new System.Drawing.Size(229, 34);
            this.expectedBtn.TabIndex = 3;
            this.expectedBtn.Text = "EDIT EXPECTED WORDS";
            this.expectedBtn.UseVisualStyleBackColor = true;
            this.expectedBtn.Click += new System.EventHandler(this.expectedBtn_Click);
            // 
            // maxColumns
            // 
            this.maxColumns.Location = new System.Drawing.Point(9, 197);
            this.maxColumns.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.maxColumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maxColumns.Name = "maxColumns";
            this.maxColumns.Size = new System.Drawing.Size(229, 20);
            this.maxColumns.TabIndex = 4;
            this.maxColumns.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "---------------------------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // railsNum
            // 
            this.railsNum.Location = new System.Drawing.Point(9, 316);
            this.railsNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.railsNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.railsNum.Name = "railsNum";
            this.railsNum.Size = new System.Drawing.Size(229, 20);
            this.railsNum.TabIndex = 6;
            this.railsNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // railfenceBtn
            // 
            this.railfenceBtn.Location = new System.Drawing.Point(9, 342);
            this.railfenceBtn.Name = "railfenceBtn";
            this.railfenceBtn.Size = new System.Drawing.Size(229, 34);
            this.railfenceBtn.TabIndex = 8;
            this.railfenceBtn.Text = "RAIL FENCE METHOD";
            this.railfenceBtn.UseVisualStyleBackColor = true;
            this.railfenceBtn.Click += new System.EventHandler(this.railfenceBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "---------------------------------------------------------------------------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "---------------------------------------------------------------------------";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // basicKeywordBtn
            // 
            this.basicKeywordBtn.Location = new System.Drawing.Point(12, 91);
            this.basicKeywordBtn.Name = "basicKeywordBtn";
            this.basicKeywordBtn.Size = new System.Drawing.Size(229, 34);
            this.basicKeywordBtn.TabIndex = 11;
            this.basicKeywordBtn.Text = "BASIC KEYWORD";
            this.basicKeywordBtn.UseVisualStyleBackColor = true;
            this.basicKeywordBtn.Click += new System.EventHandler(this.basicKeywordBtn_Click);
            // 
            // columnsNum
            // 
            this.columnsNum.Location = new System.Drawing.Point(12, 65);
            this.columnsNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.columnsNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.columnsNum.Name = "columnsNum";
            this.columnsNum.Size = new System.Drawing.Size(229, 20);
            this.columnsNum.TabIndex = 12;
            this.columnsNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // factorsBtn
            // 
            this.factorsBtn.Location = new System.Drawing.Point(12, 12);
            this.factorsBtn.Name = "factorsBtn";
            this.factorsBtn.Size = new System.Drawing.Size(229, 34);
            this.factorsBtn.TabIndex = 13;
            this.factorsBtn.Text = "GET FACTORS";
            this.factorsBtn.UseVisualStyleBackColor = true;
            this.factorsBtn.Click += new System.EventHandler(this.factorsBtn_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "---------------------------------------------------------------------------";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scytaleBtn
            // 
            this.scytaleBtn.Location = new System.Drawing.Point(9, 382);
            this.scytaleBtn.Name = "scytaleBtn";
            this.scytaleBtn.Size = new System.Drawing.Size(229, 34);
            this.scytaleBtn.TabIndex = 15;
            this.scytaleBtn.Text = "SCYTALE METHOD";
            this.scytaleBtn.UseVisualStyleBackColor = true;
            this.scytaleBtn.Click += new System.EventHandler(this.scytaleBtn_Click);
            // 
            // TranspositionTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 425);
            this.Controls.Add(this.scytaleBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.factorsBtn);
            this.Controls.Add(this.columnsNum);
            this.Controls.Add(this.basicKeywordBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.railfenceBtn);
            this.Controls.Add(this.railsNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxColumns);
            this.Controls.Add(this.expectedBtn);
            this.Controls.Add(this.rowColumnarBtn);
            this.Controls.Add(this.rowColumnBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TranspositionTools";
            this.Text = "TranspositionTools";
            ((System.ComponentModel.ISupportInitialize)(this.maxColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.railsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rowColumnBtn;
        private System.Windows.Forms.Button rowColumnarBtn;
        private System.Windows.Forms.Button expectedBtn;
        private System.Windows.Forms.NumericUpDown maxColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown railsNum;
        private System.Windows.Forms.Button railfenceBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button basicKeywordBtn;
        private System.Windows.Forms.NumericUpDown columnsNum;
        private System.Windows.Forms.Button factorsBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button scytaleBtn;
    }
}