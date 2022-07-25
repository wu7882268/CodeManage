using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos.ApiInfo
{
    /// <summary>
    /// api数据基础模板
    /// </summary>
    public class ApiLoginInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 最后一次操作的公众号ID
        /// </summary>
        public int uniacid { get; set; }
        /// <summary>
        /// 1连锁版管理员2普通管理员3门店管理员4收银员
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 商店ID
        /// </summary>
        public string storeId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string trueName { get; set; }
    }
}
