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
using Models.Delegates;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TypeUpdate : UserControl
    {
        private ApiGoodsTypeAddInfo apiGoodsTypeAddInfo;
        private GoodsAllNewInfo goodsUiInfo;
        ITypeBusiness typeBusiness = new TypeBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        IGoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
        IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();
        public TypeUpdate(GoodsAllNewInfo goodsUiInfo)
        {
            InitializeComponent();
            //this.apiGoodsTypeAddInfo = apiGoodsTypeAddInfo;
            apiGoodsTypeAddInfo = goodsTypeBusiness.GetAddId(goodsUiInfo.id);
            TextBox_name.Text = apiGoodsTypeAddInfo.name;
            TextBox_price.Text = apiGoodsTypeAddInfo.price.ToString();
            TextBox_unit.Text = apiGoodsTypeAddInfo.unit;
            TextBox_costPrice.Text = apiGoodsTypeAddInfo.costPrice.ToString();

            TextBox_inventoryAlert.Text = goodsUiInfo.inventoryAlert.ToString();
            TextBox_barCode.Text = goodsUiInfo.barCode;
            TextBox_details.Text = goodsUiInfo.note;
            TextBox_shelfLife.Text = goodsUiInfo.shelfLife.ToString();
            this.goodsUiInfo = goodsUiInfo;
        }

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
                if (apiGoodsTypeAddInfo.typeId != null && apiTypeInfo.id == apiGoodsTypeAddInfo.typeId[0])
                {
                    comboBox.SelectedItem = comboBoxItem;
                }
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
            if (string.IsNullOrEmpty(TextBox_barCode.Text))
            {
                MessageBox.Show("失败，请添加商品条码", "提示", MessageBoxButton.OK);
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
            if (!string.IsNullOrEmpty(TextBox_inventoryAlert.Text) && !double.TryParse(TextBox_inventoryAlert.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的库存下限", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!string.IsNullOrEmpty(TextBox_shelfLife.Text) && !double.TryParse(TextBox_shelfLife.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的保质期(天)", "提示", MessageBoxButton.OK);
                return false;
            }
            if (!string.IsNullOrEmpty(TextBox_costPrice.Text) && !double.TryParse(TextBox_costPrice.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的成本价格", "提示", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        private void Button_tj_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                ApiGoodsTypeAddInfo addInfo = apiGoodsTypeAddInfo;
                apiGoodsTypeAddInfo.name = TextBox_name.Text;
                apiGoodsTypeAddInfo.price = double.Parse(TextBox_price.Text.Trim());
                apiGoodsTypeAddInfo.unit = TextBox_unit.Text;
                apiGoodsTypeAddInfo.barCode = TextBox_barCode.Text;
                //if (!string.IsNullOrEmpty(TextBox_costPrice.Text.Trim()))
                //    addInfo.costPrice = double.Parse(TextBox_costPrice.Text.Trim());
                if (ComboBox_type.SelectedItem is ComboBoxItem comboBoxItem)
                {
                    var obj = comboBoxItem.DataContext as ApiTypeInfo;
                    List<int> types = new List<int>();
                    types.Add(obj.id);
                    addInfo.typeId = types;
                }
                //GoodsExtendInfo goodsExtendInfo = new GoodsExtendInfo();
                //goodsExtendInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //goodsUiInfo.goodsId = apiGoodsTypeAddInfo.id;
                goodsUiInfo.inventoryAlert = int.Parse(TextBox_inventoryAlert.Text.Trim());
                goodsUiInfo.shelfLife = int.Parse(TextBox_shelfLife.Text.Trim());
                goodsUiInfo.note = TextBox_details.Text;
                goodsUiInfo.barCode = TextBox_barCode.Text;
                //goodsExtendBusiness.Save(goodsExtendInfo);
                goodsAllNewBusiness.Update(goodsUiInfo);
                //MessageBox.Show(goodsTypeBusiness.Insert(addInfo));
                string msg = goodsTypeBusiness.Insert(addInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.Replenish.TypeUC");
                }

            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Replenish.TypeUC");

        }
    }
}
