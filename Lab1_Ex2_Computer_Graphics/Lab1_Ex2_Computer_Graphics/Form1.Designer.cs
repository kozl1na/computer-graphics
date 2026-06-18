namespace Lab1_Ex2_Computer_Graphics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 42);
            button1.Name = "button1";
            button1.Size = new Size(144, 29);
            button1.TabIndex = 0;
            button1.Text = "Ввод матрицы 1...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 77);
            button2.Name = "button2";
            button2.Size = new Size(144, 29);
            button2.TabIndex = 1;
            button2.Text = "Ввод матрицы 2...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 135);
            button3.Name = "button3";
            button3.Size = new Size(324, 29);
            button3.TabIndex = 2;
            button3.Text = "Результат умножения...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 241);
            button4.Name = "button4";
            button4.Size = new Size(324, 29);
            button4.TabIndex = 3;
            button4.Text = "Сохранить в файле “Res_Matr.txt”";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 4;
            label1.Text = "n = ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 46);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 81);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 27);
            textBox1.TabIndex = 7;
            // 
            // button5
            // 
            button5.Location = new Point(12, 170);
            button5.Name = "button5";
            button5.Size = new Size(324, 29);
            button5.TabIndex = 8;
            button5.Text = "Результат сложения...";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 205);
            button6.Name = "button6";
            button6.Size = new Size(324, 29);
            button6.TabIndex = 9;
            button6.Text = "Результат вычитания...";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 284);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Произведение матриц";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button5;
        private Button button6;
    }
}
