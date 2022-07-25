using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Helpers;
using Models;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace BLL
{
    public class OrderBusiness : IOrderBusiness
    {
        IOrderData orderData = new OrderData();
        public List<OrderInfo> GetAll()
        {
            return orderData.GetAll();
        }

        public string Save(OrderInfo info)
        {
            return orderData.Save(info);
        }

        public string Delete(OrderInfo info)
        {
            return orderData.Delete(info);
        }
    }
}
