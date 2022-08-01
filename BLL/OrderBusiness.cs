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
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
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

        public List<OrderInfo> GetList(string goodsName, int typeId, string startTime, string stopTime)
        {
            var list = GetAll();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.name.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                var goods = goodsTypeBusiness.GetAll().Where((info => int.Parse(info.typePid) == typeId)).ToList();
                List<OrderInfo> orderInfos = new List<OrderInfo>();
                foreach (var orderInfo in list)
                {
                    var goodList = goods.Where((info => info.id == orderInfo.goodsId)).ToList();
                    if (goodList.Count > 0)
                    {
                        orderInfos.Add(orderInfo);
                    }
                }
                list = orderInfos;
            }
            if (!string.IsNullOrEmpty(startTime))
            {

                list = list.Where((info =>
                {
                    DateTime date;
                    return DateTime.TryParse(info.createTime, out date) && date >= DateTime.Parse(startTime);
                })).ToList();
            }
            if (!string.IsNullOrEmpty(stopTime))
            {
                list = list.Where((info =>
                {
                    DateTime date;
                    return DateTime.TryParse(info.createTime, out date) &&
                           date <= DateTime.Parse(stopTime);
                })).ToList();
            }
            return list;
        }

        public bool IsCheck(out string msg)
        {
            throw new NotImplementedException();
        }
    }
}
