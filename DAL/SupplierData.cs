using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;
using Models.Infos;
using Models.Infos.ApiInfo;
using Models.Interfaces;

namespace DAL
{
    public class SupplierData : ISupplierData
    {
        public List<SupplierInfo> GetAll()
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            apiLocalRequestInfo.page = 1;
            List<SupplierInfo> list = new List<SupplierInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcsupplier", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "data", "total"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<SupplierInfo> subList = JsonHelper.JsonToObject<List<SupplierInfo>>(str);
            list.JoinList(subList);
            if (count > 20)
            {
                int num = MathHelper.CountPage(20, count);
                for (int i = 2; i < num + 2; i++)
                {
                    apiLocalRequestInfo.page = i;
                    list.JoinList(GetPage(webHeader, apiLocalRequestInfo));
                }
            }
            return list;
        }
        private List<SupplierInfo> GetPage(WebHeaderCollection webHeader, ApiLocalRequestInfo apiLocalRequestInfo)
        {
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcsupplier", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<SupplierInfo> list = JsonHelper.JsonToObject<List<SupplierInfo>>(str);
            return list;
        }
        public string Save(SupplierInfo info) 
        {
            info.storeId = ApiStatic.StoreId;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<SupplierInfo>($"{ApiStatic.LocalApiUrl}Imspcsupplier/update", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            else
            {
                string str = HttpHelper.HttpPost<SupplierInfo>($"{ApiStatic.LocalApiUrl}Imspcsupplier/add", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }

        public string Delete(SupplierInfo info)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<SupplierInfo>($"{ApiStatic.LocalApiUrl}Imspcsupplier/delete", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }
    }
}
