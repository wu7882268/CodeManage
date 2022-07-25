using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    /// <summary>
    /// 登录业务接口
    /// </summary>
   public  interface ILogInBusiness
    {
        (bool, string) Login(string userName, string password);
    }
}
