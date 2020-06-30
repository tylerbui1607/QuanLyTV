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
using MaterialDesignThemes.Wpf;
using System.Data;
using Microsoft.Win32;

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : UserControl
    {
        BUS_Book BUS = new BUS_Book();
        DTO_Book book;
        public bool AllowFiltering { get; set; }
        public BookManagement()
        {
            InitializeComponent();
            list_Book.ItemsSource = BUS.loadBook().DefaultView;
        }
        public void loaddata()
        {
            list_Book.ItemsSource = BUS.loadBook().DefaultView;
        }
        private void Btn_Click_openAddBookForm(object sender, RoutedEventArgs e)
        {
            frm_AddBook frm = new frm_AddBook();
            //listbook.Children.Clear();
            //listbook.Children.Add(frm);
            frm.ShowDialog();
            list_Book.ItemsSource = BUS.loadBook().DefaultView;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "")
            {
                list_Book.ItemsSource = BUS.searchBook(search.Text).DefaultView;
            }
            else
                list_Book.ItemsSource = BUS.loadBook().DefaultView;
        }
    }
}
