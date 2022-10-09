using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos
{
    /// <summary>
    /// 折线统计图实体类
    /// </summary>
    public class LineCountMapInfo
    {
        /// <summary>
        /// 所有折线
        /// </summary>
        public List<LineCountInfo> Lines { get; set; }
        /// <summary>
        /// 横坐标
        /// </summary>
        public List<string> Labels { get; set; }

    }
}
