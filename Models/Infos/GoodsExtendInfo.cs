using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 商品扩展实体类
    /// </summary>
    public class GoodsExtendInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int goodsId { get; set; }
        /// <summary>
        /// 保质期 （天）
        /// </summary>
        public int shelfLife { get; set; }
        /// <summary>
        /// 库存下限
        /// </summary>
        public string inventoryAlert { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
    }
}
