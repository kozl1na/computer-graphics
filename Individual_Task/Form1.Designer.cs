namespace Individual_Task
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(1, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 23);
            label1.TabIndex = 0;
            label1.Text = "Группа:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(1, 57);
            label2.Name = "label2";
            label2.Size = new Size(153, 23);
            label2.TabIndex = 1;
            label2.Text = "Состав команды:";
            // 
            // button1
            // 
            button1.Location = new Point(22, 218);
            button1.Name = "button1";
            button1.Size = new Size(316, 49);
            button1.TabIndex = 2;
            button1.Text = "Лабораторная работа №1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(22, 273);
            button2.Name = "button2";
            button2.Size = new Size(316, 49);
            button2.TabIndex = 3;
            button2.Text = "Лабораторная работа №2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 328);
            button3.Name = "button3";
            button3.Size = new Size(316, 49);
            button3.TabIndex = 4;
            button3.Text = "Лабораторная работа №3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(22, 383);
            button4.Name = "button4";
            button4.Size = new Size(316, 49);
            button4.TabIndex = 5;
            button4.Text = "Лабораторная работа №4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(2, 27);
            label3.Name = "label3";
            label3.Size = new Size(53, 23);
            label3.TabIndex = 6;
            label3.Text = "584-1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(2, 92);
            label4.Name = "label4";
            label4.Size = new Size(242, 23);
            label4.TabIndex = 7;
            label4.Text = "Дарбинян Айк Меружанович";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(4, 125);
            label5.Name = "label5";
            label5.Size = new Size(234, 23);
            label5.TabIndex = 8;
            label5.Text = "Козлов Егор Александрович";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(4, 157);
            label6.Name = "label6";
            label6.Size = new Size(237, 23);
            label6.TabIndex = 9;
            label6.Text = "Шилов Алексей Дмитриевич";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 457);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "КОМПЬЮТЕРНАЯ ГРАФИКА";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
