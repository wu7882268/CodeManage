using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Infos.ApiInfo;

namespace Models.Interfaces
{
    /// <summary>
    /// 商品类型数据接口
    /// </summary>
   public  interface ITypeData
    {
        List<ApiTypeInfo> GetAll();
        string Insert(ApiTypeInfo api);
        string Delete(ApiTypeInfo api);
    }
}
