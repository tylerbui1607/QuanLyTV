﻿using System;
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
    /// Interaction logic for frm_Borrow.xaml
    /// </summary>
    public partial class frm_Borrow : Window
    {
        string idtvtam;
        BUS_TV BUSTV = new BUS_TV();
        BUS_PM BUSPM = new BUS_PM();
        DTO_PHIEUMUON dtopm;
        BUS_CTM BUSCTM = new BUS_CTM();
        DTO_CTMUON dtoctm;
        BUS_Book BUSBOOK = new BUS_Book();
        public frm_Borrow(string idtv)
        {
            InitializeComponent();
            idtvtam = idtv;
            tlbid.Text = "ID : " + idtv;
            databook.ItemsSource = BUSBOOK.GetBook().DefaultView;
            databook.IsReadOnly = true;
        }

        private void btnback(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "")
            {
                databook.ItemsSource = BUSBOOK.searchBookVer2(search.Text).DefaultView;
            }
            else
                databook.ItemsSource = BUSBOOK.GetBook().DefaultView;
        }

        private void databook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int counttam = 0;
            int sltam = 1;
            DataGrid gd = (DataGrid)sender;
            DataRowView Row_Selected = gd.SelectedItem as DataRowView;
            if (Row_Selected != null)
            {
                foreach (frm_BorrowLvItem item in listbor.Items)
                {
                    if(item.idbook.Text == Row_Selected["IDSach"].ToString())
                    {
                        sltam = Int32.Parse(item.slbook.Text.ToString());
                        sltam++;
                        item.slbook.Text = sltam.ToString();
                        counttam++;
                        item.checkbook.Visibility = Visibility.Hidden;
                    }                        
                }
                if (counttam == 0)
                {
                    frm_BorrowLvItem lvitem = new frm_BorrowLvItem();
                    lvitem.nabook.Text = Row_Selected["Ten"].ToString();
                    lvitem.idbook.Text = Row_Selected["IDSach"].ToString();
                    lvitem.slbook.Text = sltam.ToString();
                    listbor.Items.Add(lvitem);
                    lvitem.checkbook.Visibility = Visibility.Hidden;
                    //lvitem.slbook.TextChanged += Slbook_TextChanged;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counttam = 0;

            foreach (frm_BorrowLvItem item in listbor.Items)
            {
                if (item.slbook.Text != "0")
                {
                    counttam++;
                }
            }

            if (counttam > 0)
            {               
                dtopm = new DTO_PHIEUMUON(idtvtam, "501", DateTime.Now, "0");
                BUSPM.addPM(dtopm);
                foreach (frm_BorrowLvItem item in listbor.Items)
                {
                    if (item.slbook.Text != "0")
                    {
                        int tam = BUSPM.GetNewPM();
                        dtoctm = new DTO_CTMUON(tam.ToString(), item.idbook.Text, item.slbook.Text, "0");
                        BUSCTM.addCTM(dtoctm);
                    }
                }
                this.Close();
            }
        }

        //private void Slbook_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    foreach (frm_BorrowLvItem item in listbor.Items)
        //    {
        //        if(item.slbook.Text == "0")
        //        {

        //        }    
        //    }
        //}
    }
}
