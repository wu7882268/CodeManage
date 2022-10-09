using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 商品扩展业务接口
    /// </summary>
   public  interface IGoodsAllBusiness
    {
        List<GoodsAllInfo> GetGoodsList();
        List<GoodsAllInfo> GetGoodsList(string goodsName, int typeId, string startTime, string stopTime);
    }
}
