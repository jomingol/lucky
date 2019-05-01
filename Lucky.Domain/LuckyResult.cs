using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Lucky.Domain
{
    [SugarTable("lucky_result")]
    public class LuckyResult
    {

        /// <summary>
        /// 中奖结果Id
        /// </summary>
        public int ResultId { get; set; }

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
        /// 账户Id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 中奖账号
        /// </summary>
        public string LuckyAccount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

    }
}
