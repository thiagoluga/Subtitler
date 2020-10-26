using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        public static void PopulateComboBox(ComboBox comboBox, string Folder, string[] fileExtensions)
        {
            if (!string.IsNullOrWhiteSpace(Folder))
            {
                string[] allFilesInFolder = Directory.GetFiles(Folder);
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

        public static void SelectFirstItem(ComboBox comboBox, bool selectWhenHasOneItem = false)
        {
            if (selectWhenHasOneItem && comboBox.Items.Count != 1)
            {
                return;
            }

            comboBox.SelectedIndex = 0;
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

                PopulateListBox(listBox, folder, $"*.{ext}");
            }
        }

        public static void Clean(ComboBox comboBox)
        {
            comboBox.SelectedIndex = -1;
        }

        public static void Clean(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        public static void Clean(ListView listView)
        {
            listView.Items.Clear();
        }
    }
}
