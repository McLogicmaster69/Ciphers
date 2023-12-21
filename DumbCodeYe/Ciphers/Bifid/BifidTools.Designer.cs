
namespace DumbCodeYe.Ciphers.Bifid
{
    partial class BifidTools
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
            this.OutputText = new System.Windows.Forms.TextBox();
            this.applyGridBtn = new System.Windows.Forms.Button();
            this.openGridBtn = new System.Windows.Forms.Button();
            this.FactorsBtn = new System.Windows.Forms.Button();
            this.PeriodLbl = new System.Windows.Forms.Label();
            this.PeriodNmrc = new System.Windows.Forms.NumericUpDown();
            this.PeriodGraphBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodNmrc)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputText
            // 
            this.OutputText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.Location = new System.Drawing.Point(275, 12);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(718, 571);
            this.OutputText.TabIndex = 1;
            // 
            // applyGridBtn
            // 
            this.applyGridBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyGridBtn.Location = new System.Drawing.Point(12, 535);
            this.applyGridBtn.Name = "applyGridBtn";
            this.applyGridBtn.Size = new System.Drawing.Size(257, 48);
            this.applyGridBtn.TabIndex = 2;
            this.applyGridBtn.Text = "APPLY GRID";
            this.applyGridBtn.UseVisualStyleBackColor = true;
            this.applyGridBtn.Click += new System.EventHandler(this.applyGridBtn_Click);
            // 
            // openGridBtn
            // 
            this.openGridBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGridBtn.Location = new System.Drawing.Point(12, 481);
            this.openGridBtn.Name = "openGridBtn";
            this.openGridBtn.Size = new System.Drawing.Size(257, 48);
            this.openGridBtn.TabIndex = 3;
            this.openGridBtn.Text = "OPEN GRID";
            this.openGridBtn.UseVisualStyleBackColor = true;
            this.openGridBtn.Click += new System.EventHandler(this.openGridBtn_Click);
            // 
            // FactorsBtn
            // 
            this.FactorsBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FactorsBtn.Location = new System.Drawing.Point(12, 401);
            this.FactorsBtn.Name = "FactorsBtn";
            this.FactorsBtn.Size = new System.Drawing.Size(257, 48);
            this.FactorsBtn.TabIndex = 4;
            this.FactorsBtn.Text = "GET FACTORS";
            this.FactorsBtn.UseVisualStyleBackColor = true;
            this.FactorsBtn.Click += new System.EventHandler(this.FactorsBtn_Click);
            // 
            // PeriodLbl
            // 
            this.PeriodLbl.Location = new System.Drawing.Point(12, 455);
            this.PeriodLbl.Name = "PeriodLbl";
            this.PeriodLbl.Size = new System.Drawing.Size(115, 20);
            this.PeriodLbl.TabIndex = 5;
            this.PeriodLbl.Text = "PERIOD";
            this.PeriodLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PeriodNmrc
            // 
            this.PeriodNmrc.Location = new System.Drawing.Point(133, 455);
            this.PeriodNmrc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PeriodNmrc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PeriodNmrc.Name = "PeriodNmrc";
            this.PeriodNmrc.Size = new System.Drawing.Size(136, 20);
            this.PeriodNmrc.TabIndex = 6;
            this.PeriodNmrc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PeriodGraphBtn
            // 
            this.PeriodGraphBtn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodGraphBtn.Location = new System.Drawing.Point(12, 347);
            this.PeriodGraphBtn.Name = "PeriodGraphBtn";
            this.PeriodGraphBtn.Size = new System.Drawing.Size(257, 48);
            this.PeriodGraphBtn.TabIndex = 7;
            this.PeriodGraphBtn.Text = "GET PERIOD GRAPH";
            this.PeriodGraphBtn.UseVisualStyleBackColor = true;
            this.PeriodGraphBtn.Click += new System.EventHandler(this.PeriodGraphBtn_Click);
            // 
            // BifidTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 595);
            this.Controls.Add(this.PeriodGraphBtn);
            this.Controls.Add(this.PeriodNmrc);
            this.Controls.Add(this.PeriodLbl);
            this.Controls.Add(this.FactorsBtn);
            this.Controls.Add(this.openGridBtn);
            this.Controls.Add(this.applyGridBtn);
            this.Controls.Add(this.OutputText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BifidTools";
            this.Text = "PolybiusTools";
            this.Load += new System.EventHandler(this.PolybiusTools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PeriodNmrc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.Button applyGridBtn;
        private System.Windows.Forms.Button openGridBtn;
        private System.Windows.Forms.Button FactorsBtn;
        private System.Windows.Forms.Label PeriodLbl;
        private System.Windows.Forms.NumericUpDown PeriodNmrc;
        private System.Windows.Forms.Button PeriodGraphBtn;
    }
}