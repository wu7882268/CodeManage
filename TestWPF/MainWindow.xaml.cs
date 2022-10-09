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
using Helpers;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Test test = new Test();
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string strPropertyInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyInfo));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            //HttpHelper.HttpPost("https://www.qinyuanyang.com/post/322.html");
            //test.Name = 123.547846;
            //test.Name = Math.Round(test.Name, 2);
            DataContext = test;
            test.Name = 1564;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            test.Name++;
            Console.WriteLine(test.Name);
        }

        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("aa");
        }
    }

    public class Test
    {
        public double Name { get; set; }
    }
}
