
namespace DumbCodeYe.Ciphers.Substitution
{
    partial class SubstitueTool
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
            this.crackBtn = new System.Windows.Forms.Button();
            this.freqBtn = new System.Windows.Forms.Button();
            this.openReplacementBtn = new System.Windows.Forms.Button();
            this.applyReplacementBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.crackOptionsBtn = new System.Windows.Forms.Button();
            this.patermBtn = new System.Windows.Forms.Button();
            this.removeSpacesBtn = new System.Windows.Forms.Button();
            this.bruteBtn = new System.Windows.Forms.Button();
            this.smartBruteBtn = new System.Windows.Forms.Button();
            this.wordDictionaryToolBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainTxt
            // 
            this.mainTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTxt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTxt.Location = new System.Drawing.Point(312, 12);
            this.mainTxt.Multiline = true;
            this.mainTxt.Name = "mainTxt";
            this.mainTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTxt.Size = new System.Drawing.Size(718, 574);
            this.mainTxt.TabIndex = 0;
            // 
            // crackBtn
            // 
            this.crackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.crackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crackBtn.Location = new System.Drawing.Point(12, 546);
            this.crackBtn.Name = "crackBtn";
            this.crackBtn.Size = new System.Drawing.Size(294, 40);
            this.crackBtn.TabIndex = 1;
            this.crackBtn.Text = "ATTEMPT CRACK";
            this.crackBtn.UseVisualStyleBackColor = true;
            this.crackBtn.Click += new System.EventHandler(this.crackBtn_Click);
            // 
            // freqBtn
            // 
            this.freqBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freqBtn.Location = new System.Drawing.Point(12, 58);
            this.freqBtn.Name = "freqBtn";
            this.freqBtn.Size = new System.Drawing.Size(294, 40);
            this.freqBtn.TabIndex = 2;
            this.freqBtn.Text = "GET FREQUENCY";
            this.freqBtn.UseVisualStyleBackColor = true;
            this.freqBtn.Click += new System.EventHandler(this.freqBtn_Click);
            // 
            // openReplacementBtn
            // 
            this.openReplacementBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openReplacementBtn.Location = new System.Drawing.Point(12, 150);
            this.openReplacementBtn.Name = "openReplacementBtn";
            this.openReplacementBtn.Size = new System.Drawing.Size(294, 40);
            this.openReplacementBtn.TabIndex = 3;
            this.openReplacementBtn.Text = "OPEN REPLACEMENTS";
            this.openReplacementBtn.UseVisualStyleBackColor = true;
            this.openReplacementBtn.Click += new System.EventHandler(this.openReplacementBtn_Click);
            // 
            // applyReplacementBtn
            // 
            this.applyReplacementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applyReplacementBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyReplacementBtn.Location = new System.Drawing.Point(12, 454);
            this.applyReplacementBtn.Name = "applyReplacementBtn";
            this.applyReplacementBtn.Size = new System.Drawing.Size(294, 40);
            this.applyReplacementBtn.TabIndex = 4;
            this.applyReplacementBtn.Text = "APPLY REPLACEMENTS";
            this.applyReplacementBtn.UseVisualStyleBackColor = true;
            this.applyReplacementBtn.Click += new System.EventHandler(this.applyReplacementBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(12, 408);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(294, 40);
            this.resetBtn.TabIndex = 5;
            this.resetBtn.Text = "RESET TEXT";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // crackOptionsBtn
            // 
            this.crackOptionsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.crackOptionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crackOptionsBtn.Location = new System.Drawing.Point(12, 500);
            this.crackOptionsBtn.Name = "crackOptionsBtn";
            this.crackOptionsBtn.Size = new System.Drawing.Size(294, 40);
            this.crackOptionsBtn.TabIndex = 6;
            this.crackOptionsBtn.Text = "CRACK OPTIONS";
            this.crackOptionsBtn.UseVisualStyleBackColor = true;
            this.crackOptionsBtn.Click += new System.EventHandler(this.crackOptionsBtn_Click);
            // 
            // patermBtn
            // 
            this.patermBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patermBtn.Location = new System.Drawing.Point(12, 104);
            this.patermBtn.Name = "patermBtn";
            this.patermBtn.Size = new System.Drawing.Size(294, 40);
            this.patermBtn.TabIndex = 7;
            this.patermBtn.Text = "OPEN PATTERNS";
            this.patermBtn.UseVisualStyleBackColor = true;
            this.patermBtn.Click += new System.EventHandler(this.patermBtn_Click);
            // 
            // removeSpacesBtn
            // 
            this.removeSpacesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSpacesBtn.Location = new System.Drawing.Point(12, 12);
            this.removeSpacesBtn.Name = "removeSpacesBtn";
            this.removeSpacesBtn.Size = new System.Drawing.Size(294, 40);
            this.removeSpacesBtn.TabIndex = 8;
            this.removeSpacesBtn.Text = "REMOVE SPACES";
            this.removeSpacesBtn.UseVisualStyleBackColor = true;
            this.removeSpacesBtn.Click += new System.EventHandler(this.removeSpacesBtn_Click);
            // 
            // bruteBtn
            // 
            this.bruteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bruteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bruteBtn.Location = new System.Drawing.Point(12, 362);
            this.bruteBtn.Name = "bruteBtn";
            this.bruteBtn.Size = new System.Drawing.Size(294, 40);
            this.bruteBtn.TabIndex = 10;
            this.bruteBtn.Text = "BRUTE CRACK";
            this.bruteBtn.UseVisualStyleBackColor = true;
            this.bruteBtn.Click += new System.EventHandler(this.bruteBtn_Click);
            // 
            // smartBruteBtn
            // 
            this.smartBruteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.smartBruteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartBruteBtn.Location = new System.Drawing.Point(12, 316);
            this.smartBruteBtn.Name = "smartBruteBtn";
            this.smartBruteBtn.Size = new System.Drawing.Size(294, 40);
            this.smartBruteBtn.TabIndex = 11;
            this.smartBruteBtn.Text = "SMART BRUTE CRACK";
            this.smartBruteBtn.UseVisualStyleBackColor = true;
            this.smartBruteBtn.Click += new System.EventHandler(this.smartBruteBtn_Click);
            // 
            // wordDictionaryToolBtn
            // 
            this.wordDictionaryToolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wordDictionaryToolBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordDictionaryToolBtn.Location = new System.Drawing.Point(12, 270);
            this.wordDictionaryToolBtn.Name = "wordDictionaryToolBtn";
            this.wordDictionaryToolBtn.Size = new System.Drawing.Size(294, 40);
            this.wordDictionaryToolBtn.TabIndex = 12;
            this.wordDictionaryToolBtn.Text = "WORD DICTIONARY TOOL";
            this.wordDictionaryToolBtn.UseVisualStyleBackColor = true;
            this.wordDictionaryToolBtn.Click += new System.EventHandler(this.wordDictionaryToolBtn_Click);
            // 
            // SubstitueTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 598);
            this.Controls.Add(this.wordDictionaryToolBtn);
            this.Controls.Add(this.smartBruteBtn);
            this.Controls.Add(this.bruteBtn);
            this.Controls.Add(this.removeSpacesBtn);
            this.Controls.Add(this.patermBtn);
            this.Controls.Add(this.crackOptionsBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.applyReplacementBtn);
            this.Controls.Add(this.openReplacementBtn);
            this.Controls.Add(this.freqBtn);
            this.Controls.Add(this.crackBtn);
            this.Controls.Add(this.mainTxt);
            this.MinimumSize = new System.Drawing.Size(1058, 637);
            this.Name = "SubstitueTool";
            this.Text = "Substitue Tool";
            this.Load += new System.EventHandler(this.SubstitueTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox mainTxt;
        private System.Windows.Forms.Button crackBtn;
        private System.Windows.Forms.Button freqBtn;
        private System.Windows.Forms.Button openReplacementBtn;
        private System.Windows.Forms.Button applyReplacementBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button crackOptionsBtn;
        private System.Windows.Forms.Button patermBtn;
        private System.Windows.Forms.Button removeSpacesBtn;
        private System.Windows.Forms.Button bruteBtn;
        private System.Windows.Forms.Button smartBruteBtn;
        private System.Windows.Forms.Button wordDictionaryToolBtn;
    }
}