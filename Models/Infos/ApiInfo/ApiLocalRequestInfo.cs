using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos.ApiInfo
{
    public class ApiLocalRequestInfo
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int storeId { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int page { get; set; }
    }
}
