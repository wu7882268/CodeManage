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
    public class ReplenishData : IReplenishData
    {
        public List<ReplenishInfo> GetAll()
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            apiLocalRequestInfo.page = 1;
            List<ReplenishInfo> list = new List<ReplenishInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcreplenish", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "data", "total"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ReplenishInfo> subList = JsonHelper.JsonToObject<List<ReplenishInfo>>(str);
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
        private List<ReplenishInfo> GetPage(WebHeaderCollection webHeader, ApiLocalRequestInfo apiLocalRequestInfo)
        {
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcreplenish", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ReplenishInfo> list = JsonHelper.JsonToObject<List<ReplenishInfo>>(str);
            return list;
        }
        public string Save(ReplenishInfo info)
        {
            info.storeId = ApiStatic.StoreId;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<ReplenishInfo>($"{ApiStatic.LocalApiUrl}Imspcreplenish/update", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            else
            {
                string str = HttpHelper.HttpPost<ReplenishInfo>($"{ApiStatic.LocalApiUrl}Imspcreplenish/add", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }

        public string Delete(ReplenishInfo info)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<ReplenishInfo>($"{ApiStatic.LocalApiUrl}Imspcreplenish/delete", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }
    }
}
