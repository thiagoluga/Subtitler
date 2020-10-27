using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
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

            SetWithHeigth();
            FillInitialData();
        }

        #region TextBox TextChanged
        private void textBoxFolder_TextChanged(object sender, EventArgs e)
        {
            var textFolder = (sender as TextBox).Text;
            if (!string.IsNullOrWhiteSpace(textFolder))
            {
                FillComboBoxData();
            }
        }
        #endregion

        #region Button Click
        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            string folder = Utils.BrowseFolder();
            if (!string.IsNullOrWhiteSpace(folder))
            {
                textBoxFolder.Text = folder;
            }
        }

        private void buttonSubtitler_Click(object sender, EventArgs e)
        {
            Subtitler();
        }

        private void buttonCleanEpisodes_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxEpisodesFileExtension);
            Utils.Clean(listBoxEpisodes, labelTotalEpisodes);
        }

        private void buttonCleanSubtitiles_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxSubtitlesFileExtension);
            Utils.Clean(listBoxSubtitles, labelTotalSubtitles);
        }

        private void buttonCleanResults_Click(object sender, EventArgs e)
        {
            Utils.Clean(comboBoxMethod);
            Utils.Clean(listViewResult, labelTotalResults);
        }

        private void checkBoxPlaylist_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxPlaylistChecked = (sender as CheckBox).Checked;
            comboBoxPlaylist.Enabled = checkBoxPlaylistChecked;
        }
        #endregion

        #region ComboBox SelectedIndexChanged
        private void comboBoxEpisodesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxEpisodes, textBoxFolder.Text, labelTotalEpisodes);
            PreviewSubtitiles();
        }

        private void comboBoxSubtitlesFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ComboBoxSelectedIndexChanged(sender, listBoxSubtitles, textBoxFolder.Text, labelTotalSubtitles);
            PreviewSubtitiles();
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.Clean(listViewResult, labelTotalResults);
            PreviewSubtitiles();
        }
        #endregion

        private void SetWithHeigth()
        {
            var widthlistViewResult = listViewResult.Width;
            columnHeaderSubtitleBefore.Width = widthlistViewResult / 2;
            columnHeaderSubtitleAfter.Width = widthlistViewResult / 2;
        }

        private void FillInitialData()
        {
            Utils.BrowseFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            comboBoxEpisodesFileExtension.Items.AddRange(this.settings.EpisodeConfiguration.FileExtensions);
            comboBoxSubtitlesFileExtension.Items.AddRange(this.settings.SubtitleConfiguration.FileExtensions);

            comboBoxMethod.Items.Add(Constants.MethodOrderedList);

            comboBoxPlaylist.Items.Add(Constants.WinMediaPlayerPLS);
            comboBoxPlaylist.Items.Add(Constants.WinampM3U);
            Utils.SelectFirstItem(comboBoxPlaylist);
        }

        private void FillComboBoxData()
        {
            comboBoxEpisodesFileExtension.Items.Clear();
            comboBoxSubtitlesFileExtension.Items.Clear();

            Utils.FillComboBoxWithExtensionsInFolder(comboBoxEpisodesFileExtension, this.settings.EpisodeConfiguration.FileExtensions, textBoxFolder.Text);
            Utils.FillComboBoxWithExtensionsInFolder(comboBoxSubtitlesFileExtension, this.settings.SubtitleConfiguration.FileExtensions, textBoxFolder.Text);

            Utils.SelectFirstItem(comboBoxEpisodesFileExtension, true);
            Utils.SelectFirstItem(comboBoxSubtitlesFileExtension, true);

            if (listBoxEpisodes.Items.Count > 0 && listBoxSubtitles.Items.Count > 0)
            {
                Utils.SelectFirstItem(comboBoxMethod);
            }
        }

        private void PreviewSubtitiles()
        {
            //if (comboBoxSubtitlesFileExtension.SelectedIndex < 0 || comboBoxSubtitlesFileExtension.SelectedIndex < 0 || comboBoxMethod.SelectedIndex < 0)
            if (string.IsNullOrWhiteSpace(comboBoxEpisodesFileExtension.Text) || string.IsNullOrWhiteSpace(comboBoxSubtitlesFileExtension.Text) || comboBoxMethod.SelectedIndex < 0)
            {
                return;
            }

            Utils.Clean(listViewResult, labelTotalResults);

            if (comboBoxMethod.SelectedItem.ToString() == Constants.MethodOrderedList)
            {
                var subtitleFileExtension = comboBoxSubtitlesFileExtension.Text;

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

            labelTotalResults.Text = listViewResult.Items.Count.ToString();
        }

        private void Subtitler()
        {
            var folder = textBoxFolder.Text;

            foreach (ListViewItem result in listViewResult.Items)
            {
                var before = result.Text;
                var fullFileBefore = Path.Combine(folder, before);

                var after = result.SubItems[1].Text;
                var fullFileafter = Path.Combine(folder, after);

                File.Move(fullFileBefore, fullFileafter);
            }

            if (checkBoxPlaylist.Checked)
            {
                CreatePlaylist();
            }

            MessageBox.Show("Successfully renamed subtitiles!");
        }

        private void CreatePlaylist()
        {
            var folder = textBoxFolder.Text;
            string textPlaylist = string.Empty;

            switch (comboBoxPlaylist.SelectedItem)
            {
                case Constants.WinMediaPlayerPLS:

                    PlsPlaylist plsPlaylist = new PlsPlaylist();

                    foreach (var episode in listBoxEpisodes.Items)
                    {
                        plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry()
                        {
                            Path = Path.Combine(folder, episode.ToString()),
                            Title = Path.GetFileNameWithoutExtension(episode.ToString())
                        });
                    }

                    PlsContent plsContent = new PlsContent();
                    textPlaylist = plsContent.ToText(plsPlaylist);

                    break;

                case Constants.WinampM3U:

                    M3uPlaylist m3uPlaylist = new M3uPlaylist();

                    foreach (var episode in listBoxEpisodes.Items)
                    {
                        m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                        {
                            Path = Path.Combine(folder, episode.ToString()),
                            Title = Path.GetFileNameWithoutExtension(episode.ToString())
                        });
                    }

                    M3uContent m3uContent = new M3uContent();
                    textPlaylist = m3uContent.ToText(m3uPlaylist);

                    break;

                default:
                    break;
            }

            string playlistName = $"Playlist - {Utils.GetTimestamp(DateTime.Now)}";
            string playlistFullName = Path.Combine(folder, playlistName);

            using (FileStream fs = File.Create(playlistFullName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(textPlaylist);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
