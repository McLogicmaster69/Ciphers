
namespace DumbCodeYe.LetterPatterns.Quadgrams
{
    partial class InitQuadgramsFrm
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.initBtn = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.statusLbl = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.getTotalBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(12, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(396, 32);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "CLOSE";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // initBtn
            // 
            this.initBtn.Location = new System.Drawing.Point(15, 50);
            this.initBtn.Name = "initBtn";
            this.initBtn.Size = new System.Drawing.Size(396, 32);
            this.initBtn.TabIndex = 2;
            this.initBtn.Text = "INITIALISE";
            this.initBtn.UseVisualStyleBackColor = true;
            this.initBtn.Click += new System.EventHandler(this.initBtn_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(12, 164);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(396, 23);
            this.loadingBar.TabIndex = 3;
            // 
            // statusLbl
            // 
            this.statusLbl.Location = new System.Drawing.Point(12, 190);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(396, 23);
            this.statusLbl.TabIndex = 4;
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(12, 88);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(396, 32);
            this.testBtn.TabIndex = 5;
            this.testBtn.Text = "TEST";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // getTotalBtn
            // 
            this.getTotalBtn.Location = new System.Drawing.Point(12, 126);
            this.getTotalBtn.Name = "getTotalBtn";
            this.getTotalBtn.Size = new System.Drawing.Size(396, 32);
            this.getTotalBtn.TabIndex = 6;
            this.getTotalBtn.Text = "GET TOTAL";
            this.getTotalBtn.UseVisualStyleBackColor = true;
            this.getTotalBtn.Click += new System.EventHandler(this.getTotalBtn_Click);
            // 
            // InitQuadgramsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 234);
            this.Controls.Add(this.getTotalBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.initBtn);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InitQuadgramsFrm";
            this.Text = "InitQuadgramsFrm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button initBtn;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button getTotalBtn;
    }
}