using System.Runtime.InteropServices;
using System.Text;

namespace AutoCopy.Utils
{
    public class IniUtil
    {
        // 系统API声明
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="Section">主节点名称</param>
        /// <param name="Key">键名称</param>
        /// <param name="Value">键值</param>
        /// <param name="path">INI文件地址</param>
        public static void WriteIni(string Section, string Key, string Value, string path)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section">主节点名称</param>
        /// <param name="Key">键名称</param>
        /// <param name="path">INI文件地址</param>
        /// <returns>键值</returns>
        public static string ReadIni(string Section, string Key, string path)
        {
            StringBuilder value = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, string.Empty, value, 255, path);
            return value.ToString();
        }
    }
}
