using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Interfaces;

namespace BLL
{
    public  class CashierBusiness: ICashierBusiness
    {
        IGoodsAllBusiness goodsAllBusiness = new GoodsAllBusiness();
        public List<SalesInfo> GetSalesList()
        {
            List<SalesInfo> salesInfos = new List<SalesInfo>();
            var list = goodsAllBusiness.GetGoodsList();
            foreach (var goodsAll in list)
            {
                SalesInfo salesInfo = new SalesInfo();
                salesInfo.Barcode = goodsAll.barCode;
                salesInfo.Name = goodsAll.name;
                salesInfo.Price = goodsAll.price??0;
                salesInfo.Note = goodsAll.note;
            }
            return salesInfos;
        }
    }
}
