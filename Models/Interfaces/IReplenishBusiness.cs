using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 送货信息业务接口
    /// </summary>
   public  interface IReplenishBusiness : IReplenishData
    {
        List<ReplenishInfo> GetList(string goodsName, string supplierName, int typeId, string startTime, string stopTime);
        bool IsCheck(out string msg);
    }
}
