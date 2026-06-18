using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Individual_Task
{
    public partial class Form7 : Form
    {
        int[,] hex = new int[6, 3];
        int[,] hex_temp = new int[6, 3];
        int[,] matr = new int[3, 3];

        double ugol = 0;
        double ugol_b = 10;
        double size = 20;
        bool f = true;

        int k, l; 

        int count = 0;

        Color[] colors = new Color[]
        {
            Color.Red, Color.Blue, Color.Green,
            Color.Orange, Color.Purple, Color.Brown
        };

        public Form7()
        {
            InitializeComponent();
        }

        private void Init_hexagon()
        {
            double r = size;

            for (int i = 0; i < 6; i++)
            {
                double a = i * Math.PI / 3;

                hex[i, 0] = (int)(r * Math.Cos(a));
                hex[i, 1] = (int)(r * Math.Sin(a));
                hex[i, 2] = 1;
            }
        }

        private void Copy()
        {
            for (int i = 0; i < 6; i++)
            {
                hex_temp[i, 0] = hex[i, 0];
                hex_temp[i, 1] = hex[i, 1];
                hex_temp[i, 2] = 1;
            }
        }

        private void Init_matr(int k1, int l1)
        {
            matr[0, 0] = 1; matr[0, 1] = 0; matr[0, 2] = 0;
            matr[1, 0] = 0; matr[1, 1] = 1; matr[1, 2] = 0;
            matr[2, 0] = k1; matr[2, 1] = l1; matr[2, 2] = 1;
        }

        private int[,] Multiply(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int[,] r = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;

                    for (int ii = 0; ii < m; ii++)
                        r[i, j] += a[i, ii] * b[ii, j];
                }
            }

            return r;
        }

        private void Povorot()
        {
            double rad = ugol * Math.PI / 180;

            for (int i = 0; i < 6; i++)
            {
                int x = hex_temp[i, 0];
                int y = hex_temp[i, 1];

                hex_temp[i, 0] = (int)(x * Math.Cos(rad) - y * Math.Sin(rad));
                hex_temp[i, 1] = (int)(x * Math.Sin(rad) + y * Math.Cos(rad));
            }
        }

        private void Mashtab()
        {
            double s = 1 + count * 0.2;

            for (int i = 0; i < 6; i++)
            {
                hex_temp[i, 0] = (int)(hex_temp[i, 0] * s);
                hex_temp[i, 1] = (int)(hex_temp[i, 1] * s);
            }
        }

        private void Draw_hex(int[,] a, Color c)
        {
            Pen p = new Pen(c, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            for (int i = 0; i < 6; i++)
            {
                int j = (i + 1) % 6;

                g.DrawLine(p,
                    a[i, 0], a[i, 1],
                    a[j, 0], a[j, 1]);
            }

            g.Dispose();
            p.Dispose();
        }

        private void Draw_osi()
        {
            Pen p = new Pen(Color.Red, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(p, 0, pictureBox1.Height / 2,
                          pictureBox1.Width, pictureBox1.Height / 2);

            g.DrawLine(p, pictureBox1.Width / 2, 0,
                          pictureBox1.Width / 2, pictureBox1.Height);

            g.Dispose();
            p.Dispose();
        }
    
        private void Draw_all()
        {
            Draw_osi();

            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Init_hexagon();
            Copy();

            Mashtab();
            Povorot();

            Init_matr(k, l);
            int[,] res = Multiply(hex_temp, matr);

            Draw_hex(res, colors[count % colors.Length]);

            count++;
            size += 5;
            ugol += ugol_b;
        }

        private void Clear()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f)
            {
                timer1.Interval = 200;
                timer1.Start();
                button1.Text = "Стоп";
            }
            else
            {
                timer1.Stop();
                button1.Text = "Старт";
            }

            f = !f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Clear();

            count = 0;
            size = 20;
            ugol = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox1.Text, out ugol_b);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw_all();
        }
    }
}