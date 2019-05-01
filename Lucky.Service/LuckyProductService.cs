using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucky.Core;
using Lucky.Domain;

namespace Lucky.Service
{
    public class LuckyProductService : BaseServer<LuckyProduct>
    {
        public async Task<LuckyProduct> GetLuckyAction(int accountId)
        {
            var res = new LuckyProduct();
            try
            {
                var allow = Db.Queryable<LuckyAccount>().Where(e => e.AccountId == accountId).First();
                if (allow == null || allow.AllowCount <= 0)
                    return await Task.Run(() => res);
                bool isSaveAction = LuckyActionDb.Insert(new LuckyAction()
                {
                    AccountId = accountId,
                    LuckyAccount = "test",
                    CreatedAt = DateTime.Now
                });

                if (isSaveAction)
                {
                    allow.AllowCount = allow.AllowCount - 1;
                    bool isUpdateAllow =
                        LuckyAccountDb.Update(allow);
                    if (isUpdateAllow)
                    {
                        var list = LuckyProductDb.GetList(e => e.ProductStatus == 1 && e.ProductStore > 0);
                        if (list != null && list.Count > 0)
                        {
                            res = list.Find(e => e.IsLucky == 0);
                            Random r = new Random();
                            int index = r.Next(1, 100);
                            foreach (LuckyProduct t in list)
                            {
                                if (t.ProductLuckyRateMin <= index && t.ProductLuckyRateMax >= index)
                                {
                                    res = t;
                                }
                            }
                            if (res != null && res.IsLucky == 1)
                            {
                                LuckyResultDb.Insert(new LuckyResult()
                                {
                                    AccountId = accountId,
                                    CreatedAt = DateTime.Now,
                                    LuckyAccount = "test",
                                    ProductCode = res.ProductCode,
                                    ProductId = res.ProductId,
                                    ProductName = res.ProductName
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return await Task.Run(() => res);
        }
    }
}
