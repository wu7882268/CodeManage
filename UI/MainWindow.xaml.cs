using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Window main;
        public MainWindow()
        {
            InitializeComponent();
            main = this;
            ContentControlMain.Content = new Frame()
            {
                Content = new MainUC()
            };
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var b = MessageBox.Show("您确定要退出登录吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (b == MessageBoxResult.Yes)
            {
                LoginWindow.login.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
