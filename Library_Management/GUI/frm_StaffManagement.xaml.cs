using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for frm_StaffManagement.xaml
    /// </summary>
    public partial class frm_StaffManagement : UserControl
    {
        public frm_StaffManagement()
        {
            InitializeComponent();
            DataTable table = new DataTable("StaffTable");
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "idnv";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hoTen";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            for (int i = 0; i <= 2; i++)
            {
                row = table.NewRow();
                row["idnv"] = i;
                row["hoTen"] = "I am staff  " + i.ToString();
                table.Rows.Add(row);
            }
            ListStaff.ItemsSource = table.DefaultView;
        }

        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            frm_AddStaff frm = new frm_AddStaff();
            frm.ShowDialog();
        }
    }
}
