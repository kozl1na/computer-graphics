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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 lab4_ike_form = new Form10();
            lab4_ike_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 lab4_egor_form = new Form11();
            lab4_egor_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 lab4_alex_form = new Form12();
            lab4_alex_form.Show();
        }
    }
}
