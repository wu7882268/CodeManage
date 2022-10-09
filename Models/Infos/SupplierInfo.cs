using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 供应商信息实体类
    /// </summary>
    public class SupplierInfo
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
        /// 供应商名称
        /// </summary>
        public string supplierName { get; set; }
        /// <summary>
        /// 供应商电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
    }
}
