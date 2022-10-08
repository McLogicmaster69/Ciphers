
namespace DumbCodeYe.Substitution
{
    partial class WordDictionaryTool
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
            this.goBtn = new System.Windows.Forms.Button();
            this.wordInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(12, 407);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(776, 31);
            this.goBtn.TabIndex = 9;
            this.goBtn.Text = "GO";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // wordInput
            // 
            this.wordInput.AcceptsReturn = true;
            this.wordInput.AcceptsTab = true;
            this.wordInput.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordInput.Location = new System.Drawing.Point(12, 12);
            this.wordInput.Multiline = true;
            this.wordInput.Name = "wordInput";
            this.wordInput.Size = new System.Drawing.Size(776, 389);
            this.wordInput.TabIndex = 8;
            // 
            // WordDictionaryTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.wordInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WordDictionaryTool";
            this.Text = "WordDictionaryTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox wordInput;
    }
}