using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Lucky.Domain
{
    [SugarTable("lucky_action")]
    public class LuckyAction
    {

        /// <summary>
        /// 抽奖Id
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// 账户Id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 抽奖账号
        /// </summary>
        public string LuckyAccount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

    }

}
