using Microsoft.Extensions.Configuration;
using System.IO;

namespace LBD.Framework
{
    /// <summary>
    /// 获取链接字符串
    /// </summary>
    public static class ConfigMange
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        private static string _connection = string.Empty;

        /// <summary>
        /// 连接字符串key
        /// </summary>
        private static string _connectionStrRoot = "LbdConnection";

        /// <summary>
        /// 默认文件 相对路径
        /// </summary>
        private static string _defaultRoot = "appsettings.json";

        /// <summary>
        /// 
        /// </summary>
        static ConfigMange()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(_defaultRoot)
           .Build();
            _connection = configuration[_connectionStrRoot];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConnStr() => _connection;
    }
}
