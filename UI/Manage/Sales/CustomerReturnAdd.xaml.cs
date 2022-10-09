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
    public partial class CustomerReturnAdd : UserControl
    {
        public CustomerReturnAdd()
        {
            InitializeComponent();
            DataContext = returnCustomerInfo;
        }
        ReturnCustomerInfo returnCustomerInfo = new ReturnCustomerInfo();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        IReturnCustomerBusiness returnCustomerBusiness = new ReturnCustomerBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                returnCustomerInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //returnCustomerInfo.userId = ApiStatic.UserId;
                returnCustomerInfo.returnTime = TimePicker_time.DateTime.ToString("yyyy-MM-dd HH:mm:ss");

                //if (ComboBox_goodsName.DataContext is GoodsAllNewInfo apiGoodsTypeInfo)
                //{
                //    returnCustomerInfo.goodsId = apiGoodsTypeInfo.id;
                //    returnCustomerInfo.goodsName = apiGoodsTypeInfo.name;
                //}
                if (ComboBox_goodsName.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                    {
                        returnCustomerInfo.goodsId = goodsAllNewInfo.id;
                        returnCustomerInfo.goodsName = goodsAllNewInfo.name;
                    }
                }
                if (ComboBox_isGoods.SelectedIndex == 1)
                {
                    returnCustomerInfo.isReturnGoods = 1;
                    goodsTypeBusiness.UpdateStock(returnCustomerInfo.goodsId, returnCustomerInfo.number);
                }
                else if (ComboBox_isGoods.SelectedIndex == 2)
                {
                    returnCustomerInfo.isReturnGoods = 0;
                }
                string msg = returnCustomerBusiness.Save(returnCustomerInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Sales.CustomerReturnUC");
                }
            }
        }
        private bool IsCheck()
        {
            if (ComboBox_isGoods.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择是否返还商品", "提示", MessageBoxButton.OK);
                return false;
            }
            if (ComboBox_goodsName.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择退货的商品", "提示", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(returnCustomerInfo.unit))
            {
                MessageBox.Show("失败，请添加退货单位", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!double.TryParse(TextBox_num.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的退货数量", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!double.TryParse(TextBox_returnPrice.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的退货单价", "提示", MessageBoxButton.OK);
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
            //returnCustomerInfo.totalPrice = returnCustomerInfo.returnPrice * (double)returnCustomerInfo.number;
            double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
            returnCustomerInfo.totalPrice = d;
            TextBox_totalPrice.Text = d.ToString();
        }
        private void ComboBox_goodsName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_goodsName.SelectedValue is ComboBoxItem comboBoxItem)
            {
                if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                {
                    returnCustomerInfo.returnPrice = goodsAllNewInfo.price;
                    TextBox_returnPrice.Text = goodsAllNewInfo.price.ToString();
                    double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
                    returnCustomerInfo.totalPrice = d;
                    TextBox_totalPrice.Text = d.ToString();
                }
            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Sales.CustomerReturnUC");
        }
    }
}
