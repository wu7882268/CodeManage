using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Infos
{
    /// <summary>
    /// 营销统计实体类
    /// </summary>
    public class InventoryStatisticsInfo
    {
        /// <summary>
        /// 进货数量
        /// </summary>
        public int numReplenish { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int numSales { get; set; }
        /// <summary>
        /// 进货金额 
        /// </summary>
        public double priceReplenish { get; set; }
        /// <summary>
        /// 销售金额 
        /// </summary>
        public double priceSales { get; set; }

    }
}
