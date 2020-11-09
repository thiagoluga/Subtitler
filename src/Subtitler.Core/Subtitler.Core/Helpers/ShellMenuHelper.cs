using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace Subtitler.Core.Helpers
{
    public static class ShellMenuHelper
    {
        public static void Register(string exe, string cd)
        {
            string correctExe = GetExecutable(exe);
            string correctExeWithCdParameter = $"{correctExe} --cd {cd}";
            CreateKey("Directory\\Background", "Subtitler", "Subtitler", correctExeWithCdParameter);
        }

        public static void UnRegister()
        {
            TryDeleteOldKey("Directory", "Subtitler");
            DeleteKey("Directory\\Background", "Subtitler");
        }

        public static void CreateKey(string fileType, string shellKeyName, string menuText, string menuCommand)
        {
            // create path to registry location
            string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);

            // add context menu to the registry
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
            {
                key.SetValue(null, menuText);
            }

            // add command that is invoked to the registry
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(string.Format(@"{0}\command", regPath)))
            {
                key.SetValue(null, menuCommand);
            }
        }

        public static void DeleteKey(string fileType, string shellKeyName)
        {
            //Debug.Assert(!string.IsNullOrEmpty(fileType) && !string.IsNullOrEmpty(shellKeyName));

            // path to the registry location
            string regPath = string.Format(@"{0}\shell\{1}", fileType, shellKeyName);

            // remove context menu from the registry
            Registry.ClassesRoot.DeleteSubKeyTree(regPath);
        }

        public static string GetExecutable(string exe)
        {
            if (File.Exists(exe))
            {
                return exe;
            }

            string codeBase = Assembly.GetEntryAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string pathDirectoryName = Path.GetDirectoryName(path);
            string fileNameExe = "Subtitler.exe";
            string fullPath = Path.Combine(pathDirectoryName, fileNameExe);
            return fullPath;
        }

        private static void TryDeleteOldKey(string fileType, string shellKeyName)
        {
            try
            {
                DeleteKey(fileType, shellKeyName);
            }
            catch {}
        }

        //RegistryKey _key = Registry.ClassesRoot.OpenSubKey("Directory\\Shell", true);
        //RegistryKey newkey = _key.CreateSubKey("Subtitler");
        //newkey.SetValue("AppliesTo", "under:C:");

        //RegistryKey subNewkey = newkey.CreateSubKey("Command");
        //subNewkey.SetValue(null, assemblyExecutable);
        //subNewkey.Close();
    }
}
