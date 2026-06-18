using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab3
{
    public partial class Form1 : Form
    {
        int[,] kv = new int[4, 3]; //матрица тела (квадрат)
        int[,] ro = new int[4, 3]; //матрица тела (ромб)
        int[,] kv_temp = new int[4, 3]; //матрица тела (копия)
        int[,] ro_temp = new int[4, 3]; //матрица тела (копия)
        int[,] osi = new int[4, 3]; // матрица координат осей
        int[,] matr_sdv = new int[3, 3]; //матрица преобразования
        int k, l; //элементы матрицы сдвига
        bool f = true; //переменная, чтобы отслеживать движение квадратика 
        bool check_kvadrat = false; //флаг отрисовки 
        bool otrazhenie_po_X = false; //флаг отражаения по горизонтали 
        bool otrazhenie_po_Y = false; //флаг отражения по вертикали 
        double size_x = 1.0; //исходный размер по оси X
        double size_y = 1.0; //исходный размер по оси Y
        double ugol = 0; //угол поворота фигуры
        bool check_dvijenie = false; //флаг режима перемещения
        bool check_povorot = false; //флаг режима поворота 
        bool check_mashtab = false; //флаг режима масштабирования 

        public Form1()
        {
            InitializeComponent();
        }

        //инициализация матрицы тела (квадрат)
        private void Init_kvadrat()
        {
            //[1,2] - 1: номер вершины; номер координаты (столбца)
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1; //левая 
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1; //верхняя 
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1; //правая
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1; //нижняя
        }

        //инициализация матрицы тела (ромб)
        private void Init_romb()
        {
            ro[0, 0] = -40; ro[0, 1] = 0; ro[0, 2] = 1;
            ro[1, 0] = 0; ro[1, 1] = 70; ro[1, 2] = 1;
            ro[2, 0] = 70; ro[2, 1] = 0; ro[2, 2] = 1;
            ro[3, 0] = 0; ro[3, 1] = -40; ro[3, 2] = 1;
        }

        //инициализация матрицы сдвига
        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; //масштаб X
            matr_sdv[0, 1] = 0; //влияние Х на У 
            matr_sdv[0, 2] = 0; //влияние Х на Z

            matr_sdv[1, 0] = 0; //влияние У на Х 
            matr_sdv[1, 1] = 1; //масштаб Y
            matr_sdv[1, 2] = 0; //влияние У на Z

            matr_sdv[2, 0] = k1; //перенос по Х
            matr_sdv[2, 1] = l1; //перенос по У 
            matr_sdv[2, 2] = 1; //Масштаб Z
        }

        //инициализация матрицы осей
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }

        //умножение матриц
        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0); //кол-во строк 
            int m = a.GetLength(1); //кол-во столбцов 

            int[,] r = new int[n, m];

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

        //отоюражение по X
        private void Otrajenie_po_x()
        {
            otrazhenie_po_X = !otrazhenie_po_X;
        }

        //отображение по Y
        private void Otrajenie_po_y()
        {
            otrazhenie_po_Y = !otrazhenie_po_Y;
        }

        //увеличение 
        private void Size_big()
        {
            size_x += 0.5;
            size_y += 0.5;
        }

        //уменьшение 
        private void Size_small()
        {
            size_x -= 0.5;
            size_y -= 0.5;

            if (size_x <= 0.5)
            {
                size_x = 0.5;
            }

            if (size_y <= 0.5)
            {
                size_y = 0.5;
            }
        }

        //очитска 
        private void Clear()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            g.Dispose();
        }

        //вывод квадратика в центре pictureBox
        private void Draw_Kv()
        {
            //исходные координаты 
            Init_kvadrat();

            //копируем во временную матрицу 
            for (int i = 0; i < 4; i++)
            {
                kv_temp[i, 0] = kv[i, 0];
                kv_temp[i, 1] = kv[i, 1];
                kv_temp[i, 2] = kv[i, 2];
            }

            //масштабирование 
            for (int i = 0; i < 4; i++)
            {
                kv_temp[i, 0] = (int)(kv_temp[i, 0] * size_x);
                kv_temp[i, 1] = (int)(kv_temp[i, 1] * size_y);
            }

            //поворот 
            double radian = ugol * Math.PI / 180;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            double matrix00 = cos;
            double matrix01 = -sin;
            double matrix10 = sin;
            double matrix11 = cos;

            for (int i = 0; i < 4; i++)
            {
                int x = kv_temp[i, 0];
                int y = kv_temp[i, 1];

                kv_temp[i, 0] = (int)(x * matrix00 + y * matrix01); 
                kv_temp[i, 1] = (int)(x * matrix10 + y * matrix11);  
            }

            //отражение по Х
            if (otrazhenie_po_X)
            {
                for (int i = 0; i < 4; i++)
                    kv_temp[i, 1] = -kv_temp[i, 1];
            }

            //отражение по У
            if (otrazhenie_po_Y)
            {
                for (int i = 0; i < 4; i++)
                    kv_temp[i, 0] = -kv_temp[i, 0];
            }

            //перенос в центр экрана 
            for (int i = 0; i < 4; i++)
            {
                kv_temp[i, 0] += k;
                kv_temp[i, 1] += l;
            }

            int[,] kv1 = kv_temp;

            Pen myPen = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);
        }

        //вывод ромба в центре pictureBox
        private void Draw_Ro()
        {
            //исходные координаты 
            Init_romb();

            //копируем во временную матрицу
            for (int i = 0; i < 4; i++)
            {
                ro_temp[i, 0] = ro[i, 0];
                ro_temp[i, 1] = ro[i, 1];
                ro_temp[i, 2] = ro[i, 2];
            }

            //поворот 
            double rad = ugol * Math.PI / 180;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            // Матрица поворота 2×2
            double matrix00 = cos;
            double matrix01 = -sin;
            double matrix10 = sin;
            double matrix11 = cos;

            for (int i = 0; i < 4; i++)
            {
                int x = ro_temp[i, 0];
                int y = ro_temp[i, 1];

                ro_temp[i, 0] = (int)(x * matrix00 + y * matrix01);
                ro_temp[i, 1] = (int)(x * matrix10 + y * matrix11);
            }

            //масштабирование 
            for (int i = 0; i < 4; i++)
            {
                ro_temp[i, 0] = (int)(ro_temp[i, 0] * size_x);
                ro_temp[i, 1] = (int)(ro_temp[i, 1] * size_y);
            }

            //отражение по Х
            if (otrazhenie_po_X)
            {
                for (int i = 0; i < 4; i++)
                    ro_temp[i, 1] = -ro_temp[i, 1];
            }

            //отражение по У
            if (otrazhenie_po_Y)
            {
                for (int i = 0; i < 4; i++)
                    ro_temp[i, 0] = -ro_temp[i, 0];
            }

            Init_matr_preob(k, l);
            int[,] ro1 = Multiply_matr(ro_temp, matr_sdv);

            Pen myPen = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(myPen, ro1[0, 0], ro1[0, 1], ro1[1, 0], ro1[1, 1]);
            g.DrawLine(myPen, ro1[1, 0], ro1[1, 1], ro1[2, 0], ro1[2, 1]);
            g.DrawLine(myPen, ro1[2, 0], ro1[2, 1], ro1[3, 0], ro1[3, 1]);
            g.DrawLine(myPen, ro1[3, 0], ro1[3, 1], ro1[0, 0], ro1[0, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        //отрисовка чего-то одного
        private void Draw_only_one()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            g.Dispose();

            Draw_osi(); //координатные оси 

            if (check_kvadrat)
            {
                Draw_Kv(); //рисуем квадрат
            }
            else
            {
                Draw_Ro(); //рисуем ромб 
            }
        }

        //вывод осей в центре pictureBox
        private void Draw_osi()
        {
            Init_osi();

            Pen myPen = new Pen(Color.Red, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            g.DrawLine(myPen, osi[0, 0] + pictureBox1.Width / 2, osi[0, 1] + pictureBox1.Height / 2,
                      osi[1, 0] + pictureBox1.Width / 2, osi[1, 1] + pictureBox1.Height / 2);

            g.DrawLine(myPen, osi[2, 0] + pictureBox1.Width / 2, osi[2, 1] + pictureBox1.Height / 2,
                              osi[3, 0] + pictureBox1.Width / 2, osi[3, 1] + pictureBox1.Height / 2);

            g.Dispose();
            myPen.Dispose();
        }

        //кнопки

        //рисование осей
        private void button1_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }

        //рисование квадрата
        private void button2_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            check_kvadrat = true;
            Draw_only_one();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //остановить таймер
            timer1.Stop();
            f = true;

            //сброс координат (в центр)
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            //сброс преобразований
            ugol = 0;
            size_x = 1.0;
            size_y = 1.0;

            otrazhenie_po_X = false;
            otrazhenie_po_Y = false;

            //выключить все режимы
            check_dvijenie = false;
            check_povorot = false;
            check_mashtab = false;

            Clear();    
        }

        //смещение фигуры вправо 
        private void button4_Click(object sender, EventArgs e)
        {
            k += 5;
            Draw_only_one();
        }

        //смещение фигуры влево 
        private void button5_Click(object sender, EventArgs e)
        {
            k -= 5;
            Draw_only_one();
        }

        //смещение фигуры вниз
        private void button6_Click(object sender, EventArgs e)
        {
            l += 5;
            Draw_only_one();
        }

        //смещение фигуры вверх 
        private void button7_Click(object sender, EventArgs e)
        {
            l -= 5;
            Draw_only_one();
        }

        //запуск или остановка анимации 
        private void button8_Click(object sender, EventArgs e)
        {
            if (f)
            {
                timer1.Interval = 50;
                timer1.Start();
                button8.Text = "Стоп";
            }
            else
            {
                timer1.Stop();
                button8.Text = "Старт";
            }

            f = !f;
        }

        //отражение по вертикали 
        private void button9_Click(object sender, EventArgs e)
        {
            Otrajenie_po_y();
            Draw_only_one();
        }

        //отражение по горизонтали 
        private void button10_Click(object sender, EventArgs e)
        {
            Otrajenie_po_x();
            Draw_only_one();
        }

        //увеличиваем размер 
        private void button11_Click(object sender, EventArgs e)
        {
            Size_big();
            Draw_only_one();
        }

        //уменьшаем размер 
        private void button12_Click(object sender, EventArgs e)
        {
            Size_small();
            Draw_only_one();
        }

        //выбор рисования ромба 
        private void button13_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            check_kvadrat = false;
            Draw_only_one();
        }

        //поворот 
        private void button14_Click(object sender, EventArgs e)
        {
            ugol += 10;
            Draw_only_one();
        }

        //движение (непрерывное)
        private void button15_Click(object sender, EventArgs e)
        {
            check_dvijenie = true;
            check_povorot = false;
            check_mashtab = false;
        }

        //поворот (непрерывное)
        private void button16_Click(object sender, EventArgs e)
        {
            check_dvijenie = false;
            check_povorot = true;
            check_mashtab = false;
        }

        //масштабирование (непрерывное)
        private void button17_Click(object sender, EventArgs e)
        {
            check_dvijenie = false;
            check_povorot = false;
            check_mashtab = true;
        }

        //выполнение анимации 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check_dvijenie)
            {
                k++; //движение по Х
            }

            if (check_povorot)
            {
                ugol += 2; //поворот на 2 градуса на каждый тик 
            }

            if (check_mashtab)
            {
                size_x += 0.01; //плавное увеличение по Х
                size_y += 0.01; //плавное увеличение по У
            }

            Draw_only_one();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}