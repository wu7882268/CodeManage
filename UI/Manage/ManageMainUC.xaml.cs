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
using UI.Manage.Information;
using UI.Manage.InventoryManage;
using UI.Manage.Replenish;
using UI.Manage.Sales;
using UI.Manage.Statistical;

namespace UI.Manage
{
    /// <summary>
    /// ManageMainUC.xaml 的交互逻辑
    /// </summary>
    public partial class ManageMainUC : UserControl
    {
        public ManageMainUC()
        {
            InitializeComponent();
        }
        private void Expander_sjjh_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_qxgl.IsExpanded = false;
            expander_rzsj.IsExpanded = false;

            expander_sqfw.IsExpanded = false;
            expander_tjfx.IsExpanded = false;
        }

        private void Expander_sqfw_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_qxgl.IsExpanded = false;
            expander_rzsj.IsExpanded = false;
            expander_sjjh.IsExpanded = false;

            expander_tjfx.IsExpanded = false;
        }

        private void Expander_rzsj_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_qxgl.IsExpanded = false;
            expander_sjjh.IsExpanded = false;

            expander_sqfw.IsExpanded = false;
            expander_tjfx.IsExpanded = false;
        }

        private void Expander_tjfx_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_qxgl.IsExpanded = false;
            expander_rzsj.IsExpanded = false;
            expander_sjjh.IsExpanded = false;

            expander_sqfw.IsExpanded = false;
        }

        private void Expander_kzmb_Expanded(object sender, RoutedEventArgs e)
        {
            expander_qxgl.IsExpanded = false;
            expander_rzsj.IsExpanded = false;
            expander_sjjh.IsExpanded = false;

            expander_sqfw.IsExpanded = false;
            expander_tjfx.IsExpanded = false;
        }

        private void Expander_qxgl_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_rzsj.IsExpanded = false;
            expander_sjjh.IsExpanded = false;
            expander_sqfw.IsExpanded = false;
            expander_tjfx.IsExpanded = false;
        }

        private void Expander_sjkgl_Expanded(object sender, RoutedEventArgs e)
        {
            expander_kzmb.IsExpanded = false;
            expander_qxgl.IsExpanded = false;
            expander_rzsj.IsExpanded = false;
            expander_sjjh.IsExpanded = false;
            expander_sqfw.IsExpanded = false;
            expander_tjfx.IsExpanded = false;
        }
        private void SamplenoSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (samplenoSource.SelectedItem == ComboBoxItem_grxx)
            {
                ContentControl_main.Content = null;
                //ContentControlsub.Content = new Frame()
                //{

                //    Content = new Personal()
                //};
            }
            else if (samplenoSource.SelectedItem == ComboBoxItem_xgmm)
            {
                ContentControl_main.Content = null;
                //ContentControlsub.Content = new Frame()
                //{

                //    Content = new password()
                //};
            }
            else if (samplenoSource.SelectedItem == ComboBoxItem_bbxx)
            {
                ContentControl_main.Content = null;
                //ContentControlsub.Content = new Frame()
                //{

                //    Content = new version()
                //};
            }
            else if (samplenoSource.SelectedItem == ComboBoxItem_aqtc)
            {
                ManageWindow.manageWindow.Close();
            }
            samplenoSource.SelectedItem = null;
        }

        private void Button_gysgl_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new SupplierUC()
            };
        }

        private void Button_type_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new TypeUC()
            };
        }

        private void Button_Goods_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new GoodsUC()
            };
        }

        private void Button_Replenish_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new ReplenishUC()
            };
        }

        private void Button_Return_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new ReturnUC()
            };
        }

        private void Button_User_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new CustomerUC()
            };
        }

        private void Button_spxs_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new SalesUC()
            };
        }

        private void Button_rzsj_gkth_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new CustomerReturnUC()
            };
        }

        private void Button_ckgl_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new WarehouseUC()
            };
        }

        private void Button_kcgl_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new TransfersUC()
            };
        }

        private void Button_xstj_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new SalesStatistics()
            };
        }

        private void Button_kctj_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControlsub.Content = new Frame()
            {
                Content = new InventoryStatistics()
            };
        }
    }
}
