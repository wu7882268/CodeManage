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
    public class GoodsAllData : IGoodsAllData
    {
        public List<GoodsAllNewInfo> GetAll()
        {
            //添加Cookie
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            apiLocalRequestInfo.page = 1;
            List<GoodsAllNewInfo> list = new List<GoodsAllNewInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imsybo2ov2coregoods", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "data", "total"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<GoodsAllNewInfo> subList = JsonHelper.JsonToObject<List<GoodsAllNewInfo>>(str);
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

            list = list.Where((info => info.deleteAt < 1)).ToList();
            //str = str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imsybo2ov2coregoods", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            //count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "count"));
            //str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            //subList = JsonHelper.JsonToObject<List<GoodsAllNewInfo>>(str);
            //list.JoinList(subList);
            //if (count > 20)
            //{
            //    int num = MathHelper.CountPage(20, count);
            //    for (int i = 2; i < num + 2; i++)
            //    {
            //        list.JoinList(GetPage(webHeader, i, 3));
            //    }
            //}
            return list;
        }

        private List<GoodsAllNewInfo> GetPage(WebHeaderCollection webHeader, ApiLocalRequestInfo apiLocalRequestInfo)
        {

            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imsybo2ov2coregoods", apiLocalRequestInfo, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<GoodsAllNewInfo> list = JsonHelper.JsonToObject<List<GoodsAllNewInfo>>(str);
            return list;
        }
        public string Insert(GoodsAllNewInfo goodsTypeAddInfo)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<GoodsAllNewInfo>($"{ApiStatic.ApiUrl}channel/good/goods-save", goodsTypeAddInfo,HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<GoodsAllNewInfo>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }

        public string Update(GoodsAllNewInfo goodsTypeAddInfo)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            //ApiLocalRequestInfo apiLocalRequestInfo = new ApiLocalRequestInfo();
            //apiLocalRequestInfo.storeId = ApiStatic.StoreId;
            List<GoodsAllNewInfo> list = new List<GoodsAllNewInfo>();
            string str = HttpHelper.HttpPost($"{ApiStatic.LocalApiUrl}Imsybo2ov2coregoods/update", goodsTypeAddInfo, HttpHelper.ContentTypeJson, webHeader);
            return str;
        }

        public string Delete(GoodsAllNewInfo goodsTypeAddInfo)
        {
            ApiDeleteInfo apiDeleteInfo = new ApiDeleteInfo();
            apiDeleteInfo.id = goodsTypeAddInfo.id.ToString();
            apiDeleteInfo.type = 1;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<ApiDeleteInfo>($"{ApiStatic.ApiUrl}channel/good/good-del", apiDeleteInfo, HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<List<GoodsAllNewInfo>>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }

        public GoodsAllNewInfo GetAddId(int id)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/good-detail", 6000, HttpHelper.ContentTypeJson, webHeader, $"?id={id}");
            str = JsonHelper.JsonSpecifiedNode(str, "data", "detail");
            GoodsAllNewInfo apiGoodsTypeAddInfo = JsonHelper.JsonToObject<GoodsAllNewInfo>(str);
            return apiGoodsTypeAddInfo;
        }
    }
}
