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
    public class InventoryStatisticsBusiness : IInventoryStatisticsBusiness
    {
        private IOrderBusiness orderBusiness = new OrderBusiness();
        private IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        private IReplenishBusiness replenishBusiness = new ReplenishBusiness();
        private IGoodsAllBusiness goodsAllBusiness = new GoodsAllBusiness();
        private IReturnCustomerBusiness returnCustomerBusiness = new ReturnCustomerBusiness();
        private IGoodsAllNewBusiness goodsAllNewBusiness = new GoodsAllNewBusiness();

        public string StartTime { get; set; }
        public string StopTIme { get; set; }
        public int GoodType { get; set; }

        public InventoryStatisticsBusiness()
        {
            StartTime = "";
            StopTIme = "";
            GoodType = -1;
        }
        /// <summary>
        /// 库存统计图
        /// </summary>
        /// <returns></returns>
        public List<RoundCountInfo> GetRoundCountMap()
        {
            List<RoundCountInfo> roundCountInfos = new List<RoundCountInfo>();
            
            //List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            //List<ApiGoodsTypeInfo> goods = goodsTypeBusiness.GetAll();
            //List<GoodsAllInfo> goodsAllInfos = goodsAllBusiness.GetGoodsList("", GoodType, StartTime, StopTIme);
            List<GoodsAllNewInfo> goodsAllInfos = goodsAllNewBusiness.GetGoodsList("", GoodType, StartTime, StopTIme);

            goodsAllInfos = goodsAllInfos.OrderByDescending((info => info.stock)).ToList();
            int s = 0;
            if (goodsAllInfos.Count > 10)
            {
                s = 10;
            }
            else
            {
                s = goodsAllInfos.Count;
            }
            for (int i = 0; i < s; i++)
            {
                RoundCountInfo roundCount = new RoundCountInfo();
                roundCount.Values = goodsAllInfos[i].stock;
                roundCount.Title = goodsAllInfos[i].name;
                roundCountInfos.Add(roundCount);
            }
            return roundCountInfos;
        }
        /// <summary>
        /// 退货统计图
        /// </summary>
        /// <returns></returns>
        public List<RoundCountInfo> GetRoundReturnMap()
        {
            List<RoundCountInfo> roundCountInfos = new List<RoundCountInfo>();
            //List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            //List<ApiGoodsTypeInfo> goods = goodsTypeBusiness.GetAll();
            List<ReturnCustomerInfo> returnCustomerInfos = returnCustomerBusiness.GetList("", GoodType, StartTime, StopTIme);
            if (returnCustomerInfos.Count < 1)
            {
                return roundCountInfos;
            }
            returnCustomerInfos = returnCustomerInfos.OrderByDescending((info => DateTime.Parse(info.createTime.ToString()))).ToList();
            int s = 0;
            if (returnCustomerInfos.Count > 10)
            {
                s = 10;
            }
            else
            {
                s = returnCustomerInfos.Count;
            }
            for (int i = 0; i < s; i++)
            {
                RoundCountInfo roundCount = new RoundCountInfo();
                roundCount.Values = returnCustomerInfos[i].number;
                roundCount.Title = returnCustomerInfos[i].goodsName;
                roundCountInfos.Add(roundCount);
            }
            return roundCountInfos;
        }


        public LineCountMapInfo GetLineMap()
        {
            LineCountMapInfo lineCountMap = new LineCountMapInfo();
            LineCountInfo lineCountInfo = new LineCountInfo();
            List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("","" ,GoodType, StartTime, StopTIme);
            //List<ApiGoodsTypeInfo> goods = goodsTypeBusiness.GetAll();
            //List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("", "", GoodType, StartTime, StopTIme);
            //List<ReturnCustomerInfo> returnCustomerInfos = returnCustomerBusiness.GetList("", GoodType, StartTime, StopTIme);
            //orderInfos.Sort(((info, orderInfo) => info.createTime.CompareTo(orderInfo.createTime))).GroupBy((info => info.createTime.Substring(10)));
            //销售统计分组
            var groupBy = replenishInfos.OrderByDescending((info => DateTime.Parse(info.createTime))).GroupBy((info => info.createTime.Substring(0,10)));
            lineCountMap.Labels = new List<string>();
            lineCountInfo.Values = new List<double>();
            foreach (var g in groupBy)
            {
                lineCountMap.Labels.Add(g.Key);
                double num = 0;
                foreach (var replenishInfo in g)
                {
                    num += replenishInfo.number;
                }
                lineCountInfo.Values.Add(num);
            }
            lineCountInfo.Title = "进货统计";
            lineCountMap.Lines = new List<LineCountInfo>();
            lineCountMap.Lines.Add(lineCountInfo);

            //营销统计分组

            return lineCountMap;
        }

        public InventoryStatisticsInfo GetReplenish()
        {
            InventoryStatisticsInfo salesStatisticsInfo = new InventoryStatisticsInfo();
            //进货数量
            salesStatisticsInfo.numReplenish = 0;
            //销售数量
            salesStatisticsInfo.numSales = 0;
            //进货金额
            salesStatisticsInfo.priceReplenish = 0;
            //销售金额
            salesStatisticsInfo.priceSales = 0;
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("", "", GoodType, StartTime, StopTIme);
            salesStatisticsInfo.numSales = orderInfos.Sum((info => info.num));
            salesStatisticsInfo.numReplenish = replenishInfos.Sum((info => info.number));
            salesStatisticsInfo.priceReplenish = replenishInfos.Sum((info => info.totalPrice));
            salesStatisticsInfo.priceSales = orderInfos.Sum((info => info.totalPrice));
            return salesStatisticsInfo;
        }
    }
}
