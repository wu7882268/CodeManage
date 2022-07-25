using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BLL;
using Helpers;
using Models;
using Models.Infos.ApiInfo;
using Models.Interfaces;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeBusiness typeBusiness = new TypeBusiness();
            var l = typeBusiness.GetAll();
            //JsonHelper.JsonToObject<List<ApiGoodsTypeInfo>>("[{\"sort\":\"1\",\"discountOpen\":\"2\",\"id\":\"29\",\"name\":\"\\u98de\\u673a\",\"icon\":\"http:\\/\\/test.jilinyx.com\\/web\\/static\\/yb_wm\\/48\\/2022\\/07\\/12\\/202207121630133235.png\",\"salesNum\":0,\"typePid\":\"37\",\"typeId\":null,\"price\":\"1123.00\",\"stock\":\"222\",\"isRecommend\":\"2\",\"display\":\"1\",\"maxPrice\":null,\"isSpecs\":\"2\",\"storeId\":\"3\",\"comboGoodsArr\":\"\",\"isMain\":1,\"category_name\":\"\\u73a9\\u5177\",\"media\":null},{\"sort\":\"1\",\"discountOpen\":\"2\",\"id\":\"19\",\"name\":\"\\u5361\\u4e01\\u8f66\",\"icon\":\"http:\\/\\/test.jilinyx.com\\/web\\/static\\/yb_wm\\/48\\/2022\\/07\\/12\\/202207121630133235.png\",\"salesNum\":0,\"typePid\":\"37\",\"typeId\":null,\"price\":\"10.00\",\"stock\":\"2\",\"isRecommend\":\"2\",\"display\":\"1\",\"maxPrice\":null,\"isSpecs\":\"2\",\"storeId\":\"3\",\"comboGoodsArr\":\"\",\"isMain\":1,\"category_name\":\"\\u73a9\\u5177\",\"media\":null}]");
            HttpHelper.GetHttpResponse($"{ApiStatic.ApiUrl}channel/good/get-good-list", 6000, HttpHelper.ContentTypeJson,null, "page=1","type=1","&name=&typePid=&goodsType=2");

            // JObject jObject = JObject.Parse("{\r\n  [\r\n  {\r\n    \"sort\": \"1\",\r\n    \"discountOpen\": \"2\",\r\n    \"id\": \"19\",\r\n    \"name\": \"卡丁车\",\r\n    \"icon\": \"http://test.jilinyx.com/web/static/yb_wm/48/2022/07/12/202207121630133235.png\",\r\n    \"salesNum\": 0,\r\n    \"typePid\": \"37\",\r\n    \"typeId\": null,\r\n    \"price\": \"10.00\",\r\n    \"stock\": \"2\",\r\n    \"isRecommend\": \"2\",\r\n    \"display\": \"1\",\r\n    \"maxPrice\": null,\r\n    \"isSpecs\": \"2\",\r\n    \"storeId\": \"3\",\r\n    \"comboGoodsArr\": \"\",\r\n    \"isMain\": 1,\r\n    \"category_name\": \"玩具\",\r\n    \"media\": null\r\n  }\r\n]\r\n}");
            var test = JsonHelper.JsonToObject<TestInfo>(
                "{\"sort\":\"1\",\"body\":\"\",\"name\":\"水蜜桃\",\"typeId\":[\"41\"],\"icon\":\"http://test.jilinyx.com/web/static/yb_wm/48/2022/07/12/202207121630133235.png\",\"media\":[],\"minNum\":1,\"unit\":\"个\",\"boxMoney\":\"1.2\",\"price\":\"10.2\",\"stock\":\"999\",\"fillType\":\"\",\"crossedPrice\":\"\",\"costPrice\":\"\",\"goodCode\":\"\",\"salesType\":\"1\",\"validity\":[\"2022-07-20 14:08:21\",\"2022-08-19 14:08:21\"],\"weekDay\":[],\"weekSalesType\":\"1\",\"salesTimeStr\":[],\"hotsaleType\":\"1\",\"specialType\":\"0\",\"aloneType\":\"2\",\"spec\":[],\"feeding\":[],\"attribute\":[],\"details\":\"\",\"comboGoodsArr\":[],\"goodsType\":\"2\"}");
            Console.WriteLine(test.body);
            Console.WriteLine(test.typeId.Count);
            WebHeaderCollection webHeader = new WebHeaderCollection();
            string ssid = RandomHelper.GetRnd(22, true, true, false, false);
            webHeader.Add("Cookie", $"PHPSESSID={ssid}");

            var str = HttpHelper.HttpPost("http://test.jilinyx.com/index.php/channel/login/loginin",
                "{\"userName\":\"test1\",\"passWord\":\"123qwe\"}", HttpHelper.ContentTypeJson, webHeader);
            str = HttpHelper.GetHttpResponse("http://test.jilinyx.com/index.php/channel/good/get-good-list?page=1&type=1&name=&typePid=&goodsType=2", 6000, HttpHelper.ContentTypeJson, webHeader);
            str = JsonHelper.JsonSpecifiedNode(str, "data", "data");
            //System.Text.Encoding chs = System.Text.Encoding.Unicode;
            //byte[] buff = chs.GetBytes(str);
            //str = chs.GetString(buff);
            //Console.WriteLine(ssid);
            JsonHelper.JsonToObject<List<ApiGoodsTypeInfo>>(str);
            Console.WriteLine(CodeHelper.Unicode2String(str));
            Console.Read();
        }
     
    }
    public class TestInfo{
        public string body { get; set; }
        public List<string> typeId { get; set; }
    }
}
