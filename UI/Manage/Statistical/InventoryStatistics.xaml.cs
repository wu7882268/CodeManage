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
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Manage.Statistical
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class InventoryStatistics : UserControl
    {
        ITypeBusiness typeBusiness = new TypeBusiness();
        IInventoryStatisticsBusiness inventoryStatisticsBusiness = new InventoryStatisticsBusiness();
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection SeriesCollection1 { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        public InventoryStatistics()
        {
            InitializeComponent();
            SetProfit();
            Map1();
            Map2();
            Map3();
            DataContext = this;
        }
        private void SetProfit()
        {
            InventoryStatisticsInfo inventoryStatisticsInfo = inventoryStatisticsBusiness.GetReplenish();
            Label_priceNum.Content = inventoryStatisticsInfo.numSales;
            Label_replenishNum.Content = inventoryStatisticsInfo.numReplenish;
            Label_JHJE.Content = inventoryStatisticsInfo.priceReplenish;
            Label_XSJE.Content = inventoryStatisticsInfo.priceSales;

        }
        private void Map1()
        {
            LineCountMapInfo lineCountMap = inventoryStatisticsBusiness.GetLineMap();
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
        private void Map2()
        {
            List<PieSeries> list = new List<PieSeries>();
            List<RoundCountInfo> roundCountInfos = inventoryStatisticsBusiness.GetRoundCountMap();
            for (int i = 0; i < roundCountInfos.Count; i++)
            {
                list.Add(new PieSeries());
                list[i].DataLabels = true;
                list[i].LabelPoint = chartPoint =>
                    string.Format("{0:P}", chartPoint.Participation);
                list[i].Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
                list[i].FontSize = 10;
                list[i].Title = roundCountInfos[i].Title;
                list[i].Values = new ChartValues<double>(new double[] { roundCountInfos[i].Values });
                SeriesCollection1 = new SeriesCollection();
                foreach (var li in list)
                {
                    SeriesCollection1.Add(li);
                }
            }
        }
        private void Map3()
        {
            List<PieSeries> list = new List<PieSeries>();
            List<RoundCountInfo> roundCountInfos = inventoryStatisticsBusiness.GetRoundReturnMap();
            for (int i = 0; i < roundCountInfos.Count; i++)
            {
                list.Add(new PieSeries());
                list[i].DataLabels = true;
                list[i].LabelPoint = chartPoint =>
                    string.Format("{0:P}", chartPoint.Participation);
                list[i].Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
                list[i].FontSize = 10;
                list[i].Title = roundCountInfos[i].Title;
                list[i].Values = new ChartValues<double>(new double[] { roundCountInfos[i].Values });
                SeriesCollection2 = new SeriesCollection();
                foreach (var li in list)
                {
                    SeriesCollection2.Add(li);
                }
            }
        }

        private void Button_select_OnClick(object sender, RoutedEventArgs e)
        {
            inventoryStatisticsBusiness.StartTime = TimePicker_startTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            inventoryStatisticsBusiness.StopTIme = TimePicker_stopTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (ComboBox_type.SelectedIndex > 0)
            {
                inventoryStatisticsBusiness.GoodType = ((ComboBox_type.SelectedItem as ComboBoxItem).DataContext as ApiTypeInfo).id;
            }
            else
            {
                inventoryStatisticsBusiness.GoodType = -1;
            }
            SetProfit();
            Map1();
            Map2();
            Map3();
            DataContext = this;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
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
    }
}

