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
    /// 订单业务接口
    /// </summary>
   public  interface IOrderBusiness : IOrderData
    {
        List<OrderInfo> GetList(string goodsName, int typeId, string startTime, string stopTime);
        bool IsCheck(out string msg);
    }
}
