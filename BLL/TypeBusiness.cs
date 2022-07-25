using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace BLL
{
    public class TypeBusiness : ITypeBusiness
    {
        ITypeData typeData = new TypeData();
        public List<ApiTypeInfo> GetAll()
        {
            return typeData.GetAll();
        }

        public string Insert(ApiTypeInfo api)
        {
            return typeData.Insert(api);
        }

        public string Delete(ApiTypeInfo api)
        {
            return typeData.Delete(api);
        }
    }
}
