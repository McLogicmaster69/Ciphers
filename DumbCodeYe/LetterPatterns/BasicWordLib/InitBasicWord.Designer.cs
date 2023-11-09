
namespace DumbCodeYe.LetterPatterns.BasicWordLib
{
    partial class InitBasicWord
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
            this.testBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.initBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(12, 88);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(396, 32);
            this.testBtn.TabIndex = 17;
            this.testBtn.Text = "TEST";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.Location = new System.Drawing.Point(12, 162);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(396, 23);
            this.statusLbl.TabIndex = 16;
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(12, 126);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(396, 23);
            this.loadingBar.TabIndex = 15;
            // 
            // initBtn
            // 
            this.initBtn.Location = new System.Drawing.Point(12, 50);
            this.initBtn.Name = "initBtn";
            this.initBtn.Size = new System.Drawing.Size(396, 32);
            this.initBtn.TabIndex = 14;
            this.initBtn.Text = "INITIALISE";
            this.initBtn.UseVisualStyleBackColor = true;
            this.initBtn.Click += new System.EventHandler(this.initBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(12, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(396, 32);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "CLOSE";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // InitBasicWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 194);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.initBtn);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InitBasicWord";
            this.Text = "InitBasicWord";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Button initBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}