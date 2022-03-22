using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AutoCopy.Utils
{
    public class FtpUtil
    {
        // 最大重试次数
        const int MaxReconnectCount = 3;

        public static NetworkCredential Credential = null;

        /// <summary>
        /// 上传文件到 ftp 服务器
        /// </summary>
        /// <param name="srcFilePath">源文件路径</param>
        /// <param name="targetUrl">目标 url</param>
        /// <param name="credential">凭证</param>
        public static async Task UploadFileToFTPServer(string srcFilePath, string targetUrl, int retryCount = 0)
        {
            if (string.IsNullOrEmpty(srcFilePath))
            {
                throw new ArgumentException("srcFilePath");
            }
            if (string.IsNullOrEmpty(targetUrl))
            {
                throw new ArgumentException("targetUrl");
            }
            if (Credential == null)
            {
                throw new ArgumentException("Credential");
            }

            targetUrl = FixUrl(targetUrl, false);

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetUrl);
                byte[] srcFileBuffer = File.ReadAllBytes(srcFilePath);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = Credential;
                request.ContentLength = srcFileBuffer.Length;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    await requestStream.WriteAsync(srcFileBuffer, 0, srcFileBuffer.Length);
                }

                Debug.WriteLine($"Upload file succeed, source file path: {srcFilePath}, target url: {targetUrl}");
            }
            catch (Exception ex)
            {
                retryCount++;
                string l = $"Upload file failed, upload it again. source file path: {srcFilePath}, target url: {targetUrl}, error message: {ex.Message}";
                Debug.WriteLine(l);
                if (retryCount > MaxReconnectCount)
                {
                    throw new WebException(l);
                }
                else
                {
                    await UploadFileToFTPServer(srcFilePath, targetUrl, retryCount);
                }
            }
        }

        /// <summary>
        /// 删除 ftp 服务器上的所有文件
        /// </summary>
        /// <param name="dirUrl">文件夹 url</param>
        public static void DeleteAllFilesOnFtp(string dirUrl)
        {
            if (string.IsNullOrEmpty(dirUrl))
            {
                throw new ArgumentException("dirUrl");
            }
            if (Credential == null)
            {
                throw new ArgumentException("Credential");
            }

            dirUrl = FixUrl(dirUrl, true);

            List<string> dirNames, fileNames;
            GetDirectoryList(dirUrl, out dirNames, out fileNames);

            foreach (var dirName in dirNames)
            {
                string url = $"{dirUrl}{dirName}/";
                DeleteAllFilesOnFtp(url);
            }

            foreach (var fileName in fileNames)
            {
                string url = dirUrl + fileName;
                DeleteFile(url);
            }
        }

        /// <summary>
        /// 获取 ftp 文件夹的列表
        /// </summary>
        public static void GetDirectoryList(string dirUrl, out List<string> dirNames, out List<string> fileNames)
        {
            if (string.IsNullOrEmpty(dirUrl))
            {
                throw new ArgumentException("dirUrl");
            }
            if (Credential == null)
            {
                throw new ArgumentException("Credential");
            }

            dirUrl = FixUrl(dirUrl, true);

            dirNames = new List<string>();
            fileNames = new List<string>();

            FtpWebResponse response = null;
            Stream responseStream = null;
            StreamReader responseReader = null;

            try
            {
                var request = (FtpWebRequest)WebRequest.Create(dirUrl);

                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = Credential;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                response = (FtpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                responseReader = new StreamReader(responseStream);

                while (!responseReader.EndOfStream)
                {
                    string line = responseReader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = words.Last();

                    #region
                    // unix/linux d|-
                    // windows <DIR>|
                    if (line[0] == 'd' || line.Contains("<DIR>")) // 表示是文件夹
                    {
                        dirNames.Add(name);
                    }
                    else if (line[0] == '-' || !line.Contains("<DIR>")) // 表示是文件
                    {
                        fileNames.Add(name);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string l = $"Get directory list failed, directory url: {dirUrl}, error message: { ex.Message}";
                Debug.WriteLine(l);
                throw new WebException(l);
            }
            finally
            {
                if (responseReader != null)
                {
                    responseReader.Dispose();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Dispose();
                }
            }
        }

        /// <summary>
        /// 删除 ftp 服务器上的文件
        /// </summary>
        public static void DeleteFile(string fileUrl, int retryCount = 0)
        {
            if (string.IsNullOrEmpty(fileUrl))
            {
                throw new ArgumentException("fileUrl");
            }
            if (Credential == null)
            {
                throw new ArgumentException("Credential");
            }

            fileUrl = FixUrl(fileUrl, false);

            WebResponse response = null;
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(fileUrl);

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = Credential;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                response = request.GetResponse();

                Debug.WriteLine(string.Format("Delete file succeed, url: {0}", fileUrl));
            }
            catch (Exception ex)
            {
                retryCount++;
                string l = string.Format("Delete file failed, url: {0}, error message: {1}", fileUrl, ex.Message);
                Debug.WriteLine(l);
                if (retryCount > MaxReconnectCount)
                {
                    throw new WebException(l);
                }
                else
                {
                    DeleteFile(fileUrl, retryCount);
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        /// <summary>
        /// 在 ftp 服务器上创建文件夹
        /// </summary>
        /// <param name="dirUrl"></param>
        /// <param name="credential"></param>
        public static void CreateFolder(string dirUrl, int retryCount = 0)
        {
            if (string.IsNullOrEmpty(dirUrl))
            {
                throw new ArgumentException("dirUrl");
            }
            if (Credential == null)
            {
                throw new ArgumentException("Credential");
            }

            dirUrl = FixUrl(dirUrl, false);

            string folderName = Path.GetFileNameWithoutExtension(dirUrl);
            string parentFolderUrl = dirUrl.Replace(folderName, "");
            List<string> dirNames, fileNames;

            GetDirectoryList(parentFolderUrl, out dirNames, out fileNames);

            if (dirNames.Contains(folderName))
            {
                return;
            }

            try
            {
                var request = (FtpWebRequest)WebRequest.Create(dirUrl);

                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = Credential;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                var response = request.GetResponse();
                response.Close();

                Debug.WriteLine($"Create folder succeed, url: {dirUrl}");
            }
            catch (Exception ex)
            {
                retryCount++;
                string l = $"Create folder failed, create again, url: {dirUrl}, error message: {ex.Message}";
                Debug.WriteLine(l);
                if (retryCount > MaxReconnectCount)
                {
                    throw new WebException(l);
                }
                else
                {
                    CreateFolder(dirUrl, retryCount);
                }
            }
        }

        static string FixUrl(string url, bool endWithSprit)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            url = url.Replace("\\", "/").TrimEnd('/');
            return endWithSprit ? url + "/" : url;
        }

    }
}
