using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Lambdagon.FCLauncher.Core.CommandLine;
using Lambdagon.FCLauncher.Core.Functions;

// Both Steam.cs and Git.cs are now in a seperate library.
using PracticeMedicine.SourceModInstaller;

namespace Lambdagon.FCLauncher.Core
{
    public class Core
    {
        private static bool GameInfoExists;
        private static bool Source2013MPExists;
        private static bool TFExists;
        private static bool IfFCExists;
        public static string MainModPath = "../gameinfo.txt";
        public static string FCSModPath = Steam.getSourcemodsFolder() + "/fc";

        public Core()
        {
            // HashSet<String> libraryFolders = Steam.getLibraryFolders();
            // InstallationStatus statusSDK = Steam.getAppIdStatus(243750, libraryFolders);
            // InstallationStatus statusTF = Steam.getAppIdStatus(440, libraryFolders);
            //
            // if (!statusSDK.isInstalled())
            // {
            //     Source2013MPExists = false;
            //     CommandLine.LauncherConsole.WriteLineWarning(4,"[FCLAUNCHER CORE] App ID 243750 - Source SDK 2013 Base Multiplayer isn't installed.");
            //     MessageBox.Show(
            //         "Source SDK 2013 Multiplayer isn't installed.\nThis is a very very critical component for FC, aswell as for the other mods based off it.",
            //         "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // }
            // else
            // {
            //     Source2013MPExists = true;
            // }
            //
            // if (!statusTF.isInstalled())
            // {
            //     TFExists = false;
            //     MessageBox.Show(
            //         "Team Fortress 2 isn't installed.\nThis is a very critical component for FC, aswell as for the other mods based off TF2.\n(NOTE: You can still run the mod but might cause texture issues)",
            //         "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // }
            // else
            // {
            //     TFExists = true;
            // }
        }

        public static bool IsBaseSDKInstalled()
        {
            return Source2013MPExists;
        }

        public static bool IsBaseTFInstalled()
        {
            return TFExists;
        }

        public static bool IsFCInstalled()
        {
            return IfFCExists;
        }
        
        public static bool IsModGameInfoTxtExist()
        {
            return GameInfoExists;
        }

        public static Core InitializeCore()
        {
            return new Core();
        }
        
        public static void FindFC()
        {
            if (!File.Exists(MainModPath))
            {
                GameInfoExists = false;
                LauncherConsole.WriteLineWarning(5,"[FCLAUNCHER CORE] GameInfo.txt doesn't exist. Please make sure that the launcher is placed on the root of the mod directory.", true);
            }
            else
            {
                GameInfoExists = true;
                LauncherConsole.WriteLineSuccess($"[FCLAUNCHER CORE] GameInfo.txt was found in {MainModPath}. ");
            }
        }

        public static void InstallFC()
        {
            if(!IsFCInstalled())
            {
                // ProgressBar statusForm = new ProgressBar();
                // statusForm.Show();
                // statusForm.lblStatus.Text = "Installing your game. Please wait...";
                //
                // statusForm.pBarStatus.Style = ProgressBarStyle.Blocks;
                // statusForm.lblStatus.Text = "Setting up Git...";
                // statusForm.pBarStatus.Value = 40;
                // statusForm.lblStatus.Text = "Installing FC...";
                // statusForm.pBarStatus.Value = 50;
                Git.Clone(true, "https://github.com/Lambdagon/fc.git", FCSModPath);
                // statusForm.pBarStatus.Value = 60;
                // statusForm.pBarStatus.Value = 80;
                // statusForm.pBarStatus.Value = 90;
                // statusForm.pBarStatus.Value = 100;

                MessageBox.Show("Fortress Connected is installed.\nRestart Steam to play.", "FCLauncher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // statusForm.Close();
            }
            else
            {
                LauncherConsole.WriteLineError(4,"[FCLAUNCHER CORE] Cannot install FC because Fortress Connected already exists. To update, click the 'Update FC' Button.", true);
                MessageBox.Show(
                    "Cannot install FC because Fortress Connected is already installed.\n(The launcher must be placed on the root of the 'fc' directory.)",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void UpdateFC()
        { 
            if(!IsModGameInfoTxtExist())
            {
                LauncherConsole.WriteLineError(4,"[FCLAUNCHER CORE] Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.", false);
                MessageBox.Show(
                    "Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.\n(The launcher must be placed on the root of the 'fc' directory.)",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ProgressBar statusForm = new ProgressBar();
                // statusForm.Show();
                // statusForm.lblStatus.Text = "Updating your game. Please wait...";
                //
                // statusForm.pBarStatus.Style = ProgressBarStyle.Blocks;
                // statusForm.lblStatus.Text = "Setting up Git...";
                // statusForm.pBarStatus.Value = 40;
                // statusForm.lblStatus.Text = "Updating FC...";
                // statusForm.pBarStatus.Value = 50;
                Git.Pull(true, Core.FCSModPath);
                // statusForm.pBarStatus.Value = 60;
                // statusForm.pBarStatus.Value = 80;
                // statusForm.pBarStatus.Value = 90;
                // statusForm.pBarStatus.Value = 100;
                MessageBox.Show("Fortress Connected is updated.", "FCLauncher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // statusForm.Close();
            }
        }
        
        public static void LaunchFC(string args)
        {
            if (!IsModGameInfoTxtExist())
            {
                MessageBox.Show("Cannot launch FC because Fortress Connected is NOT installed. \n(The launcher must be placed on the root of the 'fc' directory.)",
                                "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                // if (IsBaseSDKInstalled())
                // {
                //     if (IsBaseTFInstalled())
                //     {
                //         if (Steam.isSteamInstalled())
                //         {
                Steam.startAppId(243750, "-game " + Core.FCSModPath + " " + args);
            //             }
            //         }
            //         else
            //         {
            //             MessageBox.Show(
            //                 "Cannot launch FC because the base tool/game isn't installed.\nPlease make sure that 440 (Team Fortress 2) is installed.",
            //                 "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //         }
            //     }
            //     else
            //     {
            //         MessageBox.Show(
            //             "Cannot launch FC because the base tool/game isn't installed.\nPlease make sure that 243750 (Source SDK 2013 Multiplayer) is installed.",
            //             "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     }
            }
        }
    }
}
