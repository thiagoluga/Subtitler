using System.IO;
using System.Windows.Forms;

namespace Subtitler
{
    partial class SubtitlerForm
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
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.listBoxSubtitles = new System.Windows.Forms.ListBox();
            this.buttonSubtitler = new System.Windows.Forms.Button();
            this.comboBoxEpisodesFileExtension = new System.Windows.Forms.ComboBox();
            this.comboBoxSubtitlesFileExtension = new System.Windows.Forms.ComboBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.Label();
            this.groupBoxEpisodes = new System.Windows.Forms.GroupBox();
            this.buttonCleanEpisodes = new System.Windows.Forms.Button();
            this.labelEpisodesFileExtension = new System.Windows.Forms.Label();
            this.groupBoxSubtitiles = new System.Windows.Forms.GroupBox();
            this.buttonCleanSubtitiles = new System.Windows.Forms.Button();
            this.labelSubtitlesFileExtension = new System.Windows.Forms.Label();
            this.labelMethod = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeaderSubtitleBefore = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSubtitleAfter = new System.Windows.Forms.ColumnHeader();
            this.buttonCleanResults = new System.Windows.Forms.Button();
            this.groupBoxEpisodes.SuspendLayout();
            this.groupBoxSubtitiles.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.ItemHeight = 15;
            this.listBoxEpisodes.Location = new System.Drawing.Point(6, 55);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(496, 169);
            this.listBoxEpisodes.TabIndex = 0;
            // 
            // listBoxSubtitles
            // 
            this.listBoxSubtitles.FormattingEnabled = true;
            this.listBoxSubtitles.ItemHeight = 15;
            this.listBoxSubtitles.Location = new System.Drawing.Point(6, 55);
            this.listBoxSubtitles.Name = "listBoxSubtitles";
            this.listBoxSubtitles.Size = new System.Drawing.Size(496, 169);
            this.listBoxSubtitles.TabIndex = 1;
            // 
            // buttonSubtitler
            // 
            this.buttonSubtitler.Location = new System.Drawing.Point(904, 535);
            this.buttonSubtitler.Name = "buttonSubtitler";
            this.buttonSubtitler.Size = new System.Drawing.Size(131, 30);
            this.buttonSubtitler.TabIndex = 2;
            this.buttonSubtitler.Text = "Do Magic!";
            this.buttonSubtitler.UseVisualStyleBackColor = true;
            this.buttonSubtitler.Click += new System.EventHandler(this.buttonSubtitler_Click);
            // 
            // comboBoxEpisodesFileExtension
            // 
            this.comboBoxEpisodesFileExtension.FormattingEnabled = true;
            this.comboBoxEpisodesFileExtension.Location = new System.Drawing.Point(91, 23);
            this.comboBoxEpisodesFileExtension.Name = "comboBoxEpisodesFileExtension";
            this.comboBoxEpisodesFileExtension.Size = new System.Drawing.Size(158, 23);
            this.comboBoxEpisodesFileExtension.Sorted = true;
            this.comboBoxEpisodesFileExtension.TabIndex = 3;
            this.comboBoxEpisodesFileExtension.TextChanged += new System.EventHandler(this.comboBoxEpisodesFileExtension_SelectedIndexChanged);
            // 
            // comboBoxSubtitlesFileExtension
            // 
            this.comboBoxSubtitlesFileExtension.FormattingEnabled = true;
            this.comboBoxSubtitlesFileExtension.Location = new System.Drawing.Point(91, 23);
            this.comboBoxSubtitlesFileExtension.Name = "comboBoxSubtitlesFileExtension";
            this.comboBoxSubtitlesFileExtension.Size = new System.Drawing.Size(158, 23);
            this.comboBoxSubtitlesFileExtension.TabIndex = 3;
            this.comboBoxSubtitlesFileExtension.TextChanged += new System.EventHandler(this.comboBoxSubtitlesFileExtension_SelectedIndexChanged);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(12, 27);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(515, 23);
            this.textBoxFolder.TabIndex = 4;
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Location = new System.Drawing.Point(533, 26);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(158, 23);
            this.buttonChooseFolder.TabIndex = 5;
            this.buttonChooseFolder.Text = "Choose Folder";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(12, 9);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(40, 15);
            this.labelFolder.TabIndex = 6;
            this.labelFolder.Text = "Folder";
            // 
            // groupBoxEpisodes
            // 
            this.groupBoxEpisodes.Controls.Add(this.buttonCleanEpisodes);
            this.groupBoxEpisodes.Controls.Add(this.labelEpisodesFileExtension);
            this.groupBoxEpisodes.Controls.Add(this.listBoxEpisodes);
            this.groupBoxEpisodes.Controls.Add(this.comboBoxEpisodesFileExtension);
            this.groupBoxEpisodes.Location = new System.Drawing.Point(12, 67);
            this.groupBoxEpisodes.Name = "groupBoxEpisodes";
            this.groupBoxEpisodes.Size = new System.Drawing.Size(515, 232);
            this.groupBoxEpisodes.TabIndex = 8;
            this.groupBoxEpisodes.TabStop = false;
            this.groupBoxEpisodes.Text = "Episodes";
            // 
            // buttonCleanEpisodes
            // 
            this.buttonCleanEpisodes.Location = new System.Drawing.Point(427, 23);
            this.buttonCleanEpisodes.Name = "buttonCleanEpisodes";
            this.buttonCleanEpisodes.Size = new System.Drawing.Size(75, 23);
            this.buttonCleanEpisodes.TabIndex = 5;
            this.buttonCleanEpisodes.Text = "Clean";
            this.buttonCleanEpisodes.UseVisualStyleBackColor = true;
            this.buttonCleanEpisodes.Click += new System.EventHandler(this.buttonCleanEpisodes_Click);
            // 
            // labelEpisodesFileExtension
            // 
            this.labelEpisodesFileExtension.AutoSize = true;
            this.labelEpisodesFileExtension.Location = new System.Drawing.Point(6, 26);
            this.labelEpisodesFileExtension.Name = "labelEpisodesFileExtension";
            this.labelEpisodesFileExtension.Size = new System.Drawing.Size(79, 15);
            this.labelEpisodesFileExtension.TabIndex = 4;
            this.labelEpisodesFileExtension.Text = "File Extension";
            // 
            // groupBoxSubtitiles
            // 
            this.groupBoxSubtitiles.Controls.Add(this.buttonCleanSubtitiles);
            this.groupBoxSubtitiles.Controls.Add(this.labelSubtitlesFileExtension);
            this.groupBoxSubtitiles.Controls.Add(this.listBoxSubtitles);
            this.groupBoxSubtitiles.Controls.Add(this.comboBoxSubtitlesFileExtension);
            this.groupBoxSubtitiles.Location = new System.Drawing.Point(533, 67);
            this.groupBoxSubtitiles.Name = "groupBoxSubtitiles";
            this.groupBoxSubtitiles.Size = new System.Drawing.Size(513, 232);
            this.groupBoxSubtitiles.TabIndex = 9;
            this.groupBoxSubtitiles.TabStop = false;
            this.groupBoxSubtitiles.Text = "Subtitles";
            // 
            // buttonCleanSubtitiles
            // 
            this.buttonCleanSubtitiles.Location = new System.Drawing.Point(427, 26);
            this.buttonCleanSubtitiles.Name = "buttonCleanSubtitiles";
            this.buttonCleanSubtitiles.Size = new System.Drawing.Size(75, 23);
            this.buttonCleanSubtitiles.TabIndex = 5;
            this.buttonCleanSubtitiles.Text = "Clean";
            this.buttonCleanSubtitiles.UseVisualStyleBackColor = true;
            this.buttonCleanSubtitiles.Click += new System.EventHandler(this.buttonCleanSubtitiles_Click);
            // 
            // labelSubtitlesFileExtension
            // 
            this.labelSubtitlesFileExtension.AutoSize = true;
            this.labelSubtitlesFileExtension.Location = new System.Drawing.Point(6, 26);
            this.labelSubtitlesFileExtension.Name = "labelSubtitlesFileExtension";
            this.labelSubtitlesFileExtension.Size = new System.Drawing.Size(79, 15);
            this.labelSubtitlesFileExtension.TabIndex = 4;
            this.labelSubtitlesFileExtension.Text = "File Extension";
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(18, 313);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(49, 15);
            this.labelMethod.TabIndex = 10;
            this.labelMethod.Text = "Method";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Location = new System.Drawing.Point(103, 305);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(158, 23);
            this.comboBoxMethod.TabIndex = 11;
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethod_SelectedIndexChanged);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.listViewResult);
            this.groupBoxResult.Location = new System.Drawing.Point(18, 342);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(1034, 187);
            this.groupBoxResult.TabIndex = 12;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSubtitleBefore,
            this.columnHeaderSubtitleAfter});
            this.listViewResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(7, 22);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(1016, 155);
            this.listViewResult.TabIndex = 1;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSubtitleBefore
            // 
            this.columnHeaderSubtitleBefore.Text = "Before";
            // 
            // columnHeaderSubtitleAfter
            // 
            this.columnHeaderSubtitleAfter.Text = "After";
            // 
            // buttonCleanResults
            // 
            this.buttonCleanResults.Location = new System.Drawing.Point(960, 313);
            this.buttonCleanResults.Name = "buttonCleanResults";
            this.buttonCleanResults.Size = new System.Drawing.Size(75, 23);
            this.buttonCleanResults.TabIndex = 5;
            this.buttonCleanResults.Text = "Clean";
            this.buttonCleanResults.UseVisualStyleBackColor = true;
            this.buttonCleanResults.Click += new System.EventHandler(this.buttonCleanResults_Click);
            // 
            // SubtitlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 587);
            this.Controls.Add(this.buttonCleanResults);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.groupBoxSubtitiles);
            this.Controls.Add(this.groupBoxEpisodes);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.buttonSubtitler);
            this.Name = "SubtitlerForm";
            this.Text = "Subtitler";
            this.groupBoxEpisodes.ResumeLayout(false);
            this.groupBoxEpisodes.PerformLayout();
            this.groupBoxSubtitiles.ResumeLayout(false);
            this.groupBoxSubtitiles.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBoxEpisodes;
        private GroupBox groupBoxSubtitiles;
        private TextBox textBoxFolder;
        private ListBox listBoxEpisodes;
        private ListBox listBoxSubtitles;
        private Button buttonSubtitler;
        private Button buttonChooseFolder;
        private ComboBox comboBoxEpisodesFileExtension;
        private ComboBox comboBoxSubtitlesFileExtension;
        private Label labelFolder;
        private Label labelEpisodesFileExtension;
        private Label labelSubtitlesFileExtension;
        private Label labelMethod;
        private ComboBox comboBoxMethod;
        private GroupBox groupBoxResult;
        private ListView listViewResult;
        private ColumnHeader columnHeaderSubtitleBefore;
        private ColumnHeader columnHeaderSubtitleAfter;
        private Button buttonCleanEpisodes;
        private Button buttonCleanSubtitiles;
        private Button buttonCleanResults;
    }
}