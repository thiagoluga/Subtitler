using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using Subtitler.Core.Config;

namespace Subtitler
{
    public partial class SubtitlerForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly AppSettings settings;

        public SubtitlerForm(IServiceProvider serviceProvider, IOptions<AppSettings> settings)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            this.settings = settings.Value;

            var widthlistViewResult = listViewResult.Width;
            columnHeaderSubtitleBefore.Width = widthlistViewResult / 2;
            columnHeaderSubtitleAfter.Width = widthlistViewResult / 2;

            Utils.ChooseFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            comboBoxMethod.Items.Add(Constants.MethodOrderedList);
            comboBoxEpisodesFileExtension.Items.AddRange(this.settings.EpisodeConfiguration.FileExtensions);
            comboBoxSubtitlesFileExtension.Items.AddRange(this.settings.SubtitleConfiguration.FileExtensions);
        }

        #region Button Click
        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            string folder = Utils.ChooseFolder();
            if (!string.IsNullOrWhiteSpace(folder))
            {
                textBoxFolder.Text = folder;
                PopulateData();
            }
        }

        private void buttonSubtitler_Click(object sender, EventArgs e)
        {
            var selectedMethodSubtitler = comboBoxMethod.SelectedItem.ToString();
            var folder = textBoxFolder.Text;

            if (selectedMethodSubtitler == Constants.MethodOrderedList)
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

        private void buttonCleanEpisodes_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxEpisodesFileExtension);
            Utils.Clean(listBoxEpisodes);
        }

        private void buttonCleanSubtitiles_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxSubtitlesFileExtension);
            Utils.Clean(listBoxSubtitles);
        }

        private void buttonCleanResults_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxMethod);
            Utils.Clean(listViewResult);
        }
        #endregion

        #region ComboBox SelectedIndexChanged
        private void comboBoxEpisodesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxEpisodes, textBoxFolder.Text);
        }

        private void comboBoxSubtitlesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxSubtitles, textBoxFolder.Text);
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewResult.Items.Clear();
            PreviewSubtitiles();
        }
        #endregion

        private void PopulateData()
        {
            comboBoxEpisodesFileExtension.Items.Clear();
            comboBoxSubtitlesFileExtension.Items.Clear();

            Utils.PopulateComboBox(comboBoxEpisodesFileExtension, textBoxFolder.Text, this.settings.EpisodeConfiguration.FileExtensions);
            Utils.PopulateComboBox(comboBoxSubtitlesFileExtension, textBoxFolder.Text, this.settings.SubtitleConfiguration.FileExtensions);

            Utils.SelectFirstItem(comboBoxEpisodesFileExtension, true);
            Utils.SelectFirstItem(comboBoxSubtitlesFileExtension, true);

            if (listBoxEpisodes.Items.Count > 0 && listBoxSubtitles.Items.Count > 0)
            {
                Utils.SelectFirstItem(comboBoxMethod);
            }
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
    }
}
