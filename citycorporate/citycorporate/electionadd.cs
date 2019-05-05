using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace citycorporate
{
    public partial class electionadd : Form
    {
        SqlConnection con;
        public electionadd()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            comboBox3.Hide();
        }

        private void electionadd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void electionadd_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "COUNCILOR")
            {
                label10.Text = "AREA";
                comboBox3.Show();
            }
            else
            {
                label10.Text = "";
                comboBox3.Hide();
            }
        }

        public bool checkid(string id)
        {
            try
            {


                con.Open();
                SqlCommand str = new SqlCommand("Select * from Password where ID = '" + id + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(str);
                DataTable dt = new DataTable();
                da.Fill(dt);
                str.ExecuteNonQuery();

                ///MessageBox.Show(dt.Rows[0]["password"].ToString());
                con.Close();
                if (dt.Rows[0]["password"].ToString() != null)
                {
                    return true;
                }

                else
                    return false;

            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }

        }
        private string RandomNumber()
        {
            Random random = new Random();
            return (random.Next(1234, 9999)).ToString();

        }
        public void sendmail1(string n, string id)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("promilubnamunia@gmail.com", "thisispassword"),
                EnableSsl = true
            };
            string ran = RandomNumber();
            client.Send("promilubnamunia@gmail.com", n, "Password", "Congratulation You are Elected as Mayor.\n Put It on the System as PASSWORD: " + ran + " User Name: " + id);
            try
            {
                con.Open();
                SqlCommand str = new SqlCommand("insert into password values ('" + id + "','" + ran + "','" + n + "')", con);
                str.ExecuteNonQuery();
                MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");


                con.Close();

            }
            catch (Exception es) { con.Close(); MessageBox.Show(es.Message); }
        }

        public void sendmail2(string n, string id)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("promilubnamunia@gmail.com", "thisispassword"),
                EnableSsl = true
            };
            string ran = RandomNumber();
            client.Send("promilubnamunia@gmail.com", n, "Password", "Congratulations, You are Elected as Councilor.\n Put It on the System as PASSWORD: " + ran + " User Name: " + id);
            try
            {
                con.Open();
                SqlCommand str = new SqlCommand("insert into password values ('" + id + "','" + ran + "','" + n + "')", con);
                str.ExecuteNonQuery();
                MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");


                con.Close();

            }
            catch (Exception es) { con.Close(); MessageBox.Show(es.Message); }
        }

        public void sendmail3(string n, string id)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("promilubnamunia@gmail.com", "thisispassword"),
                EnableSsl = true
            };
            string ran = RandomNumber();
            client.Send("promilubnamunia@gmail.com", n, "Password", "Congratulation You are Elected as Member.\nPut It on the System as PASSWORD: " + ran + " User Name: " + id);
            try
            {
                con.Open();
                SqlCommand str = new SqlCommand("insert into password values ('" + id + "','" + ran + "','" + n + "')", con);
                str.ExecuteNonQuery();
                MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");


                con.Close();

            }
            catch (Exception es) { con.Close(); MessageBox.Show(es.Message); }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            electionopeningform e1 = new electionopeningform();
            e1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp ; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                textBox1.Text = open.FileName;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetColor(RadioButton rdoButton, RadioButton rdoButton1)
        {
            if (rdoButton.Checked)
            {
                ///MessageBox.Show(rdoButton.Text);
                return rdoButton.Text;
            }
            else
                return rdoButton1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = "";
            if (comboBox2.Text == "COUNCILOR")
            { id += "C-"; }
            else if (comboBox2.Text == "MEMBER")
            { id += "Me-"; }
            else if (comboBox2.Text == "MAYOR")
            { id += "M-"; }
            id += textBox5.Text;

     

            if (textBox5.Text.Equals(" ") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox1.Text.Equals(null))
            {
                MessageBox.Show("Requirement Not Full Filled", "STATUS");
            }

            else if (checkid(id) == true)
            {
                MessageBox.Show("Already Created", "STATUS");

            }

            else
            {

                string name = textBox2.Text;
                string address = textBox3.Text;
                string dob = dateTimePicker1.Text;
                string blood = comboBox1.SelectedItem.ToString();
                string gender = GetColor(radioButton1, radioButton2);
                
                string email = textBox4.Text;
                string photo = textBox1.Text;

                // MessageBox.Show(name+address+dob+blood+gender+email+photo+id);
                //int i=0;
                try
                {
                    if (id[0] == 'M' && id[1] == 'e')
                    {
                        int checker = 0;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if(email[i]=='@')
                            {
                                checker = 1;
                                
                            }
                            else if(email[i]=='.' && checker==1)
                            {
                                checker = 2;
                            }
                        }
                        if(checker==2)
                        {
                            con.Open();
                            SqlCommand str = new SqlCommand("insert into memberinfo values ('" + id + "','" + name + "','" + address + "','" + dob + "','" + gender + "','" + blood + "','" + email + "','" + photo + "')", con);
                            str.ExecuteNonQuery();
                            //MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");
                            con.Close();
                            sendmail3(email, id);
                            pictureBox1.Image = null;
                            pictureBox1.Refresh();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            dateTimePicker1.ResetText();
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Email.");
                        }
                    }

                    else if (id[0] == 'M')
                    {
                        int checker = 0;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                checker = 1;
                                
                            }
                            else if(email[i]=='.' && checker == 1)
                            {
                                checker = 2;
                                break;
                            }
                        }
                        if(checker==2)
                        {

                            con.Open();
                            SqlCommand str = new SqlCommand("insert into mayorinfo values ('" + id + "','" + name + "','" + address + "','" + dob + "','" + gender + "','" + blood + "','" + email + "','" + photo + "')", con);
                            str.ExecuteNonQuery();
                            // MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");
                            con.Close();
                            sendmail1(email, id);
                            pictureBox1.Image = null;
                            pictureBox1.Refresh();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            dateTimePicker1.ResetText();
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Email");
                        }
                    }
                    else if(id[0]=='C')
                    {
                        int checker = 0;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                checker = 1;
                                
                            }
                            else if (email[i] == '.' && checker == 1)
                            {
                                checker = 2;
                                break;
                            }
                        }

                        if(checker==2)
                        {
                            con.Open();
                            SqlCommand str = new SqlCommand("insert into councilorinfo values ('" + id + "','" + name + "','" + address + "','" + dob + "','" + gender + "','" + blood + "','" + email + "','" + photo + "','" + comboBox3.SelectedItem.ToString() + "')", con);
                            str.ExecuteNonQuery();
                            // MessageBox.Show("CREATED SUCCESSFULL- Auto Generate Password Send To your Mail", "STATUS");
                            con.Close();
                            sendmail2(email, id);
                            pictureBox1.Image = null;
                            pictureBox1.Refresh();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            dateTimePicker1.ResetText();
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                        }

                        else
                        {
                            MessageBox.Show("Invalid Email.");
                        }
                        
                    }
                    


                }
                catch (Exception es) { con.Close(); MessageBox.Show(es.Message); }

                ///MessageBox.Show(this.dateTimePicker1.Text);
                /// MessageBox.Show("Successfully Create\n\n\nId:  " + id + "\nPassword:  " + i, "STATUS");

            }

        }
    }
}
