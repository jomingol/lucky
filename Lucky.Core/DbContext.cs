using System;
using Lucky.Domain;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace Lucky.Core
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigExtensions.Configuration.GetConnectionString("MySqlConnection"),
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                //Console.WriteLine(sql + "\r\n" +
                //    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public DbSet<TDbModel> GetDb<TDbModel>() where TDbModel : class, new()
        {
            return new DbSet<TDbModel>(Db);
        }

        //Lucky设置
        public DbSet<LuckyProduct> LuckyProductDb => new DbSet<LuckyProduct>(Db);

        public DbSet<LuckyAccount> LuckyAccountDb => new DbSet<LuckyAccount>(Db);

        public DbSet<LuckyResult> LuckyResultDb => new DbSet<LuckyResult>(Db);

        public DbSet<LuckyAction> LuckyActionDb => new DbSet<LuckyAction>(Db);
    }
    /// <summary>
    /// 扩展ORM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {

        }

    }
}
