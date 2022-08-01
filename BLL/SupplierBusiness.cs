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
    public class SupplierBusiness : ISupplierBusiness
    {
        ISupplierData supplierData = new SupplierData();
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        public List<SupplierInfo> GetAll()
        {
            return supplierData.GetAll();
        }

        public string Save(SupplierInfo info)
        {
            return supplierData.Save(info);
        }

        public string Delete(SupplierInfo info)
        {
            return supplierData.Delete(info);
        }

        public List<SupplierInfo> GetList(string supplierName, string startTime, string stopTime)
        {
            var list = GetAll();
            if (!string.IsNullOrEmpty(supplierName))
            {
                list = list.Where((info => info.supplierName.Contains(supplierName))).ToList();
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
