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
using BLL;
using Models;
using Models.Delegates;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Sales
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class SalesAdd : UserControl
    {
        public SalesAdd()
        {
            InitializeComponent();
            this.DataContext = orderInfo;
        }
        OrderInfo orderInfo = new OrderInfo();
        IOrderBusiness orderBusiness = new OrderBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();

        private bool IsCheck()
        {
            if (ComboBox_goodsName.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择销售的商品", "提示", MessageBoxButton.OK);
                return false;
            }

            if (string.IsNullOrEmpty(orderInfo.unit))
            {
                MessageBox.Show("失败，请添加销售单位", "提示", MessageBoxButton.OK);
                return false;
            }

            if (!double.TryParse(TextBox_num.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的销售数量", "提示", MessageBoxButton.OK);
                return false;
            }

            if (!double.TryParse(TextBox_returnPrice.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的销售单价", "提示", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void ComboBox_goodsName_OnLoaded(object sender, RoutedEventArgs e)
        {

            List<GoodsAllNewInfo> list = goodsAllNewBusiness.GetGoodsList();
            ComboBox comboBox = sender as ComboBox;
            foreach (GoodsAllNewInfo goods in list)
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

        private void TextBox_returnPrice_OnLostFocus(object sender, RoutedEventArgs e)
        {
            double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
            orderInfo.totalPrice = d;
            TextBox_totalPrice.Text = d.ToString();
            //orderInfo.totalPrice = orderInfo.money * (double) orderInfo.num;
        }

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                //orderInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //orderInfo.userId = ApiStatic.UserId;
                orderInfo.createTime = TimePicker_time.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.num = int.Parse(TextBox_num.Text);
                orderInfo.note = TextBox_note.Text;
                if (ComboBox_goodsName.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                    {
                        orderInfo.goodsId = goodsAllNewInfo.id;
                        orderInfo.name = goodsAllNewInfo.name;
                        goodsTypeBusiness.UpdateStock(orderInfo.goodsId, orderInfo.num * -1);
                    }
                }
                string msg = orderBusiness.Save(orderInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Sales.SalesUC");
                }
                //MessageBox.Show(orderBusiness.Save(orderInfo));
            }
        }

        private void ComboBox_goodsName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_goodsName.SelectedValue is ComboBoxItem comboBoxItem)
            {
                if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                {
                    orderInfo.money = goodsAllNewInfo.price;
                    TextBox_returnPrice.Text = goodsAllNewInfo.price.ToString();
                    double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
                    orderInfo.totalPrice = d;
                    TextBox_totalPrice.Text = d.ToString();
                }
            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Sales.SalesUC");
        }
    }
}
