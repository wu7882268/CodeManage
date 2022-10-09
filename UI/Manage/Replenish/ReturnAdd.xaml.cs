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
            DataContext = returnInfo;
        }
        ReturnInfo returnInfo = new ReturnInfo();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        IReturnBusiness returnBusiness = new ReturnBusiness();
        ISupplierBusiness supplierBusiness = new SupplierBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();

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

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                returnInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //returnInfo.userId = ApiStatic.UserId;
                returnInfo.returnTime = TimePicker_time.DateTime.ToString("yyyy-MM-dd HH:mm:ss");

                //if (ComboBox_goodsName.DataContext is GoodsAllNewInfo apiGoodsTypeInfo)
                //{
                //    returnInfo.goodsId = apiGoodsTypeInfo.id;
                //    returnInfo.goodsName = apiGoodsTypeInfo.name;
                //}
                if (ComboBox_goodsName.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                    {
                        returnInfo.goodsId = goodsAllNewInfo.id;
                        returnInfo.goodsName = goodsAllNewInfo.name;
                    }
                }
                if (ComboBox_Supplier.SelectedItem is ComboBoxItem comboBoxItem1)
                {
                    if (comboBoxItem1.DataContext is SupplierInfo supplierInfo)
                    {
                        returnInfo.supplierId = supplierInfo.id;
                        returnInfo.supplierName = supplierInfo.supplierName;
                    }
                }
                string msg = returnBusiness.Save(returnInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Replenish.ReturnUC");
                }
                //MessageBox.Show(returnBusiness.Save(returnInfo));
            }
        }
        private bool IsCheck()
        {
            if (ComboBox_Supplier.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择供应商", "提示", MessageBoxButton.OK);
                return false;
            }
            if (ComboBox_goodsName.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择退货的商品", "提示", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(returnInfo.unit))
            {
                MessageBox.Show("失败，请添加退货单位", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!double.TryParse(TextBox_num.Text,out _))
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
        private void ComboBox_Supplier_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = supplierBusiness.GetAll();
            ComboBox comboBox = sender as ComboBox;
            foreach (SupplierInfo supplier in list)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.FontSize = 16;
                comboBoxItem.Height = 22;
                comboBoxItem.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x32, 0x32));
                comboBoxItem.Content = supplier.supplierName;
                comboBoxItem.DataContext = supplier;
                comboBox.Items.Add(comboBoxItem);
            }
        }

        private void TextBox_returnPrice_OnLostFocus(object sender, RoutedEventArgs e)
        {
            //returnInfo.totalPrice = returnInfo.returnPrice * (double)returnInfo.number;
            double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
            returnInfo.totalPrice = d;
            TextBox_totalPrice.Text = d.ToString();
        }
        private void ComboBox_goodsName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_goodsName.SelectedValue is ComboBoxItem comboBoxItem)
            {
                if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                {
                    returnInfo.returnPrice = goodsAllNewInfo.price;
                    TextBox_returnPrice.Text = goodsAllNewInfo.price.ToString();
                    double d = double.Parse(TextBox_returnPrice.Text) * double.Parse(TextBox_num.Text);
                    returnInfo.totalPrice = d;
                    TextBox_totalPrice.Text = d.ToString();
                }
            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Replenish.ReturnUC");
        }
    }
}
