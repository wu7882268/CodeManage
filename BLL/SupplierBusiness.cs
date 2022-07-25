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
    public class SupplierBusiness : ISupplierBusiness
    {
        ISupplierData supplierData = new SupplierData();
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
    }
}
