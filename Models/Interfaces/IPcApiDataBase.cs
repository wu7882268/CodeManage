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
   public  interface IPcApiDataBase<T>where  T:class,new()
    {
        List<T> GetAll();
        string Save(T info);
        string Delete(T info);
    }
}
