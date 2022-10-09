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
    public class ApiReturnMsgInfo
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int status { get; set; }
    }
}
