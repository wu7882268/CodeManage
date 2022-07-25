using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Helpers;
using Models.Delegates;
using Models.Infos.ApiInfo;
using Models.Interfaces;
using UI.Replenish;

namespace UI.Manage.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsUC : UserControl
    {
        public GoodsUC()
        {
            InitializeComponent();
        }
        ITypeBusiness typeBusiness = new TypeBusiness();
        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Replenish.GoodsAdd");
        }
        private void DataGrid_file_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = typeBusiness.GetAll();
            DataGrid_file.DataContext = list.SubList(0, 10);
            pg.TotalDataCount = list.Count;
            Label_num.Content = $"共有 {list.Count} 条数据";
        }

        private void Pg_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = typeBusiness.GetAll();
            Label_num.Content = $"共有 {list.Count} 条数据";
            if (pg.CurrentPageNumber <= 1)
            {
                DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
            }
            else
            {
                DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
            }
        }

        private void Button_update_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid_file.SelectedItem is ApiTypeInfo apiTypeInfo)
            {
                Delegates.JumpDelegateObj("UI.Replenish.GoodsUpdate", apiTypeInfo);
            }
        }

        private void Button_delete_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message=MessageBox.Show("您确定要删除吗", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (message == MessageBoxResult.Yes)
            {
                if (DataGrid_file.SelectedItem is ApiTypeInfo apiTypeInfo)
                {
                    MessageBox.Show(typeBusiness.Delete(apiTypeInfo));
                    var list = typeBusiness.GetAll();
                    Label_num.Content = $"共有 {list.Count} 条数据";
                    if (pg.CurrentPageNumber <= 1)
                    {
                        DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
                    }
                    else
                    {
                        DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
                    }
                }
            }
        }
    }
}
