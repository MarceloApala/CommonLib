using CommonLib.Implementations;
using CommonLib.Models;
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

namespace WpfInterfaces
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoleImpl roleImpl;
        Role role;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dgRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ltvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl userControl = null;
            gridMain.Children.Clear();

            switch (((ListViewItem)(((ListView)sender).SelectedItem)).Name)
            {
                case "ltvDashboard":
                    userControl = new Views.UscMain();
                    break;
                case "ltvProducts":
                    
                    break;
                case "ltvUsers":
                    userControl= new Views.UscUser();
                    break;
                case "ltvRoles":
                    userControl=new Views.UscRole();
                    break;
                case "ltvSettings":
                    userControl=new Views.UscSettings();
                    break;
                default:
                    break;
            }
            if (userControl!=null)
            {
                gridMain.Children.Add(userControl);
            }
        }
    }
}
