
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
            this.textInput = new System.Windows.Forms.TextBox();
            this.textOperationsBtn = new System.Windows.Forms.Button();
            this.basicCipherBtn = new System.Windows.Forms.Button();
            this.monoAlphabeticBtn = new System.Windows.Forms.Button();
            this.polyAlphabeticBtn = new System.Windows.Forms.Button();
            this.transpositionBtn = new System.Windows.Forms.Button();
            this.initButtons = new System.Windows.Forms.Button();
            this.textEditorBtn = new System.Windows.Forms.Button();
            this.autoSolveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.AcceptsReturn = true;
            this.textInput.AcceptsTab = true;
            this.textInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInput.Location = new System.Drawing.Point(300, 0);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInput.Size = new System.Drawing.Size(700, 600);
            this.textInput.TabIndex = 0;
            this.textInput.Enter += new System.EventHandler(this.textInput_Enter);
            // 
            // textOperationsBtn
            // 
            this.textOperationsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.textOperationsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textOperationsBtn.FlatAppearance.BorderSize = 2;
            this.textOperationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textOperationsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textOperationsBtn.Location = new System.Drawing.Point(0, 0);
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
            this.basicCipherBtn.Location = new System.Drawing.Point(0, 40);
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
            this.monoAlphabeticBtn.Location = new System.Drawing.Point(0, 80);
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
            this.polyAlphabeticBtn.Location = new System.Drawing.Point(0, 120);
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
            this.transpositionBtn.Location = new System.Drawing.Point(0, 160);
            this.transpositionBtn.Name = "transpositionBtn";
            this.transpositionBtn.Size = new System.Drawing.Size(300, 40);
            this.transpositionBtn.TabIndex = 26;
            this.transpositionBtn.Text = "TRANSPOSITION";
            this.transpositionBtn.UseVisualStyleBackColor = false;
            this.transpositionBtn.Click += new System.EventHandler(this.transpositionBtn_Click);
            // 
            // initButtons
            // 
            this.initButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.initButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.initButtons.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.initButtons.FlatAppearance.BorderSize = 2;
            this.initButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.initButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.initButtons.Location = new System.Drawing.Point(0, 560);
            this.initButtons.Name = "initButtons";
            this.initButtons.Size = new System.Drawing.Size(300, 40);
            this.initButtons.TabIndex = 27;
            this.initButtons.Text = "INITIALISE";
            this.initButtons.UseVisualStyleBackColor = false;
            this.initButtons.Click += new System.EventHandler(this.initButtons_Click);
            // 
            // textEditorBtn
            // 
            this.textEditorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textEditorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.textEditorBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textEditorBtn.FlatAppearance.BorderSize = 2;
            this.textEditorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textEditorBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.textEditorBtn.Location = new System.Drawing.Point(0, 520);
            this.textEditorBtn.Name = "textEditorBtn";
            this.textEditorBtn.Size = new System.Drawing.Size(300, 40);
            this.textEditorBtn.TabIndex = 28;
            this.textEditorBtn.Text = "TEXT EDITOR";
            this.textEditorBtn.UseVisualStyleBackColor = false;
            this.textEditorBtn.Click += new System.EventHandler(this.textEditorBtn_Click);
            // 
            // autoSolveBtn
            // 
            this.autoSolveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoSolveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.autoSolveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.autoSolveBtn.FlatAppearance.BorderSize = 2;
            this.autoSolveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoSolveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.autoSolveBtn.Location = new System.Drawing.Point(0, 480);
            this.autoSolveBtn.Name = "autoSolveBtn";
            this.autoSolveBtn.Size = new System.Drawing.Size(300, 40);
            this.autoSolveBtn.TabIndex = 29;
            this.autoSolveBtn.Text = "AUTO SOLVE";
            this.autoSolveBtn.UseVisualStyleBackColor = false;
            this.autoSolveBtn.Click += new System.EventHandler(this.autoSolveBtn_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.autoSolveBtn);
            this.Controls.Add(this.textEditorBtn);
            this.Controls.Add(this.initButtons);
            this.Controls.Add(this.transpositionBtn);
            this.Controls.Add(this.polyAlphabeticBtn);
            this.Controls.Add(this.monoAlphabeticBtn);
            this.Controls.Add(this.basicCipherBtn);
            this.Controls.Add(this.textOperationsBtn);
            this.Controls.Add(this.textInput);
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "mainFrm";
            this.Text = "Form lol";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.Resize += new System.EventHandler(this.mainFrm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button textOperationsBtn;
        private System.Windows.Forms.Button basicCipherBtn;
        private System.Windows.Forms.Button monoAlphabeticBtn;
        private System.Windows.Forms.Button polyAlphabeticBtn;
        private System.Windows.Forms.Button transpositionBtn;
        private System.Windows.Forms.Button initButtons;
        private System.Windows.Forms.Button textEditorBtn;
        private System.Windows.Forms.Button autoSolveBtn;
    }
}

