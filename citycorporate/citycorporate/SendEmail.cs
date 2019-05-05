using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace citycorporate
{
    class SendEmail
    {
        public SendEmail()
        { }
        public void Send(string id ,string n)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("promilubnamunia@gmail.com", "thisispassword"),
                EnableSsl = true
            };
            string ran = RandomNumber();
            client.Send("promilubnamunia@gmail.com", n, "Password", "Put It on the System as: " + ran); //textBox2.Text.TrimStart().TrimEnd(), textBox3.Text, richTextBox1.Text);
            MessageBox.Show("Mail Sent", "PASSWORD RESET");
            Confirm c = new Confirm(id,ran);
            c.Show();
        }
        private string RandomNumber()
        {
            Random random = new Random();
            return (random.Next(1234, 9999)).ToString();

        }
    }
}
