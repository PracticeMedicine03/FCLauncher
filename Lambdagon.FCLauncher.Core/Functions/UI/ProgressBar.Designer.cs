using System.ComponentModel;

namespace Lambdagon.FCLauncher.Core.Functions.UI
{
    partial class ProgressBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.pBarStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBarStatus
            // 
            this.pBarStatus.Location = new System.Drawing.Point(16, 62);
            this.pBarStatus.Name = "pBarStatus";
            this.pBarStatus.Size = new System.Drawing.Size(438, 23);
            this.pBarStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBarStatus.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(25, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(429, 29);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label here";
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(466, 97);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pBarStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressBar";
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.Label lblStatus;

        public System.Windows.Forms.ProgressBar pBarStatus;

        #endregion
    }
}