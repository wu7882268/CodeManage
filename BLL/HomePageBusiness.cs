using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace BLL
{
    public class HomePageBusiness : IHomePageBusiness
    {
        private IOrderBusiness orderBusiness = new OrderBusiness();
        private IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        private IReplenishBusiness replenishBusiness = new ReplenishBusiness();
        private IGoodsAllBusiness goodsAllBusiness = new GoodsAllBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();
        private IReturnCustomerBusiness returnCustomerBusiness = new ReturnCustomerBusiness();
        private string StartTime { get; set; }
        private string StopTIme { get; set; }
        private int GoodType { get; set; }

        public HomePageBusiness()
        {
            StartTime = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            StopTIme = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            GoodType = -1;
        }
        public TodayMessageInfo GetTodayMessage()
        {
            TodayMessageInfo todayMessageInfo = new TodayMessageInfo();
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("", "", GoodType, StartTime, StopTIme);
            List<ReturnCustomerInfo> returnCustomerInfos = returnCustomerBusiness.GetList("", GoodType, StartTime, StopTIme);
            //List<GoodsAllInfo> goodsAllInfos = goodsAllBusiness.GetGoodsList("", GoodType, StartTime, StopTIme);
            List<GoodsAllNewInfo> goodsAllInfos = goodsAllNewBusiness.GetGoodsList("", GoodType, "", "");

            todayMessageInfo.PriceSales = orderInfos.Sum((info => info.totalPrice));
            todayMessageInfo.PriceReturn = returnCustomerInfos.Sum((info => info.totalPrice));
            todayMessageInfo.NumInventory = goodsAllInfos.Sum((info => info.stock));
            todayMessageInfo.NumGoodsSpecies = goodsAllInfos.Count;
            todayMessageInfo.NumReplenish = replenishInfos.Sum((info => info.number));
            todayMessageInfo.PriceReplenish = replenishInfos.Sum((info => info.totalPrice));
            return todayMessageInfo;
        }

        public LineCountMapInfo GetLineMap()
        {
            LineCountMapInfo lineCountMap = new LineCountMapInfo();
            LineCountInfo lineCountInfo = new LineCountInfo();
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            //销售统计分组
            var groupBy = orderInfos.GroupBy((info => info.name));
            lineCountMap.Labels = new List<string>();
            lineCountInfo.Values = new List<double>();
            foreach (var g in groupBy)
            {
                lineCountMap.Labels.Add(g.Key);
                double num = 0;
                foreach (var orderInfo in g)
                {
                    num += orderInfo.totalPrice;
                }
                
                lineCountInfo.Values.Add(num);
            }

            lineCountInfo.Title = "商品盈利统计";
            lineCountMap.Lines = new List<LineCountInfo>();
            lineCountMap.Lines.Add(lineCountInfo);

            //营销统计分组
            return lineCountMap;
        }

        public List<WarningInfo> GetWarning()
        {
            List<WarningInfo> warningInfos = new List<WarningInfo>();
            //List<GoodsAllInfo> goodsAllInfos = goodsAllBusiness.GetGoodsList("", GoodType, "", "");
            List<GoodsAllNewInfo> goodsAllInfos = goodsAllNewBusiness.GetGoodsList("", GoodType, "", "");

            foreach (var goodsAllInfo in goodsAllInfos)
            {
                if (goodsAllInfo.inventoryAlert > goodsAllInfo.stock)
                {
                    WarningInfo warningInfo = new WarningInfo();
                    warningInfo.NoticeInformation =
                        $"{goodsAllInfo.name}商品库存不足，剩余{goodsAllInfo.stock}{goodsAllInfo.unit}";
                    warningInfo.NoticeType = "警告";
                    warningInfos.Add(warningInfo);
                }
            }

            return warningInfos;
        }
    }
}
