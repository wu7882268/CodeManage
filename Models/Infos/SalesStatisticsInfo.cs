using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Infos
{
    /// <summary>
    /// 营销统计实体类
    /// </summary>
    public class SalesStatisticsInfo 
    {
        /// <summary>
        /// 总营销 
        /// </summary>
        public double numTotal { get; set; }
        /// <summary>
        /// 总盈利 
        /// </summary>
        public double numPrice { get; set; }
        /// <summary>
        /// 总支出 
        /// </summary>
        public double spending { get; set; }
        /// <summary>
        /// 退货金额 
        /// </summary>
        public double returnPrice { get; set; }

    }
}
