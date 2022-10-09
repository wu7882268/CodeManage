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
    public class OrderData : IOrderData
    {
        public List<OrderInfo> GetAll()
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            apiLocalRequestInfo.page = 1;
            List<OrderInfo> list = new List<OrderInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcorder", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "data", "total"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<OrderInfo> subList = JsonHelper.JsonToObject<List<OrderInfo>>(str);
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
        private List<OrderInfo> GetPage(WebHeaderCollection webHeader, ApiLocalRequestInfo apiLocalRequestInfo)
        {
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imspcorder", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<OrderInfo> list = JsonHelper.JsonToObject<List<OrderInfo>>(str);
            return list;
        }
        public string Save(OrderInfo info)
        {
            info.storeId = ApiStatic.StoreId;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<OrderInfo>($"{ApiStatic.LocalApiUrl}Imspcorder/update", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if(apiMsg.status==200)
                    return "成功";
            }
            else
            {
                string str = HttpHelper.HttpPost<OrderInfo>($"{ApiStatic.LocalApiUrl}Imspcorder/add", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }

        public string Delete(OrderInfo info)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            if (info.id > 0)
            {
                string str = HttpHelper.HttpPost<OrderInfo>($"{ApiStatic.LocalApiUrl}Imspcorder/delete", info, HttpHelper.ContentTypeJson, webHeader);
                var apiMsg = JsonHelper.JsonToObject<ApiReturnMsgInfo>(CodeHelper.Unicode2String(str));
                if (apiMsg.status == 200)
                    return "成功";
            }
            return "失败";
        }
    }
}
