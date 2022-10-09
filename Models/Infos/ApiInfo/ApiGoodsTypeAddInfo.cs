using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infos.ApiInfo
{
    /// <summary>
    /// api商品插入模板
    /// </summary>
    public class ApiGoodsTypeAddInfo: ApiGoodsTypeInfo
    {
        /// <summary>
        /// 分类id
        /// </summary>
        new public List<int> typeId { get; set; }
        /// <summary>
        /// body
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// isBody
        /// </summary>
        public int? isBody { get; set; }
        /// <summary>
        /// isPrint
        /// </summary>
        public int? isPrint { get; set; }
        /// <summary>
        /// goodCode
        /// </summary>
        public string showLabel { get; set; }
        /// <summary>
        /// goodCode
        /// </summary>
        public List<string> platTypeId { get; set; }
        /// <summary>
        /// 商品多图片
        /// </summary>
        new public List<string> media { get; set; }
        /// <summary>
        /// 起始值
        /// </summary>
        public int? minNum { get; set; }
        /// <summary>
        /// 餐盒费
        /// </summary>
        public double? boxMoney { get; set; }
        /// <summary>
        /// 次日置满
        /// </summary>
        public int? fillType { get; set; }
        /// <summary>
        /// 划线价格
        /// </summary>
        public double? crossedPrice { get; set; }
        /// <summary>
        /// 成本价格
        /// </summary>
        public double? costPrice { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string goodCode { get; set; }
        /// <summary>
        /// 售卖时间类型1全时段售卖2自定义售卖时间
        /// </summary>
        public int? salesType { get; set; }
        /// <summary>
        /// 有效性
        /// </summary>
        public List<string> validity { get; set; }
        /// <summary>
        /// 星期一到星期日的集合
        /// </summary>
        public List<string> weekDay { get; set; }
        /// <summary>
        /// 设置星期后1全时段售卖2自定义时间售卖
        /// </summary>
        public int? weekSalesType { get; set; }
        /// <summary>
        /// 销售时间
        /// </summary>
        public List<string> salesTimeStr { get; set; }
        /// <summary>
        /// 是否参与热销排行
        /// </summary>
        public int? hotsaleType { get; set; }
        /// <summary>
        /// 单点时不配送
        /// </summary>
        public int? aloneType { get; set; }
        /// <summary>
        /// 1多规格  2为单规格
        /// </summary>
        public List<int> specs { get; set; }
        /// <summary>
        /// 材料
        /// </summary>
        public List<string> material { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public List<string> attribute { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string details { get; set; }
        /// <summary>
        /// 套餐商品数组id
        /// </summary>
        new public List<string> comboGoodsArr { get; set; }
        /// <summary>
        /// 1外卖2店内3内外
        /// </summary>
        public int? goodsType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? type { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        public int storeId { get; set; }
    }
}
