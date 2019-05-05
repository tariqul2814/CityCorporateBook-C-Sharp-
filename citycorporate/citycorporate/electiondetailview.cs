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
    public partial class electiondetailview : Form
    {
        string id = "";
        string name = "";
        string address = "";
        string dob = "";
        string gender = "";
        string bloodgroup = "";
        string email = "";
        string photoadd = "";
        string workarea ="";

        public void verifyidenty()
        {
            if (id[0] == 'M' && id[1] == 'e')
            {
                label4.Text = "MEMBER";
                string id1 = "";
                for (int i = 3; i <= 7; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
            else if (id[0] == 'M')
            {
                label4.Text = "MAYOR";
                string id1 = "";
                for (int i = 2; i <= 6; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
            else if (id[0] == 'C')
            {
                label4.Text = "COUNCILOR";
                string id1 = "";
                for (int i = 2; i <= 6; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
        }
        public electiondetailview(string id,string name,string address,string dob,string gender,string bloodgroup,string email,string photoadd,string workarea)
        {
            InitializeComponent();
            this.id = id.Trim();
            label5.Text = name.Trim();
            label7.Text = address.Trim();
            label9.Text = dob.Trim();
            label11.Text = gender.Trim();
            label13.Text = bloodgroup.Trim();
            label15.Text = email.Trim();
            photoadd = photoadd.Trim();
            Image image = Image.FromFile(photoadd);

            pictureBox1.Image = image;

            label19.Text = workarea.Trim();
            verifyidenty();
        }

        public electiondetailview(string id,string name, string address, string dob, string gender, string bloodgroup, string email, string photoadd)
        {
            InitializeComponent();
            label19.Hide();
            label18.Hide();
            this.id = id.Trim();
            label5.Text = name.Trim();
            label7.Text = address.Trim();
            label9.Text = dob.Trim();
            label11.Text = gender.Trim();
            label13.Text = bloodgroup.Trim();
            label15.Text = email.Trim();
            photoadd = photoadd.Trim();
            Image image = Image.FromFile(photoadd);

            pictureBox1.Image = image;
            label18.Text = "";
            label19.Text = "";
            verifyidenty();
        }

        private void electiondetailview_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void electiondetailview_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            electiondetail elec = new electiondetail();
            elec.Show();
        }
    }
}
