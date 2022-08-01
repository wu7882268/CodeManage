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
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Manage.Sales
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class SalesUC : UserControl
    {
        IOrderBusiness orderBusiness = new OrderBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        ITypeBusiness typeBusiness = new TypeBusiness();
        private string goodsName = "";
        private int typeId = -1;
        private string startTime = "";
        private string stopTime = "";
        public SalesUC()
        {
            InitializeComponent();
        }

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Sales.SalesAdd");
        }
        private void DataGrid_file_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = GetList();
            //DataGrid_file.DataContext = list.SubList(0, 10);
            //pg.TotalDataCount = list.Count;
        }

        private void Pg_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = GetList();

        }
        private void Button_update_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid_file.SelectedItem is OrderInfo orderInfo)
            {
                //Delegates.JumpDelegateObj("UI.Replenish.TypeUpdate", orderInfo);
            }
        }

        private void Button_delete_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("您确定要删除吗", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (message == MessageBoxResult.Yes)
            {
                if (DataGrid_file.SelectedItem is OrderInfo orderInfo)
                {
                    MessageBox.Show(orderBusiness.Delete(orderInfo));
                    var list = GetList();
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
        private List<OrderInfo> GetList()
        {
            var list = orderBusiness.GetList(goodsName, typeId, startTime, stopTime);
            if (pg != null)
                pg.TotalDataCount = list.Count;
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
            goodsName = TextBox_goodsName.Text.Trim();
            startTime = DateTimePicker_start.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            stopTime = DateTimePicker_stop.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (ComboBox_type.SelectedIndex > 0)
            {
                typeId = ((ComboBox_type.SelectedItem as ComboBoxItem).DataContext as ApiTypeInfo).id;
            }
            else
            {
                typeId = -1;
            }
            var list = GetList();
        }

    }
}
