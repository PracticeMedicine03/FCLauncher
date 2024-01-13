namespace FCLauncher
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
            this.modUpdateWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.updateButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.launchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.pContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modUpdateWebView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Controls.Add(this.modUpdateWebView);
            this.pContainer.Controls.Add(this.statusStrip1);
            this.pContainer.Location = new System.Drawing.Point(-1, -2);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(1093, 564);
            this.pContainer.TabIndex = 0;
            // 
            // modUpdateWebView
            // 
            this.modUpdateWebView.AllowExternalDrop = true;
            this.modUpdateWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.modUpdateWebView.CreationProperties = null;
            this.modUpdateWebView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.modUpdateWebView.Location = new System.Drawing.Point(615, 59);
            this.modUpdateWebView.Name = "modUpdateWebView";
            this.modUpdateWebView.Size = new System.Drawing.Size(458, 480);
            this.modUpdateWebView.TabIndex = 2;
            this.modUpdateWebView.ZoomFactor = 1D;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 17);
            this.lblStatus.Text = "HeroBrine";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.mainPage);
            this.tabControl1.Controls.Add(this.settingsPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 502);
            this.tabControl1.TabIndex = 1;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.updateButton);
            this.mainPage.Controls.Add(this.launchButton);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(604, 476);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Menu";
            this.mainPage.UseVisualStyleBackColor = true;
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
            this.launchButton.Location = new System.Drawing.Point(54, 51);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(75, 23);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch FC";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.btnSaveConfig);
            this.settingsPage.Controls.Add(this.launchBox);
            this.settingsPage.Controls.Add(this.label1);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(604, 476);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // launchBox
            // 
            this.launchBox.Location = new System.Drawing.Point(7, 20);
            this.launchBox.Name = "launchBox";
            this.launchBox.Size = new System.Drawing.Size(552, 20);
            this.launchBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Extra launch arguments";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(441, 46);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(118, 23);
            this.btnSaveConfig.TabIndex = 4;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 557);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCLauncher";
            this.pContainer.ResumeLayout(false);
            this.pContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modUpdateWebView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.settingsPage.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnSaveConfig;

        private Microsoft.Web.WebView2.WinForms.WebView2 modUpdateWebView;

        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox launchBox;

        private System.Windows.Forms.Button updateButton;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.Button launchButton;

        #endregion

        private System.Windows.Forms.Panel pContainer;
    }
}

