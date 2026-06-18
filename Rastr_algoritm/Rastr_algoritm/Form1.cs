using System.Drawing;

namespace Rastr_algoritm
{
    public partial class Form1 : Form
    {
        public int xn, yn, xk, yk; //концы отрезка
        Bitmap myBitmap; // Объект Bitmap для вывода отрезка 
        Color currentBorderColor = Color.Red; //текущий цвет отрезка и текущий цвет заливки 
        Color changedColor = Color.Black;
        int size;
        bool checkFlag = false;
        public Form1()
        {
            InitializeComponent();
            size = 1;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //Если выбран алгориитм рисования, то запоминаем начальные координаты
            if (radioButton1.Checked == true || radioButton3.Checked == true)
            {
                xn = e.X; //точка начала, координата Х
                yn = e.Y; //точка начала, координата Y
            }

            //Если выбран алгоритм заливки
            else if (radioButton2.Checked)
            {
                //Проверка, что есть изображение для заливки
                if (myBitmap != null)
                {
                    //Заливка
                    FloodFill(e.X, e.Y);
                    //Обновляем изображение в pictureBox
                    pictureBox1.Image = myBitmap;
                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
            }
        }

        //Обработчик отпускания мыши на PictureBox
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Если не выбран алгоритм рисования, то ничего не делаем
            if (!radioButton1.Checked && !radioButton3.Checked)
            {
                return;
            }

            if (myBitmap == null)
            {
                myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                //Объявляем объект "g" класса Graphics для создания фона 
                using (Graphics g = Graphics.FromImage(myBitmap))
                {
                    //Заполняем фон
                    g.Clear(Color.FromArgb(247, 249, 239));
                }
            }

            //Проверяем выбранный режим рисования
            if (radioButton3.Checked)
            {
                //Рисуем толстую линию
                FatLine(xn, yn, e.X, e.Y);
            }
            else //Режим обычной линии
            {
                CDA(xn, yn, e.X, e.Y);
            }

            //Обновляем изображение в PictureBox
            pictureBox1.Image = myBitmap;
        }

        //Кнопка "Очистить"
        private void button1_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //Задаем цвет пикселя по схеме RGB(от 0 до 255 для каждого цвета) 
            Color newPixelColor = Color.FromArgb(247, 249, 239);

            for (int x = 0; x < myBitmap.Width; x++)
            {
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    myBitmap.SetPixel(x, y, newPixelColor);
                }
            }

            pictureBox1.Image = myBitmap;
            //pictureBox1.Image = null;

            checkFlag = false;
        }


        //Вывод отрезка
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
            numberNodes = 3000;

            //Устанавливаем начальную точку
            xOutput = xn;
            yOutput = yn;

            //Цикл для рисования, закрашивает квадрат size x size
            for (index = 1; index <= numberNodes; index++)
            {
                //Смещение по оси X
                for (int a = 0; a < size; a++)
                {
                    //Смещение по оси Y
                    for (int b = 0; b < size; b++)
                    {
                        int x = (int)xOutput + a;
                        int y = (int)yOutput + b;

                        //Проверяет, что пиксель находится в пределах изображения
                        if (x >= 0 && y >= 0 &&
                            x < myBitmap.Width &&
                            y < myBitmap.Height)
                        {
                            //Устанавливаем цвет текущего пикселя
                            myBitmap.SetPixel(x, y, currentBorderColor);
                        }
                    }
                }

                //Двигаемся к следующему узлу линии
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }


        //Алгоритм рисования толстой линии
        private void FatLine(int xStart, int yStart, int xEnd, int yEnd)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            dx = xEnd - xStart;
            dy = yEnd - yStart;
            numberNodes = 3000;
            xOutput = xStart;
            yOutput = yStart;

            for (index = 1; index <= numberNodes; index++)
            {
                for (int a = -1; a <= 1; a++)
                {
                    for (int b = -1; b <= 1; b++)
                    {
                        int x = (int)xOutput + a;
                        int y = (int)yOutput + b;

                        if (x >= 0 && y >= 0 &&
                            x < myBitmap.Width &&
                            y < myBitmap.Height)
                        {
                            myBitmap.SetPixel(x, y, currentBorderColor);
                        }
                    }
                }

                //Двигаемся к следующему узлу линии
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }


        //Кнопка "Выполнить"
        private void button2_Click(object sender, EventArgs e)
        {
            //Проверка алгоритма на выполнение
            if (checkFlag)
            {
                MessageBox.Show("Алгоритм выполнен");
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

                if (radioButton1.Checked == true)
                {
                    //Рисуем прямоугольник 
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);

                    //Рисуем треугольник 
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);
                }
                else if (radioButton3.Checked == true)
                {
                    FatLine(10, 10, 10, 110);
                    FatLine(10, 10, 110, 10);
                    FatLine(10, 110, 110, 110);
                    FatLine(110, 10, 110, 110);

                    FatLine(150, 10, 150, 200);
                    FatLine(250, 50, 150, 200);
                    FatLine(150, 10, 250, 150);
                }
                else if (radioButton2.Checked == true)
                {
                    //Задаем координаты затравки для заливки
                    xn = 160;
                    yn = 40;

                    //Вызываем рекурсивную процедуру заливки с затравкой 
                    FloodFill(xn, yn);
                }
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

        //Заливка с затравкой (рекурсивная)
        private void FloodFill(int x1, int y1)
        {
            //Проверка на то, что точка находится внутри изображения 
            if (x1 < 0 || y1 < 0 || x1 >= myBitmap.Width || y1 >= myBitmap.Height)
            {
                return;
            }

            //Получаем цвет текущего пикселя с координатами x1, y1 
            Color oldPixelColor = myBitmap.GetPixel(x1, y1);
            //Сравнение цветов происходит в формате RGB 
            //Для этого используем метод ToArgb объекта Color 
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb())
            && (oldPixelColor.ToArgb() != changedColor.ToArgb()))
            {
                //Перекрашиваем пиксель 
                myBitmap.SetPixel(x1, y1, changedColor);
                //Вызываем метод для 4-х соседних пикселей 
                FloodFill(x1 + 1, y1); //справа
                FloodFill(x1 - 1, y1); //слева
                FloodFill(x1, y1 + 1); //вниз
                FloodFill(x1, y1 - 1); //вверх
            }
        }

        //Кнопка "Цвет линии"
        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) ;
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        //Кнопка "Цвет заливки"
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = colorDialog1.ShowDialog();
            if (dialogResult2 == DialogResult.OK)
            {
                changedColor = colorDialog1.Color;
            }
        }
        
        //Находится ли точка внутри или нет
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
                    degree = - degree;
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

            Color figure_color = Color.Green;

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
        private void button5_Click(object sender, EventArgs e)
        {
            //Проверка алгоритма на выполнение
            if (checkFlag)
            {
                MessageBox.Show("Алгоритм выполнен");
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
    }
}
