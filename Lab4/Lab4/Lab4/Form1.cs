using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        double[,] cube = new double[8, 4];
        double[,] cube_temp = new double[8, 4];

        double[,] osi = new double[6, 3];

        double[,] matr = new double[4, 4];

        int k, l;

        double ugol_x = 0;
        double ugol_y = 0;
        double ugol_z = 0;

        double size_x = 1;
        double size_y = 1;
        double size_z = 1;

        double min_size = 0.5;

        int dx = 0;
        int dy = 0;
        int dz = 0;

        bool f = true;

        int direction = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Init_cube()
        {
            cube[0, 0] = -50; cube[0, 1] = -50; cube[0, 2] = -50; cube[0, 3] = 1;
            cube[1, 0] = 50; cube[1, 1] = -50; cube[1, 2] = -50; cube[1, 3] = 1;
            cube[2, 0] = 50; cube[2, 1] = 50; cube[2, 2] = -50; cube[2, 3] = 1;
            cube[3, 0] = -50; cube[3, 1] = 50; cube[3, 2] = -50; cube[3, 3] = 1;

            cube[4, 0] = -50; cube[4, 1] = -50; cube[4, 2] = 50; cube[4, 3] = 1;
            cube[5, 0] = 50; cube[5, 1] = -50; cube[5, 2] = 50; cube[5, 3] = 1;
            cube[6, 0] = 50; cube[6, 1] = 50; cube[6, 2] = 50; cube[6, 3] = 1;
            cube[7, 0] = -50; cube[7, 1] = 50; cube[7, 2] = 50; cube[7, 3] = 1;
        }

        private void Copy_cube()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cube_temp[i, j] = cube[i, j];
                }
            }
        }

        //Оси
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;

            osi[2, 0] = 0; osi[2, 1] = -200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = 200; osi[3, 2] = 1;

            osi[4, 0] = -150; osi[4, 1] = 150; osi[4, 2] = 1;
            osi[5, 0] = 150; osi[5, 1] = -150; osi[5, 2] = 1;
        }

        //Матрица переноса
        private void Init_matr(int x, int y)
        {
            matr[0, 0] = 1; matr[0, 1] = 0; matr[0, 2] = 0; matr[0, 3] = 0;
            matr[1, 0] = 0; matr[1, 1] = 1; matr[1, 2] = 0; matr[1, 3] = 0;
            matr[2, 0] = 0; matr[2, 1] = 0; matr[2, 2] = 1; matr[2, 3] = 0;
            matr[3, 0] = x; matr[3, 1] = y; matr[3, 2] = 0; matr[3, 3] = 1;
        }

        //Умножение
        private double[,] Multiply(double[,] a, double[,] b)
        {
            double[,] r = new double[8, 4];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    r[i, j] = 0;

                    for (int k = 0; k < 4; k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return r;
        }

        //Масштаб
        private void Scale()
        {
            for (int i = 0; i < 8; i++)
            {
                cube_temp[i, 0] *= size_x;
                cube_temp[i, 1] *= size_y;
                cube_temp[i, 2] *= size_z;
            }
        }

        //Поворот ОХ
        private void Rotate_OX()
        {
            double rad = ugol_x * Math.PI / 180;

            for (int i = 0; i < 8; i++)
            {
                double y = cube_temp[i, 1];
                double z = cube_temp[i, 2];

                cube_temp[i, 1] = y * Math.Cos(rad) - z * Math.Sin(rad);
                cube_temp[i, 2] = y * Math.Sin(rad) + z * Math.Cos(rad);
            }
        }

        //Поворот ОУ
        private void Rotate_OY()
        {
            double rad = ugol_y * Math.PI / 180;

            for (int i = 0; i < 8; i++)
            {
                double x = cube_temp[i, 0];
                double z = cube_temp[i, 2];

                cube_temp[i, 0] = x * Math.Cos(rad) + z * Math.Sin(rad);
                cube_temp[i, 2] = -x * Math.Sin(rad) + z * Math.Cos(rad);
            }
        }

        //Поворот ОZ
        private void Rotate_OZ()
        {
            double rad = ugol_z * Math.PI / 180;

            for (int i = 0; i < 8; i++)
            {
                double x = cube_temp[i, 0];
                double y = cube_temp[i, 1];

                cube_temp[i, 0] = x * Math.Cos(rad) - y * Math.Sin(rad);
                cube_temp[i, 1] = x * Math.Sin(rad) + y * Math.Cos(rad);
            }
        }

        //Перемещение
        private void Move()
        {
            for (int i = 0; i < 8; i++)
            {
                cube_temp[i, 0] += dx;
                cube_temp[i, 1] += dy;
                cube_temp[i, 2] += dz;
            }
        }

        //Отрисовка осей
        private void Draw_osi()
        {
            Init_osi();

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen p = new Pen(Color.Red, 1);

            g.DrawLine(p, (int)osi[0, 0] + k, (int)osi[0, 1] + l, (int)osi[1, 0] + k, (int)osi[1, 1] + l);

            g.DrawLine(p, (int)osi[2, 0] + k, (int)osi[2, 1] + l, (int)osi[3, 0] + k, (int)osi[3, 1] + l);

            g.DrawLine(p, (int)osi[4, 0] + k, (int)osi[4, 1] + l, (int)osi[5, 0] + k, (int)osi[5, 1] + l);

            g.Dispose();
            p.Dispose();
        }

        //Отрисовка куба
        private void Draw_cube(double[,] cube1)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.Clear(Color.White);

            Draw_osi();

            Pen p = new Pen(Color.Blue, 2);

            //задняя грань
            Draw_edge(g, p, cube1, 0, 1);
            Draw_edge(g, p, cube1, 1, 2);
            Draw_edge(g, p, cube1, 2, 3);
            Draw_edge(g, p, cube1, 3, 0);

            //передняя грань
            Draw_edge(g, p, cube1, 4, 5);
            Draw_edge(g, p, cube1, 5, 6);
            Draw_edge(g, p, cube1, 6, 7);
            Draw_edge(g, p, cube1, 7, 4);

            //сооединяющие ребра
            Draw_edge(g, p, cube1, 0, 4);
            Draw_edge(g, p, cube1, 1, 5);
            Draw_edge(g, p, cube1, 2, 6);
            Draw_edge(g, p, cube1, 3, 7);


            g.Dispose();
            p.Dispose();
        }

        //Отрисовка ребер
        private void Draw_edge(Graphics g, Pen p, double[,] a, int i, int j)
        {
            g.DrawLine(p, (int)a[i, 0], (int)a[i, 1], (int)a[j, 0], (int)a[j, 1]);
        }

        //Отрисовка всего
        private void Draw_all()
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            Init_cube();

            Copy_cube();

            Scale();

            Rotate_OX();
            Rotate_OY();
            Rotate_OZ();

            Move();

            Init_matr(k, l);

            double[,] cube1 = Multiply(cube_temp, matr);

            Draw_cube(cube1);
        }

        //Очистка
        private void Clear()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            g.Dispose();
        }

        //Вывод осей
        private void button1_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }

        //Вывод всего
        private void button2_Click(object sender, EventArgs e)
        {
            Draw_all();
        }

        //Поворот по OX
        private void button3_Click(object sender, EventArgs e)
        {
            ugol_x += 10;
            Draw_all();
        }


        //Поворот по OY
        private void button4_Click(object sender, EventArgs e)
        {
            ugol_y += 10;
            Draw_all();
        }

        //Поворот по OZ
        private void button5_Click(object sender, EventArgs e)
        {
            ugol_z += 10;
            Draw_all();
        }

        //Перемещение вправо
        private void button6_Click(object sender, EventArgs e)
        {
            dx += 10;
            Draw_all();
        }

        //Перемещение влево
        private void button7_Click(object sender, EventArgs e)
        {
            dx -= 10;
            Draw_all();
        }

        //Увеличение по трём осям
        private void button8_Click(object sender, EventArgs e)
        {
            size_x += 0.2;
            size_y += 0.2;
            size_z += 0.2;

            Draw_all();
        }


        //Уменьшение по трем осям
        private void button9_Click(object sender, EventArgs e)
        {
            if (size_x - 0.2 >= min_size && size_y - 0.2 >= min_size && size_z - 0.2 >= min_size)
            {
                size_x -= 0.2;
                size_y -= 0.2;
                size_z -= 0.2;
            }

            Draw_all();
        }

        //Увеличение по Х
        private void button10_Click(object sender, EventArgs e)
        {
            size_x += 0.2;
            Draw_all();
        }

        //Умеьшение по Х
        private void button11_Click(object sender, EventArgs e)
        {
            if (size_x - 0.2 >= min_size)
            {
                size_x -= 0.2;
                Draw_all();
            }
        }

        //Увеличение по Y
        private void button12_Click(object sender, EventArgs e)
        {
            size_y += 0.2;
            Draw_all();
        }

        //Умеьшение по Y
        private void button13_Click(object sender, EventArgs e)
        {
            if (size_y - 0.2 >= min_size)
            {
                size_y -= 0.2;
                Draw_all();
            }
        }

        //Увеличение по Z
        private void button14_Click(object sender, EventArgs e)
        {
            size_z += 0.2;
            Draw_all();
        }

        //Умеьшение по Z
        private void button15_Click(object sender, EventArgs e)
        {
            if (size_z - 0.2 >= min_size)
            {
                size_z -= 0.2;
                Draw_all();
            }
        }

        //Вниз по OY
        private void button16_Click(object sender, EventArgs e)
        {
            dy += 10;
            Draw_all();
        }

        //Вверх по ОY
        private void button17_Click(object sender, EventArgs e)
        {
            dy -= 10;
            Draw_all();
        }

        //Вперед по OZ
        private void button18_Click(object sender, EventArgs e)
        {
            dz += 10;
            Draw_all();
        }

        //Назад по OZ
        private void button19_Click(object sender, EventArgs e)
        {
            dz -= 10;
            Draw_all();
        }

        //Перемещение по трем координатам
        private void button20_Click(object sender, EventArgs e)
        {
            dx += 10;
            dy -= 10;
            dz -= 10;
            Draw_all();
        }

        //Обратно по трём осям
        private void button21_Click(object sender, EventArgs e)
        {
            dx -= 10;
            dy += 10;
            dz += 10;
            Draw_all();
        }

        //Отображение XY
        private void button22_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                cube[i, 2] = -cube[i, 2];
            }

            Draw_all();
        }

        //Отображение XZ
        private void button23_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                cube[i, 1] = -cube[i, 1];
            }

            Draw_all();
        }

        //Отображение YZ
        private void button24_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                cube[i, 0] = -cube[i, 0];
            }

            Draw_all();
        }

        //Очистка
        private void button25_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (f)
            {
                timer1.Interval = 200;
                timer1.Start();
                button26.Text = "Стоп";
            }
            else
            {
                timer1.Stop();
                button26.Text = "Старт";
            }

            f = !f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dx += direction * 2;

            if (dx > 200 || dx < -200)
            {
                direction *= -1;
            }

            ugol_x += 2;
            ugol_y += 2;
            ugol_z += 2;

            Draw_all();
        }
    }
}
