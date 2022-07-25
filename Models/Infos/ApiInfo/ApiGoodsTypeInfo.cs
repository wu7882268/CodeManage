using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos.ApiInfo
{
    /// <summary>
    /// api数据基础模板
    /// </summary>
    public class ApiGoodsTypeInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 折扣1开启2关闭
        /// </summary>
        public int discountOpen { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品条码
        /// </summary>
        public string barCode { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 图标地址
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int salesNum { get; set; }
        /// <summary>
        /// 分类Pid
        /// </summary>
        public string typePid { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int stock { get; set; }
        /// <summary>
        /// 推荐 1是,2否
        /// </summary>
        public int isRecommend { get; set; }
        /// <summary>
        /// 1 显示，2隐藏 3待上架
        /// </summary>
        public int display { get; set; }
        /// <summary>
        /// 最大价格
        /// </summary>
        public string maxPrice { get; set; }
        /// <summary>
        /// 1多规格  2为单规格
        /// </summary>
        public string isSpecs { get; set; }
        /// <summary>
        /// 门店Id
        /// </summary>
        public string storeId { get; set; }
        /// <summary>
        /// 套餐商品数组id
        /// </summary>
        public string comboGoodsArr { get; set; }
        /// <summary>
        /// isMain
        /// </summary>
        public string isMain { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string category_name { get; set; }
        /// <summary>
        /// media
        /// </summary>
        public string media { get; set; }
    }
}
