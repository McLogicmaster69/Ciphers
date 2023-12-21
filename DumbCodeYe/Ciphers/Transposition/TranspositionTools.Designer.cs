
namespace DumbCodeYe.Ciphers.Transposition
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
            this.railsNum = new System.Windows.Forms.NumericUpDown();
            this.railfenceBtn = new System.Windows.Forms.Button();
            this.basicKeywordBtn = new System.Windows.Forms.Button();
            this.columnsNum = new System.Windows.Forms.NumericUpDown();
            this.factorsBtn = new System.Windows.Forms.Button();
            this.scytaleBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.substringLengthNum = new System.Windows.Forms.NumericUpDown();
            this.getSubstringBtn = new System.Windows.Forms.Button();
            this.substringIndexNum = new System.Windows.Forms.NumericUpDown();
            this.applyTranspositionBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.doubleBtn = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            this.border = new System.Windows.Forms.PictureBox();
            this.columnarBtn = new System.Windows.Forms.Button();
            this.routeBtn = new System.Windows.Forms.Button();
            this.xBtn = new System.Windows.Forms.Button();
            this.groupBtn = new System.Windows.Forms.Button();
            this.changeOtherBtn = new System.Windows.Forms.Button();
            this.KnownText = new System.Windows.Forms.TextBox();
            this.TestFactors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crackDoubleToolsBtn = new System.Windows.Forms.Button();
            this.cadneusBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.inputMethodBx = new System.Windows.Forms.ComboBox();
            this.CreateGridBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.railsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.substringLengthNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.substringIndexNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.border)).BeginInit();
            this.SuspendLayout();
            // 
            // rowColumnBtn
            // 
            this.rowColumnBtn.Location = new System.Drawing.Point(388, 73);
            this.rowColumnBtn.Name = "rowColumnBtn";
            this.rowColumnBtn.Size = new System.Drawing.Size(166, 34);
            this.rowColumnBtn.TabIndex = 0;
            this.rowColumnBtn.Text = "ROW COLUMN METHOD";
            this.rowColumnBtn.UseVisualStyleBackColor = true;
            this.rowColumnBtn.Click += new System.EventHandler(this.rowColumnBtn_Click);
            // 
            // rowColumnarBtn
            // 
            this.rowColumnarBtn.Location = new System.Drawing.Point(388, 156);
            this.rowColumnarBtn.Name = "rowColumnarBtn";
            this.rowColumnarBtn.Size = new System.Drawing.Size(166, 34);
            this.rowColumnarBtn.TabIndex = 2;
            this.rowColumnarBtn.Text = "ROW COLUMNAR METHOD";
            this.rowColumnarBtn.UseVisualStyleBackColor = true;
            this.rowColumnarBtn.Click += new System.EventHandler(this.rowColumnarBtn_Click);
            // 
            // expectedBtn
            // 
            this.expectedBtn.Location = new System.Drawing.Point(337, 262);
            this.expectedBtn.Name = "expectedBtn";
            this.expectedBtn.Size = new System.Drawing.Size(229, 34);
            this.expectedBtn.TabIndex = 3;
            this.expectedBtn.Text = "EDIT EXPECTED WORDS";
            this.expectedBtn.UseVisualStyleBackColor = true;
            this.expectedBtn.Click += new System.EventHandler(this.expectedBtn_Click);
            // 
            // maxColumns
            // 
            this.maxColumns.Location = new System.Drawing.Point(337, 196);
            this.maxColumns.Maximum = new decimal(new int[] {
            3000,
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
            // railsNum
            // 
            this.railsNum.Location = new System.Drawing.Point(581, 10);
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
            this.railfenceBtn.Location = new System.Drawing.Point(581, 36);
            this.railfenceBtn.Name = "railfenceBtn";
            this.railfenceBtn.Size = new System.Drawing.Size(229, 34);
            this.railfenceBtn.TabIndex = 8;
            this.railfenceBtn.Text = "RAIL FENCE METHOD";
            this.railfenceBtn.UseVisualStyleBackColor = true;
            this.railfenceBtn.Click += new System.EventHandler(this.railfenceBtn_Click);
            // 
            // basicKeywordBtn
            // 
            this.basicKeywordBtn.Location = new System.Drawing.Point(388, 36);
            this.basicKeywordBtn.Name = "basicKeywordBtn";
            this.basicKeywordBtn.Size = new System.Drawing.Size(166, 34);
            this.basicKeywordBtn.TabIndex = 11;
            this.basicKeywordBtn.Text = "BASIC KEYWORD";
            this.basicKeywordBtn.UseVisualStyleBackColor = true;
            this.basicKeywordBtn.Click += new System.EventHandler(this.basicKeywordBtn_Click);
            // 
            // columnsNum
            // 
            this.columnsNum.Location = new System.Drawing.Point(137, 8);
            this.columnsNum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.columnsNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.columnsNum.Name = "columnsNum";
            this.columnsNum.Size = new System.Drawing.Size(82, 20);
            this.columnsNum.TabIndex = 12;
            this.columnsNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // factorsBtn
            // 
            this.factorsBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.factorsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.factorsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factorsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factorsBtn.Location = new System.Drawing.Point(12, 9);
            this.factorsBtn.Name = "factorsBtn";
            this.factorsBtn.Size = new System.Drawing.Size(27, 512);
            this.factorsBtn.TabIndex = 13;
            this.factorsBtn.Text = "FACTORS";
            this.factorsBtn.UseVisualStyleBackColor = false;
            this.factorsBtn.Click += new System.EventHandler(this.factorsBtn_Click);
            // 
            // scytaleBtn
            // 
            this.scytaleBtn.Location = new System.Drawing.Point(581, 77);
            this.scytaleBtn.Name = "scytaleBtn";
            this.scytaleBtn.Size = new System.Drawing.Size(229, 34);
            this.scytaleBtn.TabIndex = 15;
            this.scytaleBtn.Text = "SCYTALE METHOD";
            this.scytaleBtn.UseVisualStyleBackColor = true;
            this.scytaleBtn.Click += new System.EventHandler(this.scytaleBtn_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(581, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "---------------------------------------------------------------------------";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // substringLengthNum
            // 
            this.substringLengthNum.Location = new System.Drawing.Point(581, 156);
            this.substringLengthNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.substringLengthNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.substringLengthNum.Name = "substringLengthNum";
            this.substringLengthNum.Size = new System.Drawing.Size(229, 20);
            this.substringLengthNum.TabIndex = 18;
            this.substringLengthNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // getSubstringBtn
            // 
            this.getSubstringBtn.Location = new System.Drawing.Point(581, 182);
            this.getSubstringBtn.Name = "getSubstringBtn";
            this.getSubstringBtn.Size = new System.Drawing.Size(229, 34);
            this.getSubstringBtn.TabIndex = 17;
            this.getSubstringBtn.Text = "GET SUBSTRING";
            this.getSubstringBtn.UseVisualStyleBackColor = true;
            this.getSubstringBtn.Click += new System.EventHandler(this.getSubstringBtn_Click);
            // 
            // substringIndexNum
            // 
            this.substringIndexNum.Location = new System.Drawing.Point(581, 130);
            this.substringIndexNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.substringIndexNum.Name = "substringIndexNum";
            this.substringIndexNum.Size = new System.Drawing.Size(229, 20);
            this.substringIndexNum.TabIndex = 19;
            // 
            // applyTranspositionBtn
            // 
            this.applyTranspositionBtn.Location = new System.Drawing.Point(581, 222);
            this.applyTranspositionBtn.Name = "applyTranspositionBtn";
            this.applyTranspositionBtn.Size = new System.Drawing.Size(229, 34);
            this.applyTranspositionBtn.TabIndex = 20;
            this.applyTranspositionBtn.Text = "APPLY TRANSPOSITIONS";
            this.applyTranspositionBtn.UseVisualStyleBackColor = true;
            this.applyTranspositionBtn.Click += new System.EventHandler(this.applyTranspositionBtn_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(581, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "---------------------------------------------------------------------------";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBtn
            // 
            this.doubleBtn.Location = new System.Drawing.Point(585, 487);
            this.doubleBtn.Name = "doubleBtn";
            this.doubleBtn.Size = new System.Drawing.Size(229, 34);
            this.doubleBtn.TabIndex = 22;
            this.doubleBtn.Text = "CRACK DOUBLE";
            this.doubleBtn.UseVisualStyleBackColor = true;
            this.doubleBtn.Click += new System.EventHandler(this.doubleBtn_Click);
            // 
            // reverseBtn
            // 
            this.reverseBtn.Location = new System.Drawing.Point(337, 435);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(229, 34);
            this.reverseBtn.TabIndex = 24;
            this.reverseBtn.Text = "REVERSE";
            this.reverseBtn.UseVisualStyleBackColor = true;
            this.reverseBtn.Click += new System.EventHandler(this.reverseBtn_Click);
            // 
            // border
            // 
            this.border.BackColor = System.Drawing.Color.Black;
            this.border.Location = new System.Drawing.Point(573, 10);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(2, 450);
            this.border.TabIndex = 25;
            this.border.TabStop = false;
            // 
            // columnarBtn
            // 
            this.columnarBtn.Location = new System.Drawing.Point(388, 117);
            this.columnarBtn.Name = "columnarBtn";
            this.columnarBtn.Size = new System.Drawing.Size(166, 34);
            this.columnarBtn.TabIndex = 26;
            this.columnarBtn.Text = "COLUMNAR METHOD";
            this.columnarBtn.UseVisualStyleBackColor = true;
            this.columnarBtn.Click += new System.EventHandler(this.columnarBtn_Click);
            // 
            // routeBtn
            // 
            this.routeBtn.Location = new System.Drawing.Point(337, 342);
            this.routeBtn.Name = "routeBtn";
            this.routeBtn.Size = new System.Drawing.Size(229, 34);
            this.routeBtn.TabIndex = 27;
            this.routeBtn.Text = "ROUTE METHOD";
            this.routeBtn.UseVisualStyleBackColor = true;
            this.routeBtn.Click += new System.EventHandler(this.routeBtn_Click);
            // 
            // xBtn
            // 
            this.xBtn.Location = new System.Drawing.Point(581, 262);
            this.xBtn.Name = "xBtn";
            this.xBtn.Size = new System.Drawing.Size(229, 34);
            this.xBtn.TabIndex = 28;
            this.xBtn.Text = "EVERY X";
            this.xBtn.UseVisualStyleBackColor = true;
            this.xBtn.Click += new System.EventHandler(this.xBtn_Click);
            // 
            // groupBtn
            // 
            this.groupBtn.Location = new System.Drawing.Point(581, 302);
            this.groupBtn.Name = "groupBtn";
            this.groupBtn.Size = new System.Drawing.Size(229, 34);
            this.groupBtn.TabIndex = 29;
            this.groupBtn.Text = "GROUP";
            this.groupBtn.UseVisualStyleBackColor = true;
            this.groupBtn.Click += new System.EventHandler(this.groupBtn_Click);
            // 
            // changeOtherBtn
            // 
            this.changeOtherBtn.Location = new System.Drawing.Point(581, 342);
            this.changeOtherBtn.Name = "changeOtherBtn";
            this.changeOtherBtn.Size = new System.Drawing.Size(229, 34);
            this.changeOtherBtn.TabIndex = 30;
            this.changeOtherBtn.Text = "CHANGE EVERY OTHER";
            this.changeOtherBtn.UseVisualStyleBackColor = true;
            this.changeOtherBtn.Click += new System.EventHandler(this.changeOtherBtn_Click);
            // 
            // KnownText
            // 
            this.KnownText.Location = new System.Drawing.Point(585, 435);
            this.KnownText.Name = "KnownText";
            this.KnownText.Size = new System.Drawing.Size(229, 20);
            this.KnownText.TabIndex = 31;
            // 
            // TestFactors
            // 
            this.TestFactors.Location = new System.Drawing.Point(585, 461);
            this.TestFactors.Name = "TestFactors";
            this.TestFactors.Size = new System.Drawing.Size(229, 20);
            this.TestFactors.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(338, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "---------------------------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // crackDoubleToolsBtn
            // 
            this.crackDoubleToolsBtn.Location = new System.Drawing.Point(337, 474);
            this.crackDoubleToolsBtn.Name = "crackDoubleToolsBtn";
            this.crackDoubleToolsBtn.Size = new System.Drawing.Size(229, 34);
            this.crackDoubleToolsBtn.TabIndex = 34;
            this.crackDoubleToolsBtn.Text = "CRACK DOUBLE TOOLS";
            this.crackDoubleToolsBtn.UseVisualStyleBackColor = true;
            this.crackDoubleToolsBtn.Click += new System.EventHandler(this.crackDoubleToolsBtn_Click);
            // 
            // cadneusBtn
            // 
            this.cadneusBtn.Location = new System.Drawing.Point(337, 382);
            this.cadneusBtn.Name = "cadneusBtn";
            this.cadneusBtn.Size = new System.Drawing.Size(229, 34);
            this.cadneusBtn.TabIndex = 35;
            this.cadneusBtn.Text = "CADNEUS";
            this.cadneusBtn.UseVisualStyleBackColor = true;
            this.cadneusBtn.Click += new System.EventHandler(this.cadneusBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Keyword Length";
            // 
            // inputMethodBx
            // 
            this.inputMethodBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputMethodBx.FormattingEnabled = true;
            this.inputMethodBx.Items.AddRange(new object[] {
            "Rows",
            "Columns"});
            this.inputMethodBx.Location = new System.Drawing.Point(53, 36);
            this.inputMethodBx.Margin = new System.Windows.Forms.Padding(2);
            this.inputMethodBx.Name = "inputMethodBx";
            this.inputMethodBx.Size = new System.Drawing.Size(166, 21);
            this.inputMethodBx.TabIndex = 37;
            // 
            // CreateGridBtn
            // 
            this.CreateGridBtn.Location = new System.Drawing.Point(53, 62);
            this.CreateGridBtn.Name = "CreateGridBtn";
            this.CreateGridBtn.Size = new System.Drawing.Size(166, 31);
            this.CreateGridBtn.TabIndex = 38;
            this.CreateGridBtn.Text = "CREATE GRID";
            this.CreateGridBtn.UseVisualStyleBackColor = true;
            this.CreateGridBtn.Click += new System.EventHandler(this.CreateGridBtn_Click);
            // 
            // TranspositionTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 530);
            this.Controls.Add(this.CreateGridBtn);
            this.Controls.Add(this.inputMethodBx);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cadneusBtn);
            this.Controls.Add(this.crackDoubleToolsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestFactors);
            this.Controls.Add(this.KnownText);
            this.Controls.Add(this.changeOtherBtn);
            this.Controls.Add(this.groupBtn);
            this.Controls.Add(this.xBtn);
            this.Controls.Add(this.routeBtn);
            this.Controls.Add(this.columnarBtn);
            this.Controls.Add(this.border);
            this.Controls.Add(this.reverseBtn);
            this.Controls.Add(this.doubleBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.applyTranspositionBtn);
            this.Controls.Add(this.substringIndexNum);
            this.Controls.Add(this.substringLengthNum);
            this.Controls.Add(this.getSubstringBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scytaleBtn);
            this.Controls.Add(this.factorsBtn);
            this.Controls.Add(this.columnsNum);
            this.Controls.Add(this.basicKeywordBtn);
            this.Controls.Add(this.railfenceBtn);
            this.Controls.Add(this.railsNum);
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
            ((System.ComponentModel.ISupportInitialize)(this.substringLengthNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.substringIndexNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.border)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rowColumnBtn;
        private System.Windows.Forms.Button rowColumnarBtn;
        private System.Windows.Forms.Button expectedBtn;
        private System.Windows.Forms.NumericUpDown maxColumns;
        private System.Windows.Forms.NumericUpDown railsNum;
        private System.Windows.Forms.Button railfenceBtn;
        private System.Windows.Forms.Button basicKeywordBtn;
        private System.Windows.Forms.NumericUpDown columnsNum;
        private System.Windows.Forms.Button factorsBtn;
        private System.Windows.Forms.Button scytaleBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown substringLengthNum;
        private System.Windows.Forms.Button getSubstringBtn;
        private System.Windows.Forms.NumericUpDown substringIndexNum;
        private System.Windows.Forms.Button applyTranspositionBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button doubleBtn;
        private System.Windows.Forms.Button reverseBtn;
        private System.Windows.Forms.Button columnarBtn;
        private System.Windows.Forms.Button routeBtn;
        private System.Windows.Forms.Button xBtn;
        private System.Windows.Forms.Button groupBtn;
        private System.Windows.Forms.Button changeOtherBtn;
        private System.Windows.Forms.PictureBox border;
        private System.Windows.Forms.TextBox KnownText;
        private System.Windows.Forms.TextBox TestFactors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crackDoubleToolsBtn;
        private System.Windows.Forms.Button cadneusBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox inputMethodBx;
        private System.Windows.Forms.Button CreateGridBtn;
    }
}