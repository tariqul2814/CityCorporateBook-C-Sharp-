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
    public partial class mayorwatchpost : Form
    {
        string id = "";
        SqlConnection con;
        public mayorwatchpost()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            fetchdata();
        }

        public mayorwatchpost(string id)
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            this.id = id;
            fetchdata();
        }

        public void fetchdata()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select serialno,id,message from mirpurmemberpost", con);
                SqlDataAdapter da = new SqlDataAdapter(str);

                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }

        public void fetchdatamayor()
        {

            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select serialno,id,message from mirpurmemberpost where pidentity ='MAYOR'", con);
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
                SqlCommand str = new SqlCommand("Select serialno,id,message from mirpurmemberpost where pidentity ='MEMBER'", con);
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
                SqlCommand str = new SqlCommand("Select serialno,id,message from mirpurmemberpost where pidentity ='COUNCILOR'", con);
                SqlDataAdapter da = new SqlDataAdapter(str);

                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }

        private void mayorwatchpost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mayorwatchpost_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayoropening m1 = new mayoropening(id);
            m1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
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
    }
}
