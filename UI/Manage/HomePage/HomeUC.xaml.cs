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
using LiveCharts;
using LiveCharts.Wpf;
using Models.Infos;
using Models.Interfaces;

namespace UI.Manage.HomePage
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        IHomePageBusiness homePageBusiness = new HomePageBusiness();
        public HomeUC()
        {
            InitializeComponent();
            Map1();
            UpdateTop();
            DataContext = this;
        }

        private void DataGrid_Warning_OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTop()
        {
           TodayMessageInfo todayMessageInfo = homePageBusiness.GetTodayMessage();
           Label_NumGoodsSpecies.Content = todayMessageInfo.NumGoodsSpecies;
           Label_NumInventory.Content = todayMessageInfo.NumInventory;
           Label_NumReplenish.Content = todayMessageInfo.NumReplenish;
           Label_PriceReplenish.Content = todayMessageInfo.PriceReplenish;
           Label_PriceReturn.Content = todayMessageInfo.PriceReturn;
           Label_PriceSales.Content = todayMessageInfo.PriceSales;
        }
        private void UpdateTable()
        {
            List<WarningInfo> warningInfos = homePageBusiness.GetWarning();
            DataGrid_Warning.DataContext = warningInfos;
            Label_WarningNum.Content = warningInfos.Count;
        }
        private void Map1()
        {
            LineCountMapInfo lineCountMap = homePageBusiness.GetLineMap();
            //添加折线图的数据

            for (int i = 0; i < lineCountMap.Lines.Count; i++)
            {
                if (lineCountMap.Labels.Count == lineCountMap.Lines[i].Values.Count)
                {
                    LineSeries mylineseries = new LineSeries();
                    //设置折线的标题
                    mylineseries.Title = lineCountMap.Lines[i].Title;
                    //折线图直线形式
                    mylineseries.LineSmoothness = 0;
                    // 折线拐点的形状尺寸
                    mylineseries.PointGeometrySize = 5;
                    //折线图的无点样式
                    mylineseries.PointGeometry = DefaultGeometries.Square;
                    //添加横坐标
                    Labels = lineCountMap.Labels;
                    double[] values = new double[lineCountMap.Labels.Count];
                    for (int j = 0; j < values.Length; j++)
                    {
                        values[j] = lineCountMap.Lines[i].Values[j];
                    }
                    mylineseries.Values = new ChartValues<double>(values);
                    SeriesCollection = new SeriesCollection { };
                    SeriesCollection.Add(mylineseries);
                }
            }
            Formatter = value => value.ToString("N");
        }

        private void Button_refresh_OnClick(object sender, RoutedEventArgs e)
        {
            Map1();
            UpdateTop();
            UpdateTable();
            DataContext = this;
        }
    }
}
