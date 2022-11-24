
namespace DumbCodeYe.Hill
{
    partial class HillCipher
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
            this.txtOutputt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtKnownText = new System.Windows.Forms.TextBox();
            this.numMatrixSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKnownC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numCurrentMatrix = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsertMatrix = new System.Windows.Forms.Button();
            this.btnDecipher = new System.Windows.Forms.Button();
            this.txtTL = new System.Windows.Forms.TextBox();
            this.txtTM = new System.Windows.Forms.TextBox();
            this.txtTR = new System.Windows.Forms.TextBox();
            this.txtML = new System.Windows.Forms.TextBox();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.txtMR = new System.Windows.Forms.TextBox();
            this.txtBL = new System.Windows.Forms.TextBox();
            this.txtBM = new System.Windows.Forms.TextBox();
            this.txtBR = new System.Windows.Forms.TextBox();
            this.chkInvertMatrix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMatrixSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutputt
            // 
            this.txtOutputt.Location = new System.Drawing.Point(12, 12);
            this.txtOutputt.Multiline = true;
            this.txtOutputt.Name = "txtOutputt";
            this.txtOutputt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputt.Size = new System.Drawing.Size(646, 402);
            this.txtOutputt.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Inverse Of  Possible Keys";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtKnownText
            // 
            this.txtKnownText.Location = new System.Drawing.Point(668, 133);
            this.txtKnownText.Name = "txtKnownText";
            this.txtKnownText.Size = new System.Drawing.Size(120, 20);
            this.txtKnownText.TabIndex = 2;
            // 
            // numMatrixSize
            // 
            this.numMatrixSize.Location = new System.Drawing.Point(668, 88);
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
            this.numMatrixSize.Size = new System.Drawing.Size(120, 20);
            this.numMatrixSize.TabIndex = 3;
            this.numMatrixSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Key size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter known text:";
            // 
            // txtKnownC
            // 
            this.txtKnownC.Location = new System.Drawing.Point(664, 188);
            this.txtKnownC.Name = "txtKnownC";
            this.txtKnownC.Size = new System.Drawing.Size(120, 20);
            this.txtKnownC.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(661, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter known cipher text:";
            // 
            // numCurrentMatrix
            // 
            this.numCurrentMatrix.Location = new System.Drawing.Point(668, 237);
            this.numCurrentMatrix.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCurrentMatrix.Name = "numCurrentMatrix";
            this.numCurrentMatrix.Size = new System.Drawing.Size(120, 20);
            this.numCurrentMatrix.TabIndex = 8;
            this.numCurrentMatrix.ValueChanged += new System.EventHandler(this.numCurrentMatrix_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Matrix keys:";
            // 
            // btnInsertMatrix
            // 
            this.btnInsertMatrix.Location = new System.Drawing.Point(663, 263);
            this.btnInsertMatrix.Name = "btnInsertMatrix";
            this.btnInsertMatrix.Size = new System.Drawing.Size(125, 38);
            this.btnInsertMatrix.TabIndex = 10;
            this.btnInsertMatrix.Text = "Insert Matrix";
            this.btnInsertMatrix.UseVisualStyleBackColor = true;
            this.btnInsertMatrix.Click += new System.EventHandler(this.btnInsertMatrix_Click);
            // 
            // btnDecipher
            // 
            this.btnDecipher.Location = new System.Drawing.Point(664, 307);
            this.btnDecipher.Name = "btnDecipher";
            this.btnDecipher.Size = new System.Drawing.Size(124, 38);
            this.btnDecipher.TabIndex = 11;
            this.btnDecipher.Text = "Decipher";
            this.btnDecipher.UseVisualStyleBackColor = true;
            this.btnDecipher.Click += new System.EventHandler(this.btnDecipher_Click);
            // 
            // txtTL
            // 
            this.txtTL.Location = new System.Drawing.Point(663, 360);
            this.txtTL.Name = "txtTL";
            this.txtTL.Size = new System.Drawing.Size(43, 20);
            this.txtTL.TabIndex = 12;
            // 
            // txtTM
            // 
            this.txtTM.Location = new System.Drawing.Point(712, 360);
            this.txtTM.Name = "txtTM";
            this.txtTM.Size = new System.Drawing.Size(43, 20);
            this.txtTM.TabIndex = 13;
            // 
            // txtTR
            // 
            this.txtTR.Location = new System.Drawing.Point(761, 360);
            this.txtTR.Name = "txtTR";
            this.txtTR.Size = new System.Drawing.Size(43, 20);
            this.txtTR.TabIndex = 14;
            // 
            // txtML
            // 
            this.txtML.Location = new System.Drawing.Point(663, 386);
            this.txtML.Name = "txtML";
            this.txtML.Size = new System.Drawing.Size(43, 20);
            this.txtML.TabIndex = 15;
            // 
            // txtMM
            // 
            this.txtMM.Location = new System.Drawing.Point(712, 386);
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(43, 20);
            this.txtMM.TabIndex = 16;
            // 
            // txtMR
            // 
            this.txtMR.Location = new System.Drawing.Point(761, 386);
            this.txtMR.Name = "txtMR";
            this.txtMR.Size = new System.Drawing.Size(43, 20);
            this.txtMR.TabIndex = 17;
            // 
            // txtBL
            // 
            this.txtBL.Location = new System.Drawing.Point(663, 412);
            this.txtBL.Name = "txtBL";
            this.txtBL.Size = new System.Drawing.Size(43, 20);
            this.txtBL.TabIndex = 18;
            // 
            // txtBM
            // 
            this.txtBM.Location = new System.Drawing.Point(712, 412);
            this.txtBM.Name = "txtBM";
            this.txtBM.Size = new System.Drawing.Size(43, 20);
            this.txtBM.TabIndex = 19;
            // 
            // txtBR
            // 
            this.txtBR.Location = new System.Drawing.Point(761, 412);
            this.txtBR.Name = "txtBR";
            this.txtBR.Size = new System.Drawing.Size(43, 20);
            this.txtBR.TabIndex = 20;
            // 
            // chkInvertMatrix
            // 
            this.chkInvertMatrix.AutoSize = true;
            this.chkInvertMatrix.Location = new System.Drawing.Point(680, 438);
            this.chkInvertMatrix.Name = "chkInvertMatrix";
            this.chkInvertMatrix.Size = new System.Drawing.Size(103, 17);
            this.chkInvertMatrix.TabIndex = 21;
            this.chkInvertMatrix.Text = "Invert text matrix";
            this.chkInvertMatrix.UseVisualStyleBackColor = true;
            this.chkInvertMatrix.CheckedChanged += new System.EventHandler(this.chkInvertMatrix_CheckedChanged);
            // 
            // HillCipher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 555);
            this.Controls.Add(this.chkInvertMatrix);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numCurrentMatrix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKnownC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMatrixSize);
            this.Controls.Add(this.txtKnownText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutputt);
            this.Name = "HillCipher";
            this.Text = "Hill";
            ((System.ComponentModel.ISupportInitialize)(this.numMatrixSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtKnownText;
        private System.Windows.Forms.NumericUpDown numMatrixSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKnownC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCurrentMatrix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsertMatrix;
        private System.Windows.Forms.Button btnDecipher;
        private System.Windows.Forms.TextBox txtTL;
        private System.Windows.Forms.TextBox txtTM;
        private System.Windows.Forms.TextBox txtTR;
        private System.Windows.Forms.TextBox txtML;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.TextBox txtMR;
        private System.Windows.Forms.TextBox txtBL;
        private System.Windows.Forms.TextBox txtBM;
        private System.Windows.Forms.TextBox txtBR;
        private System.Windows.Forms.CheckBox chkInvertMatrix;
    }
}