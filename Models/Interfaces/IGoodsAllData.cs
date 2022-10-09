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
    /// 商品数据接口
    /// </summary>
    public interface IGoodsAllData
    {
        List<GoodsAllNewInfo> GetAll();
        string Insert(GoodsAllNewInfo goodsTypeAddInfo);
        string Update(GoodsAllNewInfo goodsTypeAddInfo);
        string Delete(GoodsAllNewInfo goodsTypeAddInfo);
        GoodsAllNewInfo GetAddId(int id);
    }
}
