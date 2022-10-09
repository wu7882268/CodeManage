using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 商品数据接口
    /// </summary>
    public interface IGoodsTypeData
    {
        List<ApiGoodsTypeInfo> GetAll();
        string Insert(ApiGoodsTypeAddInfo goodsTypeAddInfo);
        string Delete(ApiGoodsTypeAddInfo goodsTypeAddInfo);
        ApiGoodsTypeAddInfo GetAddId(int id);
    }
}
