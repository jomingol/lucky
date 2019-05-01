using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lucky.Domain;

namespace Lucky.Service
{
    public class LuckyAccountService : BaseServer<LuckyAccount>
    {
        public async Task<bool> GetAllowLuckyByAccount(int accountId)
        {
            bool res = false;
            try
            {
                var allow = LuckyAccountDb.GetSingle(e => e.AccountId == accountId);
                if (allow != null && allow.AllowCount > 0)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {

            }
            return await Task.Run(() => res);
        }
    }
}
