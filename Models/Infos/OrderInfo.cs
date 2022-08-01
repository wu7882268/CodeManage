using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 订单实体类
    /// </summary>
    public class OrderInfo
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
        /// 商品id
        /// </summary>
        public int goodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public double money { get; set; }
        /// <summary>
        /// 商品总价
        /// </summary>
        public double totalPrice { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 商备注
        /// </summary>
        public string note { get; set; }
    }
}
