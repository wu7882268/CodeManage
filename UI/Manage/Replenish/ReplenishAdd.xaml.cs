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
    public partial class ReplenishAdd : UserControl
    {
        public ReplenishAdd()
        {
            InitializeComponent();
            DataContext = replenishInfo;
        }
        ReplenishInfo replenishInfo = new ReplenishInfo();
        IReplenishBusiness replenishBusiness = new ReplenishBusiness();
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
                replenishInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //replenishInfo.userId = ApiStatic.UserId;
                replenishInfo.purchaseTime = TimePicker_time.DateTime.ToString("yyyy-MM-dd HH:mm:ss");

                if (ComboBox_goodsName.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                    {
                        replenishInfo.goodsId = goodsAllNewInfo.id;
                        replenishInfo.goodsName = goodsAllNewInfo.name;
                    }
                }
                if (ComboBox_supplier.SelectedItem is ComboBoxItem comboBoxItem1)
                {
                    if (comboBoxItem1.DataContext is SupplierInfo supplierInfo)
                    {
                        replenishInfo.supplierId = supplierInfo.id;
                        replenishInfo.supplierName = supplierInfo.supplierName;
                    }
                }
                string msg = replenishBusiness.Save(replenishInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Replenish.ReplenishUC");
                }
            }
        }
        private bool IsCheck()
        {
            if (ComboBox_supplier.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择供应商", "提示", MessageBoxButton.OK);
                return false;
            }
            if (ComboBox_goodsName.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择进货的商品", "提示", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(replenishInfo.unit))
            {
                MessageBox.Show("失败，请添加进货单位", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!double.TryParse(TextBox_num.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的进货数量", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!double.TryParse(TextBox_replenishPrice.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的进货单价", "提示", MessageBoxButton.OK);
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
            //replenishInfo.totalPrice = replenishInfo.replenishPrice * (double)replenishInfo.number;
            double d = double.Parse(TextBox_replenishPrice.Text) * double.Parse(TextBox_num.Text);
            replenishInfo.totalPrice = d;
            TextBox_totalPrice.Text = d.ToString();
        }
        private void ComboBox_goodsName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_goodsName.SelectedValue is ComboBoxItem comboBoxItem)
            {
                if (comboBoxItem.DataContext is GoodsAllNewInfo goodsAllNewInfo)
                {
                    replenishInfo.replenishPrice = goodsAllNewInfo.price;
                    TextBox_replenishPrice.Text = goodsAllNewInfo.price.ToString();
                    double d = double.Parse(TextBox_replenishPrice.Text) * double.Parse(TextBox_num.Text);
                    replenishInfo.totalPrice = d;
                    TextBox_totalPrice.Text = d.ToString();
                }
            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Replenish.ReplenishUC");
        }
    }
}
