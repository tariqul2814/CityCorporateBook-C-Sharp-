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
    public partial class mayorwritepost : Form
    {
        string id = "";
        string identity = "";
        SqlConnection con;
        public mayorwritepost(string id)
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JUHJ985;Initial Catalog=Mayor_Detail;Integrated Security=True");
            this.id = id;
        }

        private void mayorwritepost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mayorwritepost_Load(object sender, EventArgs e)
        {

        }

        public void verifyidenty1()
        {
            //MessageBox.Show("Enter in Verifyindenty");
            if (id[0] == 'M' && id[1] == 'e')
            {
                identity = "MEMBER";
                
            }
            else if (id[0] == 'M')
            {
                identity = "MAYOR";
            }
            else if (id[0] == 'C')
            {
                identity= "COUNCILOR";
                
            }
        }

        public void upload() {
            verifyidenty1();

            try {

                con.Open();
                //INSERT INTO Customers(CustomerName, ContactName, Address, City, PostalCode, Country) VALUES('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway');
                SqlCommand str = new SqlCommand("INSERT INTO mirpurmemberpost (id, message, pidentity) VALUES('" + id +"','"+ richTextBox1.Text +"','"+identity+"')", con);

                str.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Added");
                int length = richTextBox1.Text.Length;
                MessageBox.Show(length.ToString());
                richTextBox1.Text = "";
                
            } catch (Exception exe) { MessageBox.Show(exe.Message); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            upload();
            richTextBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mayoropening m1 = new mayoropening(id);
            m1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
