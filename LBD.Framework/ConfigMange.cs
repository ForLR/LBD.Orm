using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LBD.Framework
{
    /// <summary>
    /// 获取链接字符串
    /// </summary>
    public static class ConfigMange
    {
        private static string _ConnStr = "";
        static ConfigMange()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            _ConnStr = configuration["ConnectionStr"];
        }

        public static string GetConnStr() => _ConnStr;
    }
}
