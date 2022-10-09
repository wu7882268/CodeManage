using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace BLL
{
   public partial class GoodsAllBusiness:IGoodsAllBusiness
    {
        IGoodsTypeBusiness goodsTypeBusiness = new GoodsTypeBusiness();
        IGoodsExtendBusiness goodsExtendBusiness = new GoodsExtendBusiness();
        public List<GoodsAllInfo> GetGoodsList()
        {
            List<ApiGoodsTypeInfo> apiGoodsTypeInfos = goodsTypeBusiness.GetAll();
            List<GoodsExtendInfo> goodsExtendInfos = goodsExtendBusiness.GetAll();
            List<GoodsAllInfo> list = (from a in apiGoodsTypeInfos
                join b in goodsExtendInfos on a.id equals b.goodsId
                select new GoodsAllInfo()
                {
                    barCode = a.barCode,
                    category_name = a.category_name,
                    comboGoodsArr = a.comboGoodsArr,
                    discountOpen = a.discountOpen,
                    display = a.display,
                    icon = a.icon,
                    id = a.id,
                    isMain = a.isMain,
                    isRecommend = a.isRecommend,
                    isSpecs = a.isSpecs,
                    maxPrice = a.maxPrice,
                    media = a.media,
                    name = a.name,
                    price = a.price,
                    salesNum = a.salesNum,
                    sort = a.sort,
                    stock = a.stock,
                    storeId = a.storeId,
                    typeId = a.typeId,
                    typePid = a.typePid,
                    unit = a.unit,
                    shelfLife = b.shelfLife,
                    createTime = b.createTime,
                    bid = b.id,
                    inventoryAlert = b.inventoryAlert,
                    note = b.note
                }).ToList();
            return list;
        }

        public List<GoodsAllInfo> GetGoodsList(string goodsName, int typeId, string startTime, string stopTime)
        {
            var list = GetGoodsList();
            if (!string.IsNullOrEmpty(goodsName))
            {
                list = list.Where((info => info.name.Contains(goodsName))).ToList();
            }
            if (typeId > 0)
            {
                list = list.Where((info => int.Parse(info.typePid) == typeId)).ToList();
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

    }
}
