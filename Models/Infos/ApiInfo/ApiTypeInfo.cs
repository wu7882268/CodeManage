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
    public class ApiTypeInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 自定义属性名称(必选 畅销  热销)
        /// </summary>
        public string customName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图标地址
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string describe { get; set; }
        /// <summary>
        /// 1 显示，2隐藏 
        /// </summary>
        public int display { get; set; }
        /// <summary>
        /// 时间段开始时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 时间段结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 周一到周日拼接的字符串
        /// </summary>
        public List<string> weekStr { get; set; }
        /// <summary>
        /// 1必选2不是必选
        /// </summary>
        public int isRequire { get; set; }
        /// <summary>
        /// 时间类型
        /// </summary>
        public int timeType { get; set; }
        /// <summary>
        /// children
        /// </summary>
        public List<string> children { get; set; }
        /// <summary>
        /// type
        /// </summary>
        public int type { get; set; }
    }
}
