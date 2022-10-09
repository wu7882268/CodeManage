using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
   public static class InfoHelper
    {
        /// <summary>
        /// 把所有为null的string类型属性设置为指定值
        /// </summary>
        /// <typeparam name="T">属性的类型</typeparam>
        /// <param name="t">属性对象</param>
        /// <param name="defaultString">默认值</param>
        public static void InitializeString<T>(T t,string defaultString="") where T:class,new()
        {
            Type type = t.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if(property.GetType() == typeof(string))
                {
                    if(!string.IsNullOrEmpty(property.GetValue(t).ToString()))
                        property.SetValue(t, defaultString);
                }
            }
        }
        public static void InitializeIntNull<T>(T t, int defaultInt = 0) where T : class, new()
        {
            Type type = t.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetType() == typeof(int?))
                {
                    if (property.GetValue(t)==null)
                        property.SetValue(t, defaultInt);
                }
            }
        }
        public static void InitializeDoubleNull<T>(T t, double defaultDouble = 0) where T : class, new()
        {
            Type type = t.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetType() == typeof(double?))
                {
                    if (property.GetValue(t) == null)
                        property.SetValue(t, defaultDouble);
                }
            }
        }
    }
}
