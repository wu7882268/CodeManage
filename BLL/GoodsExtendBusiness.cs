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
    public class GoodsExtendBusiness : IGoodsExtendBusiness
    {
        IGoodsExtendData goodsExtendData = new GoodsExtendData();
        public List<GoodsExtendInfo> GetAll()
        {
            return goodsExtendData.GetAll();
        }

        public string Save(GoodsExtendInfo info)
        {
            return goodsExtendData.Save(info);
        }

        public string Delete(GoodsExtendInfo info)
        {
            return goodsExtendData.Delete(info);
        }
    }
}
