using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Subtitler.Core.Config;
using Subtitler.Core.Helpers;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Subtitler.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly AppSettings settings;

        public SettingsForm(IServiceProvider serviceProvider, IOptions<AppSettings> settings)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            this.settings = settings.Value;
            this.Closed += (s, args) => SettingsForm_FormClosed();

            FillInitialData();
        }

        #region Form Events
        private void checkBoxPlaylist_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxPlaylistChecked = (sender as CheckBox).Checked;
            comboBoxPlaylist.Enabled = checkBoxPlaylistChecked;
            SettingsHelper.AddOrUpdateAppSetting($"{nameof(SettingsConfiguration)}:{nameof(SettingsConfiguration.PlaylistChecked)}", checkBoxPlaylistChecked);
            this.settings.SettingsConfiguration.PlaylistChecked = checkBoxPlaylistChecked;
        }

        private void comboBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBoxPlaylistText = (sender as ComboBox).Text;
            SettingsHelper.AddOrUpdateAppSetting($"{nameof(SettingsConfiguration)}:{nameof(SettingsConfiguration.PlaylistDefault)}", comboBoxPlaylistText);
            this.settings.SettingsConfiguration.PlaylistDefault = comboBoxPlaylistText;
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            string folder = Utils.BrowseFolder();
            SetTextBoxBrowseFolderText(folder);
        }

        private void textBoxBrowseFolder_TextChanged(object sender, EventArgs e)
        {
            var textBoxBrowseFolderText = (sender as TextBox).Text;
            SetTextBoxBrowseFolderText(textBoxBrowseFolderText);
        }

        private void buttonRegisterShellMenu_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void buttonUnRegisterShellMenu_Click(object sender, EventArgs e)
        {
            UnRegister();
        }
        #endregion

        private void FillInitialData()
        {
            Utils.LoadComboBoxPlaylist(comboBoxPlaylist, checkBoxPlaylist, this.settings.SettingsConfiguration);
            Utils.LoadTextBoxFolder(textBoxBrowseFolder, this.settings.SettingsConfiguration);

            //Utils.BrowseFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        private void SetTextBoxBrowseFolderText(string folder)
        {
            if (!string.IsNullOrWhiteSpace(folder))
            {
                textBoxBrowseFolder.Text = folder;
                SettingsHelper.AddOrUpdateAppSetting($"{nameof(SettingsConfiguration)}:{nameof(SettingsConfiguration.FolderDefault)}", folder);
                this.settings.SettingsConfiguration.FolderDefault = folder;
            }
        }

        private void SettingsForm_FormClosed()
        {
            MainForm mainForm = (Application.OpenForms[nameof(MainForm)] as MainForm);
            mainForm.LoadSettingsConfiguration(this.settings);
            this.Close();
        }

        private void Register()
        {
            string subtitlerExecutable = Utils.GetSubtitlerExecutable();
            Utils.StartShellMenu($@"/register /exe {subtitlerExecutable} /cd ""%V""");
        }

        private void UnRegister()
        {
            Utils.StartShellMenu("/unregister");
        }
    }
}
