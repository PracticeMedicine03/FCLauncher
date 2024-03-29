﻿namespace FCLauncher
{
    partial class MainForm
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
            this.pContainer = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBarStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.wikiWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuTabControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.btnReportIssueLauncher = new System.Windows.Forms.Button();
            this.btnReportIssueMod = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.wikiPage = new System.Windows.Forms.TabPage();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.lblDevTest = new System.Windows.Forms.Label();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.lblDevSettings = new System.Windows.Forms.Label();
            this.btnDevTools = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.launchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wikiWebView)).BeginInit();
            this.menuTabControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.wikiPage.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Controls.Add(this.menuTabControl);
            this.pContainer.Controls.Add(this.statusStrip1);
            this.pContainer.Location = new System.Drawing.Point(-1, -2);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(1093, 564);
            this.pContainer.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pBarStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.MinimumSize = new System.Drawing.Size(0, 26);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.Text = "HeroBrine";
            // 
            // pBarStatus
            // 
            this.pBarStatus.Name = "pBarStatus";
            this.pBarStatus.Size = new System.Drawing.Size(150, 24);
            this.pBarStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // wikiWebView
            // 
            this.wikiWebView.AllowExternalDrop = true;
            this.wikiWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wikiWebView.CreationProperties = null;
            this.wikiWebView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wikiWebView.Location = new System.Drawing.Point(0, 0);
            this.wikiWebView.Name = "wikiWebView";
            this.wikiWebView.Size = new System.Drawing.Size(1088, 478);
            this.wikiWebView.TabIndex = 2;
            this.wikiWebView.ZoomFactor = 1D;
            // 
            // menuTabControl
            // 
            this.menuTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuTabControl.Controls.Add(this.mainPage);
            this.menuTabControl.Controls.Add(this.wikiPage);
            this.menuTabControl.Controls.Add(this.settingsPage);
            this.menuTabControl.Location = new System.Drawing.Point(3, 3);
            this.menuTabControl.Name = "menuTabControl";
            this.menuTabControl.SelectedIndex = 0;
            this.menuTabControl.Size = new System.Drawing.Size(1092, 510);
            this.menuTabControl.TabIndex = 1;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.btnReportIssueLauncher);
            this.mainPage.Controls.Add(this.btnReportIssueMod);
            this.mainPage.Controls.Add(this.updateButton);
            this.mainPage.Controls.Add(this.launchButton);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(1084, 484);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Menu";
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // btnReportIssueLauncher
            // 
            this.btnReportIssueLauncher.Location = new System.Drawing.Point(54, 227);
            this.btnReportIssueLauncher.Name = "btnReportIssueLauncher";
            this.btnReportIssueLauncher.Size = new System.Drawing.Size(161, 23);
            this.btnReportIssueLauncher.TabIndex = 3;
            this.btnReportIssueLauncher.Text = "Report an issue (FCLauncher)\r\n";
            this.btnReportIssueLauncher.UseVisualStyleBackColor = true;
            this.btnReportIssueLauncher.Click += new System.EventHandler(this.btnReportIssueLauncher_Click);
            // 
            // btnReportIssueMod
            // 
            this.btnReportIssueMod.Location = new System.Drawing.Point(54, 158);
            this.btnReportIssueMod.Name = "btnReportIssueMod";
            this.btnReportIssueMod.Size = new System.Drawing.Size(95, 23);
            this.btnReportIssueMod.TabIndex = 2;
            this.btnReportIssueMod.Text = "Report an issue";
            this.btnReportIssueMod.UseVisualStyleBackColor = true;
            this.btnReportIssueMod.Click += new System.EventHandler(this.btnReportIssue_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(54, 80);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update FC";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(54, 49);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(75, 23);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch FC";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // wikiPage
            // 
            this.wikiPage.Controls.Add(this.wikiWebView);
            this.wikiPage.Location = new System.Drawing.Point(4, 22);
            this.wikiPage.Name = "wikiPage";
            this.wikiPage.Padding = new System.Windows.Forms.Padding(3);
            this.wikiPage.Size = new System.Drawing.Size(1084, 484);
            this.wikiPage.TabIndex = 1;
            this.wikiPage.Text = "Wiki";
            this.wikiPage.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.lblDevTest);
            this.settingsPage.Controls.Add(this.btnTest1);
            this.settingsPage.Controls.Add(this.lblDevSettings);
            this.settingsPage.Controls.Add(this.btnDevTools);
            this.settingsPage.Controls.Add(this.btnSaveConfig);
            this.settingsPage.Controls.Add(this.launchBox);
            this.settingsPage.Controls.Add(this.label1);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(1084, 484);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // lblDevTest
            // 
            this.lblDevTest.Location = new System.Drawing.Point(9, 67);
            this.lblDevTest.Name = "lblDevTest";
            this.lblDevTest.Size = new System.Drawing.Size(198, 14);
            this.lblDevTest.TabIndex = 8;
            this.lblDevTest.Text = "Developer Test";
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(9, 84);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(98, 23);
            this.btnTest1.TabIndex = 7;
            this.btnTest1.Text = "WebClient test";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // lblDevSettings
            // 
            this.lblDevSettings.Location = new System.Drawing.Point(9, 15);
            this.lblDevSettings.Name = "lblDevSettings";
            this.lblDevSettings.Size = new System.Drawing.Size(198, 14);
            this.lblDevSettings.TabIndex = 6;
            this.lblDevSettings.Text = "Developer Settings";
            // 
            // btnDevTools
            // 
            this.btnDevTools.Location = new System.Drawing.Point(7, 32);
            this.btnDevTools.Name = "btnDevTools";
            this.btnDevTools.Size = new System.Drawing.Size(152, 23);
            this.btnDevTools.TabIndex = 5;
            this.btnDevTools.Text = "Open WebView2 DevTools";
            this.btnDevTools.UseVisualStyleBackColor = true;
            this.btnDevTools.Click += new System.EventHandler(this.btnDevTools_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(442, 214);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(118, 23);
            this.btnSaveConfig.TabIndex = 4;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // launchBox
            // 
            this.launchBox.Location = new System.Drawing.Point(8, 188);
            this.launchBox.Name = "launchBox";
            this.launchBox.Size = new System.Drawing.Size(552, 20);
            this.launchBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Extra launch arguments";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 557);
            this.Controls.Add(this.pContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCLauncher";
            this.pContainer.ResumeLayout(false);
            this.pContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wikiWebView)).EndInit();
            this.menuTabControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.wikiPage.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.settingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Label lblDevTest;

        private System.Windows.Forms.Button btnReportIssueLauncher;

        private System.Windows.Forms.Button btnReportIssueMod;

        private System.Windows.Forms.Button btnDevTools;
        private System.Windows.Forms.Label lblDevSettings;

        private System.Windows.Forms.TabPage settingsPage;

        private System.Windows.Forms.Button btnSaveConfig;

        private Microsoft.Web.WebView2.WinForms.WebView2 wikiWebView;

        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox launchBox;

        private System.Windows.Forms.Button updateButton;

        private System.Windows.Forms.TabControl menuTabControl;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage wikiPage;
        private System.Windows.Forms.Button launchButton;

        #endregion

        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.ToolStripProgressBar pBarStatus;
    }
}

