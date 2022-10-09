using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 客户退货信息实体类
    /// </summary>
    public class ReturnCustomerInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public int storeId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int goodsId { get; set; }
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
        /// 退货总价
        /// </summary>
        public double totalPrice { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 是否返还商品 1是 0否
        /// </summary>
        public int isReturnGoods { get; set; }
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
