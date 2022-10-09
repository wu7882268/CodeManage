using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Infos
{
    public class GoodsAllNewInfo
    {
        /// <summary>
        /// bid
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public int storeId { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public int typePid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string category_name { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int stock { get; set; }
        /// <summary>
        /// 商品条码
        /// </summary>
        public string barCode { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 保质期 （天）
        /// </summary>
        public int? shelfLife { get; set; }
        /// <summary>
        /// 库存下限
        /// </summary>
        public int? inventoryAlert { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public int deleteAt { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        public string note { get; set; }

    }
}
