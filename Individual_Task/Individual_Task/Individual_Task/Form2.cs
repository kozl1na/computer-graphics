using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (rows != columns)
            {
                MessageBox.Show("sdfsdfsdfsddsf");
            }
        }
    }

}
