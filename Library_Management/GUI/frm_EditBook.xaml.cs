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

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for frm_EditBook.xaml
    /// </summary>
    public partial class frm_EditBook : Window
    {
        BUS_Book bus = new BUS_Book();
        SachController S_control = new SachController();
        DTO_Book dto;
        public frm_EditBook()
        {
            InitializeComponent();
        }

        private void Button_TurnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Complete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dto = new DTO_Book(Book_ID.Text, TacGia_ID.Text, NXB_ID.Text, Ten.Text, TheLoai.Text, ViTri.Text, int.Parse(SL.Text), int.Parse(SL.Text), float.Parse(Price.Text));

                if (S_control.EditBook(dto).Result)
                {
                    MessageBox.Show("Sửa sách thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa sách thất bại");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Vui long dien day du thong tin");
            }
        }


    }
}
