using System.IO;

namespace AutoCopy.Utils
{
    public class TextFileUtil
    {
        public static void WriteToTextFile(string path, string text)
        {
            var file = new FileInfo(path);
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            //if (!file.Exists)
            //{
            //    file.Create();
            //}

            File.WriteAllText(path, text);
        }

        public static string GetText(string path)
        {
            var file = new FileInfo(path);
            if (!file.Exists)
            {
                return string.Empty;
            }

            return File.ReadAllText(path);
        }
    }
}
