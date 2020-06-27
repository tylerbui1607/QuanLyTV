using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Account
        {
            public int id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        private async Task<bool> Login321()
        {
            bool str = false;

            HttpClient client = new HttpClient();

            Account account = new Account { UserName = txtUsername.Text, Password = "admin" };
            var response = client.PostAsJsonAsync("https://localhost:5001/account/", account).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }

            if (str)
                button1.Visible = false;
            return str;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login321();
        }
    }
}
