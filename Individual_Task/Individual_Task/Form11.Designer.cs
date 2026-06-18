namespace Individual_Task
{
    partial class Form11
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBarWidth;
        private System.Windows.Forms.TrackBar trackBarDash;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            trackBarWidth = new TrackBar();
            trackBarDash = new TrackBar();
            buttonColor = new Button();
            buttonReset = new Button();
            colorDialog1 = new ColorDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarDash).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(700, 500);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Сплошная ", "Толстая", "Пунктир" });
            comboBox1.Location = new Point(730, 40);
            comboBox1.SelectedIndex = 0;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // trackBarWidth
            // 
            trackBarWidth.Location = new Point(730, 100);
            trackBarWidth.Minimum = 1;
            trackBarWidth.Name = "trackBarWidth";
            trackBarWidth.Size = new Size(120, 56);
            trackBarWidth.TabIndex = 2;
            trackBarWidth.Value = 2;
            trackBarWidth.Scroll += trackBarWidth_Scroll;
            // 
            // trackBarDash
            // 
            trackBarDash.Location = new Point(730, 180);
            trackBarDash.Maximum = 20;
            trackBarDash.Minimum = 2;
            trackBarDash.Name = "trackBarDash";
            trackBarDash.Size = new Size(120, 56);
            trackBarDash.TabIndex = 3;
            trackBarDash.Value = 6;
            trackBarDash.Scroll += trackBarDash_Scroll;
            // 
            // buttonColor
            // 
            buttonColor.Location = new Point(730, 240);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(120, 30);
            buttonColor.TabIndex = 4;
            buttonColor.Text = "Цвет";
            buttonColor.Click += buttonColor_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(730, 290);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(120, 30);
            buttonReset.TabIndex = 5;
            buttonReset.Text = "Сброс";
            buttonReset.Click += buttonReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(730, 20);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 6;
            label1.Text = "Тип линии";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(730, 80);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 7;
            label2.Text = "Толщина линии";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(730, 160);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 8;
            label3.Text = "Шаг пунктира";
            // 
            // Form11
            // 
            ClientSize = new Size(900, 540);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox1);
            Controls.Add(trackBarWidth);
            Controls.Add(trackBarDash);
            Controls.Add(buttonColor);
            Controls.Add(buttonReset);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Name = "Form11";
            Text = "Form11";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarDash).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}