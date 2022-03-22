using AutoCopy.Controls;
using AutoCopy.Logics;
using AutoCopy.Properties;
using AutoCopy.Utils;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCopy
{
    public partial class Demo : Form
    {
        private static bool Locked = false;

        private IListenOnNewFileLogic _logic;

        public Demo(IListenOnNewFileLogic logic)
        {
            InitializeComponent();

            // todo auto output copy history

            _logic = logic;

            resource_input.Text = IniUtil.ReadIni(Resources.ini_paths, Resources.ini_paths_local, CommonUtil.IniFilePath);
            ftp_input.Text = IniUtil.ReadIni(Resources.ini_paths, Resources.ini_paths_ftp, CommonUtil.IniFilePath);
            user_txt.Text = IniUtil.ReadIni(Resources.ini_users, Resources.ini_users_ftp_user, CommonUtil.IniFilePath);
            pw_txt.Text = IniUtil.ReadIni(Resources.ini_users, Resources.ini_users_ftp_pw, CommonUtil.IniFilePath);

        }

        private void Demo_Activated(object sender, EventArgs e)
        {
            confirm_btn.Focus();
        }

        private void pw_txt_TextChanged(object sender, EventArgs e)
        {
            var pwTxt = (TextBoxEx)sender;
            if (pwTxt.Text.Length > 0)
            {
                pwTxt.PasswordChar = '*';
            }
            else
            {
                pwTxt.PasswordChar = default(char);
            }
        }

        private async void confirm_btn_Click(object sender, EventArgs e)
        {
            if (Locked)
            {
                return;
            }
            // reset
            TextFileUtil.WriteToTextFile(CommonUtil.LockFilePath, "0");

            Locked = true;
            stop_btn.Visible = true;
            stop_btn.Enabled = true;

            confirm_btn.Enabled = false;
            confirm_btn.Visible = false;

            // ftp认证情报
            FtpUtil.Credential = new NetworkCredential(user_txt.Text, pw_txt.Text);

            // 监视文件夹
            await Task.Factory.StartNew(() =>
            {
                while (Locked)
                {
                    var lockStr = TextFileUtil.GetText(CommonUtil.LockFilePath);
                    if (!string.IsNullOrEmpty(lockStr) && lockStr == "1")
                    {
                        Thread.Sleep(10000);
                        return;
                    }
                    else
                    {
                        // lock
                        TextFileUtil.WriteToTextFile(CommonUtil.LockFilePath, "1");
                        _logic.DetectiveNewFile();
                        // unlock
                        TextFileUtil.WriteToTextFile(CommonUtil.LockFilePath, "0");
                    }
                }
            });
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            Locked = false;
            stop_btn.Visible = false;
            stop_btn.Enabled = false;

            confirm_btn.Enabled = true;
            confirm_btn.Visible = true;
        }
    }
}
