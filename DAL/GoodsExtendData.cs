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
    public class GoodsExtendData : IGoodsExtendData
    {
        public List<GoodsExtendInfo> GetAll()
        {
            List<GoodsExtendInfo> list = new List<GoodsExtendInfo>();
            return list;
        }

        public string Save(GoodsExtendInfo info)
        {
            return "";
        }

        public string Delete(GoodsExtendInfo info)
        {
            return "";
        }
    }
}
