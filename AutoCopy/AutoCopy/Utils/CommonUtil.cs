using AutoCopy.Properties;
using System.IO;
using System.Windows.Forms;

namespace AutoCopy.Utils
{
    public class CommonUtil
    {
        /// <summary>
        /// INI配置文件路径
        /// </summary>
        public readonly static string IniFilePath = Path.Combine(Application.StartupPath, Resources.ini_file_name);

        /// <summary>
        /// 操作锁定文件路径
        /// </summary>
        public readonly static string LockFilePath = Path.Combine(Application.StartupPath, Resources.lock_file_name);

        /// <summary>
        /// 数据库连接串
        /// </summary>
        public readonly static string DbConnectionString = IniUtil.ReadIni(Resources.ini_connections, Resources.ini_connections_mysql, IniFilePath);
    }
}
