namespace Lab4
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            button26 = new Button();
            button25 = new Button();
            button24 = new Button();
            button23 = new Button();
            button22 = new Button();
            button21 = new Button();
            button20 = new Button();
            button19 = new Button();
            button18 = new Button();
            button17 = new Button();
            button16 = new Button();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(567, 794);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button26);
            groupBox1.Controls.Add(button25);
            groupBox1.Controls.Add(button24);
            groupBox1.Controls.Add(button23);
            groupBox1.Controls.Add(button22);
            groupBox1.Controls.Add(button21);
            groupBox1.Controls.Add(button20);
            groupBox1.Controls.Add(button19);
            groupBox1.Controls.Add(button18);
            groupBox1.Controls.Add(button17);
            groupBox1.Controls.Add(button16);
            groupBox1.Controls.Add(button15);
            groupBox1.Controls.Add(button14);
            groupBox1.Controls.Add(button13);
            groupBox1.Controls.Add(button12);
            groupBox1.Controls.Add(button11);
            groupBox1.Controls.Add(button10);
            groupBox1.Controls.Add(button9);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(573, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(227, 794);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button26
            // 
            button26.Location = new Point(3, 753);
            button26.Name = "button26";
            button26.Size = new Size(100, 29);
            button26.TabIndex = 25;
            button26.Text = "Старт";
            button26.UseVisualStyleBackColor = true;
            button26.Click += button26_Click;
            // 
            // button25
            // 
            button25.Location = new Point(124, 753);
            button25.Name = "button25";
            button25.Size = new Size(100, 29);
            button25.TabIndex = 24;
            button25.Text = "Очистка";
            button25.UseVisualStyleBackColor = true;
            button25.Click += button25_Click;
            // 
            // button24
            // 
            button24.Location = new Point(3, 718);
            button24.Name = "button24";
            button24.Size = new Size(221, 29);
            button24.TabIndex = 23;
            button24.Text = "Отображение YZ";
            button24.UseVisualStyleBackColor = true;
            button24.Click += button24_Click;
            // 
            // button23
            // 
            button23.Location = new Point(3, 683);
            button23.Name = "button23";
            button23.Size = new Size(221, 29);
            button23.TabIndex = 22;
            button23.Text = "Отображение XZ";
            button23.UseVisualStyleBackColor = true;
            button23.Click += button23_Click;
            // 
            // button22
            // 
            button22.Location = new Point(3, 648);
            button22.Name = "button22";
            button22.Size = new Size(221, 29);
            button22.TabIndex = 21;
            button22.Text = "Отображение XY";
            button22.UseVisualStyleBackColor = true;
            button22.Click += button22_Click;
            // 
            // button21
            // 
            button21.Dock = DockStyle.Top;
            button21.Location = new Point(3, 371);
            button21.Name = "button21";
            button21.Size = new Size(221, 29);
            button21.TabIndex = 20;
            button21.Text = "Обратно по трём осям";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // button20
            // 
            button20.Dock = DockStyle.Top;
            button20.Location = new Point(3, 342);
            button20.Name = "button20";
            button20.Size = new Size(221, 29);
            button20.TabIndex = 19;
            button20.Text = "Перемещение по трём осям";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // button19
            // 
            button19.Dock = DockStyle.Top;
            button19.Location = new Point(3, 313);
            button19.Name = "button19";
            button19.Size = new Size(221, 29);
            button19.TabIndex = 18;
            button19.Text = " Назад по оси ОZ";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button18
            // 
            button18.Dock = DockStyle.Top;
            button18.Location = new Point(3, 284);
            button18.Name = "button18";
            button18.Size = new Size(221, 29);
            button18.TabIndex = 17;
            button18.Text = "Вперед по оси ОZ";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button17
            // 
            button17.Dock = DockStyle.Top;
            button17.Location = new Point(3, 255);
            button17.Name = "button17";
            button17.Size = new Size(221, 29);
            button17.TabIndex = 16;
            button17.Text = "Вниз по оси ОY";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button16
            // 
            button16.Dock = DockStyle.Top;
            button16.Location = new Point(3, 226);
            button16.Name = "button16";
            button16.Size = new Size(221, 29);
            button16.TabIndex = 15;
            button16.Text = "Вверх по оси ОY";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button15
            // 
            button15.Location = new Point(3, 613);
            button15.Name = "button15";
            button15.Size = new Size(221, 29);
            button15.TabIndex = 14;
            button15.Text = "Уменьшение по Z";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button14
            // 
            button14.Location = new Point(3, 584);
            button14.Name = "button14";
            button14.Size = new Size(221, 29);
            button14.TabIndex = 13;
            button14.Text = "Увеличение по Z";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button13
            // 
            button13.Location = new Point(3, 555);
            button13.Name = "button13";
            button13.Size = new Size(221, 29);
            button13.TabIndex = 12;
            button13.Text = "Уменьшение по У";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.Location = new Point(3, 526);
            button12.Name = "button12";
            button12.Size = new Size(221, 29);
            button12.TabIndex = 11;
            button12.Text = "Увеличение по У";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Location = new Point(3, 497);
            button11.Name = "button11";
            button11.Size = new Size(221, 29);
            button11.TabIndex = 10;
            button11.Text = "Уменьшение по Х";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(3, 468);
            button10.Name = "button10";
            button10.Size = new Size(221, 29);
            button10.TabIndex = 9;
            button10.Text = "Увеличение по Х";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(3, 439);
            button9.Name = "button9";
            button9.Size = new Size(221, 29);
            button9.TabIndex = 8;
            button9.Text = "Уменьшение по трём осям";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Location = new Point(3, 406);
            button8.Name = "button8";
            button8.Size = new Size(221, 29);
            button8.TabIndex = 7;
            button8.Text = "Увеличение по трём осям";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.Location = new Point(3, 197);
            button7.Name = "button7";
            button7.Size = new Size(221, 29);
            button7.TabIndex = 6;
            button7.Text = "Влево по оси ОХ";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.Location = new Point(3, 168);
            button6.Name = "button6";
            button6.Size = new Size(221, 29);
            button6.TabIndex = 5;
            button6.Text = "Вправо по оси ОХ";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.Location = new Point(3, 139);
            button5.Name = "button5";
            button5.Size = new Size(221, 29);
            button5.TabIndex = 4;
            button5.Text = "Поворот по оси ОZ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.Location = new Point(3, 110);
            button4.Name = "button4";
            button4.Size = new Size(221, 29);
            button4.TabIndex = 3;
            button4.Text = "Поворот по оси ОУ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.Location = new Point(3, 81);
            button3.Name = "button3";
            button3.Size = new Size(221, 29);
            button3.TabIndex = 2;
            button3.Text = "Поворот по оси ОХ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.Location = new Point(3, 52);
            button2.Name = "button2";
            button2.Size = new Size(221, 29);
            button2.TabIndex = 1;
            button2.Text = "Фигура";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(3, 23);
            button1.Name = "button1";
            button1.Size = new Size(221, 29);
            button1.TabIndex = 0;
            button1.Text = "Оси";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick; 
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 794);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "ЛАБОРАТОРНАЯ РАБОТА №4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button8;
        private Button button7;
        private Button button9;
        private Button button10;
        private Button button12;
        private Button button11;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button19;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button button20;
        private Button button21;
        private Button button24;
        private Button button23;
        private Button button22;
        private System.Windows.Forms.Timer timer1;
        private Button button25;
        private Button button26;
    }
}
