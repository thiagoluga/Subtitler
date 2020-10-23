using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Subtitler.Model;

namespace Subtitler
{
    public partial class SubtitlerForm : Form
    {
        public SubtitlerForm()
        {
            InitializeComponent();

            var widthlistViewResult = listViewResult.Width;
            columnHeaderSubtitleBefore.Width = widthlistViewResult / 2;
            columnHeaderSubtitleAfter.Width = widthlistViewResult / 2;

            Utils.ChooseFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            comboBoxMethod.Items.AddRange(Data.MethodsSubtitler);
            comboBoxEpisodesFileExtension.Items.AddRange(Data.EpisodesFileExtensions);
            comboBoxSubtitlesFileExtension.Items.AddRange(Data.SubtitilesFileExtensions);

        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            string folder = Utils.ChooseFolder();
            textBoxFolder.Text = folder;
            PopulateData();
        }

        private void PopulateData()
        {
            comboBoxEpisodesFileExtension.Items.Clear();
            comboBoxSubtitlesFileExtension.Items.Clear();

            Utils.PopulateListBoxWithExtensionsInFolder(comboBoxEpisodesFileExtension, textBoxFolder.Text, Data.EpisodesFileExtensions);
            Utils.PopulateListBoxWithExtensionsInFolder(comboBoxSubtitlesFileExtension, textBoxFolder.Text, Data.SubtitilesFileExtensions);
        }

        private void comboBoxEpisodesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxEpisodes, textBoxFolder.Text);
        }

        private void comboBoxSubtitlesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxSubtitles, textBoxFolder.Text);
        }

        private void buttonSubtitler_Click(object sender, EventArgs e)
        {
            var selectedMethodSubtitler = comboBoxMethod.SelectedItem.ToString();
            var folder = textBoxFolder.Text;

            if (selectedMethodSubtitler == "Orderned List")
            {
                foreach (ListViewItem result in listViewResult.Items)
                {
                    var before = result.Text;
                    var fullFileBefore = Path.Combine(folder, before);

                    var after = result.SubItems[1].Text;
                    var fullFileafter = Path.Combine(folder, after);

                    File.Move(fullFileBefore, fullFileafter);
                }

                MessageBox.Show("Successfully renamed subtitiles!");
            }
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewResult.Items.Clear();
            PreviewSubtitiles();
        }

        private void PreviewSubtitiles()
        {
            if (comboBoxSubtitlesFileExtension.SelectedIndex < 0 && comboBoxSubtitlesFileExtension.SelectedIndex < 0)
            {
                return;
            }

            var subtitleFileExtension = comboBoxSubtitlesFileExtension.SelectedItem.ToString();

            foreach (var subtitile in listBoxSubtitles.Items)
            {
                var fullEpisodeName = listBoxEpisodes.Items[listBoxSubtitles.Items.IndexOf(subtitile)].ToString();
                var episodeName = Path.GetFileNameWithoutExtension(fullEpisodeName);
                var newSubtitleName = $"{episodeName}.{subtitleFileExtension}";

                //string[] row = { subtitile.ToString(), newSubtitleName };
                var listViewItem = new ListViewItem();
                listViewItem.Text = subtitile.ToString();
                listViewItem.SubItems.Add(newSubtitleName);
                listViewResult.Items.Add(listViewItem);
            }
        }

        private void buttonCleanEpisodes_Click(object sender, EventArgs e)
        {
            comboBoxEpisodesFileExtension.SelectedIndex = -1;
            listBoxEpisodes.Items.Clear();
        }

        private void buttonCleanSubtitiles_Click(object sender, EventArgs e)
        {
            comboBoxSubtitlesFileExtension.SelectedIndex = -1;
            listBoxSubtitles.Items.Clear();
        }

        private void buttonCleanResults_Click(object sender, EventArgs e)
        {
            comboBoxMethod.SelectedIndex = -1;
            listViewResult.Items.Clear();
        }
    }
}
