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
   public  interface IHomePageBusiness
    {
        /// <summary>
        /// 获取今日信息
        /// </summary>
        /// <returns></returns>
        TodayMessageInfo GetTodayMessage();
        /// <summary>
        /// 获取今日盈利统计图
        /// </summary>
        /// <returns></returns>
        LineCountMapInfo GetLineMap();

        /// <summary>
        /// 获取报价信息
        /// </summary>
        /// <returns></returns>
        List<WarningInfo> GetWarning();
    }
}
