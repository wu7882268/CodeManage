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
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsUpdate : UserControl
    {
        private ApiTypeInfo apiTypeInfo = null;
        ITypeBusiness typeBusiness = new TypeBusiness();
        public GoodsUpdate(ApiTypeInfo apiTypeInfo)
        {
            InitializeComponent();
            this.apiTypeInfo = apiTypeInfo;
            TextBox_name.Text = apiTypeInfo.name;
            TextBox_desc.Text = apiTypeInfo.describe;

        }
        private bool IsCheck()
        {

            if (string.IsNullOrEmpty(TextBox_name.Text))
            {
                MessageBox.Show("失败，请添加商品名称", "提示", MessageBoxButton.OK);
                return false;
            }

            if (string.IsNullOrEmpty(TextBox_name.Text))
            {
                MessageBox.Show("失败，请添加分类名称", "提示", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                if (apiTypeInfo != null)
                {
                    apiTypeInfo.name = TextBox_name.Text;
                    apiTypeInfo.describe = TextBox_desc.Text;
                    if (ComboBox_isShow.Text == "是")
                    {
                        apiTypeInfo.display = 1;
                    }
                    else if (ComboBox_isShow.Text == "否")
                    {
                        apiTypeInfo.display = 2;
                    }

                    //apiTypeInfo.isRequire = 2;
                    //apiTypeInfo.timeType = 1;
                    //apiTypeInfo.weekStr = new List<string>();
                    //apiTypeInfo.sort = 1;
                    //apiTypeInfo.type = 2;
                    string msg = typeBusiness.Insert(apiTypeInfo);
                    MessageBox.Show(msg);
                    if (msg.Contains("已修改"))
                    {
                        Delegates.JumpDelegate("UI.Manage.Replenish.GoodsUC");
                    }
                }
            }
        }

        private void ComboBox_isShow_OnLoaded(object sender, RoutedEventArgs e)
        {
            switch (apiTypeInfo.display)
            {
                case 1:
                    ComboBox_isShow.SelectedIndex = 1;
                    break; ;
                case 2:
                    ComboBox_isShow.SelectedIndex = 2;
                    break;
                default: ComboBox_isShow.SelectedIndex = 0; 
                    break;
            }
        }

        private void Button_xyb_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Replenish.GoodsUC");
        }
    }
}
