using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Infos
{
    /// <summary>
    /// 今日信息实体类
    /// </summary>
    public class TodayMessageInfo
    {
        /// <summary>
        /// 销售金额
        /// </summary>
        public double PriceSales { get; set; }
        /// <summary>
        /// 退货金额
        /// </summary>
        public double PriceReturn { get; set; }
        /// <summary>
        /// 进货数量
        /// </summary>
        public int NumReplenish { get; set; }
        /// <summary>
        /// 进货金额 
        /// </summary>
        public double PriceReplenish { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int NumInventory { get; set; }
        /// <summary>
        /// 商品种类数量
        /// </summary>
        public int NumGoodsSpecies { get; set; }


    }
}
