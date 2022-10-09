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
    public class ReturnData : IReturnData
    {
        public List<ReturnInfo> GetAll()
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            apiLocalRequestInfo.page = 1;
            List<ReturnInfo> list = new List<ReturnInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcreturn", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "data", "total"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ReturnInfo> subList = JsonHelper.JsonToObject<List<ReturnInfo>>(str);
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
        private List<ReturnInfo> GetPage(WebHeaderCollection webHeader, ApiLocalRequestInfo apiLocalRequestInfo)
        {
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcreturn", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ReturnInfo> list = JsonHelper.JsonToObject<List<ReturnInfo>>(str);
            return list;
        }
        public string Save(ReturnInfo info)
        {
            info.storeId = ApiStatic.StoreId;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<ReturnInfo>($"{ApiStatic.LocalApiUrl}Imspcreturn/update", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            else
            {
                string str = HttpHelper.HttpPost<ReturnInfo>($"{ApiStatic.LocalApiUrl}Imspcreturn/add", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }

        public string Delete(ReturnInfo info)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<ReturnInfo>($"{ApiStatic.LocalApiUrl}Imspcreturn/delete", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }
    }
}
