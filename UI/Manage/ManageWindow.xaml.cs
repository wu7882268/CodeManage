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
using System.Windows.Shapes;

namespace UI.Manage
{
    /// <summary>
    /// ManageWindw.xaml 的交互逻辑
    /// </summary>
    public partial class ManageWindow : Window
    {
        public static Window manageWindow = null;
        public ManageWindow()
        {
            InitializeComponent();
            manageWindow = this;
            ContentControlManage.Content = new Frame()
            {
                Content = new ManageMainUC()
            };
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.main.Show();
        }
    }
}
