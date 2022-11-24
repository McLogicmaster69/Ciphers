using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Hill
{
    public partial class HillCipher : Form
    {

        public string CipherText = "";
        public string PlainText = "";
        public int KeySize = 0;
        public string KnownText = "";
        public string KnownTextC = "";
        public List<double[,]> MatrixKeys = new List<double[,]>();
        public int MatrixKeysIndex = 0;
        public HillCipher()
        {
            InitializeComponent();
        }
        public void SetText(string inputText)
        {
            txtOutputt.Text = inputText;
        }

        public static double GetDet(double[,] matrix, int minorX = 0, int minorY = 0)
        {
            double[,] minorMatrix = { { 0, 0 }, { 0, 0 } };   //holds matrix from minors
            int detMatrixInputPos = 0;
            if (matrix.GetLength(0) != 2)
            {
                for (int matrixY = 0; matrixY < matrix.GetLength(0); matrixY++)   //for every Row...
                {
                    for (int matrixX = 0; matrixX < matrix.GetLength(1); matrixX++)   //for every column in the row...
                    {
                        if (matrixX != minorX && matrixY != minorY)     //if does not share coordinates with the minor...
                        {
                            if (detMatrixInputPos == 0)                     //if so, insert into detMatrix
                            {
                                minorMatrix[0, 0] = matrix[matrixY, matrixX];
                            }
                            else if (detMatrixInputPos == 1)
                            {
                                minorMatrix[1, 0] = matrix[matrixY, matrixX];
                            }
                            else if (detMatrixInputPos == 2)
                            {
                                minorMatrix[0, 1] = matrix[matrixY, matrixX];
                            }
                            else if (detMatrixInputPos == 3)
                            {
                                minorMatrix[1, 1] = matrix[matrixY, matrixX];
                            }
                            else
                            {
                                MessageBox.Show("Error with GetDet() detMatrix");
                            }

                            detMatrixInputPos++; //increments for next minor number
                        }
                    }
                }
            }
            else
            {
                for ( int i = 0;  i < 2; i++ )
                {
                    for (int j = 0; j < 2; j++)
                    {
                        minorMatrix[i, j] = Convert.ToDouble(matrix[i, j]);
                    }
                }
            }
            return minorMatrix[0, 0] * minorMatrix[1, 1] - minorMatrix[0, 1] * minorMatrix[1, 0];
        }

        public string ConvertToAlphabet(int number)
        {
            return Convert.ToString(Convert.ToChar(number + 64));
        }
        public int ConvertToNumber(string character)
        {
            return Convert.ToInt32(Convert.ToChar(character)) - 64;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CipherText = txtOutputt.Text;
            KeySize = Convert.ToInt32(numMatrixSize.Value);
            KnownText = txtKnownText.Text;
            KnownTextC = txtKnownC.Text;
            if (!(CipherText == "" && KnownText == ""))
            {
                if (KeySize == 2)
                {
                    txtOutputt.Text = TwoMatrix();
                }
                else
                {
                    MessageBox.Show("not done 3 yet");
                }

            }
            else
            {
                MessageBox.Show("Enter text in all fields");
            }



        }

        public void TwoSimult(int x1, int y1, int n1, int x2, int y2, int n2/*, out double xOut, out double yOut*/)
        {
            int[,] matrixXY = { };
            int[,] matrixM = { { x1, x2 }, { y1, y2 }, { n1, n2 } };
            int[,] matrixMOriginal = { { x1, x2 }, { y1, y2 }, { n1, n2 } };
            int[] matrixSingle = { 0, 0, 0 };   //0 represents x coefficient, 1 represents n, 2 represents the modulo size
            int hcf;
            int[] x1x = { 0, 0 };    //0 represents num after mod,   1 represents modulo
            int arrIndex = 0;

            //creates like congruences
            for (int ii = 0; ii < 3; ii++)
            {
                matrixM[ii, 0] = (matrixM[ii, 0] * y2) % 26;
            }
            for (int ii = 0; ii < 3; ii++)
            {
                matrixM[ii, 1] = (matrixM[ii, 1] * y1) % 26;
            }
            //subtract one congruence by the other
            if (matrixM[0, 0] > matrixM[0, 1])
            {
                matrixSingle[0] = matrixM[0, 0] - matrixM[0, 1];
                matrixSingle[1] = matrixM[2, 0] - matrixM[2, 1];
                matrixSingle[2] = matrixSingle[1] % 26;
            }
            else
            {
                matrixSingle[0] = matrixM[0, 1] - matrixM[0, 0];
                matrixSingle[1] = matrixM[2, 1] - matrixM[2, 0];
                matrixSingle[1] = matrixSingle[1] % 26;
                matrixSingle[2] = 26;
            }
            //remove the common factor between matrixSingle variables
            hcf = HCF3(matrixSingle[0], matrixSingle[1], matrixSingle[2]);
            foreach (int index in matrixSingle)
            {
                matrixSingle[index] /= hcf;
            }
            //removes coefficient of x1 (sets matrixSingle to 1)]
            x1x[0] = (FindMultiplicativeInverse(matrixSingle[0], matrixSingle[2]) * matrixSingle[1]) % matrixSingle[2];
            x1x[1] = matrixSingle[2];

            //get x values
            for (int index = 0; index < 26; index++)
            {
                if (index % matrixSingle[1] == matrixSingle[0])
                {
                    matrixXY[arrIndex, 0] = index;
                    arrIndex++;
                }
            }


            arrIndex = 1;
            //get y values
            for (int index = 0; index < matrixXY.GetLength(0); index++)
            {

            }


        }

        public int FindMultiplicativeInverse(int coefficient, int modulo)
        {
            int multiplicativeInverse = 1;
            while ((coefficient * multiplicativeInverse) % modulo != 0)
            {
                multiplicativeInverse++;
            }
            return multiplicativeInverse;
        }

        public int HCF3(int num1, int num2, int num3)   //finds HCF of 3 numbers
        {
            int hcf = 1;
            int[] num1PF = getPrimeFactors(num1);
            int[] num2PF = getPrimeFactors(num2);
            int[] num3PF = getPrimeFactors(num3);
            int num1Index = 0;
            int num2Index = 0;
            int num3Index = 0;
            do
            {
                if (num1PF[num1Index] == num2PF[num2Index] && num2PF[num2Index] == num3PF[num3Index])
                {
                    hcf *= num1PF[num1Index];
                    num1Index++;
                    num2Index++;
                    num3Index++;
                }
                else
                {
                    num1Index = NextPrimeIndex(num1PF, num1PF[num1Index]);
                    num2Index = NextPrimeIndex(num2PF, num2PF[num2Index]);
                    num2Index = NextPrimeIndex(num3PF, num3PF[num3Index]);
                }

            } while (num1PF.Length < num1Index && num2PF.Length < num2Index && num3PF.Length < num3Index);
            return hcf;
        }

        public int NextPrimeIndex(int[] arr, int currentPrime)
        {
            for (int index = currentPrime; index < arr.Length; index++)
            {
                if (arr[index] != currentPrime)
                {
                    return index;
                }
            }
            return arr.Length;
        }

        public int[] getPrimeFactors(int num)
        {
            int[] primeFactors = { };
            int largestPrime = 2;
            int index = 0;
            while (largestPrime < num)
            {
                if (num % largestPrime == 0)
                {
                    num /= largestPrime;
                    primeFactors[index] = largestPrime;
                    index++;
                }
                else
                {
                    do
                    {
                        largestPrime++;
                    } while (!CheckPrime(largestPrime));

                }
            }
            return primeFactors;


        }

        public bool CheckPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        string TwoMatrix()
        {
            int[,] SysCongruence1 = { { 0, 0 }, { 0, 0 } };
            int[,] SysCongruence2 = { { 0, 0 }, { 0, 0 } };


            string chunkOfCipher;
            string chunkOfKnown;
            chunkOfCipher = KnownTextC.Substring(0, 2);
            chunkOfKnown = KnownText.Substring(0, 2);

            //creates 1st set of simultaneous equations
            for (int ii = 0; ii < 2; ii++)
            {
                SysCongruence1[0, ii] = ConvertToNumber(chunkOfKnown.Substring(ii, 1));
            }
            for (int ii = 0; ii < 2; ii++)
            {
                SysCongruence1[1, ii] = ConvertToNumber(chunkOfCipher.Substring(ii, 1));
            }
            chunkOfCipher = KnownTextC.Substring(2, 2);
            chunkOfKnown = KnownText.Substring(2, 2);
            //creates 2nd set of simultaneous equations
            for (int ii = 0; ii < 2; ii++)
            {
                SysCongruence2[0, ii] = ConvertToNumber(chunkOfKnown.Substring(ii, 1));
            }
            for (int ii = 0; ii < 2; ii++)
            {
                SysCongruence2[1, ii] = ConvertToNumber(chunkOfCipher.Substring(ii, 1));
            }

            TwoSimult(SysCongruence1[0, 0], SysCongruence1[0, 1], SysCongruence1[1, 0], SysCongruence2[0, 0], SysCongruence2[0, 1], SysCongruence2[1, 0]);









            return "";

        }

        private void btnInsertMatrix_Click(object sender, EventArgs e)
        {
            double[,] insertMatrix = new double[3, 3];
            if (txtBR.Text == "")                                   //converts intputted matrix values to a 3x3 matrix
            {
                insertMatrix[0, 0] = Convert.ToDouble(txtTL.Text);
                insertMatrix[0, 1] = Convert.ToDouble(txtTM.Text);
                insertMatrix[1, 0] = Convert.ToDouble(txtML.Text);
                insertMatrix[1, 1] = Convert.ToDouble(txtMM.Text);

            }
            else
            {
                insertMatrix[0, 0] = Convert.ToDouble(txtTL.Text);
                insertMatrix[0, 1] = Convert.ToDouble(txtTM.Text);
                insertMatrix[0, 2] = Convert.ToDouble(txtTR.Text);
                insertMatrix[1, 0] = Convert.ToDouble(txtML.Text);
                insertMatrix[1, 1] = Convert.ToDouble(txtMM.Text);
                insertMatrix[1, 2] = Convert.ToDouble(txtMR.Text);
                insertMatrix[2, 0] = Convert.ToDouble(txtBL.Text);
                insertMatrix[2, 1] = Convert.ToDouble(txtBM.Text);
                insertMatrix[2, 2] = Convert.ToDouble(txtBR.Text);
            }

            int matrixSize = 3;
            if (insertMatrix[0,2] == 0 && insertMatrix[1,2] == 0 && insertMatrix[2,0] == 0 && insertMatrix[2,1] == 0 && insertMatrix[2,2] == 0)
                matrixSize = 2;

            double[,] insertMatrix2 = new double[matrixSize, matrixSize];

            for (int ii = 0; ii < Math.Sqrt(insertMatrix2.Length); ii++)                 //inserts new matrix to one of the correct size
            {
                for (int jj = 0; jj < Math.Sqrt(insertMatrix2.Length); jj++)
                {
                    insertMatrix2[ii,jj] = insertMatrix[ii, jj];
                }
            }
            MatrixKeys.Add(insertMatrix2);                                              //adds matrix to the list of matrix keys
        }

        public void DisplayMatrix()                                                     //displays matrix in the grid
        {
            int currentMatrix = Convert.ToInt32(numCurrentMatrix.Value);

            txtTL.Text = Convert.ToString(MatrixKeys[currentMatrix][0,0]);
            txtTM.Text = Convert.ToString(MatrixKeys[currentMatrix][0,1]);
            txtML.Text = Convert.ToString(MatrixKeys[currentMatrix][1,0]);
            txtMM.Text = Convert.ToString(MatrixKeys[currentMatrix][1,1]);
            if (MatrixKeys[currentMatrix].GetLength(1) == 3)
            {
                txtTR.Text = Convert.ToString(MatrixKeys[currentMatrix][0,2]);
                txtMR.Text = Convert.ToString(MatrixKeys[currentMatrix][1,2]);
                txtBL.Text = Convert.ToString(MatrixKeys[currentMatrix][2,0]);
                txtBM.Text = Convert.ToString(MatrixKeys[currentMatrix][2,1]);
                txtBR.Text = Convert.ToString(MatrixKeys[currentMatrix][2,2]);
            }
        }

        private void numCurrentMatrix_ValueChanged(object sender, EventArgs e)          //checks matrix trying to be displayed is within the number of matrixes
        {
            if (MatrixKeys.Count > numCurrentMatrix.Value)
                DisplayMatrix();
        }

        private void btnDecipher_Click(object sender, EventArgs e)
        {
            DisplayMatrix();
            PlainText = "";
            CipherText = txtOutputt.Text;
            double[,] decipherMatrix = new double[MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0), MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0)];
            double[,] decipherMatrixInverse = new double[MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0), MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0)];
            int[,] cipherText = new int[CipherText.Length / decipherMatrix.GetLength(0), MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0)];
            int[,] plainText = new int[CipherText.Length / decipherMatrix.GetLength(0), MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)].GetLength(0)];
            int pos = 0;
            double posSum = 0;
            decipherMatrix = MatrixKeys[Convert.ToInt32(numCurrentMatrix.Value)];


            if (Math.Sqrt(decipherMatrix.Length) == 2)
            {
                decipherMatrixInverse = GetInverse2(decipherMatrix);
            }
            else
            {
                decipherMatrixInverse = GetInverse3(decipherMatrix);
            }

            //assigns ciphertext to a matrix
            if (chkInvertMatrix.Checked)    //inverts matrix if necessary
            {
                for (int ii = 0; ii < CipherText.Length / decipherMatrixInverse.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < decipherMatrixInverse.GetLength(0); jj++)
                    {
                        cipherText[ii, jj] = ConvertToNumber(CipherText.Substring(pos++, 1));
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < decipherMatrixInverse.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < CipherText.Length / decipherMatrixInverse.GetLength(0); jj++)
                    {
                        cipherText[jj, ii] = ConvertToNumber(CipherText.Substring(pos++, 1));
                    }
                }
            }

            //matrix multiplication
            /*
            for (int index1 = 0; index1 < cipherText.GetLength(0); index1++)
            {
                for (int index2 = 0; index2 < cipherText.GetLength(1); index2++)
                {                                                                       //for every char in cipherText
                    for (int multiPos = 0; multiPos < decipherMatrix.GetLength(0); multiPos++)
                    {
                        posSum += decipherMatrix[index2, multiPos] * cipherText[multiPos, index2];
                    }
                    plainText[index1, index2] = posSum % 26;
                    posSum = 0;
                }
            }
            */

            for (int index1 = 0; index1 < cipherText.GetLength(0); index1++)        //for every column in cipherText
            {
                for (int index2 = 0; index2 < cipherText.GetLength(1); index2++)        //for every row in cipherText
                {
                    for (int multiPos = 0; multiPos < decipherMatrixInverse.GetLength(0); multiPos++)
                    {
                        posSum += decipherMatrixInverse[index2, multiPos] * cipherText[index1, multiPos];
                    }
                    plainText[index1, index2] = (Convert.ToInt32(posSum) + 26*100) % 26;
                    posSum = 0;
                }
            }

                if (chkInvertMatrix.Checked)    //inverts matrix if necessary
            {
                for (int ii = 0; ii < CipherText.Length / decipherMatrix.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < decipherMatrix.GetLength(0); jj++)
                    {
                        PlainText += ConvertToAlphabet(plainText[ii, jj]);
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < decipherMatrix.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < CipherText.Length / decipherMatrix.GetLength(0); jj++)
                    {
                        PlainText += ConvertToAlphabet(plainText[jj,ii]);
                    }
                }
            }
            txtOutputt.Text = PlainText;
        }

        public double[,] GetInverse3(double[,] matrixN)
        {

            double[,] matrixN1 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double[,] matrixMC = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double[,] matrixCT = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double detN = matrixN[0, 0] * GetDet(matrixN, 0) - matrixN[0, 1] * GetDet(matrixN, 1) + matrixN[0, 2] * GetDet(matrixN, 2);
            if (detN != 0)  //checks of matrix is singular
            {
                //getting MatrixMC for matrix of minors     (N->M)

                for (int y = 0; y < 3; y++)
                {

                    for (int x = 0; x < 3; x++)
                    {
                        matrixMC[y, x] = GetDet(matrixN, x, y);

                    }
                }

                //appling net to MatrixMC   (M->C)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if ((x + y) % 2 == 1)
                        {
                            matrixMC[y, x] *= -1;
                        }
                    }
                }
                //appling transformation to MatrixMC (C->CT)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        matrixCT[y, x] = matrixMC[x, y];
                    }
                }
                //inverse of matrixN (CT->N1)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        matrixN1[y, x] = matrixCT[y, x] / detN;
                    }
                }
            }
            return matrixN1;
        }

        public double[,] GetInverse2(double[,] matrixM)
        {
            double[,] MatrixM1 = { { 0, 0 }, { 0, 0 } };
            double detM = GetDet(matrixM);    //finds the determinate of MartixM


            MatrixM1[0, 0] = matrixM[1, 1] / detM;          //sets matrixM1 as inverse of matrixM      
            MatrixM1[1, 1] = matrixM[0, 0] / detM;
            MatrixM1[1, 0] = (matrixM[1, 0] * -1) / detM;
            MatrixM1[0, 1] = (matrixM[0, 1] * -1) / detM;
            return MatrixM1;
        }

        private void chkInvertMatrix_CheckedChanged(object sender, EventArgs e)
        {

        }
        /*
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HillCipher
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "HillCipher";
            this.ResumeLayout(false);

        }*/
    }
}