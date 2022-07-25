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
    public class GoodsTypeData: IGoodsTypeData
    {
        public List<ApiGoodsTypeInfo> GetAll()
        {
            //添加Cookie
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");

            List<ApiGoodsTypeInfo> list = new List<ApiGoodsTypeInfo>();
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/get-good-list?page=1&type=1&name=&typePid=&goodsType=2", 6000, HttpHelper.ContentTypeJson, webHeader);
            int count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "count"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ApiGoodsTypeInfo> subList = JsonHelper.JsonToObject<List<ApiGoodsTypeInfo>>(str);
            list.JoinList(subList);
            if (count > 10)
            {
                int num = MathHelper.CountPage(10, count);
                for (int i = 2; i < num + 2; i++)
                {
                    list.JoinList(GetPage(webHeader, i, 1));
                }
            }
           

            str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/get-good-list?page=1&type=3&name=&typePid=&goodsType=2", 6000, HttpHelper.ContentTypeJson, webHeader);
            count = int.Parse(JsonHelper.JsonSpecifiedNode(str, "count"));
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            subList = JsonHelper.JsonToObject<List<ApiGoodsTypeInfo>>(str);
            list.JoinList(subList);
            if (count > 10)
            {
                int num = MathHelper.CountPage(10, count);
                for (int i = 2; i < num + 2; i++)
                {
                    list.JoinList(GetPage(webHeader, i, 3));
                }
            }
            return list;
        }

        private List<ApiGoodsTypeInfo> GetPage(WebHeaderCollection webHeader,int page,int type)
        {
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/get-good-list?page={page}&type={type}&name=&typePid=&goodsType=2", 6000, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            List<ApiGoodsTypeInfo> list = JsonHelper.JsonToObject<List<ApiGoodsTypeInfo>>(str);
            return list;
        }
        public string Insert(ApiGoodsTypeAddInfo goodsTypeAddInfo)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();

            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<ApiGoodsTypeAddInfo>($"{ApiStatic.ApiUrl}channel/good/goods-save", goodsTypeAddInfo,HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<ApiGoodsTypeAddInfo>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }

        public string Delete(ApiGoodsTypeInfo goodsTypeAddInfo)
        {
            ApiDeleteInfo apiDeleteInfo = new ApiDeleteInfo();
            apiDeleteInfo.id = goodsTypeAddInfo.id.ToString();
            apiDeleteInfo.type = 1;
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.HttpPost<ApiDeleteInfo>($"{ApiStatic.ApiUrl}channel/good/good-del", apiDeleteInfo, HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<List<ApiGoodsTypeInfo>>>(CodeHelper.Unicode2String(str));
            return apiMsg.msg;
        }

        public ApiGoodsTypeAddInfo GetAddId(int id)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            webHeader.Add("Cookie", $"PHPSESSID={ApiStatic.PHPSESSID}");
            string str = HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/good-detail", 6000, HttpHelper.ContentTypeJson, webHeader, $"?id={id}");
            str = JsonHelper.JsonSpecifiedNode(str, "data", "detail");
            ApiGoodsTypeAddInfo apiGoodsTypeAddInfo = JsonHelper.JsonToObject<ApiGoodsTypeAddInfo>(str);
            return apiGoodsTypeAddInfo;
        }
    }
}
