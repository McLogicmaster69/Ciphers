
namespace DumbCodeYe
{
    partial class mainFrm
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
            System.Windows.Forms.Button initQuadBtn;
            System.Windows.Forms.Button addSpacesBtn;
            System.Windows.Forms.Button initWordFreqBtn;
            System.Windows.Forms.Button initDictionaryBtn;
            System.Windows.Forms.Button initBigramsBtn;
            this.textInput = new System.Windows.Forms.TextBox();
            this.btnHill = new System.Windows.Forms.Button();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.textOperationsBtn = new System.Windows.Forms.Button();
            this.basicCipherBtn = new System.Windows.Forms.Button();
            this.monoAlphabeticBtn = new System.Windows.Forms.Button();
            this.polyAlphabeticBtn = new System.Windows.Forms.Button();
            this.transpositionBtn = new System.Windows.Forms.Button();
            initQuadBtn = new System.Windows.Forms.Button();
            addSpacesBtn = new System.Windows.Forms.Button();
            initWordFreqBtn = new System.Windows.Forms.Button();
            initDictionaryBtn = new System.Windows.Forms.Button();
            initBigramsBtn = new System.Windows.Forms.Button();
            this.dragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // initQuadBtn
            // 
            initQuadBtn.Location = new System.Drawing.Point(228, 482);
            initQuadBtn.Name = "initQuadBtn";
            initQuadBtn.Size = new System.Drawing.Size(210, 31);
            initQuadBtn.TabIndex = 12;
            initQuadBtn.Text = "INIT QUADGRAMS";
            initQuadBtn.UseVisualStyleBackColor = true;
            initQuadBtn.Click += new System.EventHandler(this.initQuadBtn_Click);
            // 
            // addSpacesBtn
            // 
            addSpacesBtn.Location = new System.Drawing.Point(12, 519);
            addSpacesBtn.Name = "addSpacesBtn";
            addSpacesBtn.Size = new System.Drawing.Size(860, 31);
            addSpacesBtn.TabIndex = 13;
            addSpacesBtn.Text = "ADD SPACES";
            addSpacesBtn.UseVisualStyleBackColor = true;
            addSpacesBtn.Click += new System.EventHandler(this.addSpacesBtn_Click);
            // 
            // initWordFreqBtn
            // 
            initWordFreqBtn.Location = new System.Drawing.Point(662, 482);
            initWordFreqBtn.Name = "initWordFreqBtn";
            initWordFreqBtn.Size = new System.Drawing.Size(210, 31);
            initWordFreqBtn.TabIndex = 14;
            initWordFreqBtn.Text = "INIT WORD FREQ";
            initWordFreqBtn.UseVisualStyleBackColor = true;
            initWordFreqBtn.Click += new System.EventHandler(this.initWordFreqBtn_Click);
            // 
            // initDictionaryBtn
            // 
            initDictionaryBtn.Location = new System.Drawing.Point(446, 482);
            initDictionaryBtn.Name = "initDictionaryBtn";
            initDictionaryBtn.Size = new System.Drawing.Size(210, 31);
            initDictionaryBtn.TabIndex = 15;
            initDictionaryBtn.Text = "INIT DICTIONARY";
            initDictionaryBtn.UseVisualStyleBackColor = true;
            initDictionaryBtn.Click += new System.EventHandler(this.initDictionaryBtn_Click);
            // 
            // initBigramsBtn
            // 
            initBigramsBtn.Location = new System.Drawing.Point(12, 482);
            initBigramsBtn.Name = "initBigramsBtn";
            initBigramsBtn.Size = new System.Drawing.Size(210, 31);
            initBigramsBtn.TabIndex = 17;
            initBigramsBtn.Text = "INIT BIGRAMS";
            initBigramsBtn.UseVisualStyleBackColor = true;
            initBigramsBtn.Click += new System.EventHandler(this.initBigramsBtn_Click);
            // 
            // textInput
            // 
            this.textInput.AcceptsReturn = true;
            this.textInput.AcceptsTab = true;
            this.textInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInput.Location = new System.Drawing.Point(300, 30);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInput.Size = new System.Drawing.Size(900, 570);
            this.textInput.TabIndex = 0;
            this.textInput.Enter += new System.EventHandler(this.textInput_Enter);
            // 
            // btnHill
            // 
            this.btnHill.Location = new System.Drawing.Point(12, 445);
            this.btnHill.Name = "btnHill";
            this.btnHill.Size = new System.Drawing.Size(421, 31);
            this.btnHill.TabIndex = 13;
            this.btnHill.Text = "HILL";
            this.btnHill.UseVisualStyleBackColor = true;
            this.btnHill.Click += new System.EventHandler(this.btnHill_Click);
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(130)))));
            this.dragPanel.Controls.Add(this.closeBtn);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(1400, 30);
            this.dragPanel.TabIndex = 18;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseDown);
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseMove);
            this.dragPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseUp);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.FlatAppearance.BorderSize = 2;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(1370, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(26, 26);
            this.closeBtn.TabIndex = 27;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // textOperationsBtn
            // 
            this.textOperationsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.textOperationsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textOperationsBtn.FlatAppearance.BorderSize = 2;
            this.textOperationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textOperationsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textOperationsBtn.Location = new System.Drawing.Point(0, 30);
            this.textOperationsBtn.Name = "textOperationsBtn";
            this.textOperationsBtn.Size = new System.Drawing.Size(300, 40);
            this.textOperationsBtn.TabIndex = 19;
            this.textOperationsBtn.Text = "TEXT OPERATIONS";
            this.textOperationsBtn.UseVisualStyleBackColor = false;
            this.textOperationsBtn.Click += new System.EventHandler(this.textOperationsBtn_Click);
            // 
            // basicCipherBtn
            // 
            this.basicCipherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.basicCipherBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.basicCipherBtn.FlatAppearance.BorderSize = 2;
            this.basicCipherBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.basicCipherBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.basicCipherBtn.Location = new System.Drawing.Point(0, 70);
            this.basicCipherBtn.Name = "basicCipherBtn";
            this.basicCipherBtn.Size = new System.Drawing.Size(300, 40);
            this.basicCipherBtn.TabIndex = 23;
            this.basicCipherBtn.Text = "BASIC CIPHERS";
            this.basicCipherBtn.UseVisualStyleBackColor = false;
            this.basicCipherBtn.Click += new System.EventHandler(this.basicCipherBtn_Click);
            // 
            // monoAlphabeticBtn
            // 
            this.monoAlphabeticBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.monoAlphabeticBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.monoAlphabeticBtn.FlatAppearance.BorderSize = 2;
            this.monoAlphabeticBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monoAlphabeticBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.monoAlphabeticBtn.Location = new System.Drawing.Point(0, 110);
            this.monoAlphabeticBtn.Name = "monoAlphabeticBtn";
            this.monoAlphabeticBtn.Size = new System.Drawing.Size(300, 40);
            this.monoAlphabeticBtn.TabIndex = 24;
            this.monoAlphabeticBtn.Text = "MONOALPHABETIC";
            this.monoAlphabeticBtn.UseVisualStyleBackColor = false;
            this.monoAlphabeticBtn.Click += new System.EventHandler(this.monoAlphabeticBtn_Click);
            // 
            // polyAlphabeticBtn
            // 
            this.polyAlphabeticBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.polyAlphabeticBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.polyAlphabeticBtn.FlatAppearance.BorderSize = 2;
            this.polyAlphabeticBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.polyAlphabeticBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.polyAlphabeticBtn.Location = new System.Drawing.Point(0, 150);
            this.polyAlphabeticBtn.Name = "polyAlphabeticBtn";
            this.polyAlphabeticBtn.Size = new System.Drawing.Size(300, 40);
            this.polyAlphabeticBtn.TabIndex = 25;
            this.polyAlphabeticBtn.Text = "POLYALPHABETIC";
            this.polyAlphabeticBtn.UseVisualStyleBackColor = false;
            this.polyAlphabeticBtn.Click += new System.EventHandler(this.polyAlphabeticBtn_Click);
            // 
            // transpositionBtn
            // 
            this.transpositionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.transpositionBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.transpositionBtn.FlatAppearance.BorderSize = 2;
            this.transpositionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transpositionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.transpositionBtn.Location = new System.Drawing.Point(0, 190);
            this.transpositionBtn.Name = "transpositionBtn";
            this.transpositionBtn.Size = new System.Drawing.Size(300, 40);
            this.transpositionBtn.TabIndex = 26;
            this.transpositionBtn.Text = "TRNASPOSITION";
            this.transpositionBtn.UseVisualStyleBackColor = false;
            this.transpositionBtn.Click += new System.EventHandler(this.transpositionBtn_Click_1);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1400, 600);
            this.Controls.Add(this.transpositionBtn);
            this.Controls.Add(this.polyAlphabeticBtn);
            this.Controls.Add(this.monoAlphabeticBtn);
            this.Controls.Add(this.basicCipherBtn);
            this.Controls.Add(this.textOperationsBtn);
            this.Controls.Add(this.dragPanel);
            this.Controls.Add(initBigramsBtn);
            this.Controls.Add(initDictionaryBtn);
            this.Controls.Add(initWordFreqBtn);
            this.Controls.Add(addSpacesBtn);
            this.Controls.Add(this.btnHill);
            this.Controls.Add(initQuadBtn);
            this.Controls.Add(this.textInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "Form lol";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.dragPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button btnHill;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.Button textOperationsBtn;
        private System.Windows.Forms.Button basicCipherBtn;
        private System.Windows.Forms.Button monoAlphabeticBtn;
        private System.Windows.Forms.Button polyAlphabeticBtn;
        private System.Windows.Forms.Button transpositionBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}

