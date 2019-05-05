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
    public partial class PasswordChange : Form
    {
        SqlConnection con;
        public static string idname;
        public PasswordChange(string id)
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            
            idname = id;
        }

        private void Update(string id, string pass)
        {
            MessageBox.Show(id+" "+pass);
            try
            {

                con.Open();
                SqlCommand str = new SqlCommand("update Password set PASSWORD = '" + textBox1.Text + "' where id = '" + idname+"'", con);

                str.ExecuteNonQuery();
                con.Close();
                this.Hide();
            }
            catch (Exception exe) { con.Close();  MessageBox.Show(exe.Message); }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Update(idname, textBox1.Text);

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PasswordChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }
    }
}
