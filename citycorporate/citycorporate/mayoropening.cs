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
    public partial class mayoropening : Form
    {
        string id="";
        public mayoropening()
        {
            InitializeComponent();
            
        }

        public mayoropening(string id)
        {
            InitializeComponent();
            this.id = id;

        }

        private void mayoropening_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayorprofile m = new mayorprofile(id);
            m.Show();
        }

        private void mayoropening_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayorwritepost m1 = new mayorwritepost(id);
            m1.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            mypost m1 = new mypost(id);
            m1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayorwatchpost m1 = new mayorwatchpost(id);
            m1.Show();

        }
    }
}
