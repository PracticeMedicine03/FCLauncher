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
using System.Drawing;
using System.Threading;

namespace Lambdagon.FCLauncher.Core
{
    public class Core
    {
        private static bool GameInfoExists;
        private static bool Source2013MPExists;
        private static bool TFExists;
        private static bool IfFCExists;
        private static bool reinstallfc;
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

        public static bool IsGoingToReinstall()
        {
            return reinstallfc;
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

        public static void InstallFC(string branch, string extraArgs = null)
        {
            if(!Directory.Exists(FCSModPath))
            {
                Git.Clone(true, "https://github.com/Lambdagon/fc.git", branch, FCSModPath, extraArgs);

                MessageBox.Show("Fortress Connected is installed.\nRestart Steam to play.", "FCLauncher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LauncherConsole.WriteLineError(4,"[FCLAUNCHER CORE] Cannot install FC because Fortress Connected already exists. To update, click the 'Update FC' Button.", true);
                MessageBox.Show(
                    "Cannot install FC because Fortress Connected is already installed.",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void PostSetupReinstall()
        {
            reinstallfc = true;
        }

        private static void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }

        public static bool ReinstallFC(string branch = null, string extraArgs = null)
        {
            if (Directory.Exists(FCSModPath))
            {
                try
                {
                    ClearFolder(FCSModPath);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("Cannot reinstall Fortress Connected, because one of the mod files are used/opened in another program.\nPlease close the mod or the program that has the mod's main files opened.", "Reinstall FC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(branch == null)
                    // If the branch string is null, then clone the main branch of the mod.
                    Git.Clone(true, "https://github.com/Lambdagon/fc.git", "main", FCSModPath, extraArgs);
                else
                    Git.Clone(true, "https://github.com/Lambdagon/fc.git", branch, FCSModPath, extraArgs);

                MessageBox.Show("Fortress Connected is reinstalled.\nRestart Steam to play.", "FCLauncher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(Git.git_output_error != null)
                    return false;
                else
                    return true;
            }
            else
            {
                LauncherConsole.WriteLineError(4, "[FCLAUNCHER CORE] Cannot install FC because Fortress Connected already exists. To update, click the 'Update FC' Button.", true);
                MessageBox.Show(
                    "Cannot install FC because Fortress Connected is already installed.",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public static void UpdateFC(string branch, string extraArgs = null)
        { 
            if(!Directory.Exists(FCSModPath))
            {
                LauncherConsole.WriteLineError(4,"[FCLAUNCHER CORE] Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.", false);
                MessageBox.Show(
                    "Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Git.Pull(true, Core.FCSModPath, branch, extraArgs);
                MessageBox.Show("Fortress Connected is updated.", "FCLauncher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public static void LaunchFC(string args)
        {
            if (!Directory.Exists(FCSModPath))
            {
                MessageBox.Show("Cannot launch FC because Fortress Connected is NOT installed.",
                                "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Check if the game or an another Source engine game is running.
                Mutex sourceEngineMutex;
                Mutex.TryOpenExisting("hl2_singleton_mutex", out sourceEngineMutex);
                if (sourceEngineMutex != null)
                {
                    LauncherConsole.WriteLineWarning(1, "[FCLAUNCHER CORE]: the following app returned an warning", false);
                    LauncherConsole.WriteLineWarning(1, "Returned message: Only one instance of the game can be running at one time.");
                    MessageBox.Show("Cannot run Fortress Connected, because an another game client is already running.\n(Other Source engine games count. EVEN on an another engine branch.)", "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Steam.startAppId(243750, "-game " + Core.FCSModPath + " " + args);
                }

            }
        }
    }
}
