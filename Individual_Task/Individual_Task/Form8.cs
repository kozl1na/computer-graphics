using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Individual_Task
{
    public partial class Form8 : Form
    {
        int[,] kv = new int[8, 3];
        double[,] matr_sdv = new double[3, 3];
        int k, l;
        bool f;
        double currentScale = 1.0;
        double currentAngle = 0;
        int colorIndex = 0;
        List<Color> colors = new List<Color>();

        public Form8()
        {
            InitializeComponent();
            Init_Octagon();
            InitColors();
        }

        private void Init_Octagon()
        {
            kv[0, 0] = 0; kv[0, 1] = -100; kv[0, 2] = 1;

            kv[1, 0] = 70; kv[1, 1] = -70; kv[1, 2] = 1;

            kv[2, 0] = 100; kv[2, 1] = 0; kv[2, 2] = 1;

            kv[3, 0] = 70; kv[3, 1] = 70; kv[3, 2] = 1;

            kv[4, 0] = 0; kv[4, 1] = 100; kv[4, 2] = 1;

            kv[5, 0] = -70; kv[5, 1] = 70; kv[5, 2] = 1;

            kv[6, 0] = -100; kv[6, 1] = 0; kv[6, 2] = 1;

            kv[7, 0] = -70; kv[7, 1] = -70; kv[7, 2] = 1;
        }

        private void InitColors()
        {
            colors.Add(Color.Red);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Orange);
            colors.Add(Color.Purple);
            colors.Add(Color.Cyan);
            colors.Add(Color.Magenta);
            colors.Add(Color.Yellow);
            colors.Add(Color.Brown);
            colors.Add(Color.Pink);
            colors.Add(Color.Lime);
            colors.Add(Color.Teal);
            colors.Add(Color.Navy);
            colors.Add(Color.Maroon);
            colors.Add(Color.Olive);
            colors.Add(Color.Gold);
            colors.Add(Color.Coral);
            colors.Add(Color.Salmon);
            colors.Add(Color.Indigo);
        }

        private void Init_matr_preob(double scale, double angleRad, int posX, int posY)
        {
            matr_sdv[0, 0] = Math.Cos(angleRad) * scale;
            matr_sdv[0, 1] = Math.Sin(angleRad) * scale;
            matr_sdv[0, 2] = 0;

            matr_sdv[1, 0] = -Math.Sin(angleRad) * scale;
            matr_sdv[1, 1] = Math.Cos(angleRad) * scale;
            matr_sdv[1, 2] = 0;

            matr_sdv[2, 0] = posX;
            matr_sdv[2, 1] = posY;
            matr_sdv[2, 2] = 1;
        }

        private double[,] Multiply_matr(int[,] a, double[,] b)
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

        private void Draw_Octagon(double scale, double angleDegrees, int posX, int posY, Color color)
        {
            double angleRad = angleDegrees * Math.PI / 180.0;
            Init_matr_preob(scale, angleRad, posX, posY);
            double[,] kv1 = Multiply_matr(kv, matr_sdv);

            Pen myPen = new Pen(color, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(myPen, (float)kv1[i, 0], (float)kv1[i, 1],
                                  (float)kv1[i + 1, 0], (float)kv1[i + 1, 1]);
            }
            g.DrawLine(myPen, (float)kv1[7, 0], (float)kv1[7, 1],
                              (float)kv1[0, 0], (float)kv1[0, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            currentScale = 1.0;
            currentAngle = 0;
            colorIndex = 0;
            f = false;
            timer1.Stop();
            button2.Text = "Старт";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 80;

            if (f == false)
            {
                button2.Text = "Стоп";
                timer1.Start();
                f = true;
            }
            else
            {
                timer1.Stop();
                button2.Text = "Старт";
                f = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentScale < 0.05)
            {
                timer1.Stop();
                button2.Text = "Старт";
                f = false;
                currentScale = 1.0;
                currentAngle = 0;
                colorIndex = 0;
                return;
            }

            double angleStep = 0;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                double.TryParse(textBox1.Text, out angleStep);
            }

            int posX = pictureBox1.Width / 2 - 210;
            int posY = pictureBox1.Height / 2 - 150 + (int)((1.0 - currentScale) * 200);

            Color currentColor = colors[colorIndex % colors.Count];

            Draw_Octagon(currentScale, currentAngle, posX, posY, currentColor);

            currentScale -= 0.03;
            currentAngle += angleStep;
            colorIndex++;
        }
    }
}