namespace Individual_Task
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 13.8F);
            button1.Location = new Point(43, 55);
            button1.Name = "button1";
            button1.Size = new Size(366, 85);
            button1.TabIndex = 0;
            button1.Text = "Движение парусной лодки и полет чайки на фоне заката солнца";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 13.8F);
            button2.Location = new Point(43, 181);
            button2.Name = "button2";
            button2.Size = new Size(366, 69);
            button2.TabIndex = 1;
            button2.Text = "Шестиугольник, растущий из центра экрана";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 13.8F);
            button3.Location = new Point(43, 299);
            button3.Name = "button3";
            button3.Size = new Size(366, 75);
            button3.TabIndex = 2;
            button3.Text = "Восьмиугольник, уменьшающийся с краев экрана ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(171, 26);
            label1.Name = "label1";
            label1.Size = new Size(107, 26);
            label1.TabIndex = 3;
            label1.Text = "Задание 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(171, 152);
            label2.Name = "label2";
            label2.Size = new Size(107, 26);
            label2.TabIndex = 4;
            label2.Text = "Задание 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(171, 261);
            label3.Name = "label3";
            label3.Size = new Size(107, 26);
            label3.TabIndex = 5;
            label3.Text = "Задание 3";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 403);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}