using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL;
using Models;
using Models.Delegates;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;
using Tools;

namespace UI.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TypeAdd : UserControl
    {
        public TypeAdd()
        {
            InitializeComponent();
        }
        ITypeBusiness typeBusiness = new TypeBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        //GoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = typeBusiness.GetAll();
            ComboBox comboBox = sender as ComboBox;
            foreach (var apiTypeInfo in list)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.FontSize = 16;
                comboBoxItem.Height = 22;
                comboBoxItem.Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x32, 0x32, 0x32));
                comboBoxItem.Content = apiTypeInfo.name;
                comboBoxItem.DataContext = apiTypeInfo;
                comboBox.Items.Add(comboBoxItem);
            }
        }
        private bool IsCheck()
        {
            if (ComboBox_type.SelectedIndex < 1)
            {
                MessageBox.Show("失败，请选择商品类型", "提示", MessageBoxButton.OK);
                return false;
            }

            if (string.IsNullOrEmpty(TextBox_name.Text))
            {
                MessageBox.Show("失败，请添加商品名称", "提示", MessageBoxButton.OK);
                return false;
            }

            if (string.IsNullOrEmpty(TextBox_unit.Text))
            {
                MessageBox.Show("失败，请添加商品单位", "提示", MessageBoxButton.OK);
                return false;
            }

            if (!double.TryParse(TextBox_price.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的商品售价", "提示", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void Button_tj_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                ApiGoodsTypeAddInfo addInfo = new ApiGoodsTypeAddInfo()
                {
                    name = TextBox_name.Text,
                    //barCode = TextBox_barCode.Text,
                    price = double.Parse(TextBox_price.Text.Trim()),
                    unit = TextBox_unit.Text,
                    //details = TextBox_details.Text,
                    goodsType = 3,
                    storeId = ApiStatic.StoreId
                };
                InfoHelper.InitializeString(addInfo);
                InfoHelper.InitializeIntNull(addInfo);
                InfoHelper.InitializeDoubleNull(addInfo);

                //if(!string.IsNullOrEmpty(TextBox_costPrice.Text.Trim()))
                //    addInfo.costPrice = double.Parse(TextBox_costPrice.Text.Trim());
                if (ComboBox_type.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    var obj = comboBoxItem.DataContext as ApiTypeInfo;
                    List<int> types = new List<int>();
                    types.Add(obj.id);
                    addInfo.typeId = types;
                }
                string msg = goodsTypeBusiness.Insert(addInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Replenish.TypeUC");
                }
            }

            //var goods =  goodsTypeBusiness.GetAll().Where((info =>
            //    info.name == addInfo.name && info.barCode == addInfo.barCode && info.barCode == addInfo.barCode &&
            //    info.unit == addInfo.unit)).Last();
            //GoodsExtendInfo goodsExtendInfo = new GoodsExtendInfo();
            //goodsExtendInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //goodsExtendInfo.goodsId = goods.id;
            //goodsExtendInfo.inventoryAlert = int.Parse(TextBox_inventoryAlert.Text.Trim());
            //goodsExtendInfo.shelfLife = int.Parse(TextBox_shelfLife.Text.Trim());
            //goodsExtendInfo.note = TextBox_details.Text;
            //goodsExtendBusiness.Save(goodsExtendInfo);
        }

        private void Button_xyb_Click(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Replenish.TypeUC");
        }
    }
}
