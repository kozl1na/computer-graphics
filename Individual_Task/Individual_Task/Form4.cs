using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Individual_Task
{
    public partial class Form4 : Form
    {
        public int xn, yn, xk, yk;
        Bitmap myBitmap;
        Color currentBorderColor = Color.Black;
        Color collorFill = Color.Black;
        public int size = 4;
        int punktin = 0;
        int punkout = 0;
        bool checkFlag = false;




        private List<LineSegment> interactiveLines = new List<LineSegment>();
        private int tempXn, tempYn, tempXk, tempYk;
        private bool isDrawing = false;
        Color currentFillColor;
        private bool thickLineMode = false;
        private bool shapesDrawn = false;
        private bool shapesDrawnWithThickLine = false;
        private HashSet<Point> borderPoints = new HashSet<Point>();
        private bool defaultShapesDrawn = false;
        private Color originalBorderColor = Color.Red;



        public class LineSegment
        {
            public int X1, Y1, X2, Y2;
            public Color LineColor;
            public bool IsThick;

            public LineSegment(int x1, int y1, int x2, int y2, Color color, bool isThick)
            {
                X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;
                LineColor = color;
                IsThick = isThick;
            }

            public bool IsPointOnLine(int x, int y)
            {
                double d1 = Math.Sqrt((x - X1) * (x - X1) + (y - Y1) * (y - Y1));
                double d2 = Math.Sqrt((x - X2) * (x - X2) + (y - Y2) * (y - Y2));
                double lineLen = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
                return Math.Abs(d1 + d2 - lineLen) < 3.0;
            }
        }




        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            xn = xStart;
            yn = yStart;
            xk = xEnd;
            yk = yEnd;
            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;
            for (index = 1; index <= numberNodes; index++)
            {
                myBitmap.SetPixel((int)xOutput, (int)yOutput, currentBorderColor);
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }


        // Заливка с затравкой (рекурсивная)
        private void FloodFill(int x1, int y1)
        {
            // получаем цвет текущего пикселя с координатами x1, y1
            Color oldPixelColor = myBitmap.GetPixel(x1, y1);
            // сравнение цветов происходит в формате RGB
            // для этого используем метод ToArgb объекта Color
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb())
                && (oldPixelColor.ToArgb() != collorFill.ToArgb()))
            {
                //перекрашиваем пиксель
                myBitmap.SetPixel(x1, y1, currentBorderColor);

                //вызываем метод для 4-х соседних пикселей
                FloodFill(x1 + 1, y1);
                FloodFill(x1 - 1, y1);
                FloodFill(x1, y1 + 1);
                FloodFill(x1, y1 - 1);
            }
            else
            {
                //выходим из метода
                return;
            }
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //numberNodes – переменная, задающая количество узлов для
            //аппроксимации отрезка
            //xOutput – x-координата очередного узла
            //yOutput – y-координата очередного узла
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            //Объявляем объект "myPen", задающий цвет и толщину пера
            Pen myPen = new Pen(currentBorderColor, 1);

            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //реализация обычного алгоритма ЦДА
            if (radioButton1.Checked == true)
            {
                xk = e.X;
                yk = e.Y;
                dx = xk - xn;
                dy = yk - yn;
                numberNodes = 200;
                xOutput = xn;
                yOutput = yn;
                for (index = 1; index <= numberNodes; index++)
                {
                    //Рисуем прямоугольник
                    //g.DrawRectangle(myPen, (int)xOutput, (int)yOutput, 2, 2);
                    //Рисуем закрашенный прямоугольник:
                    //Объявляем объект "redBrush", задающий цвет кисти
                    SolidBrush redBrush = new SolidBrush(currentBorderColor);

                    //Рисуем закрашенный прямоугольник
                    if (checkBox1.Checked)
                    {
                        if (punkout < punktin)
                        {
                            g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                            punkout++;
                        }
                        else
                        {
                            if (punkout != punktin * 2)
                            {
                                punkout++;
                            }
                            else if (punkout == punktin * 2)
                            {
                                punkout = 0;
                            }


                        }
                    }
                    else
                    {
                        g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                    }


                    xOutput = xOutput + dx / numberNodes;
                    yOutput = yOutput + dy / numberNodes;

                }
            }

            if (radioButton3.Checked == true)
            {
                xk = e.X;
                yk = e.Y;
                dx = xk - xn;
                dy = yk - yn;
                label3.Text = "dx = " + dx.ToString();
                label4.Text = "dy = " + dy.ToString();
                xOutput = xn;
                yOutput = yn;
                SolidBrush redBrush = new SolidBrush(currentBorderColor);
                g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (xk > xn)
                    {
                        if (checkBox1.Checked)
                        {
                            while (xOutput < xk)
                            {
                                xOutput += 1;
                                yOutput = yOutput + dy / dx;
                                if (punkout < punktin)
                                {
                                    g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                                    punkout++;
                                }
                                else
                                {
                                    if (punkout != punktin * 2)
                                    {
                                        punkout++;
                                        continue;
                                    }
                                    punkout = 0;

                                }

                            }
                        }
                        else
                        {
                            while (xOutput < xk)
                            {
                                xOutput += 1;
                                yOutput = yOutput + dy / dx;
                                g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                            }
                        }
                    }
                    if (xk < xn)
                    {
                        if (checkBox1.Checked)
                        {
                            while (xOutput > xk)
                            {
                                xOutput -= 1;
                                yOutput = yOutput - dy / dx;
                                if (punkout < punktin)
                                {
                                    g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                                    punkout++;
                                }
                                else
                                {
                                    if (punkout != punktin * 2)
                                    {
                                        punkout++;
                                        continue;
                                    }
                                    punkout = 0;

                                }

                            }
                        }
                        else
                        {
                            while (xOutput > xk)
                            {
                                xOutput -= 1;
                                yOutput = yOutput - dy / dx;
                                g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                            }
                        }
                    }
                }
                else if (Math.Abs(dy) > Math.Abs(dx))
                {
                    if (yk > yn)
                    {
                        if (checkBox1.Checked)
                        {
                            while (yOutput < yk)
                            {
                                yOutput += 1;
                                xOutput = xOutput + dx / dy;
                                if (punkout < punktin)
                                {
                                    g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                                    punkout++;
                                }
                                else
                                {
                                    if (punkout != punktin * 2)
                                    {
                                        punkout++;
                                        continue;
                                    }
                                    punkout = 0;

                                }

                            }
                        }
                        else
                        {
                            while (yOutput < yk)
                            {
                                yOutput += 1;
                                xOutput = xOutput + dx / dy;
                                g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                            }
                        }
                    }
                    if (yk < yn)
                    {
                        if (checkBox1.Checked)
                        {
                            while (yOutput > yk)
                            {
                                yOutput -= 1;
                                xOutput = xOutput - dx / dy;
                                if (punkout < punktin)
                                {
                                    g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                                    punkout++;
                                }
                                else
                                {
                                    if (punkout != punktin * 2)
                                    {
                                        punkout++;
                                        continue;
                                    }
                                    punkout = 0;

                                }

                            }
                        }
                        else
                        {
                            while (yOutput > yk)
                            {
                                yOutput -= 1;
                                xOutput = xOutput - dx / dy;
                                g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, size, size);
                            }
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                currentBorderColor = colorDialog1.Color;
                Bitmap myBitmap = new Bitmap(100, 100);
                Color newPixelColor = currentBorderColor;
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    for (int y = 0; y < myBitmap.Height; y++)
                    {
                        myBitmap.SetPixel(x, y, newPixelColor);
                    }
                }
                pictureBox2.Image = myBitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отключаем кнопки
            button3.Enabled = false;
            button2.Enabled = false;
            //создаем новый экземпляр Bitmap размером с элемент
            //pictureBox1 (myBitmap)
            //на нем выводим попиксельно отрезок
            collorFill = colorDialog1.Color;

            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    //рисуем прямоугольник
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);
                    //рисуем треугольник
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);

                    CDA(50, 50, 50, 150);
                    CDA(50, 50, 150, 50);
                    CDA(50, 150, 150, 150);
                    CDA(150, 50, 150, 150);
                }
                else
                {
                    if (radioButton2.Checked == true)
                    {
                        //получаем растр созданного рисунка в mybitmap
                        myBitmap = pictureBox1.Image as Bitmap;

                        // задаем координаты затравки
                        xn = 160;
                        yn = 40;
                        // вызываем рекурсивную процедуру заливки с затравкой
                        FloodFill(xn, yn);
                    }
                }
                //передаем полученный растр mybitmap в элемент pictureBox
                pictureBox1.Image = myBitmap;
                // обновляем pictureBox и активируем кнопки
                pictureBox1.Refresh();
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            size = trackBar1.Value;
            label1.Text = "Размер пера : " + trackBar1.Value;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //pictureBox1.Image = myBitmap;
            //pictureBox1.Refresh();
            button2.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            punktin = trackBar2.Value;
            punkout = 0;
            label5.Text = "Размер пунктира : " + punktin.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true || radioButton3.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
            else if (radioButton2.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Сначала нарисуйте фигуру!");
                    return;
                }
                myBitmap = new Bitmap(pictureBox1.Image);
                xn = e.X;
                yn = e.Y;
                FloodFill(xn, yn);
                pictureBox1.Image = myBitmap;
                pictureBox1.Refresh();
            }
            else MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
        }
        //егор
        private bool PointInsideOrNot(int x, int y, int[] vershina_x, int[] vershina_y, int kolvo_vershin)
        {
            double total_degree = 0;

            for (int start_vershina = 0; start_vershina < kolvo_vershin; start_vershina++)
            {
                int next_vershina = (start_vershina + 1) % kolvo_vershin;

                double coordin_vect_x_1 = vershina_x[start_vershina] - x;
                double coordin_vect_y_1 = vershina_y[start_vershina] - y;
                double coordin_vect_x_2 = vershina_x[next_vershina] - x;
                double coordin_vect_y_2 = vershina_y[next_vershina] - y;

                double dlina_vectora_1 = Math.Sqrt(coordin_vect_x_1 * coordin_vect_x_1 + coordin_vect_y_1 * coordin_vect_y_1);
                double dlina_vectora_2 = Math.Sqrt(coordin_vect_x_2 * coordin_vect_x_2 + coordin_vect_y_2 * coordin_vect_y_2);

                double scalar_proizved = coordin_vect_x_1 * coordin_vect_x_2 + coordin_vect_y_1 * coordin_vect_y_2;

                double degree = Math.Acos(scalar_proizved / (dlina_vectora_1 * dlina_vectora_2));

                double napravlenie = coordin_vect_x_1 * coordin_vect_y_2 - coordin_vect_x_2 * coordin_vect_y_1;


                if (napravlenie < 0)
                {
                    degree = -degree;
                }

                total_degree += degree;
            }

            //2pi это 6.28.. радиан или 360 градусов
            return Math.Abs(total_degree - Math.PI * 2) < 0.001;
        }

        //"Невидимый" прямоугольник и закрашиване пикселей
        private void CreateRectangleAndDrawPixels(int[] vershina_x, int[] vershina_y, int kolvo_vershin)
        {
            int minX = vershina_x[0];
            int maxX = vershina_x[0];
            int minY = vershina_y[0];
            int maxY = vershina_y[0];

            for (int i = 1; i < kolvo_vershin; i++)
            {
                if (vershina_x[i] < minX)
                {
                    minX = vershina_x[i];
                }

                if (vershina_x[i] > maxX)
                {
                    maxX = vershina_x[i];
                }

                if (vershina_y[i] < minY)
                {
                    minY = vershina_y[i];
                }

                if (vershina_y[i] > maxY)
                {
                    maxY = vershina_y[i];
                }
            }

            Color figure_color = currentBorderColor;

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (PointInsideOrNot(x, y, vershina_x, vershina_y, kolvo_vershin))
                    {
                        myBitmap.SetPixel(x, y, figure_color);
                    }
                }
            }
        }

        //кнопка "Многоугольники"
        private void button4_Click(object sender, EventArgs e)
        {
            //Проверка алгоритма на выполнение
            if (checkFlag)
            {
                MessageBox.Show("Алгоритм выполнен");
                checkFlag = false;
                return;
            }

            //Отключаем кнопки 
            button1.Enabled = false;
            button2.Enabled = false;

            //Создаем новый экземпляр Bitmap размером с элемент pictureBox1 (myBitmap) на нем выводим попиксельно отрезок 
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(myBitmap))
            {
                //Заполняем фон
                g.Clear(Color.FromArgb(247, 249, 239));

                if (radioButton4.Checked == true)
                {
                    //Рисуем 5-угольник
                    CDA(100, 200, 150, 150);
                    CDA(150, 150, 200, 200);
                    CDA(200, 200, 175, 250);
                    CDA(175, 250, 125, 250);
                    CDA(100, 200, 125, 250);

                    //Рисуем 6-угольник
                    CDA(300, 350, 350, 300);
                    CDA(350, 300, 400, 300);
                    CDA(400, 300, 450, 350);
                    CDA(450, 350, 400, 400);
                    CDA(400, 400, 350, 400);
                    CDA(350, 400, 300, 350);
                }

                int[] dataX_5 = { 100, 150, 200, 175, 125 };
                int[] dataY_5 = { 200, 150, 200, 250, 250 };
                int[] dataX_6 = { 300, 350, 400, 450, 400, 350 };
                int[] dataY_6 = { 350, 300, 300, 350, 400, 400 };

                CreateRectangleAndDrawPixels(dataX_5, dataY_5, 5);
                CreateRectangleAndDrawPixels(dataX_6, dataY_6, 6);

                //Передаем полученный растр mybitmap в элемент pictureBox 
                pictureBox1.Image = myBitmap;
                //Зафиксировали, что алгоритм выполнен
                checkFlag = true;

                //Обновляем pictureBox и активируем кнопки 
                pictureBox1.Refresh();
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        //айк
        public class ContourTraversal
        {
            private Bitmap bmp;
            private int borderColorArgb;
            private bool isThick;
            private HashSet<Point> borderPts;
            private List<Point> points;
            private Stack<Point> stack;
            private int w, h;

            private Random rand = new Random();
            private int trailColorArgb;
            private int branchColorArgb;
            private int returnColorArgb;

            private static readonly Point[] dirs = new Point[]
            {
                new Point(0, -1), new Point(1, -1), new Point(1, 0), new Point(1, 1),
                new Point(0, 1), new Point(-1, 1), new Point(-1, 0), new Point(-1, -1)
            };

            public ContourTraversal(Bitmap bitmap, Color borderColor, bool thick, HashSet<Point> borderPoints = null)
            {
                bmp = bitmap;
                borderColorArgb = borderColor.ToArgb();
                isThick = thick;
                borderPts = borderPoints ?? new HashSet<Point>();
                points = new List<Point>();
                stack = new Stack<Point>();
                w = bmp.Width;
                h = bmp.Height;

                SetRandomColors();
            }

            private void SetRandomColors()
            {
                trailColorArgb = Color.FromArgb(rand.Next(100, 255), rand.Next(50, 255), rand.Next(50, 255)).ToArgb();
                branchColorArgb = Color.FromArgb(rand.Next(200, 255), rand.Next(100, 200), rand.Next(50, 150)).ToArgb();
                returnColorArgb = Color.FromArgb(rand.Next(50, 150), rand.Next(50, 150), rand.Next(200, 255)).ToArgb();
            }

            private bool IsBorder(int x, int y)
            {
                if (x < 0 || x >= w || y < 0 || y >= h) return false;
                return isThick ? borderPts.Contains(new Point(x, y)) : bmp.GetPixel(x, y).ToArgb() == borderColorArgb;
            }

            private List<Point> GetNeighbors(Point p, bool unvisited = true)
            {
                List<Point> n = new List<Point>(4);
                foreach (var d in dirs)
                {
                    int nx = p.X + d.X, ny = p.Y + d.Y;
                    if (IsBorder(nx, ny) && (!unvisited || bmp.GetPixel(nx, ny).ToArgb() != trailColorArgb))
                        n.Add(new Point(nx, ny));
                }
                return n;
            }

            public Point FindStart()
            {
                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                        if (IsBorder(x, y)) return new Point(x, y);
                return new Point(-1, -1);
            }

            // Алгоритм обхода сложного контура
            public List<Point> TraverseComplex()
            {
                points.Clear();
                stack.Clear();

                Point start = FindStart();
                if (start.X == -1) return points;

                Point cur = start;
                points.Add(cur);
                bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(trailColorArgb));

                while (true)
                {
                    var neighbors = GetNeighbors(cur, true);

                    if (neighbors.Count > 1 && points.Count > 1)
                    {
                        stack.Push(cur);
                        bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(branchColorArgb));
                    }

                    if (neighbors.Count > 0)
                    {
                        cur = neighbors[0];
                        points.Add(cur);
                        bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(trailColorArgb));
                    }
                    else if (stack.Count > 0)
                    {
                        cur = stack.Pop();
                        bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(returnColorArgb));
                    }
                    else break;

                    if (cur == start && stack.Count == 0 && points.Count > 1) break;
                }

                return points;
            }

            // Алгоритм обхода простого контура
            public List<Point> TraverseSimple()
            {
                points.Clear();

                Point start = FindStart();
                if (start.X == -1) return points;

                Point cur = start, prev = new Point(-1, -1);
                points.Add(cur);
                bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(trailColorArgb));

                while (true)
                {
                    Point next = new Point(-1, -1);
                    foreach (var d in dirs)
                    {
                        int nx = cur.X + d.X, ny = cur.Y + d.Y;
                        if (IsBorder(nx, ny) && !(nx == prev.X && ny == prev.Y) &&
                            bmp.GetPixel(nx, ny).ToArgb() != trailColorArgb)
                        {
                            next = new Point(nx, ny);
                            break;
                        }
                    }

                    if (next.X == -1) break;

                    prev = cur;
                    cur = next;
                    points.Add(cur);
                    bmp.SetPixel(cur.X, cur.Y, Color.FromArgb(trailColorArgb));

                    if (cur == start && points.Count > 1) break;
                }

                return points;
            }

            public void Recolor(Color newColor)
            {
                int newArgb = newColor.ToArgb();
                foreach (var p in points)
                {
                    int c = bmp.GetPixel(p.X, p.Y).ToArgb();
                    if (c == trailColorArgb || c == branchColorArgb || c == returnColorArgb)
                        bmp.SetPixel(p.X, p.Y, newColor);
                }
            }
        }

        // Метод запуска обхода контура с анимацией
        private async void TraverseContourWithAnimation()
        {
            //if (myBitmap == null || (!shapesDrawn && interactiveLines.Count == 0))
            //{
            //    MessageBox.Show("Сначала нарисуйте фигуры!");
            //    return;
            //}

            Color borderClr = interactiveLines.Count > 0 ? interactiveLines[0].LineColor : originalBorderColor;
            bool isThick = interactiveLines.Count > 0 ? interactiveLines[0].IsThick : shapesDrawnWithThickLine;
            HashSet<Point> borderPts = isThick ? borderPoints : null;

            Bitmap original = new Bitmap(myBitmap);
            ContourTraversal traversal = new ContourTraversal(myBitmap, borderClr, isThick, borderPts);

            bool isComplex = MessageBox.Show("Контур сложный (с пересечениями)?", "Тип контура",
                MessageBoxButtons.YesNo) == DialogResult.Yes;

            List<Point> points = isComplex ? traversal.TraverseComplex() : traversal.TraverseSimple();

            if (points.Count == 0)
            {
                MessageBox.Show("Контур не найден!");
                return;
            }

            // Анимация обхода
            for (int i = 0; i < points.Count; i++)
            {
                if (i % 3 == 0 || i == points.Count - 1)
                {
                    Bitmap display = new Bitmap(original);
                    for (int j = 0; j <= i; j++)
                    {
                        Point p = points[j];
                        display.SetPixel(p.X, p.Y, myBitmap.GetPixel(p.X, p.Y));
                    }
                    pictureBox1.Image = display;
                    pictureBox1.Refresh();
                    await Task.Delay(3);
                }
            }

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                traversal.Recolor(colorDialog.Color);
                pictureBox1.Image = myBitmap;
                pictureBox1.Refresh();
                MessageBox.Show($"Обход завершен! Пройдено точек: {points.Count}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TraverseContourWithAnimation();
        }
    }
}
