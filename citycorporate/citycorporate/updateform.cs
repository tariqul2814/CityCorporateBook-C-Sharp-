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
    public partial class updateform : Form
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
        public updateform()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
        }

        public updateform(string id)
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            this.id = id;
            collect();
        }

        private void updateform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        public void update()
        {
            if (textBox2.Text != "" || textBox3.Text != "" || dateTimePicker1.Text != "" || textBox4.Text!="" || comboBox1.Text!="")
            {
                try {
                    if (searchid[0] == 'M' && searchid[1] == 'e')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE memberinfo set name = '" + textBox2.Text.Trim() + "', address ='" + textBox3.Text.Trim() + "', dob ='" + dateTimePicker1.Text.Trim() + "',gender = '" + GetColor(radioButton1, radioButton2) + "', email= '" + textBox4.Text.Trim() + "', bloodgroup = '" + comboBox1.Text + "'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();

                        string emailcheck = textBox4.Text;

                        int checker = 0;
                        for (int i = 0; i < emailcheck.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                checker = 1;

                            }
                            else if (email[i] == '.' && checker == 1)
                            {
                                checker = 2;
                            }
                        }

                        if (checker == 2)
                        {
                            sqlq = "UPDATE PASSWORD SET EMAIL = '" + textBox4.Text.Trim() + "' WHERE ID = '" + id.Trim() + "'";
                            str = new SqlCommand(sqlq, con);
                            str.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Successful");
                        }
                        else
                        {
                            MessageBox.Show("Invalid Email");
                        }

                        
                    }
                    else if (searchid[0] == 'M')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE mayorinfo set name = '" + textBox2.Text.Trim() + "', address ='" + textBox3.Text.Trim() + "', dob ='" + dateTimePicker1.Text.Trim() + "',gender = '" + GetColor(radioButton1, radioButton2) + "', email= '" + textBox4.Text.Trim() + "', bloodgroup = '" + comboBox1.Text + "'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();

                        string emailcheck = textBox4.Text;

                        int checker = 0;
                        for (int i = 0; i < emailcheck.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                checker = 1;

                            }
                            else if (email[i] == '.' && checker == 1)
                            {
                                checker = 2;
                            }
                        }

                        if (checker == 2)
                        {
                            sqlq = "UPDATE PASSWORD SET EMAIL = '" + textBox4.Text.Trim() + "' WHERE ID = '" + id.Trim() + "'";
                            str = new SqlCommand(sqlq, con);
                            str.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Successful");
                        }
                        else{
                            MessageBox.Show("Invalid Email.");
                        }

                    }
                    else if (searchid[0] == 'C')
                    {
                        DataTable dt = new DataTable();
                        con.Open();

                        string sqlq = "UPDATE councilorinfo set name = '" + textBox2.Text.Trim() + "', address ='" + textBox3.Text.Trim() + "', dob ='" + dateTimePicker1.Text.Trim() + "',gender = '" + GetColor(radioButton1, radioButton2) + "', email= '" + textBox4.Text.Trim() + "', bloodgroup = '" + comboBox1.Text + "'";

                        SqlCommand str = new SqlCommand(sqlq, con);

                        str.ExecuteNonQuery();

                        string emailcheck = textBox4.Text;

                        int checker = 0;
                        for (int i = 0; i < emailcheck.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                checker = 1;

                            }
                            else if (email[i] == '.' && checker == 1)
                            {
                                checker = 2;
                            }
                        }

                        if(checker==2)
                        {
                            sqlq = "UPDATE PASSWORD SET EMAIL = '" + textBox4.Text.Trim() + "' WHERE ID = '" + id.Trim() + "'";
                            str = new SqlCommand(sqlq, con);
                            str.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Successful");
                        }

                        else
                        {
                            MessageBox.Show("Invalid Email");
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid");
                    }
                } catch (Exception exe) {
                    MessageBox.Show("Invalid");
                }
            }
        }

        public void collect()
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
                        //MessageBox.Show("Success");
                        id = searchid;
                        
                        name  = dt.Rows[0]["name"].ToString();
                        textBox2.Text = name.Trim();
                        address = dt.Rows[0]["address"].ToString();
                        textBox3.Text = address.Trim();
                        dob = dt.Rows[0]["dob"].ToString();
                        dateTimePicker1.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();
                        if (gender == "MALE")
                        {
                        radioButton1.Checked = true;
                    }
                        else if(gender == "FEMALE")
                        {
                        radioButton2.Checked = true;
                        }
                        bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    comboBox1.SelectedText = bloodgroup;
                        email = dt.Rows[0]["email"].ToString();
                        textBox4.Text = email.Trim();
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
                        SqlCommand str = new SqlCommand("Select * from mayorinfo where mayorid = '" + searchid + "'", con);
                        SqlDataAdapter da = new SqlDataAdapter(str);
                        da.Fill(dt);
                    //MessageBox.Show(dt.Rows[0]["name"].ToString());

                    id = searchid;

                    name = dt.Rows[0]["name"].ToString();
                    textBox2.Text = name.Trim();
                    address = dt.Rows[0]["address"].ToString();
                    textBox3.Text = address.Trim();
                    dob = dt.Rows[0]["dob"].ToString();
                    dateTimePicker1.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();
                    if (gender == "MALE")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (gender == "FEMALE")
                    {
                        radioButton2.Checked = true;
                    }
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    comboBox1.SelectedText = bloodgroup.Trim();
                    email = dt.Rows[0]["email"].ToString();
                    textBox4.Text = email.Trim();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    pictureBox1.Image = new Bitmap(photoadd.Trim());
                    //MessageBox.Show("UnSuccess");
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
                    textBox2.Text = name.Trim();
                    address = dt.Rows[0]["address"].ToString();
                    textBox3.Text = address.Trim();
                    dob = dt.Rows[0]["dob"].ToString();
                    dateTimePicker1.Text = dob.Trim();
                    gender = dt.Rows[0]["gender"].ToString();
                    if (gender == "MALE")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (gender == "FEMALE")
                    {
                        radioButton2.Checked = true;
                    }
                    bloodgroup = dt.Rows[0]["bloodgroup"].ToString();
                    comboBox1.SelectedText = bloodgroup.Trim();
                    email = dt.Rows[0]["email"].ToString();
                    textBox4.Text = email.Trim();
                    photoadd = dt.Rows[0]["photoadd"].ToString();
                    pictureBox1.Image = new Bitmap(photoadd.Trim());
                    con.Close();
                    }

                    else
                    {
                        MessageBox.Show("Invalid ID");
                    }

                }
                catch (Exception exe) { MessageBox.Show(exe.Message); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f5 = new Form1();
            f5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            updelform upd = new updelform();
            upd.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void updateform_Load(object sender, EventArgs e)
        {

        }
    }
}
