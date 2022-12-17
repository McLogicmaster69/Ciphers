
namespace DumbCodeYe.TwoSquare
{
    partial class TwoSquareTools
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
            this.freqBtn = new System.Windows.Forms.Button();
            this.grid1Btn = new System.Windows.Forms.Button();
            this.grid2Btn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.mainTxt = new System.Windows.Forms.TextBox();
            this.bigramTxt = new System.Windows.Forms.TextBox();
            this.followingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // freqBtn
            // 
            this.freqBtn.Location = new System.Drawing.Point(12, 12);
            this.freqBtn.Name = "freqBtn";
            this.freqBtn.Size = new System.Drawing.Size(137, 40);
            this.freqBtn.TabIndex = 0;
            this.freqBtn.Text = "FREQUENCY";
            this.freqBtn.UseVisualStyleBackColor = true;
            this.freqBtn.Click += new System.EventHandler(this.freqBtn_Click);
            // 
            // grid1Btn
            // 
            this.grid1Btn.Location = new System.Drawing.Point(12, 58);
            this.grid1Btn.Name = "grid1Btn";
            this.grid1Btn.Size = new System.Drawing.Size(137, 40);
            this.grid1Btn.TabIndex = 1;
            this.grid1Btn.Text = "GRID 1";
            this.grid1Btn.UseVisualStyleBackColor = true;
            this.grid1Btn.Click += new System.EventHandler(this.grid1Btn_Click);
            // 
            // grid2Btn
            // 
            this.grid2Btn.Location = new System.Drawing.Point(12, 104);
            this.grid2Btn.Name = "grid2Btn";
            this.grid2Btn.Size = new System.Drawing.Size(137, 40);
            this.grid2Btn.TabIndex = 2;
            this.grid2Btn.Text = "GRID 2";
            this.grid2Btn.UseVisualStyleBackColor = true;
            this.grid2Btn.Click += new System.EventHandler(this.grid2Btn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(12, 150);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(137, 40);
            this.applyBtn.TabIndex = 3;
            this.applyBtn.Text = "APPLY";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // mainTxt
            // 
            this.mainTxt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTxt.Location = new System.Drawing.Point(155, 12);
            this.mainTxt.Multiline = true;
            this.mainTxt.Name = "mainTxt";
            this.mainTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTxt.Size = new System.Drawing.Size(633, 426);
            this.mainTxt.TabIndex = 4;
            // 
            // bigramTxt
            // 
            this.bigramTxt.Location = new System.Drawing.Point(12, 196);
            this.bigramTxt.MaxLength = 2;
            this.bigramTxt.Name = "bigramTxt";
            this.bigramTxt.Size = new System.Drawing.Size(137, 20);
            this.bigramTxt.TabIndex = 5;
            // 
            // followingBtn
            // 
            this.followingBtn.Location = new System.Drawing.Point(12, 222);
            this.followingBtn.Name = "followingBtn";
            this.followingBtn.Size = new System.Drawing.Size(137, 40);
            this.followingBtn.TabIndex = 6;
            this.followingBtn.Text = "FOLLOWING";
            this.followingBtn.UseVisualStyleBackColor = true;
            this.followingBtn.Click += new System.EventHandler(this.followingBtn_Click);
            // 
            // TwoSquareTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.followingBtn);
            this.Controls.Add(this.bigramTxt);
            this.Controls.Add(this.mainTxt);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.grid2Btn);
            this.Controls.Add(this.grid1Btn);
            this.Controls.Add(this.freqBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TwoSquareTools";
            this.Text = "TwoSquareTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button freqBtn;
        private System.Windows.Forms.Button grid1Btn;
        private System.Windows.Forms.Button grid2Btn;
        private System.Windows.Forms.Button applyBtn;
        public System.Windows.Forms.TextBox mainTxt;
        private System.Windows.Forms.TextBox bigramTxt;
        private System.Windows.Forms.Button followingBtn;
    }
}