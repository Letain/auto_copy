using AutoCopy.Models;
using AutoCopy.Properties;
using AutoCopy.Repositories;
using AutoCopy.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AutoCopy.Logics
{
    public class ListenOnNewFileLogic : IListenOnNewFileLogic
    {
        /// <summary>
        /// 本地被监视的路径
        /// </summary>
        private readonly string LocalPath = IniUtil.ReadIni(Resources.ini_paths, Resources.ini_paths_local, CommonUtil.IniFilePath);
        /// <summary>
        /// FTP服务器目录
        /// </summary>
        private readonly string FtpPath = IniUtil.ReadIni(Resources.ini_paths, Resources.ini_paths_ftp, CommonUtil.IniFilePath);

        public IDataRepository _dataRepository;

        public ListenOnNewFileLogic(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void DetectiveNewFile()
        {
            // 前一次同期时间
            //var lastWriteTime = Directory.GetLastWriteTimeUtc(srcPath);
            var lastInfoPath = Path.Combine(Application.StartupPath, Resources.last_sync_record_file_name);
            var lastWriteTimeStr = TextFileUtil.GetText(lastInfoPath);
            DateTime lastWriteTime = DateTime.Now;
            if (DateTime.TryParse(lastWriteTimeStr, out lastWriteTime))
            {
                Debug.WriteLine($"前回同步时间：{lastWriteTime}");
            }
            else
            {
                // 如果没有，取半个小时内的
                lastWriteTime = DateTime.Now.AddMinutes(-30);
            }

            // 文件夹一览
            DealWithFolder(LocalPath, FtpPath, lastWriteTime);

            // 更新处理时间
            TextFileUtil.WriteToTextFile(lastInfoPath, DateTime.Now.ToString());
        }

        /// <summary>
        /// 文件夹结构拷贝
        /// </summary>
        /// <param name="path">本地路径</param>
        /// <param name="ftpPath">本地路径对应的FTP路径</param>
        /// <param name="last">前回同步时间</param>
        private void DealWithFolder(string path, string ftpPath, DateTime last)
        {
            var directories = Directory.GetDirectories(path).ToList();
            directories.ForEach(d =>
            {
                var subD = new DirectoryInfo(d);
                if (subD.LastWriteTime > last)
                {
                    var ftpSubD = ftpPath + "/" + subD.Name;
                    // 检查是否有FTP子目录，没有就创建
                    FtpUtil.CreateFolder(ftpSubD);

                    // 继续处理下一层目录结构
                    DealWithFolder(d, ftpSubD, last);
                }
            });

            // 处理当前目录下的文件
            var dir = new DirectoryInfo(path);
            dir.GetFiles().ToList().ForEach(f =>
            {
                var ftpFilePath = ftpPath + "/" + f.Name;
                DealWithFile(f.FullName, ftpFilePath, last);
            });

        }

        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="filePath">文件</param>
        /// <param name="ftpFilePath">FTP文件</param>
        /// <param name="last">前回同步时间</param>
        private async void DealWithFile(string filePath, string ftpFilePath, DateTime last)
        {
            if(new FileInfo(filePath).LastWriteTime > last)
            {
                await FtpUtil.UploadFileToFTPServer(filePath, ftpFilePath);
                await _dataRepository.InsertCopyHistory(new CopyHistory
                {
                    FileAddress = filePath,
                    RecordDateTime = DateTime.UtcNow
                });

                // todo record log
            }
        }
    }
}
