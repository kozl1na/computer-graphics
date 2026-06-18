namespace Individual_Task
{
    partial class Form7
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
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
            pictureBox1.Size = new Size(531, 564);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(537, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(162, 564);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(13, 139);
            button2.Name = "button2";
            button2.Size = new Size(143, 35);
            button2.TabIndex = 3;
            button2.Text = "Очистить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(16, 99);
            button1.Name = "button1";
            button1.Size = new Size(140, 35);
            button1.TabIndex = 2;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 26);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Угол:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 564);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Form7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Индивидульный вариант";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
