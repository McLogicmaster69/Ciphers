﻿
namespace DumbCodeYe.Ciphers.Transposition
{
    partial class GridOutput
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
            this.gridList = new System.Windows.Forms.ListBox();
            this.swap1 = new System.Windows.Forms.NumericUpDown();
            this.swap2 = new System.Windows.Forms.NumericUpDown();
            this.swapBtn = new System.Windows.Forms.Button();
            this.outputBtn = new System.Windows.Forms.Button();
            this.bestPairsBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.selectedColumnNum = new System.Windows.Forms.NumericUpDown();
            this.shiftValueNum = new System.Windows.Forms.NumericUpDown();
            this.shiftBtn = new System.Windows.Forms.Button();
            this.outputMethodBx = new System.Windows.Forms.ComboBox();
            this.columnNumbersTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.swap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColumnNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftValueNum)).BeginInit();
            this.SuspendLayout();
            // 
            // gridList
            // 
            this.gridList.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridList.FormattingEnabled = true;
            this.gridList.HorizontalScrollbar = true;
            this.gridList.ItemHeight = 32;
            this.gridList.Location = new System.Drawing.Point(12, 44);
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(740, 388);
            this.gridList.TabIndex = 0;
            // 
            // swap1
            // 
            this.swap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swap1.Location = new System.Drawing.Point(758, 12);
            this.swap1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.swap1.Name = "swap1";
            this.swap1.Size = new System.Drawing.Size(159, 26);
            this.swap1.TabIndex = 1;
            this.swap1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // swap2
            // 
            this.swap2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swap2.Location = new System.Drawing.Point(758, 44);
            this.swap2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.swap2.Name = "swap2";
            this.swap2.Size = new System.Drawing.Size(159, 26);
            this.swap2.TabIndex = 2;
            this.swap2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // swapBtn
            // 
            this.swapBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swapBtn.Location = new System.Drawing.Point(758, 76);
            this.swapBtn.Name = "swapBtn";
            this.swapBtn.Size = new System.Drawing.Size(159, 34);
            this.swapBtn.TabIndex = 3;
            this.swapBtn.Text = "SWAP";
            this.swapBtn.UseVisualStyleBackColor = true;
            this.swapBtn.Click += new System.EventHandler(this.swapBtn_Click);
            // 
            // outputBtn
            // 
            this.outputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBtn.Location = new System.Drawing.Point(758, 398);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(159, 34);
            this.outputBtn.TabIndex = 4;
            this.outputBtn.Text = "OUTPUT";
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.outputBtn_Click);
            // 
            // bestPairsBtn
            // 
            this.bestPairsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestPairsBtn.Location = new System.Drawing.Point(758, 333);
            this.bestPairsBtn.Name = "bestPairsBtn";
            this.bestPairsBtn.Size = new System.Drawing.Size(159, 34);
            this.bestPairsBtn.TabIndex = 6;
            this.bestPairsBtn.Text = "BEST PAIRS";
            this.bestPairsBtn.UseVisualStyleBackColor = true;
            this.bestPairsBtn.Click += new System.EventHandler(this.bestPairsBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertBtn.Location = new System.Drawing.Point(758, 116);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(159, 34);
            this.insertBtn.TabIndex = 7;
            this.insertBtn.Text = "INSERT";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // selectedColumnNum
            // 
            this.selectedColumnNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedColumnNum.Location = new System.Drawing.Point(758, 156);
            this.selectedColumnNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectedColumnNum.Name = "selectedColumnNum";
            this.selectedColumnNum.Size = new System.Drawing.Size(159, 26);
            this.selectedColumnNum.TabIndex = 8;
            this.selectedColumnNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shiftValueNum
            // 
            this.shiftValueNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftValueNum.Location = new System.Drawing.Point(758, 188);
            this.shiftValueNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shiftValueNum.Name = "shiftValueNum";
            this.shiftValueNum.Size = new System.Drawing.Size(159, 26);
            this.shiftValueNum.TabIndex = 9;
            this.shiftValueNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shiftBtn
            // 
            this.shiftBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftBtn.Location = new System.Drawing.Point(758, 220);
            this.shiftBtn.Name = "shiftBtn";
            this.shiftBtn.Size = new System.Drawing.Size(159, 34);
            this.shiftBtn.TabIndex = 10;
            this.shiftBtn.Text = "SHIFT";
            this.shiftBtn.UseVisualStyleBackColor = true;
            this.shiftBtn.Click += new System.EventHandler(this.shiftBtn_Click);
            // 
            // outputMethodBx
            // 
            this.outputMethodBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputMethodBx.FormattingEnabled = true;
            this.outputMethodBx.Items.AddRange(new object[] {
            "Rows",
            "Columns"});
            this.outputMethodBx.Location = new System.Drawing.Point(758, 372);
            this.outputMethodBx.Margin = new System.Windows.Forms.Padding(2);
            this.outputMethodBx.Name = "outputMethodBx";
            this.outputMethodBx.Size = new System.Drawing.Size(159, 21);
            this.outputMethodBx.TabIndex = 38;
            // 
            // columnNumbersTxt
            // 
            this.columnNumbersTxt.Enabled = false;
            this.columnNumbersTxt.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnNumbersTxt.Location = new System.Drawing.Point(12, 12);
            this.columnNumbersTxt.Name = "columnNumbersTxt";
            this.columnNumbersTxt.Size = new System.Drawing.Size(740, 39);
            this.columnNumbersTxt.TabIndex = 39;
            // 
            // GridOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 444);
            this.Controls.Add(this.columnNumbersTxt);
            this.Controls.Add(this.outputMethodBx);
            this.Controls.Add(this.shiftBtn);
            this.Controls.Add(this.shiftValueNum);
            this.Controls.Add(this.selectedColumnNum);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.bestPairsBtn);
            this.Controls.Add(this.outputBtn);
            this.Controls.Add(this.swapBtn);
            this.Controls.Add(this.swap2);
            this.Controls.Add(this.swap1);
            this.Controls.Add(this.gridList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GridOutput";
            this.Text = "GridOutput";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GridOutput_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.swap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColumnNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftValueNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gridList;
        private System.Windows.Forms.NumericUpDown swap1;
        private System.Windows.Forms.NumericUpDown swap2;
        private System.Windows.Forms.Button swapBtn;
        private System.Windows.Forms.Button outputBtn;
        private System.Windows.Forms.Button bestPairsBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.NumericUpDown selectedColumnNum;
        private System.Windows.Forms.NumericUpDown shiftValueNum;
        private System.Windows.Forms.Button shiftBtn;
        private System.Windows.Forms.ComboBox outputMethodBx;
        private System.Windows.Forms.TextBox columnNumbersTxt;
    }
}