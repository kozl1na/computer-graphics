namespace Lab1_Computer_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonHello_Click(object sender, EventArgs e)
        {
            labelHello.Text = "Hello World!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Result = OK!";
            }    
            else
            {
                label1.Text = "Result = Cancel!"; 
            }
        }
    }
}
