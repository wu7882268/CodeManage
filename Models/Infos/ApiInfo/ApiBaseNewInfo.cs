using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos.ApiInfo
{
    /// <summary>
    /// api数据基础实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiBaseNewInfo
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }
}
