namespace DumbCodeYe.Hill
{
    partial class HillCipherRemastered
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.chkIndexAt0 = new System.Windows.Forms.CheckBox();
            this.txtBR = new System.Windows.Forms.TextBox();
            this.txtBM = new System.Windows.Forms.TextBox();
            this.txtBL = new System.Windows.Forms.TextBox();
            this.txtMR = new System.Windows.Forms.TextBox();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.txtML = new System.Windows.Forms.TextBox();
            this.txtTR = new System.Windows.Forms.TextBox();
            this.txtTM = new System.Windows.Forms.TextBox();
            this.txtTL = new System.Windows.Forms.TextBox();
            this.btnDecipher = new System.Windows.Forms.Button();
            this.btnInsertMatrix = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKnownC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMatrixSize = new System.Windows.Forms.NumericUpDown();
            this.txtKnownText = new System.Windows.Forms.TextBox();
            this.btnInverseKeys = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMatrixSize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(500, 500);
            this.txtInput.TabIndex = 0;
            // 
            // chkIndexAt0
            // 
            this.chkIndexAt0.AutoSize = true;
            this.chkIndexAt0.Location = new System.Drawing.Point(518, 495);
            this.chkIndexAt0.Name = "chkIndexAt0";
            this.chkIndexAt0.Size = new System.Drawing.Size(73, 17);
            this.chkIndexAt0.TabIndex = 42;
            this.chkIndexAt0.Text = "Index at 0";
            this.chkIndexAt0.UseVisualStyleBackColor = true;
            // 
            // txtBR
            // 
            this.txtBR.Location = new System.Drawing.Point(615, 258);
            this.txtBR.MaxLength = 3;
            this.txtBR.Name = "txtBR";
            this.txtBR.Size = new System.Drawing.Size(43, 20);
            this.txtBR.TabIndex = 41;
            // 
            // txtBM
            // 
            this.txtBM.Location = new System.Drawing.Point(566, 258);
            this.txtBM.MaxLength = 3;
            this.txtBM.Name = "txtBM";
            this.txtBM.Size = new System.Drawing.Size(43, 20);
            this.txtBM.TabIndex = 40;
            // 
            // txtBL
            // 
            this.txtBL.Location = new System.Drawing.Point(517, 258);
            this.txtBL.MaxLength = 3;
            this.txtBL.Name = "txtBL";
            this.txtBL.Size = new System.Drawing.Size(43, 20);
            this.txtBL.TabIndex = 39;
            // 
            // txtMR
            // 
            this.txtMR.Location = new System.Drawing.Point(615, 232);
            this.txtMR.MaxLength = 3;
            this.txtMR.Name = "txtMR";
            this.txtMR.Size = new System.Drawing.Size(43, 20);
            this.txtMR.TabIndex = 38;
            // 
            // txtMM
            // 
            this.txtMM.Location = new System.Drawing.Point(566, 232);
            this.txtMM.MaxLength = 3;
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(43, 20);
            this.txtMM.TabIndex = 37;
            // 
            // txtML
            // 
            this.txtML.Location = new System.Drawing.Point(517, 232);
            this.txtML.MaxLength = 3;
            this.txtML.Name = "txtML";
            this.txtML.Size = new System.Drawing.Size(43, 20);
            this.txtML.TabIndex = 36;
            // 
            // txtTR
            // 
            this.txtTR.Location = new System.Drawing.Point(615, 206);
            this.txtTR.MaxLength = 3;
            this.txtTR.Name = "txtTR";
            this.txtTR.Size = new System.Drawing.Size(43, 20);
            this.txtTR.TabIndex = 35;
            // 
            // txtTM
            // 
            this.txtTM.Location = new System.Drawing.Point(566, 206);
            this.txtTM.MaxLength = 3;
            this.txtTM.Name = "txtTM";
            this.txtTM.Size = new System.Drawing.Size(43, 20);
            this.txtTM.TabIndex = 34;
            // 
            // txtTL
            // 
            this.txtTL.Location = new System.Drawing.Point(517, 206);
            this.txtTL.MaxLength = 3;
            this.txtTL.Name = "txtTL";
            this.txtTL.Size = new System.Drawing.Size(43, 20);
            this.txtTL.TabIndex = 33;
            // 
            // btnDecipher
            // 
            this.btnDecipher.Location = new System.Drawing.Point(517, 451);
            this.btnDecipher.Name = "btnDecipher";
            this.btnDecipher.Size = new System.Drawing.Size(141, 38);
            this.btnDecipher.TabIndex = 32;
            this.btnDecipher.Text = "Decipher";
            this.btnDecipher.UseVisualStyleBackColor = true;
            // 
            // btnInsertMatrix
            // 
            this.btnInsertMatrix.Location = new System.Drawing.Point(516, 284);
            this.btnInsertMatrix.Name = "btnInsertMatrix";
            this.btnInsertMatrix.Size = new System.Drawing.Size(141, 38);
            this.btnInsertMatrix.TabIndex = 31;
            this.btnInsertMatrix.Text = "Insert Matrix";
            this.btnInsertMatrix.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(518, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Enter known cipher text:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKnownC
            // 
            this.txtKnownC.Location = new System.Drawing.Point(518, 132);
            this.txtKnownC.Name = "txtKnownC";
            this.txtKnownC.Size = new System.Drawing.Size(140, 20);
            this.txtKnownC.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(518, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Enter known text:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(518, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Enter Key size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMatrixSize
            // 
            this.numMatrixSize.Location = new System.Drawing.Point(518, 36);
            this.numMatrixSize.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numMatrixSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMatrixSize.Name = "numMatrixSize";
            this.numMatrixSize.Size = new System.Drawing.Size(140, 20);
            this.numMatrixSize.TabIndex = 24;
            this.numMatrixSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtKnownText
            // 
            this.txtKnownText.Location = new System.Drawing.Point(518, 84);
            this.txtKnownText.Name = "txtKnownText";
            this.txtKnownText.Size = new System.Drawing.Size(140, 20);
            this.txtKnownText.TabIndex = 23;
            // 
            // btnInverseKeys
            // 
            this.btnInverseKeys.Location = new System.Drawing.Point(516, 158);
            this.btnInverseKeys.Name = "btnInverseKeys";
            this.btnInverseKeys.Size = new System.Drawing.Size(141, 38);
            this.btnInverseKeys.TabIndex = 22;
            this.btnInverseKeys.Text = "Get inverse of possible keys";
            this.btnInverseKeys.UseVisualStyleBackColor = true;
            this.btnInverseKeys.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 38);
            this.button1.TabIndex = 43;
            this.button1.Text = "Brute Force";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(686, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 409);
            this.textBox1.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(686, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 22);
            this.label4.TabIndex = 45;
            this.label4.Text = "Enter Key words:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HillCipherRemastered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkIndexAt0);
            this.Controls.Add(this.txtBR);
            this.Controls.Add(this.txtBM);
            this.Controls.Add(this.txtBL);
            this.Controls.Add(this.txtMR);
            this.Controls.Add(this.txtMM);
            this.Controls.Add(this.txtML);
            this.Controls.Add(this.txtTR);
            this.Controls.Add(this.txtTM);
            this.Controls.Add(this.txtTL);
            this.Controls.Add(this.btnDecipher);
            this.Controls.Add(this.btnInsertMatrix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKnownC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMatrixSize);
            this.Controls.Add(this.txtKnownText);
            this.Controls.Add(this.btnInverseKeys);
            this.Controls.Add(this.txtInput);
            this.Name = "HillCipherRemastered";
            this.Text = "HillCipherRemastered";
            ((System.ComponentModel.ISupportInitialize)(this.numMatrixSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox chkIndexAt0;
        private System.Windows.Forms.TextBox txtBR;
        private System.Windows.Forms.TextBox txtBM;
        private System.Windows.Forms.TextBox txtBL;
        private System.Windows.Forms.TextBox txtMR;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.TextBox txtML;
        private System.Windows.Forms.TextBox txtTR;
        private System.Windows.Forms.TextBox txtTM;
        private System.Windows.Forms.TextBox txtTL;
        private System.Windows.Forms.Button btnDecipher;
        private System.Windows.Forms.Button btnInsertMatrix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKnownC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMatrixSize;
        private System.Windows.Forms.TextBox txtKnownText;
        private System.Windows.Forms.Button btnInverseKeys;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}