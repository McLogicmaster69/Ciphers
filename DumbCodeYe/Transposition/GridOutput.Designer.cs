
namespace DumbCodeYe.Transposition
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
            ((System.ComponentModel.ISupportInitialize)(this.swap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swap2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridList
            // 
            this.gridList.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridList.FormattingEnabled = true;
            this.gridList.ItemHeight = 32;
            this.gridList.Location = new System.Drawing.Point(12, 12);
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(776, 420);
            this.gridList.TabIndex = 0;
            // 
            // swap1
            // 
            this.swap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swap1.Location = new System.Drawing.Point(794, 12);
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
            this.swap2.Location = new System.Drawing.Point(794, 44);
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
            this.swapBtn.Location = new System.Drawing.Point(794, 76);
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
            this.outputBtn.Location = new System.Drawing.Point(794, 398);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(159, 34);
            this.outputBtn.TabIndex = 4;
            this.outputBtn.Text = "OUTPUT";
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.outputBtn_Click);
            // 
            // GridOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 444);
            this.Controls.Add(this.outputBtn);
            this.Controls.Add(this.swapBtn);
            this.Controls.Add(this.swap2);
            this.Controls.Add(this.swap1);
            this.Controls.Add(this.gridList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GridOutput";
            this.Text = "GridOutput";
            ((System.ComponentModel.ISupportInitialize)(this.swap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swap2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox gridList;
        private System.Windows.Forms.NumericUpDown swap1;
        private System.Windows.Forms.NumericUpDown swap2;
        private System.Windows.Forms.Button swapBtn;
        private System.Windows.Forms.Button outputBtn;
    }
}