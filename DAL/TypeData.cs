using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace DAL
{
    public class TypeData : ITypeData
    {
        public List<ApiTypeInfo> GetAll()
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            List<ApiTypeInfo> list = new List<ApiTypeInfo>();
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/category/get-category-list", 6000, HttpHelper.ContentTypeJson, webHeader, $"?page=1&storeId={ApiStatic.StoreId}");
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "count"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            var subList = JsonHelper.JsonToObject<List<ApiTypeInfo>>(str);
            list.JoinList(subList);
            if (count > 10)
            {
                int num = MathHelper.CountPage(10, count);
                for (int i = 2; i < num + 2; i++)
                {
                    list.JoinList(GetPage(webHeader, i));
                }
            }
            return list;
        }
        private List<ApiTypeInfo> GetPage(WebHeaderCollection webHeader, int page)
        {
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/category/get-category-list", 6000, HttpHelper.ContentTypeJson, webHeader, $"?page={page}&storeId=1");
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ApiTypeInfo> list = JsonHelper.JsonToObject<List<ApiTypeInfo>>(str);
            return list;
        }
        public string Insert(ApiTypeInfo api)
        {
            api.storeId = ApiStatic.StoreId;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<ApiTypeInfo>($"{ApiStatic.ApiUrl}channel/category/category-save", api, HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<ApiTypeInfo>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }

        public string Delete(ApiTypeInfo api)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            api.storeId = ApiStatic.StoreId;
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<ApiTypeInfo>($"{ApiStatic.ApiUrl}channel/category/category-del", api, HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<ApiTypeInfo>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }
    }
}
