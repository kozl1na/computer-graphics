namespace Individual_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 lab1_form = new Form2();
            lab1_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 lab2_form = new Form4();
            lab2_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 lab3_form = new Form5();
            lab3_form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 lab4_form = new Form9();
            lab4_form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
