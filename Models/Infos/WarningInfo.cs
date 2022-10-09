using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 告警通知实体类
    /// </summary>
    public class WarningInfo
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public string NoticeType { get; set; }
        /// <summary>
        /// 通知信息
        /// </summary>
        public string NoticeInformation { get; set; }
        
    }
}
