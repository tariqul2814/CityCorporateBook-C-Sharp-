using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace citycorporate
{
    public partial class Confirm : Form
    {
        public string random;
        public string id;
        public Confirm()
        {
            InitializeComponent();
        }

        public Confirm(string id,string ran)
        {
            InitializeComponent();
            random = ran;
            this.id = id;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string x = textBox1.Text;
            if (x.Equals(random))
            {
                this.Hide();
                MessageBox.Show("Successfully Matched", "STATUS");
                PasswordChange p = new PasswordChange(id);
                p.Show();
                

            }
            else
                MessageBox.Show("CHECK YOUR ID OR NUMBER", "STATUS");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
