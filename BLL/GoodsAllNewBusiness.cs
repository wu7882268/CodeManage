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
   public partial class GoodsAllNewBusiness : IGoodsAllNewBusiness
    {
        IGoodsAllData goodsAllData = new GoodsAllData();
        ITypeBusiness typeBusiness = new TypeBusiness();
        public List<GoodsAllNewInfo> GetGoodsList()
        {
            List<GoodsAllNewInfo> goodsAllNewInfos = goodsAllData.GetAll();
            List<ApiTypeInfo> typeInfos = typeBusiness.GetAll();
            foreach (var goodsAllNewInfo in goodsAllNewInfos)
            {
                List<ApiTypeInfo> typeList = typeInfos.Where((info => info.id == goodsAllNewInfo.typePid)).ToList();
                if (typeList.Count > 0)
                {
                    goodsAllNewInfo.category_name = typeList[0].name;

                }
            }
            return goodsAllNewInfos;
        }

        public List<GoodsAllNewInfo> GetGoodsList(string goodsName, int typeId, string startTime, string stopTime)
        {
            var list = GetGoodsList();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.name.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                list = list.Where((info => info.typePid == typeId)).ToList();
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

        public string Update(GoodsAllNewInfo goodsTypeAddInfo)
        {
            return goodsAllData.Update(goodsTypeAddInfo);
        }
    }
}
