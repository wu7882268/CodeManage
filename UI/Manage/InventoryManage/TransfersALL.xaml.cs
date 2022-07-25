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
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Manage.InventoryManage
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TransfersALL : UserControl
    {
        private ApiGoodsTypeAddInfo apiGoodsTypeAddInfo;
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        public TransfersALL(ApiGoodsTypeInfo apiGoodsTypeInfo)
        {
            InitializeComponent();
            apiGoodsTypeAddInfo = goodsTypeBusiness.GetAddId(apiGoodsTypeInfo.id);
            TextBox_name.Text = apiGoodsTypeInfo.name;
            TextBox_stock.Text = apiGoodsTypeInfo.stock.ToString();
            TextBox_type.Text = apiGoodsTypeInfo.category_name;
        }

        private void Button_gg_OnClick(object sender, RoutedEventArgs e)
        {
            ApiGoodsTypeAddInfo addInfo = apiGoodsTypeAddInfo;
            addInfo.stock = int.Parse(TextBox_stock.Text);    
            MessageBox.Show(goodsTypeBusiness.Insert(addInfo));
        }
    }
}
