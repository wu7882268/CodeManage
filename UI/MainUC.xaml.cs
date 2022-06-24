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
using UI.Cashier;
using UI.Manage;

namespace UI
{
    /// <summary>
    /// MainWindowUC.xaml 的交互逻辑
    /// </summary>
    public partial class MainUC : UserControl
    {
        public MainUC()
        {
            InitializeComponent();
        }

        private void Button_Cashier_OnClick(object sender, RoutedEventArgs e)
        {
            CashierWindow cashierWindow = new CashierWindow();
            MainWindow.main.Hide();
            cashierWindow.ShowDialog();
        }

        private void Button_Manage_OnClick(object sender, RoutedEventArgs e)
        {
            ManageWindw manageWindw = new ManageWindw();
            MainWindow.main.Hide();
            manageWindw.ShowDialog();
        }

        private void Button_Stop_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Close();
        }
    }
}
