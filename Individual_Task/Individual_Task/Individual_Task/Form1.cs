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
            MessageBox.Show("Здесь пока что пусто.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь пока что пусто.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь пока что пусто.");
        }
    }
}
