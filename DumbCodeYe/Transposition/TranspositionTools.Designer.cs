
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
            ((System.ComponentModel.ISupportInitialize)(this.maxColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // rowColumnBtn
            // 
            this.rowColumnBtn.Location = new System.Drawing.Point(12, 12);
            this.rowColumnBtn.Name = "rowColumnBtn";
            this.rowColumnBtn.Size = new System.Drawing.Size(229, 34);
            this.rowColumnBtn.TabIndex = 0;
            this.rowColumnBtn.Text = "ROW COLUMN METHOD";
            this.rowColumnBtn.UseVisualStyleBackColor = true;
            this.rowColumnBtn.Click += new System.EventHandler(this.rowColumnBtn_Click);
            // 
            // rowColumnarBtn
            // 
            this.rowColumnarBtn.Location = new System.Drawing.Point(12, 78);
            this.rowColumnarBtn.Name = "rowColumnarBtn";
            this.rowColumnarBtn.Size = new System.Drawing.Size(229, 34);
            this.rowColumnarBtn.TabIndex = 2;
            this.rowColumnarBtn.Text = "ROW COLUMNAR METHOD";
            this.rowColumnarBtn.UseVisualStyleBackColor = true;
            this.rowColumnarBtn.Click += new System.EventHandler(this.rowColumnarBtn_Click);
            // 
            // expectedBtn
            // 
            this.expectedBtn.Location = new System.Drawing.Point(12, 118);
            this.expectedBtn.Name = "expectedBtn";
            this.expectedBtn.Size = new System.Drawing.Size(229, 34);
            this.expectedBtn.TabIndex = 3;
            this.expectedBtn.Text = "EDIT EXPECTED WORDS";
            this.expectedBtn.UseVisualStyleBackColor = true;
            this.expectedBtn.Click += new System.EventHandler(this.expectedBtn_Click);
            // 
            // maxColumns
            // 
            this.maxColumns.Location = new System.Drawing.Point(12, 52);
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
            // TranspositionTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 163);
            this.Controls.Add(this.maxColumns);
            this.Controls.Add(this.expectedBtn);
            this.Controls.Add(this.rowColumnarBtn);
            this.Controls.Add(this.rowColumnBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TranspositionTools";
            this.Text = "TranspositionTools";
            ((System.ComponentModel.ISupportInitialize)(this.maxColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rowColumnBtn;
        private System.Windows.Forms.Button rowColumnarBtn;
        private System.Windows.Forms.Button expectedBtn;
        private System.Windows.Forms.NumericUpDown maxColumns;
    }
}