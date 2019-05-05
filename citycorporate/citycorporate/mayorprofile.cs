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
    public partial class mayorprofile : Form
    { 
        SqlConnection con;
        string rec = "";
        string name = "";
        string id = "";
        string address = "";
        string dob = "";
        string gender = "";
        string bloodgroup = "";
        string email = "";
        string photoadd = "";
        string workarea = "";
        string searchid = "";

        public mayorprofile()
        {
            
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            //con.Open();
            verifyidenty();
            collect();
        }

        public mayorprofile(string id)
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            //con.Open();
            this.id = id;
            verifyidenty();
            collect();
        }

        public void verifyidenty()
        {
            //MessageBox.Show("Enter in Verifyindenty");
            if (id[0] == 'M' && id[1] == 'e')
            {
                label18.Text = "MEMBER";
                string id1 = "";
                for (int i = 3; i <= 7; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
            else if (id[0] == 'M')
            {
                label18.Text = "MAYOR";
                string id1 = "";
                for (int i = 2; i <= 6; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
            else if (id[0] == 'C')
            {
                label18.Text = "COUNCILOR";
                string id1 = "";
                for (int i = 2; i <= 6; i++)
                {
                    id1 += id[i];
                }
                label17.Text = id1;
            }
        }

        public void collect()
        {
            //MessageBox.Show("Enter in Collect");

            searchid = id;
            searchid = searchid.Trim();
            ///MessageBox.Show(searchid + " " + searchid[0] + " " + searchid[1]);

            try
            {
                if (searchid[0] == 'M' && searchid[1] == 'e')
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand str = new SqlCommand("Select * from memberinfo where memberid = '" + searchid + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    da.Fill(dt);
                    //MessageBox.Show("Success");
                    id = searchid;

                    name = dt.Rows[0]["name"].ToString();
                    label10.Text = name.Trim();
                    address = dt.Rows[0]["address"].ToString();
                    label11.Text = address.Trim();
                    dob = dt.Rows[0]["dob"].ToString();
                    label12.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();
                    //MessageBox.Show(gender);
                    label13.Text = gender;
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    label14.Text = bloodgroup.Trim();
                    email = dt.Rows[0]["email"].ToString();
                    label15.Text = email.Trim();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    pictureBox1.Image = new Bitmap(photoadd.Trim());
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    //MessageBox.Show("End Success");
                    con.Close();
                }

                else if (searchid[0] == 'M')
                {

                    DataTable dt = new DataTable();
                    con.Open();
                    //MessageBox.Show(searchid);
                    SqlCommand str = new SqlCommand("Select * from mayorinfo where mayorid = '" + searchid + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    da.Fill(dt);
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    //MessageBox.Show("Cross Sql");

                    id = searchid;

                    name = dt.Rows[0]["name"].ToString();
                    label10.Text = name.Trim();
                    address = dt.Rows[0]["address"].ToString();
                    label11.Text = address.Trim();
                    dob = dt.Rows[0]["dob"].ToString();
                    label12.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();
                    //MessageBox.Show(gender);
                    label13.Text = gender;
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    label14.Text = bloodgroup.Trim();
                    email = dt.Rows[0]["email"].ToString();
                    label15.Text = email.Trim();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    pictureBox1.Image = new Bitmap(photoadd.Trim());
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    //MessageBox.Show("End Success");
                    con.Close();

                }
                else if (searchid[0] == 'C')
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand str = new SqlCommand("Select * from councilorinfo where councilorid = '" + searchid + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    da.Fill(dt);
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    id = searchid;

                    name = dt.Rows[0]["name"].ToString();
                    label10.Text = name.Trim();
                    address = dt.Rows[0]["address"].ToString();
                    label11.Text = address.Trim();
                    dob = dt.Rows[0]["dob"].ToString();
                    label12.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();

                    //MessageBox.Show(gender);
                    label13.Text = gender;
                    
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    label14.Text = bloodgroup.Trim();
                    email = dt.Rows[0]["email"].ToString();
                    label15.Text = email.Trim();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    pictureBox1.Image = new Bitmap(photoadd.Trim());
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    //MessageBox.Show("End Success");
                    con.Close();
                }

                else
                {
                    con.Close();
                    MessageBox.Show("Invalid ID");
                }

            }
            catch (Exception exe) { con.Close();  MessageBox.Show(exe.Message); }

        }

        private void mayorprofile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mayorprofile_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void update()
        {
            if (textBox1.Text!=null)
            {
                try
                {
                    if (searchid[0] == 'M' && searchid[1] == 'e')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE Password set password = '" + textBox1.Text.Trim()+ "' where id = '"+searchid+"'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();
                        textBox1.Text= "";
                        
                        con.Close();

                        MessageBox.Show("Successful");
                    }
                    else if (searchid[0] == 'M')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE Password set password = '" + textBox1.Text.Trim() + "' where id = '" + searchid + "'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();
                        textBox1.Text = "";

                        con.Close();
                        MessageBox.Show("Successful");

                    }
                    else if (searchid[0] == 'C')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE Password set password = '" + textBox1.Text.Trim() + "' where id = '" + searchid + "'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();
                        textBox1.Text = "";
                        con.Close();
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Invalid");
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Invalid");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayoropening m1 = new mayoropening(id);
            m1.Show();
        }
    }
}
