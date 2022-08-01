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
    public class ReturnBusiness : IReturnBusiness
    {
        IReturnData returnData = new ReturnData();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();

        public List<ReturnInfo> GetAll()
        {
            return returnData.GetAll();
        }

        public string Save(ReturnInfo info)
        {
            return returnData.Save(info);
        }

        public string Delete(ReturnInfo info)
        {
            return returnData.Delete(info);
        }

        public List<ReturnInfo> GetList(string goodsName, string supplierName, int typeId,string startTime,string stopTime)
        {
            var list = GetAll();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.goodsName.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                var goods = goodsTypeBusiness.GetAll().Where((info => int.Parse(info.typePid) == typeId)).ToList();
                List<ReturnInfo> returnInfos = new List<ReturnInfo>();
                foreach (var returnInfo in list)
                {
                    var goodList = goods.Where((info => info.id == returnInfo.goodsId)).ToList();
                    if (goodList.Count > 0)
                    {
                        returnInfos.Add(returnInfo);
                    }
                }
                list = returnInfos;
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
                    return DateTime.TryParse(info.returnTime, out date) && date >= DateTime.Parse(startTime);
                })).ToList();
            }
            if (!string.IsNullOrEmpty(stopTime))
            {
                list = list.Where((info =>
                {
                    DateTime date;
                    return DateTime.TryParse(info.returnTime, out date) &&
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
