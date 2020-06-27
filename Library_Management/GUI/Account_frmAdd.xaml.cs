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
using Microsoft.Win32;
using Library_Management.DTO;
using Library_Management.BUS;
namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for AccountFrmAdd.xaml
    /// </summary>
    public partial class Account_frmAdd : Window

    {
        BUS_TV bus = new BUS_TV();
        DTO_ThanhVien dto;
        public Account_frmAdd()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string a = openFileDialog.FileName;
            IMG.Source = new BitmapImage(new Uri(@a, UriKind.RelativeOrAbsolute));
            Btn_Search.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dto = new DTO_ThanhVien(id.Text, Name.Text, address.Text, phone.Text, cmnd.Text, System.DateTime.Now, Nghethan.SelectedDate.Value, NgaySinh.SelectedDate.Value, LTV.Text, mail.Text, IMG.Source.ToString(), "Nam");
                if (bus.themThanhVien(dto))
                {
                    MessageBox.Show("Them thanh cong");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("them that bai");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Vui long dien day du thong tin");
            }
        }

        private void Button_TurnBack(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
