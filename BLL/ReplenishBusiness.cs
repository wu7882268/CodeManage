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
    public class ReplenishBusiness : IReplenishBusiness
    {
        IReplenishData replenishData = new ReplenishData();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        public List<ReplenishInfo> GetAll()
        {
            return replenishData.GetAll();
        }

        public string Save(ReplenishInfo info)
        {
            return replenishData.Save(info);
        }

        public string Delete(ReplenishInfo info)
        {
            return replenishData.Delete(info);
        }

        public List<ReplenishInfo> GetList(string goodsName, string supplierName, int typeId, string startTime, string stopTime)
        {
            var list = GetAll();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.goodsName.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                var goods = goodsTypeBusiness.GetAll().Where((info => int.Parse(info.typePid) == typeId)).ToList();
                List<ReplenishInfo> replenishInfos = new List<ReplenishInfo>();
                foreach (var returnInfo in list)
                {
                    var goodList = goods.Where((info => info.id == returnInfo.goodsId)).ToList();
                    if (goodList.Count > 0)
                    {
                        replenishInfos.Add(returnInfo);
                    }
                }
                list = replenishInfos;
            }
            if (!string.IsNullOrEmpty(supplierName))
            {
                list = list.Where((info => info.supplierName.Contains(supplierName))).ToList();
            }
            if (!string.IsNullOrEmpty(startTime))
            {

                list = list.Where((info =>
                {
                    DateTime date;
                    return DateTime.TryParse(info.purchaseTime, out date) && date >= DateTime.Parse(startTime);
                })).ToList();
            }
            if (!string.IsNullOrEmpty(stopTime))
            {
                list = list.Where((info =>
                {
                    DateTime date;
                    return DateTime.TryParse(info.purchaseTime, out date) &&
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
