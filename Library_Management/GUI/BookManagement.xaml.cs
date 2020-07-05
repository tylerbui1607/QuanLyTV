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
        SachController S_control = new SachController();
        DTO_Book book;
       // GUI.frm_EditBook frm_editBook = new GUI.frm_EditBook();
        public bool AllowFiltering { get; set; }
        public BookManagement()
        {
            InitializeComponent();
            loaddata();

        }
        public void loaddata()
        {
            //list_Book.ItemsSource = BUS.loadBook().DefaultView;
            list_Book.ItemsSource = S_control.LoadBook().Result.DefaultView;
            list_Book.IsReadOnly = true;
        }
        private void Btn_Click_openAddBookForm(object sender, RoutedEventArgs e)
        {
            frm_AddBook frm = new frm_AddBook();
            frm.ShowDialog();
            loaddata();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DataGridRow row = sender as DataGridRow;
            // Some operations with this row
            //listbook.Children.Clear();
            //listbook.Children.Add(frm_editBook);
            frm_EditBook frm = new frm_EditBook();
            DataRowView dataRowView = (DataRowView)list_Book.SelectedItem;

            frm.Ten.Text = dataRowView["ten"].ToString();
            frm.TacGia_ID.Text = dataRowView["idtg"].ToString();
            frm.Book_ID.Text = dataRowView["idSach"].ToString();
            frm.Book_ID.IsReadOnly = true;
            frm.NXB_ID.Text = dataRowView["idnxb"].ToString();
            frm.ViTri.Text = dataRowView["viTri"].ToString();
            frm.SL.Text = dataRowView["slHienTai"].ToString();
            frm.TheLoai.Text = dataRowView["theLoai"].ToString();
            frm.Price.Text = dataRowView["giaSach"].ToString();
            frm.ShowDialog();
            loaddata();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "")
            {
                list_Book.ItemsSource = S_control.SearchBook(search.Text).Result.DefaultView;
            }
            else
                loaddata();
        }
    }
}
