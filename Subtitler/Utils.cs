using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Subtitler.Model;

namespace Subtitler
{
    public static class Utils
    {
        private static FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public static void PopulateListBox(ListBox listBox, string Folder, string FileType)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
            FileInfo[] Files = directoryInfo.GetFiles(FileType);

            foreach (FileInfo file in Files)
            {
                listBox.Items.Add(file.Name);
            }
        }

        public static void PopulateListBoxWithExtensionsInFolder(ComboBox comboBox, string Folder, FileExtension[] fileExtensions)
        {
            if (!string.IsNullOrWhiteSpace(Folder))
            {
                string[] allFilesInFolder = Directory.GetFiles(Folder);
                var allExtensionsInFolder = allFilesInFolder.Select(x => Path.GetExtension(x)).Select(x => new FileExtension { Name = x.ToString() }).Distinct();

                foreach (var extension in allExtensionsInFolder)
                {
                    var resultExtension = fileExtensions.Where(x => x.Value.ToLower() == extension.Name.ToLower());

                    if (resultExtension.Count() > 0)
                    {
                        comboBox.Items.Add(resultExtension.First());
                    }
                }
            }
        }

        public static string ChooseFolder(string pathDefault = default)
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

        public static void ComboBoxSelectedIndexChanged(object sender, ListBox listBox, string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                var selectedFileExtension = (sender as ComboBox).SelectedItem as FileExtension;
                var ext = string.Empty;

                if (selectedFileExtension == null)
                {
                    var auxSender = (sender as ComboBox);
                    ext = $"*.{auxSender.Text}";
                }
                else
                {
                    ext = selectedFileExtension.ValueWithWildcard;
                }

                PopulateListBox(listBox, folder, ext);
            }
        }
    }
}
