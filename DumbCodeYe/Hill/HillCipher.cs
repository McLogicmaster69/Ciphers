using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DumbCodeYe.Hill
{
    public partial class HillCipher : Form
    {
        public string CipherText = "";
        public string PlainText = "";
        public int KeySize = 0;
        public string KnownText = "";
        public string KnownTextC = "";
        public List<double[,]> MatrixKeys = new List<double[,]>();  //[row, column]
        public int MatrixKeysIndex = 0;
        public List<int[]> valuesAB = new List<int[]>();
        public List<int[]> valuesCD = new List<int[]>();
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
                for (int i = 0; i < 2; i++)
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
            if (number == 0)    //checks for the letter z
                number += 26;
            return Convert.ToString(Convert.ToChar(number + 64));
        }
        public int ConvertToNumber(string character)
        {

            return (Convert.ToInt32(Convert.ToChar(character)) - 64) % 26;
        }

        private void button1_Click(object sender, EventArgs e)  //decipher button
        {
            CipherText = txtOutputt.Text;
            KeySize = Convert.ToInt32(numMatrixSize.Value);
            KnownText = txtKnownText.Text;
            KnownTextC = txtKnownC.Text;
            if (!(CipherText == "" && KnownText == "")) //checks if fields are empty
            {
                if (KeySize == 2)   //checks if key size is valid
                {
                    TwoMatrix();
                }
                else
                {
                    MessageBox.Show("not done 3");
                }

            }
            else
            {
                MessageBox.Show("Enter text in all fields");
            }
        }

        public List<int[]> TwoSimultaneousEquationSlover(int x1, int y1, int n1, int x2, int y2, int n2/*, out double xOut, out double yOut*/)
        {
            List<int> matrixX = new List<int>();    //stores x values
            List<List<int>> matrixXY = new List<List<int>>();   //stores x and y values
            int[,] matrixM = { { x1, x2 }, { y1, y2 }, { n1, n2 } };
            int[,] matrixMOriginal = { { x1, x2 }, { y1, y2 }, { n1, n2 } };
            int[] matrixSingle = { 0, 0, 0 };   //0 represents x/y coefficient, 1 represents n, 2 represents the modulo size
            int hcf;    //stroes highest ommon factor
            int[] x1x = { 0, 0 };    //0 represents num after mod,   1 represents modulo
            int arrIndex = 0;

            List<int[]> matrixXYValid = new List<int[]>();   //stores valid x and y values that work for both congruences

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
            //if (matrixM[0, 0] > matrixM[0, 1])
            //{
                matrixSingle[0] = (matrixM[0, 0] - matrixM[0, 1] + 260) % 26;
                matrixSingle[1] = (matrixM[2, 0] - matrixM[2, 1] + 260) % 26;
                matrixSingle[2] = 26;
            /*}
            else
            {
                matrixSingle[0] = matrixM[0, 1] - matrixM[0, 0];
                matrixSingle[1] = matrixM[2, 1] - matrixM[2, 0];
                matrixSingle[1] = matrixSingle[1] % 26;
                matrixSingle[2] = 26;
            }*/

            //remove the common factor between matrixSingle variables
            hcf = HCF3(matrixSingle[0], matrixSingle[1], matrixSingle[2]);
            for (int index = 0; index < matrixSingle.Length; index++)
            {
                matrixSingle[index] /= hcf;
            }
            //removes coefficient of x1 (sets matrixSingle[0] to 1)]
            matrixSingle[1] = (FindMultiplicativeInverse(matrixSingle[0], matrixSingle[2]) * matrixSingle[1]) % matrixSingle[2];
            matrixSingle[0] = 1;

            //get x values
            for (int letter = 0; letter < 26; letter++)     //cycles through every letter
            {
                if (letter % matrixSingle[2] == matrixSingle[1])    //adds it if it is valid
                {
                    matrixX.Add(letter);
                    arrIndex++;
                }
            }

            //get y values
            for (int Xindex = 0; Xindex < matrixX.Count; Xindex++) //for every x value
            {
                List<int> matrixY = new List<int>();                    //stores y values
                matrixSingle[0] = matrixMOriginal[1, 1];    //sets y value
                matrixSingle[1] = ((matrixMOriginal[2, 1] - matrixMOriginal[0, 1] * matrixX[Xindex] ) + 2600) % 26;  //sets n value to n2 - solved x value * its coefficient
                matrixSingle[2] = 26;       //sets modulo to 26

                //checks and divides by the highest common factor
                hcf = HCF3(matrixSingle[0], matrixSingle[1], matrixSingle[2]);
                for (int index = 0; index < matrixSingle.Length; index++)
                {
                    matrixSingle[index] /= hcf;
                }

                //removes coefficient of y (sets matrixSingle[0] to 1)]
                matrixSingle[1] = (FindMultiplicativeInverse(matrixSingle[0], matrixSingle[2]) * matrixSingle[1]) % matrixSingle[2];
                matrixSingle[0] = 1;

                arrIndex = 0;
                matrixY.Add(matrixX[Xindex]);
                //get y values
                for (int letter = 0; letter < 26; letter++) //cycles through every letter
                {
                    if (letter % matrixSingle[2] == matrixSingle[1])    //adds it if it is valid
                    {
                        matrixY.Add(letter);
                        arrIndex++;
                    }
                }

                //stores them
                matrixXY.Add(matrixY);
                //matrixY.Clear();
            }

            //checks which x and y values are valid pairs and adds them to a list
            for (int currentXvalue = 0; currentXvalue < matrixXY.Count; currentXvalue++)
            {
                for (int currentYvalue = 1; currentYvalue < matrixXY[currentXvalue].Count; currentYvalue++)
                { 
                    if (((matrixXY[currentXvalue][0] * matrixMOriginal[0, 0] + matrixXY[currentXvalue][currentYvalue] * matrixMOriginal[1, 0] + 2600) % 26 == matrixMOriginal[2, 0]) && ((matrixXY[currentXvalue][0] * matrixMOriginal[0, 1] + matrixXY[currentXvalue][currentYvalue] * matrixMOriginal[1, 1] + 2600) % 26 == matrixMOriginal[2, 1]))   //if x and y valeus work for both congruences
                    {                                                       //adds the valid X and Y pair to a list
                        int[] validXYPairs = new int[2];                  //stores valid x and y values that work for both congruences before they are added to the list
                        validXYPairs[0] = matrixXY[currentXvalue][0];
                        validXYPairs[1] = matrixXY[currentXvalue][currentYvalue];
                        matrixXYValid.Add(validXYPairs);
                    }
                }
            }

            //returns the valid pairs
            return matrixXYValid;
        }

        public int FindMultiplicativeInverse(int coefficient, int modulo)   //finds the number the coefficent must be multiplied with so that it equals 1 after modulo, e.g. the MI of 7 mod 26 would be 15 - 7*15 = 105, 105 mod 26 = 1
        {
            int multiplicativeInverse = 1;  //coefficient start value
            while ((coefficient * multiplicativeInverse) % modulo != 1)
            {
                multiplicativeInverse++;
            }
            return multiplicativeInverse;
        }

        public int HCF3(int num1, int num2, int num3)   //finds HCF of 3 numbers    - look man, i know this could be done much easier using modulo but im too far deep in this rabbit hole and its 9pm
        {
            int hcf = 1;
            int[] num1PF = getPrimeFactors(num1);   //stores prime factors
            int[] num2PF = getPrimeFactors(num2);   //stores prime factors
            int[] num3PF = getPrimeFactors(num3);   //stores prime factors
            int num1Index = 0;
            int num2Index = 0;
            int num3Index = 0;
            do
            {
                if (num1PF[num1Index] == num2PF[num2Index] && num2PF[num2Index] == num3PF[num3Index])   //if the current prime factor is the same between the numbers
                {
                    hcf *= num1PF[num1Index];
                    num1Index++;
                    num2Index++;
                    num3Index++;
                }
                else
                {
                    num1Index = NextPrimeIndex(num1PF, num1PF[num1Index]);  //move the prime factor to the next index
                    num2Index = NextPrimeIndex(num2PF, num2PF[num2Index]);  //move the prime factor to the next index
                    num2Index = NextPrimeIndex(num3PF, num3PF[num3Index]);  //move the prime factor to the next index
                }

            } while (num1PF.Length < num1Index && num2PF.Length < num2Index && num3PF.Length < num3Index);
            return hcf;
        }

        public int NextPrimeIndex(int[] arr, int currentPrime)  //for HCF3, sets index to the one of the next unique prime factor
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

        public int[] getPrimeFactors(int num)   //gets the prime factors
        {
            List<int> primeFactors = new List<int>();
            int largestPrime = 2;
            while (largestPrime <= num)
            {
                if (num % largestPrime == 0)
                {
                    num /= largestPrime;
                    primeFactors.Add(largestPrime);
                }
                else
                {
                    do
                    {
                        largestPrime++;
                    } while (!CheckPrime(largestPrime));

                }
            }
            //places output into array format
            int[] output = new int[primeFactors.Count()];

            for (int i = 0; i < primeFactors.Count(); i++)
                output[i] = primeFactors[i];
            return output;


        }

        public bool CheckPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0) return false;
            return true;
        }

        public void TwoMatrix()
        {
            int[,] SysCongruence1 = { { 0, 0 }, { 0, 0 } };
            int[,] SysCongruence2 = { { 0, 0 }, { 0, 0 } };
            int keyDeterminant;

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
            //gets the values for each of the possible matrixes
            valuesAB = TwoSimultaneousEquationSlover(SysCongruence1[0, 0], SysCongruence1[0, 1], SysCongruence1[1, 0], SysCongruence2[0, 0], SysCongruence2[0, 1], SysCongruence2[1, 0]);
            valuesCD = TwoSimultaneousEquationSlover(SysCongruence1[0, 0], SysCongruence1[0, 1], SysCongruence1[1, 1], SysCongruence2[0, 0], SysCongruence2[0, 1], SysCongruence2[1, 1]);
            
            //puts possible matrixes in keys
            foreach (int[] AB in valuesAB)
            {
                foreach (int[] CD in valuesCD)
                {
                    keyDeterminant = (AB[0] * CD[1] - AB[1] * CD[0] + 26000) % 26;
                    if (keyDeterminant % 2 == 1 && keyDeterminant != 13)
                    {
                        double[,] keyMatrix = new double[2, 2];
                        keyMatrix[0, 0] = AB[0];
                        keyMatrix[0, 1] = AB[1];
                        keyMatrix[1, 0] = CD[0];
                        keyMatrix[1, 1] = CD[1];
                        MatrixKeys.Add(keyMatrix);
                    }
                }
            }
        }

        private void btnInsertMatrix_Click(object sender, EventArgs e)
        {
            double[,] insertMatrix = new double[3, 3];
            if (txtBR.Text == "")                                   //converts intputted matrix values to a matrix - checks a corner to decide if matrix is a 2x2 or 3x3
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
            if (insertMatrix[0, 2] == 0 && insertMatrix[1, 2] == 0 && insertMatrix[2, 0] == 0 && insertMatrix[2, 1] == 0 && insertMatrix[2, 2] == 0)
                matrixSize = 2;

            double[,] insertMatrix2 = new double[matrixSize, matrixSize];

            for (int ii = 0; ii < Math.Sqrt(insertMatrix2.Length); ii++)                 //inserts new matrix to one of the correct size
            {
                for (int jj = 0; jj < Math.Sqrt(insertMatrix2.Length); jj++)
                {
                    insertMatrix2[ii, jj] = insertMatrix[ii, jj];
                }
            }
            MatrixKeys.Add(insertMatrix2);                                              //adds matrix to the list of matrix keys
        }

        public void DisplayMatrix()                                                     //displays matrix in the grid
        {
            int currentMatrix = Convert.ToInt32(numCurrentMatrix.Value);

            txtTL.Text = Convert.ToString(MatrixKeys[currentMatrix][0, 0]);
            txtTM.Text = Convert.ToString(MatrixKeys[currentMatrix][0, 1]);
            txtML.Text = Convert.ToString(MatrixKeys[currentMatrix][1, 0]);
            txtMM.Text = Convert.ToString(MatrixKeys[currentMatrix][1, 1]);
            if (MatrixKeys[currentMatrix].GetLength(1) == 3)
            {
                txtTR.Text = Convert.ToString(MatrixKeys[currentMatrix][0, 2]);
                txtMR.Text = Convert.ToString(MatrixKeys[currentMatrix][1, 2]);
                txtBL.Text = Convert.ToString(MatrixKeys[currentMatrix][2, 0]);
                txtBM.Text = Convert.ToString(MatrixKeys[currentMatrix][2, 1]);
                txtBR.Text = Convert.ToString(MatrixKeys[currentMatrix][2, 2]);
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

            int indexAtZero = chkIndexAt0.Checked == true ? 1 : 0;

            if (Math.Sqrt(decipherMatrix.Length) == 2)
            {
                decipherMatrixInverse = GetInverse2(decipherMatrix);
            }
            else
            {
                decipherMatrixInverse = GetInverse3(decipherMatrix);
            }

            //assigns ciphertext to a matrix
            //if (chkInvertMatrix.Checked)    //inverts matrix if necessary
            //{
                for (int ii = 0; ii < CipherText.Length / decipherMatrixInverse.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < decipherMatrixInverse.GetLength(0); jj++)
                    {
                        cipherText[ii, jj] = ConvertToNumber(CipherText.Substring(pos++, 1)) - indexAtZero;
                    }
                }
            /*}
            else
            {
                for (int ii = 0; ii < decipherMatrixInverse.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < CipherText.Length / decipherMatrixInverse.GetLength(0); jj++)
                    {
                        cipherText[jj, ii] = ConvertToNumber(CipherText.Substring(pos++, 1));
                    }
                }
            }*/

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
                    plainText[index1, index2] = (Convert.ToInt32(posSum) + 26 * 100) % 26;
                    posSum = 0;
                }
            }

            /*if (chkInvertMatrix.Checked)    //inverts matrix if necessary
            {*/
                for (int ii = 0; ii < CipherText.Length / decipherMatrix.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < decipherMatrix.GetLength(0); jj++)
                    {
                        PlainText += ConvertToAlphabet(plainText[ii, jj] + indexAtZero);
                    }
                }
            /*}
            else
            {
                for (int ii = 0; ii < decipherMatrix.GetLength(0); ii++)
                {
                    for (int jj = 0; jj < CipherText.Length / decipherMatrix.GetLength(0); jj++)
                    {
                        PlainText += ConvertToAlphabet(plainText[jj, ii]);
                    }
                }
            }*/
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
            double[,] matrixM1 = { { 0, 0 }, { 0, 0 } };
            double[,] MatrixM2 = { { 0, 0 }, { 0, 0 } };
            double detM = GetDet(matrixM);    //finds the determinate of MartixM
            double[,] identity = { { 1, 0 }, { 0, 1 } };
            if (detM == 0)
            {
                MessageBox.Show("Invalid key - singular matrix");
                return identity;
            }
            /*
            double temp;

            temp = matrixM[0, 0];
            matrixM[0, 0] = matrixM[1, 1];
            matrixM[1, 1] = temp;

            MatrixM1[0, 0] = (matrixM[0, 0] / detM;          //sets matrixM1 as inverse of matrixM      
            MatrixM1[1, 1] = (matrixM[1, 1] / detM;
            MatrixM1[1, 0] = ((matrixM[1, 0] * -1) / detM;        // * 1 is there for the -1 part of the matrix multipleication
            MatrixM1[0, 1] = ((matrixM[0, 1] * -1) / detM;

            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    if (column != row)
                        matrixM[row, column] *= -1;
                    if (MatrixM1[row,column] != (int)MatrixM1[row, column])
                    {
                        MatrixM1[row, column] = Convert.ToInt32((matrixM[row,column] * FindMultiplicativeInverse(Convert.ToInt32(detM), 26)) + 2600) % 26;
                    }
                }

            }
            */
            matrixM1[0, 0] = matrixM[1, 1];          //sets matrixM1 as inverse of matrixM      
            matrixM1[1, 1] = matrixM[0, 0];
            matrixM1[1, 0] = matrixM[1, 0] * -1;
            matrixM1[0, 1] = matrixM[0, 1] * -1;

            MatrixM2[0, 0] = matrixM1[0, 0] / detM;        //sets M2 values  
            MatrixM2[1, 1] = matrixM1[1, 1] / detM;
            MatrixM2[1, 0] = matrixM1[1, 0] / detM;
            MatrixM2[0, 1] = matrixM1[0, 1] / detM;


            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    if (MatrixM2[row, column] != (int)MatrixM2[row, column])
                        MatrixM2[row, column] = Convert.ToInt32((matrixM1[row, column] * FindMultiplicativeInverse(Convert.ToInt32(detM), 26)) + 2600) % 26;
                }
            }
                return MatrixM2;
        }
    }
}
/*
THEPLAINTEXTWORDSAREWRITTENINSMALLLETTERSY
XPUVLACBRAHNUKJNGCLSAZOFRAHWBUOEHDTUVXYFCS

UKJN
WORD 
*/