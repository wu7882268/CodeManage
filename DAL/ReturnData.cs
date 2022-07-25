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
    public class ReturnData : IReturnData
    {
        public List<ReturnInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Save(ReturnInfo info)
        {
            throw new NotImplementedException();
        }

        public string Delete(ReturnInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
