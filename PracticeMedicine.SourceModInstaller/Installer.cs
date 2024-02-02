using System;
using System.Net;

namespace PracticeMedicine.SourceModInstaller
{ 
    public class SModInstaller
    {
        public static int progressPercent = 0;
        public static void InstallMod(string type, string link, string branch, string directory)
        {
            if(type == "git")
            {
                Git.Clone(true, link, branch, directory);
            }
            else if (type == "webclient")
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("a", "a");
                    try
                    {
                        wc.DownloadFile(link, directory);
                        wc.DownloadProgressChanged += Wc_DownloadProgressChanged;

                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    }
                    catch (Exception ex)
                    {
                        // bruh
                        Console.WriteLine(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace + "\n" + ex.HelpLink);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("SMOD Installer: There is no package manager type. Please specify an package manager type.");
            }
        }

        private static void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("The downloaded file has been successfully installed.", "Installer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressPercent = e.ProgressPercentage;
        }

        public static void UpdateMod(string type, string link, string branch, string directory)
        {
            if (type == "git")
            {
                Git.Pull(true, directory, branch);
            }
            else if (type == "webclient")
            {
                throw new NotImplementedException("SMOD Installer: The implementation of using the C# WebClient is not fully implemented yet. Check the FCLauncher repository for updates.");
            }
            else
            {
                throw new ArgumentNullException("SMOD Installer: There is no package manager type. Please specify an package manager type.");
            }
        }
    }
}