using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Individual_Task
{
    public partial class Form12 : Form
    {
        double[,] osi = new double[6, 3];
        double[,] prisma = new double[5, 4];
        double[,] tetr = new double[4, 4];
        int k, l;
        double[,] matr_sdv = new double[4, 4];
        int[,] matr_sdv_prism = new int[3, 3];
        double[,] trio = new double[3, 3];
        double[] n = new double[3];



        private void Inint_tetr()
        {
            tetr[0, 0] = -100; tetr[0, 1] = -100; tetr[0, 2] = 0; tetr[0, 3] = 1;
            tetr[1, 0] = 100; tetr[1, 1] = -100; tetr[1, 2] = 0; tetr[1, 3] = 1;
            tetr[2, 0] = 0; tetr[2, 1] = -100; tetr[2, 2] = 100; tetr[2, 3] = 1;
            tetr[3, 0] = 0; tetr[3, 1] = 100; tetr[3, 2] = 50; tetr[3, 3] = 1;
        }

        private void Init_trio()
        {
            trio[0, 0] = -100; trio[0, 1] = -100; trio[0, 2] = 1;
            trio[1, 0] = 100; trio[1, 1] = -100; trio[1, 2] = 1;
            trio[2, 0] = 0; trio[2, 1] = 100; trio[2, 2] = 1;
        }

        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 0; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 0; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
            osi[4, 0] = 200; osi[4, 1] = 200; osi[4, 2] = 1;
            osi[5, 0] = 0; osi[5, 1] = 0; osi[5, 2] = 1;

        }

        private void Init_prism()
        {
            prisma[0, 0] = -100; prisma[0, 1] = -100; prisma[0, 2] = 0; prisma[0, 3] = 1;
            prisma[1, 0] = 100; prisma[1, 1] = -100; prisma[1, 2] = 0; prisma[1, 3] = 1;
            prisma[2, 0] = 0; prisma[2, 1] = 100; prisma[2, 2] = 0; prisma[2, 3] = 1;
            prisma[3, 0] = 0; prisma[3, 1] = 0; prisma[3, 2] = 100; prisma[3, 3] = 1;
            prisma[4, 0] = 0; prisma[4, 1] = 0; prisma[4, 2] = -100; prisma[4, 3] = 1;
        }

        private double[,] Multiply_matr_osi(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        private double[,] Multiply_matr(double[,] a, double[,] b)
        {
            double[,] result = new double[5, 4];


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        private double[,] Multiply_matr_tetr(double[,] a, double[,] b)
        {
            double[,] result = new double[4, 4];


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        private void Init_matr_preob_3D(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0; matr_sdv[0, 3] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0; matr_sdv[1, 3] = 0;
            matr_sdv[2, 0] = 0; matr_sdv[2, 1] = 0; matr_sdv[2, 2] = 1; matr_sdv[2, 3] = 0;
            matr_sdv[3, 0] = k1; matr_sdv[3, 1] = l1; matr_sdv[3, 2] = 0; matr_sdv[3, 3] = 1;
        }

        private void Init_matr_preob_OX()
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0; matr_sdv[0, 3] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = Math.Cos((5 * Math.PI) / 180); matr_sdv[1, 2] = Math.Sin((5 * Math.PI) / 180); matr_sdv[1, 3] = 0;
            matr_sdv[2, 0] = 0; matr_sdv[2, 1] = -Math.Sin((5 * Math.PI) / 180); matr_sdv[2, 2] = Math.Cos((5 * Math.PI) / 180); matr_sdv[2, 3] = 0;
            matr_sdv[3, 0] = 0; matr_sdv[3, 1] = 0; matr_sdv[3, 2] = 0; matr_sdv[3, 3] = 1;
        }

        private void Init_matr_preob_OY()
        {
            matr_sdv[0, 0] = Math.Cos((5 * Math.PI) / 180); matr_sdv[0, 1] = 0; matr_sdv[0, 2] = -Math.Sin((5 * Math.PI) / 180); matr_sdv[0, 3] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0; matr_sdv[1, 3] = 0;
            matr_sdv[2, 0] = Math.Sin((5 * Math.PI) / 180); matr_sdv[2, 1] = 0; matr_sdv[2, 2] = Math.Cos((5 * Math.PI) / 180); matr_sdv[2, 3] = 0;
            matr_sdv[3, 0] = 0; matr_sdv[3, 1] = 0; matr_sdv[3, 2] = 0; matr_sdv[3, 3] = 1;
        }

        private void Init_matr_preob_OZ()
        {
            matr_sdv[0, 0] = Math.Cos((5 * Math.PI) / 180); matr_sdv[0, 1] = Math.Sin((5 * Math.PI) / 180); matr_sdv[0, 2] = 0; matr_sdv[0, 3] = 0;
            matr_sdv[1, 0] = -Math.Sin((5 * Math.PI) / 180); matr_sdv[1, 1] = 1; matr_sdv[1, 2] = Math.Cos((5 * Math.PI) / 180); matr_sdv[1, 3] = 0;
            matr_sdv[2, 0] = 0; matr_sdv[2, 1] = 0; matr_sdv[2, 2] = 1; matr_sdv[2, 3] = 0;
            matr_sdv[3, 0] = 0; matr_sdv[3, 1] = 0; matr_sdv[3, 2] = 0; matr_sdv[3, 3] = 1;
        }

        private void Init_matr_preob_n()
        {
            n[0] = Math.Cos((45 * Math.PI) / 180);
            n[1] = Math.Cos((45 * Math.PI) / 180);
            n[2] = Math.Cos((45 * Math.PI) / 180);
            double sinf = Math.Sin((5 * Math.PI) / 180);
            double cosf = Math.Cos((5 * Math.PI) / 180);


            matr_sdv[0, 0] = Math.Pow(n[0], 2) + (1 - Math.Pow(n[0], 2)) * cosf; matr_sdv[0, 1] = n[0] * n[1] * (1 - cosf) + n[2] * sinf; matr_sdv[0, 2] = n[0] * n[2] * (1 - cosf) - n[1] * sinf; matr_sdv[0, 3] = 0;
            matr_sdv[1, 0] = n[0] * n[1] * (1 - cosf) - n[2] * sinf; matr_sdv[1, 1] = Math.Pow(n[1], 2) + (1 - Math.Pow(n[1], 2)) * cosf; matr_sdv[1, 2] = n[1] * n[2] * (1 - cosf) + n[0] * sinf; matr_sdv[1, 3] = 0;
            matr_sdv[2, 0] = n[0] * n[2] * (1 - cosf) + n[1] * sinf; matr_sdv[2, 1] = n[1] * n[2] * (1 - cosf) - n[0] * sinf; matr_sdv[2, 2] = Math.Pow(n[2], 2) + (1 - Math.Pow(n[2], 2)) * cosf; matr_sdv[2, 3] = 0;
            matr_sdv[3, 0] = 0; matr_sdv[3, 1] = 0; matr_sdv[3, 2] = 0; matr_sdv[3, 3] = 1;
        }


        private void Prism_New(double[,] prisma1)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    prisma[i, j] = prisma1[i, j];
                }
            }
        }

        private void Tetr_New(double[,] tetr1)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tetr[i, j] = tetr1[i, j];
                }
            }
        }


        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(k, l);
            double[,] osi1 = Multiply_matr_osi(osi, matr_sdv);
            Pen myPen = new Pen(Color.Red, 1);// цвет линии и ширина
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            // рисуем ось ОХ
            g.DrawLine(myPen, (int)osi1[0, 0], (int)osi1[0, 1], (int)osi1[1, 0], (int)osi1[1, 1]);
            // рисуем ось ОУ
            g.DrawLine(myPen, (int)osi1[2, 0], (int)osi1[2, 1], (int)osi1[3, 0], (int)osi1[3, 1]);
            // рисуем ось OZ
            g.DrawLine(myPen, (int)osi1[4, 0], (int)osi1[4, 1], (int)osi1[5, 0], (int)osi1[5, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        public void Draw_prism(double[,] prisma)
        {
            double[,] prisma1 = Multiply_matr(prisma, matr_sdv);
            Pen myPen = new Pen(Color.Blue, 2);// цвет линии и ширина
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();
            g.DrawLine(myPen, (int)prisma1[0, 0], (int)prisma1[0, 1], (int)prisma1[1, 0], (int)prisma1[1, 1]);
            g.DrawLine(myPen, (int)prisma1[0, 0], (int)prisma1[0, 1], (int)prisma1[2, 0], (int)prisma1[2, 1]);
            g.DrawLine(myPen, (int)prisma1[1, 0], (int)prisma1[1, 1], (int)prisma1[2, 0], (int)prisma1[2, 1]);
            g.DrawLine(myPen, (int)prisma1[3, 0], (int)prisma1[3, 1], (int)prisma1[4, 0], (int)prisma1[4, 1]);
            g.DrawLine(myPen, (int)prisma1[3, 0], (int)prisma1[3, 1], (int)prisma1[0, 0], (int)prisma1[0, 1]);
            g.DrawLine(myPen, (int)prisma1[3, 0], (int)prisma1[3, 1], (int)prisma1[1, 0], (int)prisma1[1, 1]);
            g.DrawLine(myPen, (int)(int)prisma1[4, 0], (int)prisma1[4, 1], (int)prisma1[1, 0], (int)prisma1[1, 1]);
            g.DrawLine(myPen, (int)prisma1[4, 0], (int)prisma1[4, 1], (int)prisma1[0, 0], (int)prisma1[0, 1]);
            g.DrawLine(myPen, (int)prisma1[2, 0], (int)prisma1[2, 1], (int)prisma1[3, 0], (int)prisma1[3, 1]);
            g.DrawLine(myPen, (int)prisma1[2, 0], (int)prisma1[2, 1], (int)prisma1[4, 0], (int)prisma1[4, 1]);
        }

        public void Draw_tetr(double[,] tetr)
        {
            double[,] tetr1 = Multiply_matr_tetr(tetr, matr_sdv);
            Pen myPen = new Pen(Color.Blue, 2);// цвет линии и ширина
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();
            g.DrawLine(myPen, (int)tetr1[0, 0], (int)tetr1[0, 1], (int)tetr1[1, 0], (int)tetr1[1, 1]);
            g.DrawLine(myPen, (int)tetr1[0, 0], (int)tetr1[0, 1], (int)tetr1[2, 0], (int)tetr1[2, 1]);
            g.DrawLine(myPen, (int)tetr1[1, 0], (int)tetr1[1, 1], (int)tetr1[2, 0], (int)tetr1[2, 1]);
            g.DrawLine(myPen, (int)tetr1[0, 0], (int)tetr1[0, 1], (int)tetr1[3, 0], (int)tetr1[3, 1]);
            g.DrawLine(myPen, (int)tetr1[1, 0], (int)tetr1[1, 1], (int)tetr1[3, 0], (int)tetr1[3, 1]);
            g.DrawLine(myPen, (int)tetr1[2, 0], (int)tetr1[2, 1], (int)tetr1[3, 0], (int)tetr1[3, 1]);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_prism();
            Init_matr_preob_3D(k, l);
            Draw_prism(prisma);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //k = pictureBox1.Width / 2;
            //l = pictureBox1.Height / 2;
            //Init_trio();
            //Init_matr_preob(k, l);
            //float[,] prisma1 = Multiply_matr_osi(trio, matr_sdv);
            //Pen myPen = new Pen(Color.Blue, 2);// цвет линии и ширина
            //Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //g.DrawLine(myPen, prisma1[0, 0], prisma1[0, 1], prisma1[1, 0], prisma1[1, 1]);
            //g.DrawLine(myPen, prisma1[0, 0], prisma1[0, 1], prisma1[2, 0], prisma1[2, 1]);
            //g.DrawLine(myPen, prisma1[1, 0], prisma1[1, 1], prisma1[2, 0], prisma1[2, 1]);
            //g.Dispose();
            //myPen.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_matr_preob_OX();
            double[,] prisma1 = Multiply_matr_osi(prisma, matr_sdv);
            Init_matr_preob_3D(k, l);
            Draw_prism(prisma1);
            Prism_New(prisma1);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Inint_tetr();
            Init_matr_preob_3D(k, l);
            //Draw_tetr(tetr);
            Draw_tetr_with_normals(tetr);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_matr_preob_OX();
            double[,] tetr1 = Multiply_matr_osi(tetr, matr_sdv);
            Init_matr_preob_3D(k, l);
            //Draw_tetr(tetr1);
            Draw_tetr_with_normals(tetr1);
            Tetr_New(tetr1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_matr_preob_OY();
            double[,] tetr1 = Multiply_matr_osi(tetr, matr_sdv);
            Init_matr_preob_3D(k, l);
            //Draw_tetr(tetr1);
            Draw_tetr_with_normals(tetr1);
            Tetr_New(tetr1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_matr_preob_OZ();
            double[,] tetr1 = Multiply_matr_osi(tetr, matr_sdv);
            Init_matr_preob_3D(k, l);
            //Draw_tetr(tetr1);
            Draw_tetr_with_normals(tetr);
            Tetr_New(tetr1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_matr_preob_n();
            double[,] tetr1 = Multiply_matr_osi(tetr, matr_sdv);
            Init_matr_preob_3D(k, l);
            //Draw_tetr(tetr1);
            Draw_tetr_with_normals(tetr);
            Tetr_New(tetr1);
        }


        private void Draw_tetr_with_normals(double[,] tetr)
        {
            double[,] tetr1 = Multiply_matr_tetr(tetr, matr_sdv);
            Pen myPen = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            int[,] faces = new int[4, 3]
            {
        {0, 1, 2},
        {0, 1, 3},
        {0, 2, 3},
        {1, 2, 3}
            };

            double[] barycenter = new double[3];
            for (int j = 0; j < 3; j++)
            {
                barycenter[j] = (tetr1[0, j] + tetr1[1, j] + tetr1[2, j] + tetr1[3, j]) / 4.0;
            }

            double[] viewDirection = new double[] { 0, 0, 1 };

            for (int faceIndex = 0; faceIndex < 4; faceIndex++)
            {
                int v0 = faces[faceIndex, 0];
                int v1 = faces[faceIndex, 1];
                int v2 = faces[faceIndex, 2];

                double[] faceCenter = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    faceCenter[j] = (tetr1[v0, j] + tetr1[v1, j] + tetr1[v2, j]) / 3.0;
                }
                double[] vectorToFace = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    vectorToFace[j] = faceCenter[j] - barycenter[j];
                }

                // Вычисляем нормаль грани (векторное произведение двух ребер грани)
                double[] edge1 = new double[3];
                double[] edge2 = new double[3];
                double[] normal = new double[3];

                for (int j = 0; j < 3; j++)
                {
                    edge1[j] = tetr1[v1, j] - tetr1[v0, j];
                    edge2[j] = tetr1[v2, j] - tetr1[v0, j];
                }

                normal[0] = edge1[1] * edge2[2] - edge1[2] * edge2[1];
                normal[1] = edge1[2] * edge2[0] - edge1[0] * edge2[2];
                normal[2] = edge1[0] * edge2[1] - edge1[1] * edge2[0];

                // Нормализуем нормаль
                double length = Math.Sqrt(normal[0] * normal[0] + normal[1] * normal[1] + normal[2] * normal[2]);
                if (length > 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normal[j] /= length;
                    }
                }

                // Проверяем, направлен ли вектор от барицентра к грани в ту же сторону, что и нормаль
                double dotProduct = vectorToFace[0] * normal[0] + vectorToFace[1] * normal[1] + vectorToFace[2] * normal[2];

                // Если скалярное произведение отрицательное, инвертируем нормаль
                if (dotProduct < 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normal[j] = -normal[j];
                    }
                }

                // Вычисляем угол между нормалью и направлением взгляда
                double dotWithView = normal[0] * viewDirection[0] + normal[1] * viewDirection[1] + normal[2] * viewDirection[2];

                if (dotWithView < 0)
                    continue;

                g.DrawLine(myPen,
                    (int)tetr1[v0, 0], (int)tetr1[v0, 1],
                    (int)tetr1[v1, 0], (int)tetr1[v1, 1]);
                g.DrawLine(myPen,
                    (int)tetr1[v0, 0], (int)tetr1[v0, 1],
                    (int)tetr1[v2, 0], (int)tetr1[v2, 1]);
                g.DrawLine(myPen,
                    (int)tetr1[v1, 0], (int)tetr1[v1, 1],
                    (int)tetr1[v2, 0], (int)tetr1[v2, 1]);
            }

            g.Dispose();
            myPen.Dispose();
        }




        public Form12()
        {
            InitializeComponent();
        }
    }
}

