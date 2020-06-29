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
        public void Logincheck()
        {

            if (Login_Result == 2)
                MessageBox.Show("Dang nhap thanh cong");
           
          
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DAL.DAL_LOGIN logincheck = new DAL.DAL_LOGIN();
            if (logincheck.CheckLogin(username.Text, pass.Password))
            {
                Login_Result = 1;
                this.Close();
            }
        
             else
                MessageBox.Show("Incorrect password or username!");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
