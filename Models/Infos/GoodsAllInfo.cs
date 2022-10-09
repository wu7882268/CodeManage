using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Infos
{
    public class GoodsAllInfo : ApiGoodsTypeInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int bid { get; set; }
        /// <summary>
        /// 保质期 （天）
        /// </summary>
        public int shelfLife { get; set; }
        /// <summary>
        /// 库存下限
        /// </summary>
        public int inventoryAlert { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string note { get; set; }

    }
}
