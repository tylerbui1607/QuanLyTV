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
    /// Interaction logic for frm_BorrowManagement.xaml
    /// </summary>
    public partial class frm_BorrowManagement : UserControl
    {
        BUS_TV BUSTV = new BUS_TV();
        DTO_ThanhVien tv;
        BUS_PM BUSPM = new BUS_PM();
        DTO_PHIEUMUON pm;
        BUS_CTM BUSCTM = new BUS_CTM();
        DTO_CTMUON ctm;
        public frm_BorrowManagement()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (idseach.Text == "")
            {
                MessageBox.Show(@"Vui lòng nhập id thành viên muốn tìm");
            }
            else
            {
                foreach (DataRow row in BUSTV.GetThanhVienTheoID(idseach.Text).Rows)
                {
                    if (row != null)
                    {
                        //AccImg.ImageSource = new BitmapImage(new Uri(row["Anh"].ToString(), UriKind.RelativeOrAbsolute));
                        tlbname.Text = row["HoTen"].ToString();
                        tlbid.Text = row["IDTV"].ToString();
                        foreach (DataRow row1 in BUSPM.GetPM(row["IDTV"].ToString()).Rows)
                        {
                            if (row1 != null)
                            {
                                string tam;
                                DateTime ngaytam;
                                ngaytam = DateTime.Parse(row1["NgayMuon"].ToString());
                                frm_BorrowList item = new frm_BorrowList();                               
                                if (row1["Tra"].ToString() == "1")
                                {
                                    tam = "Returned";
                                    item.btncomple.Visibility = Visibility.Hidden;
                                }
                                else
                                {
                                    tam = "Not returned";
                                }
                                item.btntam.Content = tam;
                                item.datebor.Text = "Date borrow : " + ngaytam.ToShortDateString();
                                item.EXpan.Header = "ID: " + row1["IDPM"] + "\t\t\t" + ngaytam.ToShortDateString() + "\t\tStatus: " + tam;
                                foreach (DataRow row2 in BUSCTM.GetCTM(row1["IDPM"].ToString()).Rows)
                                {
                                    if(row2 != null)
                                    {
                                        frm_BorrowLvItem stack = new frm_BorrowLvItem();
                                        stack.nabook.Text = row2["IDPM"].ToString();//đổi thành tên sách
                                        stack.idbook.Text = "ID: " + row2["IDSach"].ToString();
                                        stack.slbook.Text = "SL: " + row2["SL"].ToString();
                                        if (row2["checktra"].ToString() == "1")
                                            stack.checkbook.IsChecked = true;
                                        else
                                            stack.checkbook.IsChecked = false;
                                        item.LstView.Items.Add(stack);
                                    }                        
                                }
                                CallCardView.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
