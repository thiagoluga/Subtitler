namespace Subtitler.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxPlaylist = new System.Windows.Forms.CheckBox();
            this.groupBoxUserPreferences = new System.Windows.Forms.GroupBox();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.textBoxBrowseFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPlaylist = new System.Windows.Forms.ComboBox();
            this.groupBoxExtras = new System.Windows.Forms.GroupBox();
            this.buttonUnRegisterShellMenu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRegisterShellMenu = new System.Windows.Forms.Button();
            this.groupBoxUserPreferences.SuspendLayout();
            this.groupBoxExtras.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxPlaylist
            // 
            this.checkBoxPlaylist.AutoSize = true;
            this.checkBoxPlaylist.Location = new System.Drawing.Point(19, 40);
            this.checkBoxPlaylist.Name = "checkBoxPlaylist";
            this.checkBoxPlaylist.Size = new System.Drawing.Size(100, 19);
            this.checkBoxPlaylist.TabIndex = 0;
            this.checkBoxPlaylist.Text = "Create Playlist";
            this.checkBoxPlaylist.UseVisualStyleBackColor = true;
            this.checkBoxPlaylist.CheckedChanged += new System.EventHandler(this.checkBoxPlaylist_CheckedChanged);
            // 
            // groupBoxUserPreferences
            // 
            this.groupBoxUserPreferences.Controls.Add(this.buttonBrowseFolder);
            this.groupBoxUserPreferences.Controls.Add(this.textBoxBrowseFolder);
            this.groupBoxUserPreferences.Controls.Add(this.label1);
            this.groupBoxUserPreferences.Controls.Add(this.comboBoxPlaylist);
            this.groupBoxUserPreferences.Controls.Add(this.checkBoxPlaylist);
            this.groupBoxUserPreferences.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserPreferences.Name = "groupBoxUserPreferences";
            this.groupBoxUserPreferences.Size = new System.Drawing.Size(599, 157);
            this.groupBoxUserPreferences.TabIndex = 1;
            this.groupBoxUserPreferences.TabStop = false;
            this.groupBoxUserPreferences.Text = "User Preferences";
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Location = new System.Drawing.Point(453, 106);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(140, 24);
            this.buttonBrowseFolder.TabIndex = 4;
            this.buttonBrowseFolder.Text = "Browse Folder";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // textBoxBrowseFolder
            // 
            this.textBoxBrowseFolder.Location = new System.Drawing.Point(19, 107);
            this.textBoxBrowseFolder.Name = "textBoxBrowseFolder";
            this.textBoxBrowseFolder.Size = new System.Drawing.Size(428, 23);
            this.textBoxBrowseFolder.TabIndex = 3;
            this.textBoxBrowseFolder.TextChanged += new System.EventHandler(this.textBoxBrowseFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default Folder";
            // 
            // comboBoxPlaylist
            // 
            this.comboBoxPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaylist.FormattingEnabled = true;
            this.comboBoxPlaylist.Location = new System.Drawing.Point(151, 38);
            this.comboBoxPlaylist.Name = "comboBoxPlaylist";
            this.comboBoxPlaylist.Size = new System.Drawing.Size(186, 23);
            this.comboBoxPlaylist.TabIndex = 1;
            this.comboBoxPlaylist.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaylist_SelectedIndexChanged);
            // 
            // groupBoxExtras
            // 
            this.groupBoxExtras.Controls.Add(this.buttonUnRegisterShellMenu);
            this.groupBoxExtras.Controls.Add(this.label2);
            this.groupBoxExtras.Controls.Add(this.buttonRegisterShellMenu);
            this.groupBoxExtras.Location = new System.Drawing.Point(12, 187);
            this.groupBoxExtras.Name = "groupBoxExtras";
            this.groupBoxExtras.Size = new System.Drawing.Size(599, 81);
            this.groupBoxExtras.TabIndex = 2;
            this.groupBoxExtras.TabStop = false;
            this.groupBoxExtras.Text = "Extras";
            // 
            // buttonUnRegisterShellMenu
            // 
            this.buttonUnRegisterShellMenu.Location = new System.Drawing.Point(412, 30);
            this.buttonUnRegisterShellMenu.Name = "buttonUnRegisterShellMenu";
            this.buttonUnRegisterShellMenu.Size = new System.Drawing.Size(152, 23);
            this.buttonUnRegisterShellMenu.TabIndex = 0;
            this.buttonUnRegisterShellMenu.Text = "UnRegister Shell Menu";
            this.buttonUnRegisterShellMenu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Windows Explorer Integration";
            // 
            // buttonRegisterShellMenu
            // 
            this.buttonRegisterShellMenu.Location = new System.Drawing.Point(232, 30);
            this.buttonRegisterShellMenu.Name = "buttonRegisterShellMenu";
            this.buttonRegisterShellMenu.Size = new System.Drawing.Size(152, 23);
            this.buttonRegisterShellMenu.TabIndex = 0;
            this.buttonRegisterShellMenu.Text = "Register Shell Menu";
            this.buttonRegisterShellMenu.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 289);
            this.Controls.Add(this.groupBoxExtras);
            this.Controls.Add(this.groupBoxUserPreferences);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBoxUserPreferences.ResumeLayout(false);
            this.groupBoxUserPreferences.PerformLayout();
            this.groupBoxExtras.ResumeLayout(false);
            this.groupBoxExtras.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPlaylist;
        private System.Windows.Forms.GroupBox groupBoxUserPreferences;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.TextBox textBoxBrowseFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPlaylist;
        private System.Windows.Forms.GroupBox groupBoxExtras;
        private System.Windows.Forms.Button buttonUnRegisterShellMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRegisterShellMenu;
    }
}