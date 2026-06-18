using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Individual_Task
{
    public partial class Form11 : Form
    {
        double[,] prism = new double[10, 4];
        double[,] prism_temp = new double[10, 4];

        int k, l;

        double ugol_x = 20;
        double ugol_y = 20;
        double ugol_z = 0;

        Color pen_color = Color.Blue;
        double pen_width = 2;
        int pen_rezhim = 0; 
        double shag_punctira = 6;

        bool mouse_down = false;
        Point last_position_mouse;

        public Form11()
        {
            InitializeComponent();
            Draw_all();
        }

        private void Init_prism()
        {
            double r = 60;

            for (int i = 0; i < 5; i++)
            {
                double a = i * 2 * Math.PI / 5;

                prism[i, 0] = r * Math.Cos(a);
                prism[i, 1] = r * Math.Sin(a);
                prism[i, 2] = -50;
                prism[i, 3] = 1;

                prism[i + 5, 0] = prism[i, 0];
                prism[i + 5, 1] = prism[i, 1];
                prism[i + 5, 2] = 50;
                prism[i + 5, 3] = 1;
            }
        }

        private void Copy_prism()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 4; j++)
                    prism_temp[i, j] = prism[i, j];
        }

        private void Rotate_x()
        {
            double r = ugol_x * Math.PI / 180;

            for (int i = 0; i < 10; i++)
            {
                double y = prism_temp[i, 1];
                double z = prism_temp[i, 2];

                prism_temp[i, 1] = y * Math.Cos(r) - z * Math.Sin(r);
                prism_temp[i, 2] = y * Math.Sin(r) + z * Math.Cos(r);
            }
        }

        private void Rotate_y()
        {
            double r = ugol_y * Math.PI / 180;

            for (int i = 0; i < 10; i++)
            {
                double x = prism_temp[i, 0];
                double z = prism_temp[i, 2];

                prism_temp[i, 0] = x * Math.Cos(r) + z * Math.Sin(r);
                prism_temp[i, 2] = -x * Math.Sin(r) + z * Math.Cos(r);
            }
        }
        private void Rotate_z()
        {
            double r = ugol_z * Math.PI / 180;

            for (int i = 0; i < 10; i++)
            {
                double x = prism_temp[i, 0];
                double y = prism_temp[i, 1];

                prism_temp[i, 0] = x * Math.Cos(r) - y * Math.Sin(r);
                prism_temp[i, 1] = x * Math.Sin(r) + y * Math.Cos(r);
            }
        }

        //Перспектива (1 точка схода)
        private Point Project(double x, double y, double z)
        {
            //расстояние камеры
            double d = 300;

            //коэффициент перспективы
            double k = d / (d + z);

            //получаем экранные координаты
            return new Point((int)(x * k) + this.k, (int)(y * k) + this.l);
        }

        private Pen Get_pen()
        {
            Pen p = new Pen(pen_color, (float)pen_width);

            if (pen_rezhim == 1)
            {
                p.Width = (float)pen_width * 2;
            }    
                
            if (pen_rezhim == 2)
            {
                p.DashStyle = DashStyle.Dash;
            }

            return p;
        }

        private bool Roberts(Point3 a, Point3 b, Point3 c)
        {
            //два вектора грани
            double ux = b.X - a.X;
            double uy = b.Y - a.Y;
            double uz = b.Z - a.Z;

            double vx = c.X - a.X;
            double vy = c.Y - a.Y;
            double vz = c.Z - a.Z;

            //нормаль через векторное произведение
            double nx = uy * vz - uz * vy;
            double ny = uz * vx - ux * vz;
            double nz = ux * vy - uy * vx;

            //если z-нормали < 0 — грань видима
            return nz < 0;
        }

        //Структура 3D точки
        private struct Point3
        {
            public double X, Y, Z;
            public Point3(double x, double y, double z)
            {
                X = x; Y = y; Z = z;
            }
        }

        private void Draw_osi(Graphics g)
        {
            Pen p = new Pen(Color.Gray, 1);

            g.DrawLine(p, k - 200, l, k + 200, l);

            g.DrawLine(p, k, l - 200, k, l + 200);

            p.Dispose();
        }

        private void Draw_object(Graphics g)
        {
            Pen p = Get_pen();

            Point3[] p3 = new Point3[10];
            Point[] p2 = new Point[10];

            //Переводим вершину из 3D в 2D
            for (int i = 0; i < 10; i++)
            {
                p3[i] = new Point3(prism_temp[i, 0], prism_temp[i, 1], prism_temp[i, 2]);
                p2[i] = Project(prism_temp[i, 0], prism_temp[i, 1], prism_temp[i, 2]);
            }


            if (Roberts(p3[0], p3[1], p3[2]))
            {
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(p, p2[i], p2[(i + 1) % 5]);
                }
            }
                
            if (Roberts(p3[5], p3[6], p3[7]))
            {
                for (int i = 0; i < 5; i++)
                { 
                    g.DrawLine(p, p2[i + 5], p2[5 + (i + 1) % 5]);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (Roberts(p3[i], p3[(i + 1) % 5], p3[i + 5]))
                {
                    g.DrawLine(p, p2[i], p2[i + 5]);
                }
            }
                

            p.Dispose();
        }

        private void Draw_line(Graphics g)
        {
            Pen p = new Pen(Color.Black, 1);

            //Направляющие косинусы
            double lx = 0.6, ly = 0.4, lz = 0.7;

            //Нормализация вектора
            double len = Math.Sqrt(lx * lx + ly * ly + lz * lz);

            //Получаем единичный вектор направления
            lx /= len; ly /= len; lz /= len;

            double size = 200;

            //Проекция 3D в 2D
            Point a = Project(-lx * size, -ly * size, -lz * size);
            Point b = Project(lx * size, ly * size, lz * size);

            g.DrawLine(p, a, b);

            p.Dispose();
        }

        private void Draw_all()
        {
            if (pictureBox1.Width == 0)
            {
                return;
            }

            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Init_prism();
            Copy_prism();

            Rotate_x();
            Rotate_y();
            Rotate_z();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Draw_object(g);
                Draw_osi(g);
                Draw_line(g);
            }

            pictureBox1.Image = bmp;
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            pen_width = trackBarWidth.Value;
            Draw_all();
        }

        private void trackBarDash_Scroll(object sender, EventArgs e)
        {
            shag_punctira = trackBarDash.Value;
            Draw_all();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pen_rezhim = comboBox1.SelectedIndex;
            Draw_all();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen_color = colorDialog1.Color;
                Draw_all();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
            last_position_mouse = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse_down)
            {
                return;
            }

            ugol_y += (e.X - last_position_mouse.X) * 0.5;
            ugol_x += (e.Y - last_position_mouse.Y) * 0.5;

            last_position_mouse = e.Location;
            Draw_all();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ugol_x = 20;
            ugol_y = 20;
            ugol_z = 0;

            pen_color = Color.Blue;
            pen_width = 2;
            pen_rezhim = 0;
            shag_punctira = 6;

            comboBox1.SelectedIndex = 0;
            trackBarWidth.Value = 2;
            trackBarDash.Value = 6;

            Draw_all();
        }
    }
}