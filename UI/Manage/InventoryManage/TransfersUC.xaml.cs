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

namespace UI.Manage.InventoryManage
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class TransfersUC : UserControl
    {
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        ITypeBusiness typeBusiness = new TypeBusiness();
        private string goodsName = "";
        private int typeId = -1;
        public TransfersUC()
        {
            InitializeComponent();
        }

        private void DataGrid_file_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = GetList();
            Label_num.Content = $"共有 {list.Count} 条数据";
            DataGrid_file.DataContext = list.SubList(0, 10);
            pg.TotalDataCount = list.Count;
        }

        private void Pg_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = GetList();
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
        private void Pg_OnLoaded(object sender, RoutedEventArgs e)
        {
            //pg.PageDataCountCollection = new ObservableCollection<int>() { 15, 10 };
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

        private List<ApiGoodsTypeInfo> GetList()
        {
            var list = goodsTypeBusiness.GetAll();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.name.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                list = list.Where((info => int.Parse(info.typePid) == typeId)).ToList();
            }
            pg.TotalDataCount = list.Count;
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
            if (DataGrid_file.SelectedItem is ApiGoodsTypeInfo apiGoodsTypeInfo)
            {
                Delegates.JumpDelegateObj("UI.Manage.InventoryManage.TransfersALL", apiGoodsTypeInfo);
            }
        }
    }
}
