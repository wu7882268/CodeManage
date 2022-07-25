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
    public class ReturnBusiness : IReturnBusiness
    {
        IReturnData returnData = new ReturnData();
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
    }
}
