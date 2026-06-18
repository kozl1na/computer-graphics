namespace Lab1_Computer_Graphics
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
            btnHello = new Button();
            labelHello = new Label();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnHello
            // 
            btnHello.Location = new Point(86, 256);
            btnHello.Name = "btnHello";
            btnHello.Size = new Size(156, 29);
            btnHello.TabIndex = 0;
            btnHello.Text = "PRESS";
            btnHello.UseVisualStyleBackColor = true;
            btnHello.Click += buttonHello_Click;
            // 
            // labelHello
            // 
            labelHello.AutoSize = true;
            labelHello.Location = new Point(137, 210);
            labelHello.Name = "labelHello";
            labelHello.Size = new Size(63, 20);
            labelHello.TabIndex = 1;
            labelHello.Text = "PHRASE";
            // 
            // button1
            // 
            button1.Location = new Point(417, 271);
            button1.Name = "button1";
            button1.Size = new Size(156, 29);
            button1.TabIndex = 2;
            button1.Text = "Show Form 2";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(456, 210);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 3;
            label1.Text = "Result =";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(labelHello);
            Controls.Add(btnHello);
            Name = "Form1";
            Text = "Form1_Computer_Graphics";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHello;
        private Label labelHello;
        private Button button1;
        private Label label1;
    }
}
