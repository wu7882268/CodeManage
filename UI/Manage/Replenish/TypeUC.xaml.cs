using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;
using UI.Models;

namespace UI.Manage.Replenish
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TypeUC : UserControl
    {
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        ITypeBusiness typeBusiness = new TypeBusiness();
        IGoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
        private string goodsName = "";
        private int typeId = -1;
        public TypeUC()
        {
            InitializeComponent();
        }

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Replenish.TypeAdd");
        }

        private void DataGrid_file_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = GetList();
            //DataGrid_file.DataContext = list.SubList(0,10); 
            //pg.TotalDataCount = list.Count;
        }

        private void Pg_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = GetList();
            //if (pg.CurrentPageNumber <= 1)
            //{
            //    DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
            //}
            //else
            //{
            //    DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
            //}
        }

        private void Pg_OnLoaded(object sender, RoutedEventArgs e)
        {
            //pg.PageDataCountCollection = new ObservableCollection<int>() { 15, 10 };
        }

        private void Button_update_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid_file.SelectedItem is GoodsUiInfo goodsUiInfo)
            {
                Delegates.JumpDelegateObj("UI.Replenish.TypeUpdate", goodsUiInfo);
            }
        }

        private void Button_delete_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("您确定要删除吗", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (message == MessageBoxResult.Yes)
            {
                if (DataGrid_file.SelectedItem is GoodsUiInfo goodsUiInfo)
                {
                    MessageBox.Show(goodsTypeBusiness.Delete(goodsUiInfo));
                    var list = GetList();
                    //if (pg.CurrentPageNumber <= 1)
                    //{
                    //    DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
                    //}
                    //else
                    //{
                    //    DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
                    //}
                }
            }
        }

        private void ComboBox_type_OnLoaded(object sender, RoutedEventArgs e)
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

        private List<GoodsUiInfo> GetList()
        {
            var apiGoodsTypeInfos = goodsTypeBusiness.GetList(goodsName, typeId);
            var goodsExtendInfos = goodsExtendBusiness.GetAll();
            var list = (from a in apiGoodsTypeInfos
                        join b in goodsExtendInfos on a.id equals b.goodsId
                        select new GoodsUiInfo()
                        {
                            barCode = a.barCode,
                            category_name = a.category_name,
                            comboGoodsArr = a.comboGoodsArr,
                            discountOpen = a.discountOpen,
                            display = a.display,
                            icon = a.icon,
                            id = a.id,
                            isMain = a.isMain,
                            isRecommend = a.isRecommend,
                            isSpecs = a.isSpecs,
                            maxPrice = a.maxPrice,
                            media = a.media,
                            name = a.name,
                            price = a.price,
                            salesNum = a.salesNum,
                            sort = a.sort,
                            stock = a.stock,
                            storeId = a.storeId,
                            typeId = a.typeId,
                            typePid = a.typePid,
                            unit = a.unit,
                            shelfLife = b.shelfLife,
                            createTime = b.createTime,
                            bid = b.id,
                            inventoryAlert = b.inventoryAlert,
                        }).ToList();
            List<int> ids = list.Select((info => info.id)).ToList();
            foreach (ApiGoodsTypeInfo apiGoodsTypeInfo in apiGoodsTypeInfos)
            {
                if (!ids.Contains(apiGoodsTypeInfo.id))
                {
                    GoodsUiInfo goodsUiInfo = JsonHelper.ParentToSubObject<ApiGoodsTypeInfo, GoodsUiInfo>(apiGoodsTypeInfo);
                    list.Add(goodsUiInfo);
                }
            }
            pg.TotalDataCount = list.Count;
            Label_num.Content = $"共有 {list.Count} 条数据";
            if (pg.CurrentPageNumber <= 1)
            {
                DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
            }
            else
            {
                DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
            }

            return list;
        }
        private void Button_select_OnClick(object sender, RoutedEventArgs e)
        {

            goodsName = TextBox_name.Text;
            if (ComboBox_type.SelectedIndex > 0)
            {
                typeId = ((ComboBox_type.SelectedItem as ComboBoxItem).DataContext as ApiTypeInfo).id;
            }
            else
            {
                typeId = -1;
            }
            var list = GetList();

            //if (pg.CurrentPageNumber <= 1)
            //{
            //    DataGrid_file.DataContext = list.SubList(0, pg.PageDataCount);
            //}
            //else
            //{
            //    DataGrid_file.DataContext = list.SubList((pg.CurrentPageNumber - 1) * pg.PageDataCount, pg.PageDataCount);
            //}
        }
    }
}
