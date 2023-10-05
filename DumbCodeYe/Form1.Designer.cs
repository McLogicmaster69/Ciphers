
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
            this.textOperationsDropout = new System.Windows.Forms.Panel();
            this.justLettersBtn = new System.Windows.Forms.Button();
            this.toUpperBtn = new System.Windows.Forms.Button();
            this.basicCiphersDropout = new System.Windows.Forms.Panel();
            this.binaryBtn = new System.Windows.Forms.Button();
            this.morseBtn = new System.Windows.Forms.Button();
            this.baconBtn = new System.Windows.Forms.Button();
            this.ceaserBtn = new System.Windows.Forms.Button();
            this.monoAlphabeticDropout = new System.Windows.Forms.Panel();
            this.substituteBtn = new System.Windows.Forms.Button();
            this.polyAlphabeticDropout = new System.Windows.Forms.Panel();
            this.twoSquareBtn = new System.Windows.Forms.Button();
            this.playfairBtn = new System.Windows.Forms.Button();
            this.polybiusBtn = new System.Windows.Forms.Button();
            this.vigenereBtn = new System.Windows.Forms.Button();
            this.transpositionDropout = new System.Windows.Forms.Panel();
            this.factorsBtn = new System.Windows.Forms.Button();
            this.gridBtn = new System.Windows.Forms.Button();
            this.transpositionOtherBtn = new System.Windows.Forms.Button();
            this.groupingBtn = new System.Windows.Forms.Button();
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
            this.textOperationsDropout.SuspendLayout();
            this.basicCiphersDropout.SuspendLayout();
            this.monoAlphabeticDropout.SuspendLayout();
            this.polyAlphabeticDropout.SuspendLayout();
            this.transpositionDropout.SuspendLayout();
            this.SuspendLayout();
            // 
            // initQuadBtn
            // 
            initQuadBtn.Location = new System.Drawing.Point(304, 593);
            initQuadBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            initQuadBtn.Name = "initQuadBtn";
            initQuadBtn.Size = new System.Drawing.Size(280, 38);
            initQuadBtn.TabIndex = 12;
            initQuadBtn.Text = "INIT QUADGRAMS";
            initQuadBtn.UseVisualStyleBackColor = true;
            initQuadBtn.Click += new System.EventHandler(this.initQuadBtn_Click);
            // 
            // addSpacesBtn
            // 
            addSpacesBtn.Location = new System.Drawing.Point(16, 639);
            addSpacesBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            addSpacesBtn.Name = "addSpacesBtn";
            addSpacesBtn.Size = new System.Drawing.Size(1147, 38);
            addSpacesBtn.TabIndex = 13;
            addSpacesBtn.Text = "ADD SPACES";
            addSpacesBtn.UseVisualStyleBackColor = true;
            addSpacesBtn.Click += new System.EventHandler(this.addSpacesBtn_Click);
            // 
            // initWordFreqBtn
            // 
            initWordFreqBtn.Location = new System.Drawing.Point(883, 593);
            initWordFreqBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            initWordFreqBtn.Name = "initWordFreqBtn";
            initWordFreqBtn.Size = new System.Drawing.Size(280, 38);
            initWordFreqBtn.TabIndex = 14;
            initWordFreqBtn.Text = "INIT WORD FREQ";
            initWordFreqBtn.UseVisualStyleBackColor = true;
            initWordFreqBtn.Click += new System.EventHandler(this.initWordFreqBtn_Click);
            // 
            // initDictionaryBtn
            // 
            initDictionaryBtn.Location = new System.Drawing.Point(595, 593);
            initDictionaryBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            initDictionaryBtn.Name = "initDictionaryBtn";
            initDictionaryBtn.Size = new System.Drawing.Size(280, 38);
            initDictionaryBtn.TabIndex = 15;
            initDictionaryBtn.Text = "INIT DICTIONARY";
            initDictionaryBtn.UseVisualStyleBackColor = true;
            initDictionaryBtn.Click += new System.EventHandler(this.initDictionaryBtn_Click);
            // 
            // initBigramsBtn
            // 
            initBigramsBtn.Location = new System.Drawing.Point(16, 593);
            initBigramsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            initBigramsBtn.Name = "initBigramsBtn";
            initBigramsBtn.Size = new System.Drawing.Size(280, 38);
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
            this.textInput.Location = new System.Drawing.Point(400, 37);
            this.textInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInput.Size = new System.Drawing.Size(1199, 701);
            this.textInput.TabIndex = 0;
            this.textInput.Enter += new System.EventHandler(this.textInput_Enter);
            // 
            // btnHill
            // 
            this.btnHill.Location = new System.Drawing.Point(16, 548);
            this.btnHill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHill.Name = "btnHill";
            this.btnHill.Size = new System.Drawing.Size(561, 38);
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
            this.dragPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(1867, 37);
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
            this.closeBtn.Location = new System.Drawing.Point(1827, 2);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 32);
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
            this.textOperationsBtn.Location = new System.Drawing.Point(0, 37);
            this.textOperationsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textOperationsBtn.Name = "textOperationsBtn";
            this.textOperationsBtn.Size = new System.Drawing.Size(400, 49);
            this.textOperationsBtn.TabIndex = 19;
            this.textOperationsBtn.Text = "TEXT OPERATIONS";
            this.textOperationsBtn.UseVisualStyleBackColor = false;
            this.textOperationsBtn.Click += new System.EventHandler(this.textOperationsBtn_Click);
            // 
            // textOperationsDropout
            // 
            this.textOperationsDropout.Controls.Add(this.justLettersBtn);
            this.textOperationsDropout.Controls.Add(this.toUpperBtn);
            this.textOperationsDropout.Location = new System.Drawing.Point(400, 37);
            this.textOperationsDropout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textOperationsDropout.Name = "textOperationsDropout";
            this.textOperationsDropout.Size = new System.Drawing.Size(400, 98);
            this.textOperationsDropout.TabIndex = 20;
            this.textOperationsDropout.Visible = false;
            // 
            // justLettersBtn
            // 
            this.justLettersBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.justLettersBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.justLettersBtn.FlatAppearance.BorderSize = 2;
            this.justLettersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.justLettersBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.justLettersBtn.Location = new System.Drawing.Point(0, 49);
            this.justLettersBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.justLettersBtn.Name = "justLettersBtn";
            this.justLettersBtn.Size = new System.Drawing.Size(400, 49);
            this.justLettersBtn.TabIndex = 21;
            this.justLettersBtn.Text = "JUST LETTERS";
            this.justLettersBtn.UseVisualStyleBackColor = false;
            this.justLettersBtn.Click += new System.EventHandler(this.lettersBtn_Click);
            // 
            // toUpperBtn
            // 
            this.toUpperBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.toUpperBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.toUpperBtn.FlatAppearance.BorderSize = 2;
            this.toUpperBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toUpperBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.toUpperBtn.Location = new System.Drawing.Point(0, 0);
            this.toUpperBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toUpperBtn.Name = "toUpperBtn";
            this.toUpperBtn.Size = new System.Drawing.Size(400, 49);
            this.toUpperBtn.TabIndex = 20;
            this.toUpperBtn.Text = "TO UPPER";
            this.toUpperBtn.UseVisualStyleBackColor = false;
            this.toUpperBtn.Click += new System.EventHandler(this.upperBtn_Click);
            // 
            // basicCiphersDropout
            // 
            this.basicCiphersDropout.Controls.Add(this.binaryBtn);
            this.basicCiphersDropout.Controls.Add(this.morseBtn);
            this.basicCiphersDropout.Controls.Add(this.baconBtn);
            this.basicCiphersDropout.Location = new System.Drawing.Point(400, 86);
            this.basicCiphersDropout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.basicCiphersDropout.Name = "basicCiphersDropout";
            this.basicCiphersDropout.Size = new System.Drawing.Size(400, 148);
            this.basicCiphersDropout.TabIndex = 22;
            this.basicCiphersDropout.Visible = false;
            // 
            // binaryBtn
            // 
            this.binaryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.binaryBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.binaryBtn.FlatAppearance.BorderSize = 2;
            this.binaryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.binaryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.binaryBtn.Location = new System.Drawing.Point(0, 49);
            this.binaryBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.binaryBtn.Name = "binaryBtn";
            this.binaryBtn.Size = new System.Drawing.Size(400, 49);
            this.binaryBtn.TabIndex = 21;
            this.binaryBtn.Text = "BINARY";
            this.binaryBtn.UseVisualStyleBackColor = false;
            this.binaryBtn.Click += new System.EventHandler(this.binaryBtn_Click);
            // 
            // morseBtn
            // 
            this.morseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.morseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.morseBtn.FlatAppearance.BorderSize = 2;
            this.morseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.morseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.morseBtn.Location = new System.Drawing.Point(0, 0);
            this.morseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.morseBtn.Name = "morseBtn";
            this.morseBtn.Size = new System.Drawing.Size(400, 49);
            this.morseBtn.TabIndex = 20;
            this.morseBtn.Text = "MORSE";
            this.morseBtn.UseVisualStyleBackColor = false;
            this.morseBtn.Click += new System.EventHandler(this.morseBtn_Click);
            // 
            // baconBtn
            // 
            this.baconBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.baconBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.baconBtn.FlatAppearance.BorderSize = 2;
            this.baconBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baconBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.baconBtn.Location = new System.Drawing.Point(0, 98);
            this.baconBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baconBtn.Name = "baconBtn";
            this.baconBtn.Size = new System.Drawing.Size(400, 49);
            this.baconBtn.TabIndex = 26;
            this.baconBtn.Text = "BACON";
            this.baconBtn.UseVisualStyleBackColor = false;
            this.baconBtn.Click += new System.EventHandler(this.btnBacon_Click);
            // 
            // ceaserBtn
            // 
            this.ceaserBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.ceaserBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.ceaserBtn.FlatAppearance.BorderSize = 2;
            this.ceaserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ceaserBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.ceaserBtn.Location = new System.Drawing.Point(0, 0);
            this.ceaserBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ceaserBtn.Name = "ceaserBtn";
            this.ceaserBtn.Size = new System.Drawing.Size(400, 49);
            this.ceaserBtn.TabIndex = 22;
            this.ceaserBtn.Text = "CEASER";
            this.ceaserBtn.UseVisualStyleBackColor = false;
            this.ceaserBtn.Click += new System.EventHandler(this.ceaserBtn_Click);
            // 
            // monoAlphabeticDropout
            // 
            this.monoAlphabeticDropout.Controls.Add(this.substituteBtn);
            this.monoAlphabeticDropout.Controls.Add(this.ceaserBtn);
            this.monoAlphabeticDropout.Location = new System.Drawing.Point(400, 135);
            this.monoAlphabeticDropout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monoAlphabeticDropout.Name = "monoAlphabeticDropout";
            this.monoAlphabeticDropout.Size = new System.Drawing.Size(400, 98);
            this.monoAlphabeticDropout.TabIndex = 22;
            this.monoAlphabeticDropout.Visible = false;
            // 
            // substituteBtn
            // 
            this.substituteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.substituteBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.substituteBtn.FlatAppearance.BorderSize = 2;
            this.substituteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.substituteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.substituteBtn.Location = new System.Drawing.Point(0, 49);
            this.substituteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.substituteBtn.Name = "substituteBtn";
            this.substituteBtn.Size = new System.Drawing.Size(400, 49);
            this.substituteBtn.TabIndex = 22;
            this.substituteBtn.Text = "SUBSTITUTE";
            this.substituteBtn.UseVisualStyleBackColor = false;
            this.substituteBtn.Click += new System.EventHandler(this.substituteBtn_Click);
            // 
            // polyAlphabeticDropout
            // 
            this.polyAlphabeticDropout.Controls.Add(this.twoSquareBtn);
            this.polyAlphabeticDropout.Controls.Add(this.playfairBtn);
            this.polyAlphabeticDropout.Controls.Add(this.polybiusBtn);
            this.polyAlphabeticDropout.Controls.Add(this.vigenereBtn);
            this.polyAlphabeticDropout.Location = new System.Drawing.Point(400, 185);
            this.polyAlphabeticDropout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.polyAlphabeticDropout.Name = "polyAlphabeticDropout";
            this.polyAlphabeticDropout.Size = new System.Drawing.Size(400, 197);
            this.polyAlphabeticDropout.TabIndex = 22;
            this.polyAlphabeticDropout.Visible = false;
            // 
            // twoSquareBtn
            // 
            this.twoSquareBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.twoSquareBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.twoSquareBtn.FlatAppearance.BorderSize = 2;
            this.twoSquareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoSquareBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.twoSquareBtn.Location = new System.Drawing.Point(0, 148);
            this.twoSquareBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.twoSquareBtn.Name = "twoSquareBtn";
            this.twoSquareBtn.Size = new System.Drawing.Size(400, 49);
            this.twoSquareBtn.TabIndex = 25;
            this.twoSquareBtn.Text = "TWO SQUARE";
            this.twoSquareBtn.UseVisualStyleBackColor = false;
            this.twoSquareBtn.Click += new System.EventHandler(this.twoSquareBtn_Click);
            // 
            // playfairBtn
            // 
            this.playfairBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.playfairBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.playfairBtn.FlatAppearance.BorderSize = 2;
            this.playfairBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playfairBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.playfairBtn.Location = new System.Drawing.Point(0, 98);
            this.playfairBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playfairBtn.Name = "playfairBtn";
            this.playfairBtn.Size = new System.Drawing.Size(400, 49);
            this.playfairBtn.TabIndex = 24;
            this.playfairBtn.Text = "PLAYFAIR";
            this.playfairBtn.UseVisualStyleBackColor = false;
            this.playfairBtn.Click += new System.EventHandler(this.playfairBtn_Click);
            // 
            // polybiusBtn
            // 
            this.polybiusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.polybiusBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.polybiusBtn.FlatAppearance.BorderSize = 2;
            this.polybiusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.polybiusBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.polybiusBtn.Location = new System.Drawing.Point(0, 49);
            this.polybiusBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.polybiusBtn.Name = "polybiusBtn";
            this.polybiusBtn.Size = new System.Drawing.Size(400, 49);
            this.polybiusBtn.TabIndex = 23;
            this.polybiusBtn.Text = "POLYBIUS";
            this.polybiusBtn.UseVisualStyleBackColor = false;
            this.polybiusBtn.Click += new System.EventHandler(this.polybiusBtn_Click);
            // 
            // vigenereBtn
            // 
            this.vigenereBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.vigenereBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.vigenereBtn.FlatAppearance.BorderSize = 2;
            this.vigenereBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vigenereBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.vigenereBtn.Location = new System.Drawing.Point(0, 0);
            this.vigenereBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vigenereBtn.Name = "vigenereBtn";
            this.vigenereBtn.Size = new System.Drawing.Size(400, 49);
            this.vigenereBtn.TabIndex = 23;
            this.vigenereBtn.Text = "VIGENERE";
            this.vigenereBtn.UseVisualStyleBackColor = false;
            this.vigenereBtn.Click += new System.EventHandler(this.vigenereBtn_Click);
            // 
            // transpositionDropout
            // 
            this.transpositionDropout.Controls.Add(this.factorsBtn);
            this.transpositionDropout.Controls.Add(this.gridBtn);
            this.transpositionDropout.Controls.Add(this.transpositionOtherBtn);
            this.transpositionDropout.Controls.Add(this.groupingBtn);
            this.transpositionDropout.Location = new System.Drawing.Point(400, 234);
            this.transpositionDropout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transpositionDropout.Name = "transpositionDropout";
            this.transpositionDropout.Size = new System.Drawing.Size(400, 197);
            this.transpositionDropout.TabIndex = 22;
            this.transpositionDropout.Visible = false;
            // 
            // factorsBtn
            // 
            this.factorsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.factorsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.factorsBtn.FlatAppearance.BorderSize = 2;
            this.factorsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factorsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.factorsBtn.Location = new System.Drawing.Point(0, 0);
            this.factorsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.factorsBtn.Name = "factorsBtn";
            this.factorsBtn.Size = new System.Drawing.Size(400, 49);
            this.factorsBtn.TabIndex = 23;
            this.factorsBtn.Text = "FACTORS";
            this.factorsBtn.UseVisualStyleBackColor = false;
            // 
            // gridBtn
            // 
            this.gridBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.gridBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridBtn.FlatAppearance.BorderSize = 2;
            this.gridBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gridBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridBtn.Location = new System.Drawing.Point(0, 49);
            this.gridBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridBtn.Name = "gridBtn";
            this.gridBtn.Size = new System.Drawing.Size(400, 49);
            this.gridBtn.TabIndex = 23;
            this.gridBtn.Text = "GRIDS";
            this.gridBtn.UseVisualStyleBackColor = false;
            // 
            // transpositionOtherBtn
            // 
            this.transpositionOtherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.transpositionOtherBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.transpositionOtherBtn.FlatAppearance.BorderSize = 2;
            this.transpositionOtherBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transpositionOtherBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.transpositionOtherBtn.Location = new System.Drawing.Point(0, 98);
            this.transpositionOtherBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transpositionOtherBtn.Name = "transpositionOtherBtn";
            this.transpositionOtherBtn.Size = new System.Drawing.Size(400, 49);
            this.transpositionOtherBtn.TabIndex = 23;
            this.transpositionOtherBtn.Text = "OTHER";
            this.transpositionOtherBtn.UseVisualStyleBackColor = false;
            // 
            // groupingBtn
            // 
            this.groupingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.groupingBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupingBtn.FlatAppearance.BorderSize = 2;
            this.groupingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupingBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupingBtn.Location = new System.Drawing.Point(0, 148);
            this.groupingBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupingBtn.Name = "groupingBtn";
            this.groupingBtn.Size = new System.Drawing.Size(400, 49);
            this.groupingBtn.TabIndex = 23;
            this.groupingBtn.Text = "GROUPINGS";
            this.groupingBtn.UseVisualStyleBackColor = false;
            // 
            // basicCipherBtn
            // 
            this.basicCipherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.basicCipherBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.basicCipherBtn.FlatAppearance.BorderSize = 2;
            this.basicCipherBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.basicCipherBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.basicCipherBtn.Location = new System.Drawing.Point(0, 86);
            this.basicCipherBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.basicCipherBtn.Name = "basicCipherBtn";
            this.basicCipherBtn.Size = new System.Drawing.Size(400, 49);
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
            this.monoAlphabeticBtn.Location = new System.Drawing.Point(0, 135);
            this.monoAlphabeticBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monoAlphabeticBtn.Name = "monoAlphabeticBtn";
            this.monoAlphabeticBtn.Size = new System.Drawing.Size(400, 49);
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
            this.polyAlphabeticBtn.Location = new System.Drawing.Point(0, 185);
            this.polyAlphabeticBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.polyAlphabeticBtn.Name = "polyAlphabeticBtn";
            this.polyAlphabeticBtn.Size = new System.Drawing.Size(400, 49);
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
            this.transpositionBtn.Location = new System.Drawing.Point(0, 234);
            this.transpositionBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transpositionBtn.Name = "transpositionBtn";
            this.transpositionBtn.Size = new System.Drawing.Size(400, 49);
            this.transpositionBtn.TabIndex = 26;
            this.transpositionBtn.Text = "TRANSPOSITION";
            this.transpositionBtn.UseVisualStyleBackColor = false;
            this.transpositionBtn.Click += new System.EventHandler(this.transpositionBtn_Click_1);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1867, 738);
            this.Controls.Add(this.transpositionBtn);
            this.Controls.Add(this.polyAlphabeticBtn);
            this.Controls.Add(this.monoAlphabeticBtn);
            this.Controls.Add(this.basicCipherBtn);
            this.Controls.Add(this.basicCiphersDropout);
            this.Controls.Add(this.textOperationsDropout);
            this.Controls.Add(this.monoAlphabeticDropout);
            this.Controls.Add(this.polyAlphabeticDropout);
            this.Controls.Add(this.transpositionDropout);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "Form lol";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.dragPanel.ResumeLayout(false);
            this.textOperationsDropout.ResumeLayout(false);
            this.basicCiphersDropout.ResumeLayout(false);
            this.monoAlphabeticDropout.ResumeLayout(false);
            this.polyAlphabeticDropout.ResumeLayout(false);
            this.transpositionDropout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button btnHill;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.Button textOperationsBtn;
        private System.Windows.Forms.Panel textOperationsDropout;
        private System.Windows.Forms.Button toUpperBtn;
        private System.Windows.Forms.Button justLettersBtn;
        private System.Windows.Forms.Panel basicCiphersDropout;
        private System.Windows.Forms.Panel monoAlphabeticDropout;
        private System.Windows.Forms.Panel polyAlphabeticDropout;
        private System.Windows.Forms.Panel transpositionDropout;
        private System.Windows.Forms.Button binaryBtn;
        private System.Windows.Forms.Button morseBtn;
        private System.Windows.Forms.Button basicCipherBtn;
        private System.Windows.Forms.Button monoAlphabeticBtn;
        private System.Windows.Forms.Button polyAlphabeticBtn;
        private System.Windows.Forms.Button transpositionBtn;
        private System.Windows.Forms.Button ceaserBtn;
        private System.Windows.Forms.Button substituteBtn;
        private System.Windows.Forms.Button playfairBtn;
        private System.Windows.Forms.Button polybiusBtn;
        private System.Windows.Forms.Button vigenereBtn;
        private System.Windows.Forms.Button twoSquareBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button baconBtn;
        private System.Windows.Forms.Button factorsBtn;
        private System.Windows.Forms.Button gridBtn;
        private System.Windows.Forms.Button groupingBtn;
        private System.Windows.Forms.Button transpositionOtherBtn;
    }
}

