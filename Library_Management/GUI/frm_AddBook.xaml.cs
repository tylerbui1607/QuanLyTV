using Library_Management.BUS;
using Library_Management.DTO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for frm_AddBook.xaml
    /// </summary>
    public partial class frm_AddBook : Window
    {
<<<<<<< HEAD:Library_Management/GUI/frm_AddBook.xaml.cs
=======
        BUS_Book bus = new BUS_Book();
        DTO_Book dto;
>>>>>>> book:Library_Management/GUI/frmAddBook.xaml.cs
        public frm_AddBook()
        {
            InitializeComponent();
        }
        private void Button_Complete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dto = new DTO_Book(Book_ID.Text, TacGia_ID.Text, NXB_ID.Text, Ten.Text, TheLoai.Text, ViTri.Text, int.Parse(SL.Text), int.Parse(SL.Text), float.Parse(Price.Text));

                if (bus.themBook(dto))
                {
                    MessageBox.Show("Thêm sách thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Vui long dien day du thong tin");
            }
        }
        private void Button_TurnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
