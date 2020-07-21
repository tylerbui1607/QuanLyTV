using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net;
using Library_Management.DTO;
using System.Net.Http.Headers;

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public int Login_Result;
        public Login()
        {
            InitializeComponent();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Login_Result = -1;
            this.Close();
        }
        private async Task<DTO_NhanVien> Login321()
        {
            bool str = false;
            string str1 = "";
            HttpClient client = new HttpClient();
            DTO_NhanVien dTO_NhanVien = new DTO_NhanVien();
            DTO_NhanVien account = new DTO_NhanVien { UserName_NV = username.Text, PassWord_NV = pass.Password };
            var response = client.PostAsJsonAsync("https://localhost:5001/login/", account).Result;
            if (response.IsSuccessStatusCode)
            {
                dTO_NhanVien = await response.Content.ReadAsAsync<DTO_NhanVien>();
            }

            if (dTO_NhanVien.HoTen_NV=="Thai")
            {
                Login_Result = 1;
                return account;
            }
            else
                MessageBox.Show("Incorrect password or username!");
            return account;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login321();
            if(Login_Result==1)
                this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
