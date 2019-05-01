using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Lucky.Domain
{
    [SugarTable("lucky_account")]
    public class LuckyAccount
    {

        /// <summary>
        /// 账户Id
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 账户允许剩余抽奖次数
        /// </summary>
        public int AllowCount { get; set; }

    }

}
