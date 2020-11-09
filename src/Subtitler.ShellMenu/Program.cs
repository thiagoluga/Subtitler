using System;
using System.Windows.Forms;
using Subtitler.Core.Helpers;

namespace Subtitler.ShellMenu
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string[] args = Environment.GetCommandLineArgs();
                ArgumentsHelper cmdline = new ArgumentsHelper(args);

                if (Convert.ToBoolean(cmdline["register"]))
                {
                    ShellMenuHelper.Register(cmdline["exe"], cmdline["cd"]);
                    MessageBox.Show("Register ShellMenu sucessfully");
                }
                if (Convert.ToBoolean(cmdline["unregister"]))
                {
                    ShellMenuHelper.UnRegister();
                    MessageBox.Show("UnRegister ShellMenu sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
