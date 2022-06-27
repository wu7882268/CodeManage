using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Models.Infos;

namespace UI.Cashier
{
    /// <summary>
    /// CashierMainUC.xaml 的交互逻辑
    /// </summary>
    public partial class CashierMainUC : UserControl
    {
        public CashierMainUC()
        {
            InitializeComponent();
        }

        private void ListView_Sales_OnLoaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<SalesUiInfo> list = new ObservableCollection<SalesUiInfo>();
            list.Add(new SalesUiInfo()
            {
                No = 1,
                Number = 1,
                Barcode = "0000001",
                Name = "商品1",
                Price = 6.5,
                Amount = 6.5
            });
            list.Add(new SalesUiInfo()
            {
                No = 2,
                Number = 2,
                Barcode = "0000002",
                Name = "商品2",
                Price = 3,
                Amount = 6
            });
            ListView_Sales.DataContext = list;
        }
    }
}
