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
    /// 供应商业务接口
    /// </summary>
   public  interface ISupplierBusiness : ISupplierData
    {
        List<SupplierInfo> GetList(string supplierName, string startTime, string stopTime);
        bool IsCheck(out string msg);
    }
}
