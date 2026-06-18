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
    public partial class Form3 : Form
    {
        public TextBox[,] MatrText;
        public int Rows, Columns;
        int dx = 40, dy = 20;

        public Form3(int rows, int columns)
        {
            InitializeComponent();
            Rows = rows;
            Columns = columns;

            MatrText = new TextBox[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new Point(10 + j * dx, 10 + i * dy);
                    MatrText[i, j].Size = new Size(dx, dy);
                    Controls.Add(MatrText[i, j]);
                }

            button1.Top = 50 + rows * dy;
            button1.Left = 20;
            button1.Width = columns * dx;
            button1.DialogResult = DialogResult.OK;

            Width = button1.Left + button1.Width + 50;
            Height = button1.Top + button1.Height + 50;


        }
    }
}
