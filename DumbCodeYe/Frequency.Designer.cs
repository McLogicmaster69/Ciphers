
namespace DumbCodeYe
{
    partial class FrequencyFrm
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
            this.freqLbl = new System.Windows.Forms.Label();
            this.quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // freqLbl
            // 
            this.freqLbl.AutoSize = true;
            this.freqLbl.Location = new System.Drawing.Point(12, 9);
            this.freqLbl.Name = "freqLbl";
            this.freqLbl.Size = new System.Drawing.Size(13, 13);
            this.freqLbl.TabIndex = 0;
            this.freqLbl.Text = "a";
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(15, 357);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(157, 23);
            this.quit.TabIndex = 1;
            this.quit.Text = "OK";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // FrequencyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 392);
            this.ControlBox = false;
            this.Controls.Add(this.quit);
            this.Controls.Add(this.freqLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrequencyFrm";
            this.Text = "Frequency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label freqLbl;
        private System.Windows.Forms.Button quit;
    }
}