using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;
using Models.Infos.ApiInfo;

namespace BLL
{
    public class LogInBusiness: ILogInBusiness
    {
        public (bool,string) Login(string userName, string password)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            string ssid = RandomHelper.GetRnd(22, true, true, false, false);
            webHeader.Add("Cookie", $"PHPSESSID={ssid}");
            string msg = HttpHelper.HttpPost($"{ApiStatic.ApiUrl}channel/login/loginin",
                "{\"userName\":\""+ userName + "\",\"passWord\":\"" + password + "\"}", HttpHelper.ContentTypeJson, webHeader);
            var apiMsg = JsonHelper.JsonToObject<ApiBaseInfo<ApiLoginInfo>>(CodeHelper.Unicode2String(msg));
            if (apiMsg.msg.Contains("登录成功"))
            {
                ApiStatic.PHPSESSID = ssid;
                ApiStatic.UserName = apiMsg.data.userName;
                ApiStatic.UserId = apiMsg.data.id;
                return (true,apiMsg.msg);
            }
            else
            {
                return (false, apiMsg.msg);
            }
        }
    }
}
