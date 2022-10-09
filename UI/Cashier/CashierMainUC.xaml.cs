using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Models;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace UI.Cashier
{
    /// <summary>
    /// CashierMainUC.xaml 的交互逻辑
    /// </summary>
    public partial class CashierMainUC : UserControl
    {
        //绑定集合
        private ObservableCollection<SalesInfo> observable = new ObservableCollection<SalesInfo>();
        //商品集合
        //private List<GoodsAllInfo> goodsAllInfos = new List<GoodsAllInfo>();
        private List<GoodsAllNewInfo> goodsAllInfos = new List<GoodsAllNewInfo>();

        //已添加商品集合
        private List<GoodsAllInfo> isGoodsAllInfos = new List<GoodsAllInfo>();
        private IGoodsAllBusiness goodsAllBusiness = new GoodsAllBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();

        private IOrderBusiness orderBusiness = new OrderBusiness();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();

        private bool isAuto = false;

        public CashierMainUC()
        {
            InitializeComponent();
            //goodsAllInfos = goodsAllBusiness.GetGoodsList();
            goodsAllInfos = goodsAllNewBusiness.GetGoodsList();
            //goodsList = new ObservableCollection<GoodsAllInfo>(list);
        }

        private void ListView_Sales_OnLoaded(object sender, RoutedEventArgs e)
        {

            //list.Add(new SalesUiInfo()
            //{
            //    No = 1,
            //    Number = 1,
            //    Barcode = "0000001",
            //    Name = "商品1",
            //    Price = 6.5,
            //    Amount = 6.5
            //});
            //list.Add(new SalesUiInfo()
            //{
            //    No = 2,
            //    Number = 2,
            //    Barcode = "0000002",
            //    Name = "商品2",
            //    Price = 3,
            //    Amount = 6
            //});
            ListView_Sales.DataContext = observable;
        }

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            AddGood();
        }
        private bool IsCheck()
        {
            bool b = true;
            int i;
            if (int.TryParse(TextBox_num.Text, out i))
            {
                if (i < 0)
                {
                    MessageBox.Show("数量不能小于0", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    b = false;
                    return b;
                }
            }
            else
            {
                MessageBox.Show("请输入正确的数值", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                b = false;
                return b;
            }

            return b;
        }
        private void Button_autoAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (Button_autoAdd.Content.ToString() == "扫码自动添加")
            {
                Button_autoAdd.Content = "关闭自动添加";
                isAuto = true;
            }
            else
            {
                Button_autoAdd.Content = "扫码自动添加";
                isAuto = false;
            }
        }

        private void AddGood()
        {
            if (isAuto)
            {
                List<GoodsAllNewInfo> list = goodsAllInfos.Where((info => info.barCode == TextBox_tm.Text.Trim())).ToList();
                if (list.Count > 0)
                {
                    SalesInfo salesInfo = new SalesInfo();
                    salesInfo.Barcode = list[0].barCode;
                    salesInfo.Name = list[0].name;
                    salesInfo.Price = list[0].price;
                    salesInfo.Note = list[0].note;
                    salesInfo.Number = 1;
                    salesInfo.Amount = (double)salesInfo.Number * salesInfo.Price;

                    salesInfo.goodsId = list[0].id;
                    salesInfo.unit = list[0].unit;
                    observable.Add(salesInfo);
                    Refresh();
                    TextBox_tm.Text = "";
                }
                else
                {
                    MessageBox.Show("商品不存在", "失败", MessageBoxButton.OK, MessageBoxImage.None);
                }
            }
            else
            {
                List<GoodsAllNewInfo> list = goodsAllInfos.Where((info => info.barCode == TextBox_tm.Text.Trim())).ToList();
                if (list.Count > 0)
                {
                    if (IsCheck())
                    {
                        SalesInfo salesInfo = new SalesInfo();
                        salesInfo.Barcode = list[0].barCode;
                        salesInfo.Name = list[0].name;
                        salesInfo.Price = list[0].price;
                        salesInfo.Note = list[0].note;
                        salesInfo.Number = int.Parse(TextBox_num.Text);
                        salesInfo.Amount = (double)salesInfo.Number * salesInfo.Price;

                        salesInfo.goodsId = list[0].id;
                        salesInfo.unit = list[0].unit;
                        observable.Add(salesInfo);
                        Refresh();
                        TextBox_tm.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("商品不存在", "失败", MessageBoxButton.OK, MessageBoxImage.None);
                }
            }

        }
        private void Refresh()
        {
            int num = 0;
            foreach (var salesInfo in observable)
            {
                num += salesInfo.Number;
            }
            Label_Number.Content = num.ToString();
            double money = 0;
            foreach (var salesInfo in observable)
            {
                money += salesInfo.Amount;
            }
            Label_Money.Content = money.ToString("f2");
            TextBox_YSJE.Text = money.ToString("f2");
        }

        private void TextBox_tm_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (isAuto)
            {
                if (e.Key == Key.Return || e.Key == Key.Tab)
                {
                    AddGood();
                }
            }
        }

        private void TextBox_num_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Regex re = new Regex("[^0-9.-]+");
            Regex re = new Regex("[^0-9.]+");
            e.Handled = re.IsMatch(e.Text);
        }

        private void MenuItem_delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListView_Sales.SelectedItem is SalesInfo salesInfo)
            {
                observable.Remove(salesInfo);
                Refresh();
            }
        }

        private void CleanAll()
        {
            TextBox_SSJE.Text = "";
            TextBox_jlje.Text = "";
            TextBox_yzje.Text = "";
            TextBox_YSJE.Text = "";
            TextBox_num.Text = "";
            TextBox_tm.Text = "";
            Label_Money.Content = "0.00";
            Label_Number.Content = "0";
            observable.Clear();
            Button_autoAdd.Content = "扫码自动添加";
            isAuto = false;
        }
        private void Button_sy_OnClick(object sender, RoutedEventArgs e)
        {
            if (observable.Count > 0)
            {
                foreach (var salesInfo in observable)
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        goodsId = salesInfo.goodsId,
                        money = salesInfo.Price,
                        name = salesInfo.Name,
                        note = salesInfo.Note,
                        num = salesInfo.Number,
                        totalPrice = salesInfo.Amount,
                        unit = salesInfo.unit,
                        //userId = ApiStatic.UserId
                    };
                    orderBusiness.Save(orderInfo);
                    goodsTypeBusiness.UpdateStock(salesInfo.goodsId, salesInfo.Number * -1);
                }
                MessageBox.Show("交易完成,已自动保存订单");
                CleanAll();
            }
            else
            {
                MessageBox.Show("订单生成失败，请添加商品", "失败", MessageBoxButton.OK, MessageBoxImage.None);
            }

        }

        private void Button_return_OnClick(object sender, RoutedEventArgs e)
        {
            CashierWindow.cashierWindow.Close();
        }

        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            double ysje,ssje;
            if (double.TryParse(TextBox_YSJE.Text, out ysje))
            {
                if (double.TryParse(TextBox_SSJE.Text, out ssje))
                {
                    TextBox_yzje.Text = (ssje - ysje).ToString("f2");
                    TextBox_SSJE.Text = ssje.ToString("f2");
                    TextBox_jlje.Text = TextBox_SSJE.Text;
                }
            }
        }
    }
}
