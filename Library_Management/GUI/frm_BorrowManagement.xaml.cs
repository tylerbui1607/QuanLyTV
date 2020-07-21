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
using Library_Management.DAL;

namespace Library_Management.GUI
{
    /// <summary>
    /// Interaction logic for frm_BorrowManagement.xaml
    /// </summary>
    public partial class frm_BorrowManagement : UserControl
    {
        //BUS_TV BUSTV = new BUS_TV();
        ThanhVienController TVcontrol = new ThanhVienController();
        ChiTietMuonController CTMcontrol = new ChiTietMuonController();
        PhieuMuonController PMcontrol = new PhieuMuonController();
        PhieuTraController PTcontrol = new PhieuTraController();
        SachController Scontrol = new SachController();
        //BUS_PM BUSPM = new BUS_PM();
        // BUS_CTM BUSCTM = new BUS_CTM();
        // BUS_Book BUSBOOK = new BUS_Book();
        // BUS_PT BUSPT = new BUS_PT();
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
                CallCardView.Items.Clear();
                //foreach (DataRow row in BUSTV.GetThanhVienTheoID(idseach.Text).Rows)
                foreach (DataRow row in TVcontrol.GetThanhVienTheoID(Int32.Parse(idseach.Text)).Result.Rows)
                {
                    if (row != null)
                    {
                        GridInfo.Visibility = Visibility.Visible;
                        //AccImg.ImageSource = new BitmapImage(new Uri(row["Anh"].ToString(), UriKind.RelativeOrAbsolute));
                        tlbname.Text = row["HoTen"].ToString();
                        tlbid.Text = row["IDTV"].ToString();
                        //foreach (DataRow row1 in BUSPM.GetPM(row["IDTV"].ToString()).Rows)
                        foreach (DataRow row1 in PMcontrol.GetPMTheoID(Int32.Parse(row["IDTV"].ToString())).Result.Rows)
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
                                    //foreach (DataRow row4 in BUSPT.GetPT(row1["IDPM"].ToString()).Rows)
                                    foreach (DataRow row4 in PTcontrol.GetPTTheoID(Int32.Parse(row1["IDPM"].ToString())).Result.Rows)
                                    {
                                        DateTime ngaytra;
                                        ngaytra = DateTime.Parse(row4["NgayTra"].ToString());
                                        item.Fine.Text = row4["TienPhat"].ToString();
                                        TimeSpan interval = ngaytra.Subtract(ngaytam);
                                        //item.Overdue.Text = interval.TotalDays.ToString();
                                        double overdue = 0;
                                        if(interval.TotalDays>(double)30)
                                        {
                                            overdue = interval.TotalDays - (double)30;
                                        }
                                        item.Overdue.Text = overdue.ToString();
                                    }
                                    //item.IsEnabled = false;
                                }
                                else
                                {
                                    tam = "Not returned";
                                }
                                item.idtv.Text = row["IDTV"].ToString();
                                item.idpm.Text = row1["IDPM"].ToString();
                                item.btntam.Content = tam;
                                item.datebor.Text = ngaytam.ToShortDateString();
                                item.EXpan.Header = "ID: " + row1["IDPM"].ToString() + "\t\t\t" + ngaytam.ToShortDateString() + "\t\tStatus: " + tam;
                                //foreach (DataRow row2 in BUSCTM.GetCTM(row1["IDPM"].ToString()).Rows)
                                foreach (DataRow row2 in CTMcontrol.GetCTMTheoID(Int32.Parse(row1["IDPM"].ToString())).Result.Rows)
                                {
                                    if (row2 != null)
                                    {
                                        frm_BorrowLvItem stack = new frm_BorrowLvItem();
                                        //foreach (DataRow row3 in BUSBOOK.GetBookWithID(row2["IDSach"].ToString()).Rows)
                                        //foreach (DataRow row3 in Scontrol.FindBook(Int32.Parse(row2["IDSach"].ToString())).Result.Rows)
                                        //{
                                        //    stack.nabook.Text = row3["Ten"].ToString();
                                        //}           
                                        stack.idbook.Text = row2["IDSach"].ToString();
                                        stack.slbook.Text = row2["SL"].ToString();
                                        stack.slbook.IsReadOnly = true;
                                        if (tam == "Returned")
                                            stack.checkbook.IsEnabled = false;
                                        if (row2["checktra"].ToString() == "1")
                                        {
                                            stack.checkbook.IsChecked = true;
                                        }
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

        private void BtnLoadbook(object sender, RoutedEventArgs e)
        {
            if (tlbname.Text != "")
            {
                frm_Borrow frm = new frm_Borrow(tlbid.Text);
                frm.ShowDialog();
            }
        }
    }
}
