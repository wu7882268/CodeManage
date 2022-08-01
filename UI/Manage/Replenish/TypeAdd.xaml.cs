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
        GoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
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

        private void Button_tj_OnClick(object sender, RoutedEventArgs e)
        {
            ApiGoodsTypeAddInfo addInfo = new ApiGoodsTypeAddInfo()
            {
                name = TextBox_name.Text,
                barCode = TextBox_barCode.Text,
                price = double.Parse(TextBox_price.Text.Trim()),
                unit = TextBox_unit.Text,
                details = TextBox_details.Text,
                goodsType = 2,
            };
            if(!string.IsNullOrEmpty(TextBox_costPrice.Text.Trim()))
                addInfo.costPrice = double.Parse(TextBox_costPrice.Text.Trim());
            if (ComboBox_type.SelectedItem is ComboBoxItem comboBoxItem)
            {
                var obj = comboBoxItem.DataContext as ApiTypeInfo;
                List<int> types = new List<int>();
                types.Add(obj.id);
                addInfo.typeId = types;
            }
            string msg = goodsTypeBusiness.Insert(addInfo);
            var goods =  goodsTypeBusiness.GetAll().Where((info =>
                info.name == addInfo.name && info.barCode == addInfo.barCode && info.barCode == addInfo.barCode &&
                info.unit == addInfo.unit)).Last();
            GoodsExtendInfo goodsExtendInfo = new GoodsExtendInfo();
            goodsExtendInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            goodsExtendInfo.goodsId = goods.id;
            goodsExtendInfo.inventoryAlert = TextBox_inventoryAlert.Text.Trim();
            goodsExtendInfo.shelfLife = int.Parse(TextBox_shelfLife.Text.Trim());
            goodsExtendBusiness.Save(goodsExtendInfo);
            MessageBox.Show(msg);

        }
    }
}
