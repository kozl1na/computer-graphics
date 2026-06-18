using System.IO;
using System.Text;

namespace Lab1_Ex2_Computer_Graphics
{
    public partial class Form1 : Form
    {
        const int MaxN = 10;
        int n = 3;
        TextBox[,] MatrText = null;

        double[,] Matr1 = new double[MaxN, MaxN];
        double[,] Matr2 = new double[MaxN, MaxN];
        double[,] Matr3 = new double[MaxN, MaxN];

        bool f1;
        bool f2;

        int dx = 40, dy = 20;   

        Form2 form2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            textBox1.Text = "";
            f1 = f2 = false; 
            label2.Text = "false";
            label3.Text = "false";
            
            int i, j;
           
            form2 = new Form2();
            
            MatrText = new TextBox[MaxN, MaxN];
            
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    
                    MatrText[i, j] = new TextBox();
                    
                    MatrText[i, j].Text = "0";
                    
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i *
                    dx, 10 + j * dy);
                   
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    
                    MatrText[i, j].Visible = false;
                    
                    form2.Controls.Add(MatrText[i, j]);
                }
        }

        private void Clear_MatrText()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Text = "0";
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            Clear_MatrText();


            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }

            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;

            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;

            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                        {
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        }
                        else
                        {
                            Matr1[i, j] = 0;
                        }

                f1 = true;
                label2.Text = "true";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            Clear_MatrText();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }

            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;

            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;

            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                    }

                f2 = true;
                label3.Text = "true";
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);

            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true))) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                    }
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            form2.ShowDialog();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true))) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] + Matr2[i, j];
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true))) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] - Matr2[i, j];
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив     

            fw = new FileStream("Res_Matr.txt", FileMode.Create);

            //Сначала записать число элементов матрицы Matr3    
            msg = n.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte    
            msgByte = Encoding.Default.GetBytes(msg);
            // запись массива msgByte в файл    
            fw.Write(msgByte, 0, msgByte.Length);
            //Теперь записать саму матрицу    
            msg = "";

            for (int j = 0; j < n; j++)
            {
                // формируем строку msg из элементов матрицы      
                for (int i = 0; i < n; i++)
                {
                    msg = msg + Matr3[i, j].ToString() + "  ";
                }

                msg = msg + "\r\n";
                // добавить перевод строки    
            }
            // 3. Перевод строки msg в байтовый массив msgByte    
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. запись строк матрицы в файл    
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. Закрыть файл    
            if (fw != null)
            {
                fw.Close();
            }
        }

    }
}
