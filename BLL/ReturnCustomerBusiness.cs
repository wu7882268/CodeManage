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
    public class ReturnCustomerBusiness : IReturnCustomerBusiness
    {
        IReturnCustomerData returnCustomerData = new ReturnCustomerData();
        public List<ReturnCustomerInfo> GetAll()
        {
            return returnCustomerData.GetAll();
        }

        public string Save(ReturnCustomerInfo info)
        {
            return returnCustomerData.Save(info);
        }

        public string Delete(ReturnCustomerInfo info)
        {
            return returnCustomerData.Delete(info);
        }
    }
}
