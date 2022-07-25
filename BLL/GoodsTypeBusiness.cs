using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace BLL
{
    public class GoodsTypeBusiness:IGoodsTypeBusiness
    {
        IGoodsTypeData goodsTypeData = new GoodsTypeData();
        public List<ApiGoodsTypeInfo> GetAll()
        {
            return goodsTypeData.GetAll();
        }

        public string Insert(ApiGoodsTypeAddInfo goodsTypeAddInfo)
        {
            return goodsTypeData.Insert(goodsTypeAddInfo);
        }

        public string Delete(ApiGoodsTypeInfo   goodsTypeAddInfo)
        {
            return goodsTypeData.Delete(goodsTypeAddInfo);
        }

        public ApiGoodsTypeAddInfo GetAddId(int id)
        {
            return goodsTypeData.GetAddId(id);
        }
    }
}
