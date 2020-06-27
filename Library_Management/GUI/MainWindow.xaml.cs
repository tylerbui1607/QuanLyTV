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

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GUI.DashBoard dashBoard = new GUI.DashBoard();
        GUI.BookManagement bookManagement = new GUI.BookManagement();
        
        GUI.AccountManagement accountManagement = new GUI.AccountManagement();
        GUI.Login login = new GUI.Login();
        public MainWindow()
        {
            InitializeComponent();
            int LoginResult = 0;
            login.ShowDialog();
            while (LoginResult != 1)
            {
                LoginResult = login.Login_Result;
                if (LoginResult == -1)
                {
                    Application.Current.Shutdown();
                }
            }
            MainGrid.Children.Clear();
            MainGrid.Children.Add(dashBoard);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
         
        private void MoveMenu(int index)
        {
            TrContent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 80 + 55 * index, 0, 0);
        }

        private void Select_Page(int index)
        {
            MoveMenu(index);
            MainGrid.Children.Clear();
            switch(index)
            {
                case 0:
                    MainGrid.Children.Add(dashBoard);
                    break;
                case 1:
                    MainGrid.Children.Add(bookManagement);
                    break;
                case 3:
                    MainGrid.Children.Add(accountManagement);
                    break;
            }
           
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            Select_Page(index);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
