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

namespace UI.Manage.InventoryManage
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TransfersALL : UserControl
    {
        private ApiGoodsTypeAddInfo apiGoodsTypeAddInfo;
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        public TransfersALL(GoodsAllNewInfo apiGoodsTypeInfo)
        {
            InitializeComponent();
            apiGoodsTypeAddInfo = goodsTypeBusiness.GetAddId(apiGoodsTypeInfo.id);
            TextBox_name.Text = apiGoodsTypeInfo.name;
            TextBox_stock.Text = apiGoodsTypeInfo.stock.ToString();
            TextBox_type.Text = apiGoodsTypeInfo.category_name;
        }
        private bool IsCheck()
        {
            if (!int.TryParse(TextBox_stock.Text, out _))
            {
                MessageBox.Show("失败，请添加正确的库存数量", "提示", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        private void Button_gg_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                ApiGoodsTypeAddInfo addInfo = apiGoodsTypeAddInfo;
                if (int.TryParse(TextBox_stock.Text, out int i))
                {
                    addInfo.stock = i;
                }
                else
                {
                    MessageBox.Show("失败，请选填写正确的数量", "提示", MessageBoxButton.OK);

                }

                string msg = goodsTypeBusiness.Insert(addInfo);
                MessageBox.Show(msg);
                if (msg.Contains("成功"))
                {
                    Delegates.JumpDelegate("UI.Manage.InventoryManage.TransfersUC");
                }

            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.InventoryManage.TransfersUC");
        }
    }
}
