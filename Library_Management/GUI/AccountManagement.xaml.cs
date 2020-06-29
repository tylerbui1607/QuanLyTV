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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library_Management.BUS;
using Library_Management.DTO;
using System.Data;
using Microsoft.Win32;
namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for AccountManagement.xaml
    /// </summary>
    public partial class AccountManagement : UserControl
    {
        BUS_TV BUS = new BUS_TV();
        DTO_ThanhVien tv;
        public AccountManagement()
        {
            
            InitializeComponent();
            ListAccount.ItemsSource = BUS.GetThanhVien().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account_frmAdd frm = new Account_frmAdd();
            frm.ShowDialog();
        }

        private void ListAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView Row_Selected = gd.SelectedItem as DataRowView;
            if (Row_Selected != null)
            {
                IDTV.Text = Row_Selected["IDTV"].ToString();
                IDLTV.Text = Row_Selected["IDLTV"].ToString();
                name.Text = Row_Selected["HoTen"].ToString();
                address.Text = Row_Selected["DiaChi"].ToString();
                phone.Text = Row_Selected["SDT"].ToString();
                email.Text = Row_Selected["email"].ToString();
                DateExpired.Text = Row_Selected["NgayHetHan"].ToString();
                DOB.Text = Row_Selected["NgaySinh"].ToString();
                cmnd.Text = Row_Selected["CMND"].ToString();
                Img.Source = new BitmapImage(new Uri(Row_Selected["Anh"].ToString(), UriKind.RelativeOrAbsolute));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BUS.xoaThanhVien(Convert.ToInt32(IDTV.Text)))
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai hoac thanh vien khong ton tai");
            }
            ListAccount.ItemsSource = BUS.GetThanhVien().DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DOB.IsEnabled = true;
            DateExpired.IsEnabled = true;
            name.IsEnabled = true;
            email.IsEnabled = true;
            phone.IsEnabled = true;
            IDLTV.IsEnabled = true;
            address.IsEnabled = true;
            Complete.Visibility = Visibility.Visible;

        }
        private void Btn_AddImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string a = openFileDialog.FileName;
            Img.Source = new BitmapImage(new Uri(@a, UriKind.RelativeOrAbsolute));
            Btn_Search.Visibility = Visibility.Hidden;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tv = new DTO_ThanhVien(IDTV.Text, name.Text, address.Text, phone.Text, cmnd.Text, System.DateTime.Now, DateExpired.SelectedDate.Value, DOB.SelectedDate.Value, IDLTV.Text, email.Text, Img.Source.ToString(), "Nam");
            BUS.suaThanhVien(tv);
            ListAccount.ItemsSource = BUS.GetThanhVien().DefaultView;
            DOB.IsEnabled = false;
            DateExpired.IsEnabled = false;
            name.IsEnabled = false;
            email.IsEnabled = false;
            phone.IsEnabled = false;
            IDLTV.IsEnabled = false;
            address.IsEnabled = false;
            Complete.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ListAccount.ItemsSource = BUS.GetThanhVien().DefaultView;
        }
    }
}
