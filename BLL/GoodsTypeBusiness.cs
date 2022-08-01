using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models.Infos;
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

        public List<ApiGoodsTypeInfo> GetList(string goodsName, int typeId)
        {
            var list = GetAll();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.name.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                list = list.Where((info => int.Parse(info.typePid) == typeId)).ToList();
            }
            return list;

        }

        public bool IsCheck(out string msg)
        {
            throw new NotImplementedException();
        }
    }
}
