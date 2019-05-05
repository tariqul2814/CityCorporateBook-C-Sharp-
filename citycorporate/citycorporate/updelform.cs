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
    public partial class updelform : Form
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
        public updelform()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            
        }

        private void updelform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f4 = new Form1();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            electionopeningform elop1 = new electionopeningform();
            elop1.Show();
        }

        public bool collect(string id)
        {
            
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
                        
                         con.Close();
                    if (dt.Rows[0][0].ToString() == null)
                        return false;
                    else
                    return true;
                    }

                    else if (searchid[0] == 'M')
                    {

                        DataTable dt = new DataTable();
                        con.Open();
                        SqlCommand str = new SqlCommand("Select * from mayorinfo where mayorid = '" + searchid + "'", con);
                        SqlDataAdapter da = new SqlDataAdapter(str);
                        da.Fill(dt);
                    
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());


                    con.Close();
                    if (dt.Rows[0][0].ToString() == null)
                        return false;
                    else
                        return true;
                }
                    else if(searchid[0]=='C')
                    {
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand str = new SqlCommand("Select * from councilorinfo where councilorid = '" + searchid + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    da.Fill(dt);
                    if (dt.Rows[0][0].ToString() == null)
                        return false;
                    else
                        return true;
                }

                    else
                    {
                        MessageBox.Show("Invalid ID");
                        return false;
                    }

                }
                catch (Exception exe) { con.Close();  return false; }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(collect(textBox1.Text)==true)
            {
                string naaa = textBox1.Text;
                naaa = naaa.Trim();
                if (naaa == "")
                {
                    MessageBox.Show("Empty Field");
                }
                else if(naaa!=null)
                {
                    this.Hide();
                    updateform up1 = new updateform(textBox1.Text);
                    up1.Show();
                }

            }
            else
            {
                MessageBox.Show("Invalid");
            }
            
        }

        public void delete()
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
                    con.Open();
                    SqlCommand str = new SqlCommand("Delete from Password where id='" + searchid + "'", con);

                    str.ExecuteNonQuery();

                    str = new SqlCommand("Delete from memberinfo where memberid='" + searchid + "'", con);

                    str.ExecuteNonQuery();

                    MessageBox.Show("Successfully Delete");

                    con.Close();
                }

                else if (searchid[0] == 'M')
                {
                    con.Open();
                    SqlCommand str = new SqlCommand("Delete from Password where id='" + searchid + "'", con);

                    str.ExecuteNonQuery();

                    str = new SqlCommand("Delete from mayorinfo where mayorid='" + searchid + "'", con);

                    str.ExecuteNonQuery();


                    MessageBox.Show("Successfully Delete");
                    con.Close();

                }
                else if (searchid[0] == 'C')
                {
                    con.Open();
                    SqlCommand str = new SqlCommand("Delete from Password where id='" + searchid + "'", con);

                    str.ExecuteNonQuery();

                    str = new SqlCommand("Delete from councilorinfo where councilorid='" + searchid + "'", con);

                    str.ExecuteNonQuery();

                    con.Close();
                }

                else
                {
                    MessageBox.Show("Invalid ID");
                }

            }
            catch (Exception epp) { con.Close(); MessageBox.Show("Invalid ID"); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           delete();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
