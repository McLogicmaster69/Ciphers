
namespace DumbCodeYe.Ciphers.Polybius
{
    partial class PolybiusTools
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
            this.mainTxt = new System.Windows.Forms.TextBox();
            this.applyGridBtn = new System.Windows.Forms.Button();
            this.openGridBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainTxt
            // 
            this.mainTxt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTxt.Location = new System.Drawing.Point(275, 12);
            this.mainTxt.Multiline = true;
            this.mainTxt.Name = "mainTxt";
            this.mainTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTxt.Size = new System.Drawing.Size(718, 571);
            this.mainTxt.TabIndex = 1;
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
            // PolybiusTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 595);
            this.Controls.Add(this.openGridBtn);
            this.Controls.Add(this.applyGridBtn);
            this.Controls.Add(this.mainTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PolybiusTools";
            this.Text = "PolybiusTools";
            this.Load += new System.EventHandler(this.PolybiusTools_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox mainTxt;
        private System.Windows.Forms.Button applyGridBtn;
        private System.Windows.Forms.Button openGridBtn;
    }
}