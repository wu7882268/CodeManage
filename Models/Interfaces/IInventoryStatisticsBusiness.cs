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
    /// 进货统计接口
    /// </summary>
   public  interface IInventoryStatisticsBusiness
    {
        string StartTime { get; set; }
        string StopTIme { get; set; }
        int GoodType { get; set; }
        /// <summary>
        /// 获取进货信息
        /// </summary>
        /// <returns></returns>
        InventoryStatisticsInfo GetReplenish();
        /// <summary>
        /// 获取进货折线统计图
        /// </summary>
        /// <returns></returns>
        LineCountMapInfo GetLineMap();

        /// <summary>
        /// 退货圆形统计图
        /// </summary>
        /// <returns></returns>
        List<RoundCountInfo> GetRoundReturnMap();
        /// <summary>
        /// 获取圆形统计图
        /// </summary>
        /// <returns></returns>
        List<RoundCountInfo> GetRoundCountMap();
    }
}
