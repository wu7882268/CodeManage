using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 退货信息实体类
    /// </summary>
    public class ReturnInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 退货单价
        /// </summary>
        public double returnPrice { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string supplierName { get; set; }
        /// <summary>
        /// 退货时间
        /// </summary>
        public string returnTime { get; set; }
        /// <summary>
        /// 退货原因
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
    }
}
