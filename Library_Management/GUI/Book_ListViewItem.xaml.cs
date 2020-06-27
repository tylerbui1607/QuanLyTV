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

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for Book_ListViewItem.xaml
    /// </summary>
    public partial class Book_ListViewItem : ListViewItem
    {
        public Book_ListViewItem(string str_name, string str_author, string str_publisher, int n_remain, string str_shelf )
        {
            InitializeComponent();
            //du lieu dc truyen vao ham dung thong qua truy van csdl
            Book_name.Text = " "+str_name;
            Author.Text = str_author;
            Publisher.Text = str_publisher;
            Remain.Text = n_remain.ToString();
            Shelf.Text = str_shelf;
        }
    }
}
