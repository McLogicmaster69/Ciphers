
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
            this.textInput = new System.Windows.Forms.TextBox();
            this.ceaserBtn = new System.Windows.Forms.Button();
            this.substituteBtn = new System.Windows.Forms.Button();
            this.vigenereBtn = new System.Windows.Forms.Button();
            this.polybiusBtn = new System.Windows.Forms.Button();
            this.upperBtn = new System.Windows.Forms.Button();
            this.transpositionBtn = new System.Windows.Forms.Button();
            this.morseBtn = new System.Windows.Forms.Button();
            this.binaryBtn = new System.Windows.Forms.Button();
            this.playfairBtn = new System.Windows.Forms.Button();
            this.lettersBtn = new System.Windows.Forms.Button();
            this.btnBacon = new System.Windows.Forms.Button();
            this.btnHill = new System.Windows.Forms.Button();
            initQuadBtn = new System.Windows.Forms.Button();
            addSpacesBtn = new System.Windows.Forms.Button();
            initWordFreqBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // initQuadBtn
            // 
            initQuadBtn.Location = new System.Drawing.Point(12, 482);
            initQuadBtn.Name = "initQuadBtn";
            initQuadBtn.Size = new System.Drawing.Size(421, 31);
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
            initWordFreqBtn.Location = new System.Drawing.Point(451, 482);
            initWordFreqBtn.Name = "initWordFreqBtn";
            initWordFreqBtn.Size = new System.Drawing.Size(421, 31);
            initWordFreqBtn.TabIndex = 14;
            initWordFreqBtn.Text = "INIT WORD FREQ";
            initWordFreqBtn.UseVisualStyleBackColor = true;
            initWordFreqBtn.Click += new System.EventHandler(this.initWordFreqBtn_Click);
            // 
            // textInput
            // 
            this.textInput.AcceptsReturn = true;
            this.textInput.AcceptsTab = true;
            this.textInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInput.Location = new System.Drawing.Point(12, 12);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInput.Size = new System.Drawing.Size(860, 242);
            this.textInput.TabIndex = 0;
            // 
            // ceaserBtn
            // 
            this.ceaserBtn.Location = new System.Drawing.Point(12, 334);
            this.ceaserBtn.Name = "ceaserBtn";
            this.ceaserBtn.Size = new System.Drawing.Size(421, 31);
            this.ceaserBtn.TabIndex = 1;
            this.ceaserBtn.Text = "CEASER";
            this.ceaserBtn.UseVisualStyleBackColor = true;
            this.ceaserBtn.Click += new System.EventHandler(this.ceaserBtn_Click);
            // 
            // substituteBtn
            // 
            this.substituteBtn.Location = new System.Drawing.Point(12, 371);
            this.substituteBtn.Name = "substituteBtn";
            this.substituteBtn.Size = new System.Drawing.Size(421, 31);
            this.substituteBtn.TabIndex = 2;
            this.substituteBtn.Text = "SUBSTITUE";
            this.substituteBtn.UseVisualStyleBackColor = true;
            this.substituteBtn.Click += new System.EventHandler(this.substituteBtn_Click);
            // 
            // vigenereBtn
            // 
            this.vigenereBtn.Location = new System.Drawing.Point(451, 371);
            this.vigenereBtn.Name = "vigenereBtn";
            this.vigenereBtn.Size = new System.Drawing.Size(421, 31);
            this.vigenereBtn.TabIndex = 3;
            this.vigenereBtn.Text = "VIGENERE";
            this.vigenereBtn.UseVisualStyleBackColor = true;
            this.vigenereBtn.Click += new System.EventHandler(this.vigenereBtn_Click);
            // 
            // polybiusBtn
            // 
            this.polybiusBtn.Location = new System.Drawing.Point(12, 408);
            this.polybiusBtn.Name = "polybiusBtn";
            this.polybiusBtn.Size = new System.Drawing.Size(421, 31);
            this.polybiusBtn.TabIndex = 4;
            this.polybiusBtn.Text = "POLYBIUS";
            this.polybiusBtn.UseVisualStyleBackColor = true;
            this.polybiusBtn.Click += new System.EventHandler(this.polybiusBtn_Click);
            // 
            // upperBtn
            // 
            this.upperBtn.Location = new System.Drawing.Point(12, 260);
            this.upperBtn.Name = "upperBtn";
            this.upperBtn.Size = new System.Drawing.Size(421, 31);
            this.upperBtn.TabIndex = 5;
            this.upperBtn.Text = "TO UPPER";
            this.upperBtn.UseVisualStyleBackColor = true;
            this.upperBtn.Click += new System.EventHandler(this.upperBtn_Click);
            // 
            // transpositionBtn
            // 
            this.transpositionBtn.Location = new System.Drawing.Point(451, 334);
            this.transpositionBtn.Name = "transpositionBtn";
            this.transpositionBtn.Size = new System.Drawing.Size(421, 31);
            this.transpositionBtn.TabIndex = 6;
            this.transpositionBtn.Text = "TRANSPOSITION";
            this.transpositionBtn.UseVisualStyleBackColor = true;
            this.transpositionBtn.Click += new System.EventHandler(this.transpositionBtn_Click);
            // 
            // morseBtn
            // 
            this.morseBtn.Location = new System.Drawing.Point(12, 297);
            this.morseBtn.Name = "morseBtn";
            this.morseBtn.Size = new System.Drawing.Size(421, 31);
            this.morseBtn.TabIndex = 7;
            this.morseBtn.Text = "MORSE";
            this.morseBtn.UseVisualStyleBackColor = true;
            this.morseBtn.Click += new System.EventHandler(this.morseBtn_Click);
            // 
            // binaryBtn
            // 
            this.binaryBtn.Location = new System.Drawing.Point(451, 297);
            this.binaryBtn.Name = "binaryBtn";
            this.binaryBtn.Size = new System.Drawing.Size(421, 31);
            this.binaryBtn.TabIndex = 8;
            this.binaryBtn.Text = "BINARY";
            this.binaryBtn.UseVisualStyleBackColor = true;
            this.binaryBtn.Click += new System.EventHandler(this.binaryBtn_Click);
            // 
            // playfairBtn
            // 
            this.playfairBtn.Location = new System.Drawing.Point(451, 408);
            this.playfairBtn.Name = "playfairBtn";
            this.playfairBtn.Size = new System.Drawing.Size(421, 31);
            this.playfairBtn.TabIndex = 9;
            this.playfairBtn.Text = "PLAYFAIR";
            this.playfairBtn.UseVisualStyleBackColor = true;
            this.playfairBtn.Click += new System.EventHandler(this.playfairBtn_Click);
            // 
            // lettersBtn
            // 
            this.lettersBtn.Location = new System.Drawing.Point(451, 260);
            this.lettersBtn.Name = "lettersBtn";
            this.lettersBtn.Size = new System.Drawing.Size(421, 31);
            this.lettersBtn.TabIndex = 10;
            this.lettersBtn.Text = "JUST LETTERS";
            this.lettersBtn.UseVisualStyleBackColor = true;
            this.lettersBtn.Click += new System.EventHandler(this.lettersBtn_Click);
            // 
            // btnBacon
            // 
            this.btnBacon.Location = new System.Drawing.Point(451, 445);
            this.btnBacon.Name = "btnBacon";
            this.btnBacon.Size = new System.Drawing.Size(421, 31);
            this.btnBacon.TabIndex = 11;
            this.btnBacon.Text = "bACON";
            this.btnBacon.UseVisualStyleBackColor = true;
            this.btnBacon.Click += new System.EventHandler(this.btnBacon_Click);
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
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 558);
            this.Controls.Add(initWordFreqBtn);
            this.Controls.Add(addSpacesBtn);
            this.Controls.Add(this.btnHill);
            this.Controls.Add(initQuadBtn);
            this.Controls.Add(this.btnBacon);
            this.Controls.Add(this.lettersBtn);
            this.Controls.Add(this.playfairBtn);
            this.Controls.Add(this.binaryBtn);
            this.Controls.Add(this.morseBtn);
            this.Controls.Add(this.transpositionBtn);
            this.Controls.Add(this.upperBtn);
            this.Controls.Add(this.polybiusBtn);
            this.Controls.Add(this.vigenereBtn);
            this.Controls.Add(this.substituteBtn);
            this.Controls.Add(this.ceaserBtn);
            this.Controls.Add(this.textInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "Form lol";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button ceaserBtn;
        private System.Windows.Forms.Button substituteBtn;
        private System.Windows.Forms.Button vigenereBtn;
        private System.Windows.Forms.Button polybiusBtn;
        private System.Windows.Forms.Button upperBtn;
        private System.Windows.Forms.Button transpositionBtn;
        private System.Windows.Forms.Button morseBtn;
        private System.Windows.Forms.Button binaryBtn;
        private System.Windows.Forms.Button playfairBtn;
        private System.Windows.Forms.Button lettersBtn;
        private System.Windows.Forms.Button btnBacon;
        private System.Windows.Forms.Button btnHill;
    }
}

