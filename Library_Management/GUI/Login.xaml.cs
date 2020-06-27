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
using System.Text;
using System.Threading.Tasks;
using Library_Management.DTO;

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
        }

        private async Task<bool> Login321()
        {
            bool str = false;

            HttpClient client = new HttpClient();

            DTO_NhanVien account = new DTO_NhanVien { UserName_NV = username.Text, PassWord_NV = pass.Password };
            var response = client.PostAsJsonAsync("https://localhost:5001/account/", account).Result;
            if (response.IsSuccessStatusCode)
            {
                str = await response.Content.ReadAsAsync<bool>();
            }

            if (str)
            {
                Login_Result = 1;
                this.Close();
            }
            else
                MessageBox.Show("Incorrect password or username!");
            return true;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login321();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
