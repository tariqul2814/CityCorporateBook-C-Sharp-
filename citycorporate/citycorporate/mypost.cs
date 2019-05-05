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
    public partial class mypost : Form
    {
        string id = "";
        SqlConnection con;
        public mypost()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            fetchdata();
        }

        public mypost(string id)
        {
            InitializeComponent();
            this.id = id;
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            fetchdata();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mypost_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayoropening m1 = new mayoropening(id);
            m1.Show();
        }

        public void update()
        {
            try
            {
                con.Open();
                SqlCommand str = new SqlCommand("Update mirpurmemberpost Set message='" + richTextBox1.Text + "' where Id='" + id+ "' and serialno ='"+textBox1.Text+"'", con);

                str.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e) { con.Close(); MessageBox.Show(e.Message); }
        }

        public void fetchdata()
        {
           
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                SqlCommand str = new SqlCommand("Select * from mirpurmemberpost where id = '" + id + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(str);
                
                //MessageBox.Show("End Success");
                //con.Close();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID For DataGrid"); }
        }

        public void delete()
        {
           if(textBox1.Text!=null)
            {
                try
                {
                    //DELETE FROM table_name WHERE condition;
                    con.Open();
                    SqlCommand str = new SqlCommand("Delete from mirpurmemberpost where id= '" + id + "' and serialno = '" + textBox1.Text + "'", con);

                    str.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID for delete"); }
            }
        }

        public void fetchmessage()
        {
            if(textBox1.Text!=null)
            {
                try
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand str = new SqlCommand("Select * from mirpurmemberpost where id = '" + id + "' and serialno = '" + textBox1.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);

                    //MessageBox.Show("End Success");
                    con.Close();
                    da.Fill(dt);

                    richTextBox1.Text = dt.Rows[0]["message"].ToString();

                    dataGridView1.DataSource = dt;


                }
                catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID"); }
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = richTextBox1.Text;
            a = a.Trim();
            b = b.Trim();

            //MessageBox.Show(a + b);

            if (a == " " || b == " " || a=="" || b=="")
            { }
            else if (a!=null && b!=null)
            {
                update();
                fetchdata();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mypost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fetchmessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
            {
                delete();
                //dataGridView1.DataSource = null;
                fetchdata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
