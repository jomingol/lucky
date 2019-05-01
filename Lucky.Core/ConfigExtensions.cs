using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Lucky.Core
{
    public class ConfigExtensions
    {
        public static IConfiguration Configuration { get; set; }
        static ConfigExtensions()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }

        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }

        /// <summary>
        /// 获得配置文件的对象值
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJson(string jsonPath, string key)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build(); //json文件地址
            string s = config.GetSection(key).Value; //json某个对象
            return s;
        }

        /// <summary>
        /// 根据配置文件和Key获得对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">文件名称</param>
        /// <param name="key">节点Key</param>
        /// <returns></returns>
        public static T GetAppSettings<T>(string fileName, string key) where T : class, new()
        {
            var baseDir = AppContext.BaseDirectory + "json/";
            var currentClassDir = baseDir;

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                .Add(new JsonConfigurationSource { Path = fileName, Optional = false, ReloadOnChange = true })
                .Build();
            var appconfig = new ServiceCollection().AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }
    }
}
