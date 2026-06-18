using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Task
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 lab31_form = new Form6();
            lab31_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 lab32_form = new Form7();
            lab32_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 lab33_form = new Form8();
            lab33_form.Show();
        }
    }
}
