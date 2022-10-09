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
    public class SalesStatisticsBusiness : ISalesStatisticsBusiness
    {
        private IOrderBusiness orderBusiness = new OrderBusiness();
        private IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        private IReplenishBusiness replenishBusiness = new ReplenishBusiness();
        private IReturnCustomerBusiness returnCustomerBusiness = new ReturnCustomerBusiness();
        private IReturnBusiness returnBusiness = new ReturnBusiness();
        private IGoodsAllNewBusiness goodsAllBusiness = new GoodsAllNewBusiness();
        public string StartTime { get; set; }
        public string StopTIme { get; set; }
        public int GoodType { get; set; }

        public SalesStatisticsBusiness()
        {
            StartTime = "";
            StopTIme = "";
            GoodType = -1;
        }

        public List<RoundCountInfo> GetRoundCountMap()
        {
            List<RoundCountInfo> roundCountInfos = new List<RoundCountInfo>();
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            List<GoodsAllNewInfo> goods = goodsAllBusiness.GetGoodsList();
            var groupBy = orderInfos.GroupBy((info => info.goodsId)).ToList();
            int s = 0;
            if (groupBy.Count > 5)
            {
                s = 5;
            }
            else
            {
                s = groupBy.Count;
            }
            for (int i = 0; i < s; i++)
            {
                RoundCountInfo roundCount = new RoundCountInfo();
                roundCount.Values = groupBy[i].Sum((info => info.totalPrice));
                roundCount.Title = goods.Where((info => info.id == groupBy[i].Key)).First().name;
                roundCountInfos.Add(roundCount);
            }

            return roundCountInfos;
        }
        public List<SalesRankingInfo> GetSalesRanking()
        {
            List<SalesRankingInfo> salesRankingInfos = new List<SalesRankingInfo>();
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            List<IGrouping<string, OrderInfo>> groupBy = orderInfos.OrderByDescending((info => DateTime.Parse(info.createTime))).GroupBy((info => info.createTime.Substring(0,10))).ToList();
            List<double> nums = new List<double>();
            List<IGrouping<string, OrderInfo>> groupList = groupBy.OrderByDescending((infos => infos.Sum((info => info.totalPrice)))).ToList();
            int s = 0;
            if (groupBy.Count> 5)
            {
                s = 5;
            }
            else
            {
                s = groupBy.Count;
            }
            for (int i = 0; i < s; i++)
            {
                SalesRankingInfo salesRankingInfo = new SalesRankingInfo();
                salesRankingInfo.Price=groupList[i].Sum((info => info.totalPrice));
                salesRankingInfo.date = groupList[i].Key;
                salesRankingInfos.Add(salesRankingInfo);
            }
            return salesRankingInfos;
        }

        public LineCountMapInfo GetLineMap()
        {
            LineCountMapInfo lineCountMap = new LineCountMapInfo();
            LineCountInfo lineCountInfo = new LineCountInfo();
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            //List<ApiGoodsTypeInfo> goods = goodsTypeBusiness.GetAll();
            //List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("", "", -1, StartTime, StopTIme);
            //List<ReturnCustomerInfo> returnCustomerInfos = returnCustomerBusiness.GetList("", -1, StartTime, StopTIme);
            //orderInfos.Sort(((info, orderInfo) => info.createTime.CompareTo(orderInfo.createTime))).GroupBy((info => info.createTime.Substring(10)));
            //销售统计分组
            var groupBy = orderInfos.OrderByDescending((info => DateTime.Parse(info.createTime))).GroupBy((info => info.createTime.Substring(0,9)));
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
            lineCountInfo.Title = "销售统计";
            lineCountMap.Lines = new List<LineCountInfo>();
            lineCountMap.Lines.Add(lineCountInfo);

            //营销统计分组

            return lineCountMap;
        }

        public SalesStatisticsInfo GetProfit()
        {
            SalesStatisticsInfo salesStatisticsInfo = new SalesStatisticsInfo();
            //总营销
            salesStatisticsInfo.numTotal = 0;
            //总盈利
            salesStatisticsInfo.numPrice = 0;
            //总支出
            salesStatisticsInfo.spending = 0;
            List<OrderInfo> orderInfos = orderBusiness.GetList("", GoodType, StartTime, StopTIme);
            List<ReturnInfo> returnInfos = returnBusiness.GetList("", "", GoodType, StartTime, StopTIme);
            List<ReplenishInfo> replenishInfos = replenishBusiness.GetList("", "", GoodType, StartTime, StopTIme);
            List<ReturnCustomerInfo> returnCustomerInfos = returnCustomerBusiness.GetList("", GoodType, StartTime, StopTIme);
            foreach (var orderInfo in orderInfos)
            {
                salesStatisticsInfo.numTotal += orderInfo.totalPrice;
            }
            //进货总价
            double replenishPrice = replenishInfos.Sum((info => info.totalPrice));
            //客户退货总价
            double returnCustomerPrice = returnCustomerInfos.Sum((info => info.totalPrice));
            //退货总价
            double returnPrice = returnInfos.Sum((info => info.totalPrice));
            //foreach (var orderInfo in orderInfos)
            //{

            //    ApiGoodsTypeInfo goodsTypeInfo = goods.Where((info => info.id == orderInfo.goodsId)).First();
            //    salesStatisticsInfo.numPrice += orderInfo.totalPrice - goodsTypeInfo.costPrice * orderInfo.num;
            //}
            salesStatisticsInfo.spending = replenishPrice + returnCustomerPrice;
            salesStatisticsInfo.numPrice = salesStatisticsInfo.numTotal - replenishPrice - returnCustomerPrice + returnPrice;
            return salesStatisticsInfo;
        }
    }
}
