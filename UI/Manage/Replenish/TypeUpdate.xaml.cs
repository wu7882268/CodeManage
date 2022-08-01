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
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;
using UI.Models;

namespace UI.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TypeUpdate : UserControl
    {
        private ApiGoodsTypeAddInfo apiGoodsTypeAddInfo;
        private GoodsUiInfo goodsUiInfo;
        ITypeBusiness typeBusiness = new TypeBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        IGoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
        public TypeUpdate(GoodsUiInfo goodsUiInfo)
        {
            InitializeComponent();
            //this.apiGoodsTypeAddInfo = apiGoodsTypeAddInfo;
            apiGoodsTypeAddInfo = goodsTypeBusiness.GetAddId(goodsUiInfo.id);
            TextBox_name.Text = apiGoodsTypeAddInfo.name;
            TextBox_barCode.Text = apiGoodsTypeAddInfo.barCode;
            TextBox_price.Text = apiGoodsTypeAddInfo.price.ToString();
            TextBox_unit.Text = apiGoodsTypeAddInfo.unit;
            TextBox_details.Text = apiGoodsTypeAddInfo.details;
            TextBox_costPrice.Text = apiGoodsTypeAddInfo.costPrice.ToString();
            TextBox_inventoryAlert.Text = goodsUiInfo.inventoryAlert;
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

        private void Button_tj_OnClick(object sender, RoutedEventArgs e)
        {
            ApiGoodsTypeAddInfo addInfo = apiGoodsTypeAddInfo;
            apiGoodsTypeAddInfo.name = TextBox_name.Text;
            apiGoodsTypeAddInfo.barCode = TextBox_barCode.Text;
            apiGoodsTypeAddInfo.price = double.Parse(TextBox_price.Text.Trim());
            apiGoodsTypeAddInfo.unit = TextBox_unit.Text;
            apiGoodsTypeAddInfo.details = TextBox_details.Text;
            if (!string.IsNullOrEmpty(TextBox_costPrice.Text.Trim()))
                addInfo.costPrice = double.Parse(TextBox_costPrice.Text.Trim());
            if (ComboBox_type.SelectedItem is ComboBoxItem comboBoxItem)
            {
                var obj = comboBoxItem.DataContext as ApiTypeInfo;
                List<int> types = new List<int>();
                types.Add(obj.id);
                addInfo.typeId = types;
            }
            GoodsExtendInfo goodsExtendInfo = new GoodsExtendInfo();
            //goodsExtendInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            goodsExtendInfo.goodsId = apiGoodsTypeAddInfo.id;
            goodsExtendInfo.inventoryAlert = TextBox_inventoryAlert.Text.Trim();
            goodsExtendInfo.shelfLife = int.Parse(TextBox_shelfLife.Text.Trim());
            goodsExtendInfo.id = goodsUiInfo.bid;
            goodsExtendBusiness.Save(goodsExtendInfo);
            MessageBox.Show(goodsTypeBusiness.Insert(addInfo));

        }
    }
}
