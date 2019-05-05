using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace citycorporate
{
    public partial class electionopeningform : Form
    {
        public electionopeningform()
        {
            InitializeComponent();
        }

        private void electionopeningform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            electionadd es = new electionadd();
            es.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            electiondetail elct = new electiondetail();
            elct.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            updelform up = new updelform();
            up.Show();
        }
    }
}
