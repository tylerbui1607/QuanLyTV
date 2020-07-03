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
    /// Interaction logic for frm_BorrowList.xaml
    /// </summary>
    public partial class frm_BorrowList : UserControl
    {
        //BUS_TV BUSTV = new BUS_TV();
        //BUS_PM BUSPM = new BUS_PM();
        //BUS_CTM BUSCTM = new BUS_CTM();
        //BUS_Book BUSBOOK = new BUS_Book();
        //BUS_PT BUSPT = new BUS_PT();
        ThanhVienController TVcontrol = new ThanhVienController();
        ChiTietMuonController CTMcontrol = new ChiTietMuonController();
        PhieuMuonController PMcontrol = new PhieuMuonController();
        PhieuTraController PTcontrol = new PhieuTraController();
        SachController Scontrol = new SachController();
        DTO_PHIEUTRA dtopt;
        DTO_PHIEUMUON dtopm;
        DTO_CTMUON dtoctm;
        public frm_BorrowList()
        {
            InitializeComponent();
        }

        private void btncomple_Click(object sender, RoutedEventArgs e)
        {
            double tien = 0;
            double tam = 0;
            double tam1 = 0;
            dtopm = new DTO_PHIEUMUON(idpm.Text, "1");
            //BUSPM.suaPM(dtopm);
            PMcontrol.UpdatePM(dtopm);
            foreach (frm_BorrowLvItem item in LstView.Items)
            {
                if (item.checkbook.IsChecked == true)
                {
                    dtoctm = new DTO_CTMUON(idpm.Text, item.idbook.Text, item.slbook.Text, "1");
                }
                else
                {
                    tam1 += Int32.Parse(item.slbook.Text);
                    dtoctm = new DTO_CTMUON(idpm.Text, item.idbook.Text, item.slbook.Text, "0");
                }
                //BUSCTM.suaCTM(dtoctm);
                CTMcontrol.UpdateCTM(dtoctm);

            }
            DateTime dtnow = DateTime.Now;
            DateTime dtmuon = DateTime.Parse(datebor.Text);
            TimeSpan interval = dtnow.Subtract(dtmuon);
            if (interval.TotalDays > 30)
            {
                tam = interval.TotalDays - (double)30;
                tien += tam * 2000;
            }
            if(tam1>0)
            {
                tien += tam1 * 5000; 
            }    
            dtopt = new DTO_PHIEUTRA(idpm.Text, idtv.Text, "501", DateTime.Now, tien.ToString());
            //BUSPT.addPT(dtopt);
            PTcontrol.AddPT(dtopt);
        }
    }
}
