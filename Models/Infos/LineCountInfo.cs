using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 单条折线实体类
    /// </summary>
    public class LineCountInfo
    {
        /// <summary>
        /// 值
        /// </summary>
        public List<double> Values { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

    }
}