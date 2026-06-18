using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Individual_Task
{
    public partial class Form2 : Form
    {
        const int MaxN = 4;
        int rows;
        int columns;
        int secondRows;
        int secondColumns;
        double[,] Matr1 = new double[MaxN, MaxN];
        double[,] Matr2 = new double[MaxN, MaxN];
        double[] Vector = new double[MaxN];
        double constanta;
        int sizeVector;
        double total;
        double vectorModule;
        bool vectorFlag = false;
        bool matrixFlag1 = false;
        bool matrixFlag2 = false;
        double summa;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out rows) || !int.TryParse(textBox2.Text, out columns))
            {
                MessageBox.Show("Введите корректные числа.");
                return;
            }

            if (rows < 1 || rows > MaxN || columns < 1 || columns > MaxN)
            {
                MessageBox.Show("Размер от 1 до 4.");
                return;
            }

            Form3 form3 = new Form3(rows, columns);

            if (form3.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if (!double.TryParse(form3.MatrText[i, j].Text, out Matr1[i, j]))
                        {
                            Matr1[i, j] = 0;
                        }
                        matrixFlag1 = true;
                    }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rows == 0 || columns == 0)
            {
                MessageBox.Show("Введите матрицы.");
                return;
            }

            string result = "Транспонированная матрица:\n";

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result += Matr1[j, i] + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rows == 0 || columns == 0)
            {
                MessageBox.Show("Сначала введите матрицу.");
                return;
            }

            string result = "Матрица, умноженная на коснтанту:\n";
            if (!double.TryParse(textBox4.Text, out constanta))
            {
                MessageBox.Show("Введите корректное число для константы.");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += (Matr1[i, j] * constanta) + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out sizeVector))
            {
                MessageBox.Show("Введите корректный размер вектора.");
                return;
            }

            if (sizeVector < 1 || sizeVector > 4)
            {
                MessageBox.Show("Размер вектора от 1 до 4.");
                return;
            }

            Vector = new double[sizeVector];

            Form3 form3 = new Form3(1, sizeVector);
            if (form3.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < sizeVector; i++)
                {
                    if (!double.TryParse(form3.MatrText[0, i].Text, out Vector[i]))
                        Vector[i] = 0;
                }

                vectorFlag = true;
            }

            string result = "Вектор:\n";
            for (int i = 0; i < sizeVector; i++)
                result += Vector[i] + " ";

            MessageBox.Show(result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out sizeVector) || sizeVector < 1 || sizeVector > 4)
            {
                MessageBox.Show("Введите размерность.");
                return;
            }

            if (!vectorFlag)
            {
                MessageBox.Show("Заполните вектор.");
                return;
            }

            for (int i = 0; i < Vector.Length; i++)
            {
                total += Vector[i] * Vector[i];
            }

            vectorModule = Math.Sqrt(total);
            MessageBox.Show("Модуль вектора: " + vectorModule);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out secondRows) || !int.TryParse(textBox5.Text, out secondColumns))
            {
                MessageBox.Show("Введите корректные числа.");
                return;
            }

            if (secondColumns < 1 || secondRows > MaxN || secondColumns < 1 || secondColumns > MaxN)
            {
                MessageBox.Show("Размер от 1 до 4.");
                return;
            }

            Form3 form3 = new Form3(secondRows, secondColumns);

            if (form3.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < secondRows; i++)
                    for (int j = 0; j < secondColumns; j++)
                    {
                        if (!double.TryParse(form3.MatrText[i, j].Text, out Matr2[i, j]))
                        {
                            Matr2[i, j] = 0;
                        }
                        matrixFlag2 = true;
                    }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!matrixFlag1)
            {
                MessageBox.Show("Введите первую матрицу.");
                return;
            }

            if (!matrixFlag2)
            {
                MessageBox.Show("Введите вторую матрицу.");
                return;
            }

            if (rows != secondRows || columns != secondColumns)
            {
                MessageBox.Show("Матрицы должны быть одинакового размера.");
                return;
            }

            string result = "Сумма матриц:\n";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += (Matr1[i, j] + Matr2[i, j]) + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!matrixFlag1)
            {
                MessageBox.Show("Введите первую матрицу.");
                return;
            }

            if (!matrixFlag2)
            {
                MessageBox.Show("Введите вторую матрицу.");
                return;
            }

            if (rows != secondRows || columns != secondColumns)
            {
                MessageBox.Show("Матрицы должны быть одинакового размера.");
                return;
            }

            string result = "Вычитание матриц:\n";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += (Matr1[i, j] - Matr2[i, j]) + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (columns != secondRows)
            {
                MessageBox.Show("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
                return;
            }

            string result = "Умножение матриц:\n";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < secondColumns; j++)
                {
                    summa = 0;

                    for (int k = 0; k < columns; k++)
                    {
                        summa += Matr1[i, k] * Matr2[k, j];
                    }

                    result += summa + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (secondRows == 0 || secondColumns == 0)
            {
                MessageBox.Show("Введите матрицу.");
                return;
            }

            string result = "Транспонированная матрица:\n";

            for (int i = 0; i < secondColumns; i++)
            {
                for (int j = 0; j < secondRows; j++)
                {
                    result += Matr2[j, i] + "\t";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                rows = Convert.ToInt32(textBox1.Text);
                columns = Convert.ToInt32(textBox2.Text);

                if ((rows > 4 || columns > 4) || (rows == 0 || columns == 0))
                {
                    MessageBox.Show("Размерность матрицы должна быть не больше 4");
                    return;
                }
                if (rows != columns)
                {
                    MessageBox.Show("Матрица должна быть квадратной");
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовые значения!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число слишком большое или слишком маленькое!");
            }
            if (!matrixFlag1)
            {
                MessageBox.Show("Заполните матрицу");
                return;
            }
            string result = "Определитель матрицы = ";
            switch (rows)
            {
                case 1:
                    {
                        result += Matr1[0, 0];
                        break;
                    }
                case 2:
                    {
                        result += Matr1[0, 0] * Matr1[1, 1] - Matr1[0, 1] * Matr1[1, 0];
                        break;
                    }
                case 3:
                    {
                        result += Matr1[0, 0] * Matr1[1, 1] * Matr1[2, 2] +
                            Matr1[0, 1] * Matr1[2, 0] * Matr1[1, 2] +
                            Matr1[1, 0] * Matr1[0, 2] * Matr1[2, 1] -
                            Matr1[0, 2] * Matr1[1, 1] * Matr1[2, 0] -
                            Matr1[0, 0] * Matr1[1, 2] * Matr1[2, 1] -
                            Matr1[2, 2] * Matr1[1, 0] * Matr1[0, 1];
                        break;
                    }
                case 4:
                    {
                        double det = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            double minor = GetMinor4x4(Matr1, 0, j);
                            int znak;

                            if (j % 2 == 0)
                            {
                                znak = 1;
                            }
                            else
                            {
                                znak = -1;
                            }

                            det = det + znak * Matr1[0, j] * minor;
                        }
                        result += det;
                        break;
                    }
            }

            MessageBox.Show(result);
        }

        private static double GetMinor4x4(double[,] matrix, int rows, int columns)
        {
            double[,] minor = new double[3, 3];
            int mi = 0;
            int mj;

            for (int i = 0; i < 4; i++)
            {
                if (i == rows)
                {
                    continue;
                }

                mj = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (j == columns)
                    {
                        continue;
                    }

                    minor[mi, mj] = matrix[i, j];
                    mj++;
                }
                mi++;
            }
            return minor[0, 0] * minor[1, 1] * minor[2, 2] +
                   minor[0, 1] * minor[2, 0] * minor[1, 2] +
                   minor[1, 0] * minor[0, 2] * minor[2, 1] -
                   minor[0, 2] * minor[1, 1] * minor[2, 0] -
                   minor[0, 0] * minor[1, 2] * minor[2, 1] -
                   minor[2, 2] * minor[1, 0] * minor[0, 1];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "Исходная матрица 1\n";
            if (matrixFlag1)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result += Matr1[i, j] + " ";
                    }
                    result += "\n";
                }
            }
            result += "\nИсходная матрица 2\n";
            if (matrixFlag2)
            {
                for (int i = 0; i < secondRows; i++)
                {
                    for (int j = 0; j < secondColumns; j++)
                    {
                        result += Matr2[i, j] + " ";
                    }
                    result += "\n";
                }
            }
            result += "\nВектор = ";
            if (vectorFlag)
            {
                for (int i = 0;i< sizeVector; i++) 
                {
                    result += Vector[i]+" ";
                }
            }
            result +="\nКонстанта = " + constanta;
            MessageBox.Show(result);
        }
    }
}

