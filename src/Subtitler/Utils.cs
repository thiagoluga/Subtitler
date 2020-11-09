using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Subtitler.Core.Config;
using Subtitler.Core.Helpers;

namespace Subtitler
{
    public static class Utils
    {
        private static FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public static string BrowseFolder(string pathDefault = default)
        {
            if (pathDefault != default)
            {
                folderBrowserDialog.SelectedPath = pathDefault;
                return folderBrowserDialog.SelectedPath;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }

            return string.Empty;
        }

        public static void FillListBoxWithFilesInFolder(ListBox listBox, string folder, string fileType, Label labelTotal)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            if (directoryInfo.Exists)
            {
                FileInfo[] Files = directoryInfo.GetFiles(fileType);

                foreach (FileInfo file in Files)
                {
                    listBox.Items.Add(file.Name);
                }

                labelTotal.Text = listBox.Items.Count.ToString();
            }
        }


        public static void FillComboBoxWithExtensionsInFolder(ComboBox comboBox, string[] fileExtensions, string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder) && Directory.Exists(folder))
            {
                string[] allFilesInFolder = Directory.GetFiles(folder);

                var allExtensionsInFolder = allFilesInFolder
                                                .Select(x => Path.GetExtension(x)
                                                .Replace(".", string.Empty))
                                                .Distinct();

                foreach (var extension in allExtensionsInFolder)
                {
                    var resultExtension = fileExtensions.Where(x => x.ToLower() == extension.ToLower());

                    if (resultExtension.Count() > 0)
                    {
                        comboBox.Items.Add(resultExtension.First());
                    }
                }
            }
        }

        public static void LoadComboBoxPlaylist(ComboBox comboBoxPlaylist, CheckBox checkBoxPlaylist, SettingsConfiguration settings)
        {
            comboBoxPlaylist.Items.Add(Constants.WinMediaPlayerPLS);
            comboBoxPlaylist.Items.Add(Constants.WinampM3U);

            bool playlistChecked = settings.PlaylistChecked;
            checkBoxPlaylist.Checked = playlistChecked;
            comboBoxPlaylist.Enabled = playlistChecked;

            try
            {
                string playlistDefault = settings.PlaylistDefault;
                SelectItem(comboBoxPlaylist, playlistDefault, true);
            }
            catch (Exception)
            {
                SelectFirstItem(comboBoxPlaylist);
            }
        }

        public static void LoadTextBoxFolder(TextBox textBoxFolder, SettingsConfiguration settings)
        {
            string[] args = Environment.GetCommandLineArgs();
            ArgumentsHelper cmdline = new ArgumentsHelper(args);
            string cd = cmdline["cd"];

            if(!string.IsNullOrWhiteSpace(cd))
            {
                textBoxFolder.Text = cd;
            }
            else
            {
                string folderDefault = settings.FolderDefault;

                if (!string.IsNullOrWhiteSpace(folderDefault))
                {
                    textBoxFolder.Text = folderDefault;
                }
            }
        }

        //private static void LoadSettingsConfiguration(SettingsConfiguration settings)
        //{
        //    Utils.LoadComboBoxPlaylist(comboBoxPlaylist, checkBoxPlaylist, settings.SettingsConfiguration);
        //    Utils.LoadTextBoxFolder(textBoxFolder, this.settings.SettingsConfiguration);
        //}

        public static void ComboBoxSelectedIndexChanged(object sender, ListBox listBox, string folder, Label labelTotal)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                Clean(listBox, labelTotal);

                var selectedFileExtension = (sender as ComboBox).SelectedItem;
                var ext = string.Empty;

                if (selectedFileExtension == null)
                {
                    var auxSender = (sender as ComboBox);
                    ext = auxSender.Text;
                }
                else
                {
                    ext = selectedFileExtension.ToString();
                }

                FillListBoxWithFilesInFolder(listBox, folder, $"*.{ext}", labelTotal);
            }
        }

        public static void SelectFirstItem(ComboBox comboBox, bool selectWhenHasOneItem = false)
        {
            if (selectWhenHasOneItem && comboBox.Items.Count != 1)
            {
                return;
            }

            comboBox.SelectedIndex = 0;
        }

        public static void SelectItem(ComboBox comboBox, string item, bool selectFirstIfCantFind)
        {
            var findIndex = comboBox.FindStringExact(item);
            if (findIndex == -1 && selectFirstIfCantFind)
            {
                SelectFirstItem(comboBox);
            }
            else
            {
                comboBox.SelectedIndex = findIndex;
            }
        }

        public static void Clean(ComboBox comboBox)
        {
            comboBox.Text = string.Empty;
            comboBox.SelectedIndex = -1;
        }

        public static void Clean(ListBox listBox, Label labelTotal)
        {
            listBox.Items.Clear();
            labelTotal.Text = "0";
        }

        public static void Clean(ListView listView, Label labelTotal)
        {
            listView.Items.Clear();
            labelTotal.Text = "0";
        }

        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static void StartShellMenu(string arguments)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Utils.GetShellMenuExecutable(),
                    Arguments = arguments,
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                process.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public static string GetSubtitlerExecutable()
        //{
        //string codeBase = Assembly.GetEntryAssembly().CodeBase;
        //UriBuilder uri = new UriBuilder(codeBase);
        //string path = Uri.UnescapeDataString(uri.Path);
        //string pathDirectoryName = Path.GetDirectoryName(path);
        //string fileName = Path.GetFileName(path);
        //string fileNameExe = Path.ChangeExtension(fileName, "exe");
        //string fullPath = Path.Combine(pathDirectoryName, fileNameExe);
        //return fullPath;
        //}

        public static string GetSubtitlerExecutable()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }

        public static string GetShellMenuExecutable()
        {
            string codeBase = Assembly.GetEntryAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string pathDirectoryName = Path.GetDirectoryName(path);
            string fileNameExe = "Subtitler.ShellMenu2.exe";
            string fullPath = Path.Combine(pathDirectoryName, fileNameExe);
            return fullPath;
        }
    }
}
