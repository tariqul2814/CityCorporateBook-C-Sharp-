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
    public partial class electiondetail : Form
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

        public electiondetail()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            button4.Hide();
        }

        private void electiondetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            electionopeningform elop = new electionopeningform();
            elop.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f3 = new Form1();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchid;
            searchid = textBox1.Text;
   
            textBox1.Text = "";
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
                    address = dt.Rows[0]["address"].ToString();
                    dob = dt.Rows[0]["dob"].ToString();
                    gender = dt.Rows[0]["gender"].ToString();
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    dataGridView1.DataSource = dt;
                    //MessageBox.Show("End Success");
                    con.Close();
                    rec = textBox1.Text;
                    

                    button4.Show();
                }

                else if (searchid[0] == 'M')
                {
                    
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand str = new SqlCommand("Select * from mayorinfo where mayorid = '" + searchid + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    da.Fill(dt);
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());
                    
                    id = searchid;
                    name = dt.Rows[0]["name"].ToString();
                    address = dt.Rows[0]["address"].ToString();
                    dob = dt.Rows[0]["dob"].ToString();
                    gender = dt.Rows[0]["gender"].ToString();
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    dataGridView1.DataSource = dt;
                    //MessageBox.Show("UnSuccess");
                    con.Close();
                    rec = textBox1.Text;
                    button4.Show();

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
                    address = dt.Rows[0]["address"].ToString();
                    dob = dt.Rows[0]["dob"].ToString();
                    gender = dt.Rows[0]["gender"].ToString();
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    workarea = dt.Rows[0]["workarea"].ToString();
                    dataGridView1.DataSource = dt;
                    con.Close();
                    rec = textBox1.Text;
                    button4.Show();
                }

                else
                {
                    MessageBox.Show("Invalid ID");
                }

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID"); }
        }

        public void fetchdatamayor()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select * from memberinfo", con);
                SqlDataAdapter da = new SqlDataAdapter(str);

                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }

        public void fetchdataMember()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select * from mayorinfo", con);
                SqlDataAdapter da = new SqlDataAdapter(str);

                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }
        public void fetchdataCouncilor()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select * from councilorinfo", con);
                SqlDataAdapter da = new SqlDataAdapter(str);

                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (workarea == "")
            {
                electiondetailview elv = new electiondetailview(id, name, address, dob, gender, bloodgroup, email, photoadd);
                elv.Show();
            }
            else
            {
                electiondetailview elv = new electiondetailview(id, name, address, dob, gender, bloodgroup, email, photoadd,workarea);
                elv.Show();
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void electiondetail_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fetchdatamayor();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fetchdataCouncilor();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fetchdataMember();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
