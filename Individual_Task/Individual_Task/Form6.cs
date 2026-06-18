using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Task
{
    public partial class Form6 : Form
    {
        int[,] kv = new int[4, 3];
        int[,] stick = new int[4, 3];
        int[,] sail = new int[4, 3];
        int[,] matr_sdv = new int[3, 3];
        int x_bird = 230;
        int y_bird = 20;
        int bird_move = 5;
        int boat_move = 1;
        int k, l;
        bool f = true;

        public Form6()
        {
            InitializeComponent();
            Init_boat();
            Init_stick();
            Init_sail();
        }

        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = b.GetLength(1);
            int p = a.GetLength(1);

            int[,] r = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int k = 0; k < p; k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        private void Init_boat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 55; kv[1, 1] = 0; kv[1, 2] = 1;
            kv[2, 0] = 20; kv[2, 1] = 20; kv[2, 2] = 1;
            kv[3, 0] = -10; kv[3, 1] = 20; kv[3, 2] = 1;
        }

        private void Init_stick()
        {
            stick[0, 0] = 10; stick[0, 1] = 0; stick[0, 2] = 1;
            stick[1, 0] = 10; stick[1, 1] = 0; stick[1, 2] = 1;
            stick[2, 0] = 10; stick[2, 1] = -70; stick[2, 2] = 1;
            stick[3, 0] = 10; stick[3, 1] = -70; stick[3, 2] = 1;
        }

        private void Init_sail()
        {
            sail[0, 0] = 10; sail[0, 1] = -70; sail[0, 2] = 1;
            sail[1, 0] = 25; sail[1, 1] = -35; sail[1, 2] = 1;
            sail[2, 0] = 10; sail[2, 1] = -20; sail[2, 2] = 1;
            sail[3, 0] = 10; sail[3, 1] = -70; sail[3, 2] = 1;
        }

        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        // Матрица сдвига по X для движения
        private void Init_matr_move(int n)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = n; matr_sdv[2, 1] = 0; matr_sdv[2, 2] = 1;
        }

        private void Move_object(int[,] obj, int n)
        {
            Init_matr_move(n);
            int[,] result = Multiply_matr(obj, matr_sdv);

            // Копируем результат обратно в объект
            for (int i = 0; i < 4; i++)
            {
                obj[i, 0] = result[i, 0];
                obj[i, 1] = result[i, 1];
                obj[i, 2] = result[i, 2];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x_bird >= 400)
            {
                bird_move *= -1;
            }
            else if (x_bird <= 10)
            {
                bird_move *= -1;
            }
            x_bird += bird_move;
            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_sky();
            Draw_boat();
            Draw_stick();
            Draw_sail();
            Draw_sun(500, -20);
            Draw_bird(x_bird, y_bird);
        }

        private void Draw_bird(int x, int y)
        {
            Rectangle myRectangle = new Rectangle(x, y, 10, 10);
            Pen myPen = new Pen(Color.White, 10);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawEllipse(myPen, myRectangle);
        }

        private void Draw_sun(int x, int y)
        {
            Rectangle myRectangle = new Rectangle(x, y, 100, 100);
            Pen myPen = new Pen(Color.Orange, 100);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawEllipse(myPen, myRectangle);
        }

        private void Draw_sail()
        {
            Init_matr_preob(k, l);
            int[,] kv1 = Multiply_matr(sail, matr_sdv);

            Pen myPen = new Pen(Color.White, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void Draw_sky()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.SkyBlue);
        }

        private void Draw_boat()
        {
            Init_matr_preob(k, l);
            int[,] kv1 = Multiply_matr(kv, matr_sdv);

            Pen myPen = new Pen(Color.Brown, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void Draw_stick()
        {
            Init_matr_preob(k, l);
            int[,] kv1 = Multiply_matr(stick, matr_sdv);

            Pen myPen = new Pen(Color.Black, 4);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            button2.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button2.Text = "Старт";
            }
            f = !f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Движение птицы
            if (x_bird >= 400)
            {
                bird_move *= -1;
            }
            else if (x_bird <= 10)
            {
                bird_move *= -1;
            }

            // Проверка границ для лодки (используем координату X мачты)
            if (stick[0, 0] + k >= pictureBox1.Width - 70)
            {
                boat_move = -Math.Abs(boat_move);
            }
            else if (stick[0, 0] + k <= 30)
            {
                boat_move = Math.Abs(boat_move);
            }

            x_bird += bird_move;

            // Сдвигаем все части лодки
            Move_object(kv, boat_move);
            Move_object(stick, boat_move);
            Move_object(sail, boat_move);

            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Draw_sky();
            Draw_boat();
            Draw_stick();
            Draw_sail();
            Draw_sun(500, -20);
            Draw_bird(x_bird, y_bird);
        }
    }
}