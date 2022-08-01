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
    /// 顾客退货业务接口
    /// </summary>
   public  interface IReturnCustomerBusiness : IReturnCustomerData
    {
        List<ReturnCustomerInfo> GetList(string goodsName, int typeId, string startTime, string stopTime);
        bool IsCheck(out string msg);
    }
}
