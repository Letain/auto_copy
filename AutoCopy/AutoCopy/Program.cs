using AutoCopy.Logics;
using AutoCopy.Repositories;
using System;
using System.Windows.Forms;

namespace AutoCopy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // todo autofac
            var repository = new DataRepository();

            Application.Run(new Demo(new ListenOnNewFileLogic(repository)));



            // todo exception handdle
        }
    }
}
