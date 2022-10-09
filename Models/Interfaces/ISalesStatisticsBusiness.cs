using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 销售统计接口
    /// </summary>
   public  interface ISalesStatisticsBusiness
    {
        string StartTime { get; set; }
        string StopTIme { get; set; }
        int GoodType { get; set; }
        /// <summary>
        /// 获取营销信息
        /// </summary>
        /// <returns></returns>
        SalesStatisticsInfo GetProfit();
        /// <summary>
        /// 获取营销折线统计图
        /// </summary>
        /// <returns></returns>
        LineCountMapInfo GetLineMap();
        /// <summary>
        /// 获取营销排行
        /// </summary>
        /// <returns></returns>
        List<SalesRankingInfo> GetSalesRanking();
        /// <summary>
        /// 获取圆形统计图
        /// </summary>
        /// <returns></returns>
        List<RoundCountInfo> GetRoundCountMap();
    }
}
