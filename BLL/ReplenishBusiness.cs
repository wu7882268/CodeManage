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
    public class ReplenishBusiness : IReplenishBusiness
    {
        IReplenishData replenishData = new ReplenishData();
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
    }
}
