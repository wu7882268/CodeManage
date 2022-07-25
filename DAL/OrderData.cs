using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace DAL
{
    public class OrderData : IOrderData
    {
        public List<OrderInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Save(OrderInfo info)
        {
            throw new NotImplementedException();
        }

        public string Delete(OrderInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
