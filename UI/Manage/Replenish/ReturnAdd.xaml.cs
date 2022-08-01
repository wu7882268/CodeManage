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
using BLL;
using Models.Interfaces;

namespace UI.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class ReturnAdd : UserControl
    {
        public ReturnAdd()
        {
            InitializeComponent();
        }
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();

        private void ComboBox_goodsName_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = goodsTypeBusiness.GetAll();
            ComboBox comboBox = sender as ComboBox;
            foreach (var goods in list)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.FontSize = 16;
                comboBoxItem.Height = 22;
                comboBoxItem.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x32, 0x32));
                comboBoxItem.Content = goods.name;
                comboBoxItem.DataContext = goods;
                comboBox.Items.Add(comboBoxItem);
            }
        }
    }
}
