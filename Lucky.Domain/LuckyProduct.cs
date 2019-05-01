using System;
using SqlSugar;

namespace Lucky.Domain
{
    [SugarTable("lucky_product")]
    public class LuckyProduct
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品库存
        /// </summary>
        public int ProductStore { get; set; }

        /// <summary>
        /// 中奖概率小
        /// </summary>
        public int ProductLuckyRateMin { get; set; }

        /// <summary>
        /// 中奖概率da
        /// </summary>
        public int ProductLuckyRateMax { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int ProductStatus { get; set; }

        /// <summary>
        /// 中奖停留位置
        /// </summary>
        public string LuckyIndex { get; set; }

        /// <summary>
        /// 是否中奖
        /// </summary>
        public int IsLucky { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }

    }

}
