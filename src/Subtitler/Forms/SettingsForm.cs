using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using Subtitler.Core.Config;
using Subtitler.Core.Helpers;

namespace Subtitler.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly AppSettings settings;

        public SettingsForm(IOptions<AppSettings> settings)
        {
            InitializeComponent();
            this.settings = settings.Value;
            FillInitialData();
        }

        #region Form Events
        private void checkBoxPlaylist_CheckedChanged(object sender, System.EventArgs e)
        {
            var checkBoxPlaylistChecked = (sender as CheckBox).Checked;
            comboBoxPlaylist.Enabled = checkBoxPlaylistChecked;
            SettingsHelpers.AddOrUpdateAppSetting("SettingsConfiguration:PlaylistChecked", checkBoxPlaylistChecked);
        }

        private void comboBoxPlaylist_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var comboBoxPlaylistText = (sender as ComboBox).Text;
            SettingsHelpers.AddOrUpdateAppSetting("SettingsConfiguration:PlaylistDefault", comboBoxPlaylistText);
        }

        private void buttonBrowseFolder_Click(object sender, System.EventArgs e)
        {
            string folder = Utils.BrowseFolder();
            SetTextBoxBrowseFolderText(folder);
        }

        private void textBoxBrowseFolder_TextChanged(object sender, System.EventArgs e)
        {
            var textBoxBrowseFolderText = (sender as TextBox).Text;
            SetTextBoxBrowseFolderText(textBoxBrowseFolderText);
        }
        #endregion

        private void FillInitialData()
        {
            Utils.LoadComboBoxPlaylist(comboBoxPlaylist, checkBoxPlaylist, this.settings.SettingsConfiguration);
            Utils.LoadTextBoxFolder(textBoxBrowseFolder, this.settings.SettingsConfiguration);


            //Utils.BrowseFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            //comboBoxEpisodesFileExtension.Items.AddRange(this.settings.EpisodeConfiguration.FileExtensions);
            //comboBoxSubtitlesFileExtension.Items.AddRange(this.settings.SubtitleConfiguration.FileExtensions);
        }

        private void SetTextBoxBrowseFolderText(string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                textBoxBrowseFolder.Text = folder;
                SettingsHelpers.AddOrUpdateAppSetting("SettingsConfiguration:FolderDefault", folder);
            }
        }
    }
}
