using Library_Management.BUS;
using Library_Management.DTO;
using Library_Management.DAL;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace Library_Management.GUI
{
    public partial class AccountManagement : UserControl
    {
        BUS_TV BUS = new BUS_TV();
        ThanhVienController TVcontrol = new ThanhVienController();
        DTO_ThanhVien tv;
        public AccountManagement()
        {
            
            InitializeComponent();
            ListAccount.ItemsSource = TVcontrol.GetThanhVien().Result.DefaultView;
        }

        //Complete add ThanhVien
        private void Button_Click_Complete(object sender, RoutedEventArgs e)
        {
            try 
            {
                ComboBoxItem typeItem = (ComboBoxItem)IDLTV.SelectedItem;
                string value = typeItem.Content.ToString();
                tv = new DTO_ThanhVien(IDTV.Text, name.Text, address.Text, phone.Text, cmnd.Text, System.DateTime.Now, DateExpired.SelectedDate.Value, DOB.SelectedDate.Value, value, email.Text, IMG.Source.ToString(), "Nam");
                TVcontrol.UpdateThanhVien(tv);
                ListAccount.ItemsSource = TVcontrol.GetThanhVien().Result.DefaultView;
                DOB.IsEnabled = false;
                DateExpired.IsEnabled = false;
                name.IsEnabled = false;
                email.IsEnabled = false;
                phone.IsEnabled = false;
                IDLTV.IsEnabled = false;
                address.IsEnabled = false;
                Complete.Visibility = Visibility.Hidden;
                Turnback.Visibility = Visibility.Hidden;
                Browse.Visibility = Visibility.Hidden;
                Confirm.Visibility = Visibility.Hidden;
            }
            catch(Exception a)
            {
                MessageBox.Show("Vui long dien day du thong tin");
            }
        }
        
        private void ListAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView Row_Selected = gd.SelectedItem as DataRowView;
            if (Row_Selected != null)
            {
                IDTV.Text = Row_Selected["IDTV"].ToString();
                IDLTV.SelectedItem = Row_Selected["IDLTV"].ToString();
                name.Text = Row_Selected["HoTen"].ToString();
                address.Text = Row_Selected["DiaChi"].ToString();
                phone.Text = Row_Selected["SDT"].ToString();
                email.Text = Row_Selected["email"].ToString();
                DateExpired.Text = Row_Selected["NgayHetHan"].ToString();
                DOB.Text = Row_Selected["NgaySinh"].ToString();
                cmnd.Text = Row_Selected["CMND"].ToString();
                IMG.Source = new BitmapImage(new Uri(Row_Selected["Anh"].ToString(), UriKind.RelativeOrAbsolute));
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (TVcontrol.DeleteThanhVien(Convert.ToInt32(IDTV.Text)).Result)
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai hoac thanh vien khong ton tai");
            }
            ListAccount.ItemsSource = TVcontrol.GetThanhVien().Result.DefaultView;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            DOB.IsEnabled = true;
            DateExpired.IsEnabled = true;
            name.IsEnabled = true;
            email.IsEnabled = true;
            phone.IsEnabled = true;
            IDLTV.IsEnabled = true;
            address.IsEnabled = true;
            Complete.Visibility = Visibility.Visible;
            Turnback.Visibility = Visibility.Visible;
            Browse.Visibility = Visibility.Visible;
            Confirm.Visibility = Visibility.Visible;
        }
      

      

     

        private void Button_Click_Reload(object sender, RoutedEventArgs e)
        {
            ListAccount.ItemsSource = BUS.GetThanhVien().DefaultView;
        }



        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Account_frmAdd frm = new Account_frmAdd();
            frm.ShowDialog();
        }

        private void Button_Click_BrowseIMG(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string a = openFileDialog.FileName;
            IMG.Source = new BitmapImage(new Uri(@a, UriKind.RelativeOrAbsolute));            
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            if (IMG.Source != null)
            {
                Browse.Visibility = Visibility.Hidden;
                Confirm.Visibility = Visibility.Hidden;
            }
            else
            {
                Uri resourceUri = new Uri("/Resources/Natsu.png", UriKind.Relative);
                IMG.Source = new BitmapImage(resourceUri);
            }
        }

        private void Button_Click_Turnback(object sender, RoutedEventArgs e)
        {
            DOB.IsEnabled = false;
            DateExpired.IsEnabled = false;
            name.IsEnabled = false;
            email.IsEnabled = false;
            phone.IsEnabled = false;
            IDLTV.IsEnabled = false;
            address.IsEnabled = false;
            Complete.Visibility = Visibility.Hidden;
            Turnback.Visibility = Visibility.Hidden;
        }
    }
}
