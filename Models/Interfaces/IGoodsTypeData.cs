using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 登录业务接口
    /// </summary>
    public interface IGoodsTypeData
    {
        List<ApiGoodsTypeInfo> GetAll();
        string Insert(ApiGoodsTypeAddInfo goodsTypeAddInfo);
        string Delete(ApiGoodsTypeInfo goodsTypeAddInfo);
        ApiGoodsTypeAddInfo GetAddId(int id);
    }
}
