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
    /// 订单数据接口
    /// </summary>
   public  interface IOrderData : IPcApiDataBase<OrderInfo>
    {
    }
}
