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
    /// Interaction logic for frm_Management.xaml
    /// </summary>
    public partial class frm_Management : UserControl
    {
        public frm_Management()
        {
            InitializeComponent();
            frm_StaffManagement staffManagement = new frm_StaffManagement();
            gridManager.Children.Add(staffManagement);
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            gridManager.Children.Clear();
            frm_StaffManagement staffManagement = new frm_StaffManagement();
            gridManager.Children.Add(staffManagement);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            gridManager.Children.Clear();
            frm_Report report = new frm_Report();
            gridManager.Children.Add(report);
        }
    }
}
