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
    /// 商品业务接口
    /// </summary>
   public  interface IGoodsTypeBusiness: IGoodsTypeData
    {
        List<ApiGoodsTypeInfo> GetList(string goodsName, int typeId);
        bool IsCheck(out string msg);
    }
}
