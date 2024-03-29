﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 退货信息业务接口
    /// </summary>
   public  interface IReturnBusiness : IReturnData
    {
        List<ReturnInfo> GetList(string goodsName, string supplierName, int typeId, string startTime, string stopTime);
        bool IsCheck(out string msg);
    }
}
