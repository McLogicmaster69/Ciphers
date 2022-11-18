
namespace DumbCodeYe
{
    partial class ProgressBarForm
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
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(12, 12);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(527, 20);
            this.loadingBar.TabIndex = 0;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(12, 40);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(527, 13);
            this.status.TabIndex = 1;
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 62);
            this.ControlBox = false;
            this.Controls.Add(this.status);
            this.Controls.Add(this.loadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProgressBarForm";
            this.Text = "Calculating";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar loadingBar;
        public System.Windows.Forms.Label status;
    }
}