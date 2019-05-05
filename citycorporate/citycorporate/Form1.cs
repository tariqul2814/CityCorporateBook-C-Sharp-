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
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            pictureBox1.Image = new Bitmap(@"D:\Photos\City.png");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public bool checkAccount(string userid,string pass)
        {
           try{
                SqlCommand str = new SqlCommand("Select password from Password where Id='" + userid+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(str);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows[0]["password"].ToString() == pass)
                    return true;
                else
                    return false;


            } catch (Exception exe) { con.Close(); return false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox2.Text != null)
            {
                string userid = textBox1.Text;
                string pass = textBox2.Text;
                if (checkAccount(userid, pass))
                {
                    MessageBox.Show("Successfully Match");
                    if (userid[0] == 'M' && userid[1] == 'e')
                    {
                        this.Hide();
                        mayoropening m3 = new mayoropening(textBox1.Text);
                        m3.Show();
                    }
                    else if (userid[0] == 'M')
                    {
                        this.Hide();
                        mayoropening m1 = new mayoropening(textBox1.Text);
                        m1.Show();

                    }
                    else if (userid[0] == 'C')
                    {
                        this.Hide();
                        mayoropening m2 = new mayoropening(textBox1.Text);
                        m2.Show();
                    }
                    else if (userid[0] == 'E')
                    {
                        this.Hide();
                        electionopeningform elec = new electionopeningform();
                        elec.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null || textBox1.Text!=null)
            {
                try
                {
                    con.Open();
                    SqlCommand str = new SqlCommand("select email from Password where ID = '" + textBox1.Text+"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(str);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string mail = dt.Rows[0]["email"].ToString();
                    MessageBox.Show(mail);
                    con.Close();
                    SendEmail s = new SendEmail();
                    s.Send(textBox1.Text,mail);

                }
                catch (Exception exe) { con.Close(); MessageBox.Show("Invalid Username and Password"); }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
