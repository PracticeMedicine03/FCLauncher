using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Lambdagon.FCLauncher.Core.CommandLine;

namespace PracticeMedicine.SourceModInstaller
{
    public class Steam
    {
        private static String installationFolder;

        public Steam()
        {
            installationFolder = fetchInstallationFolder();
        }

        public static bool isSteamInstalled()
        {
            return installationFolder != null;
        }

        public static String getInstallationFolder()
        {
            return installationFolder;
        }

        private static String fetchInstallationFolder()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\");

            //Seems like steam is either not installed or it's a 32bit system.
            // if (key == null)
            // {
            //     key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam\");
            // }

            //If the key is still null then steam just isn't installed.
            if (key == null)
            {
                //LauncherConsole.WriteLineWarning(1,
                //    "[ NOTE ] Warnings on Level 5 can cause an application to exit");
                //LauncherConsole.WriteLineWarning(5,
                //    "[ WARNING ] Steam isn't installed, Please install Steam to play Fortress Connected.");
                return null;
            }

            // return key.GetValue("InstallPath").ToString(); // InstallPath is now SteamPath.
            return key.GetValue("SteamPath").ToString();
        }

        public static bool startAppId(int appId, String additionalParams)
        {
            String steamExecutable = fetchInstallationFolder() + @"\steam.exe";
            Process launchProcess = new Process();
            launchProcess.StartInfo.FileName = steamExecutable;
            launchProcess.StartInfo.Arguments = "-applaunch " + appId + " " + additionalParams;
            return launchProcess.Start();
        }

        public static String getSourcemodsFolder()
        {
            return fetchInstallationFolder() + @"\steamapps\sourcemods";
        }

        public static HashSet<String> getLibraryFolders()
        {
            HashSet<String> folders = new HashSet<String>();
            folders.Add(fetchInstallationFolder());

            using (StreamReader reader = new StreamReader(fetchInstallationFolder() + @"\SteamApps\libraryfolders.vdf"))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Regex that matches line that contain a library folder specificiation.
                    Regex regex = new Regex("^( *\t*)*\"path\"( *\t*)*\".*\"$");
                    if (regex.IsMatch(line))
                    {
                        String folder = Regex.Replace(line, "^( *\t*)*\"path\"( *\t*)*", "").Replace("\"", "").Replace(@"\\", "\\");
                        //This check ensures only actual existing folders referenced in the file will be used.
                        if (Directory.Exists(folder) && !folders.Contains(folder))
                        {
                            folders.Add(folder);
                        }
                    }
                }
            }
            return folders;
        }

        public static InstallationStatus getAppIdStatus(int appid)
        {
            return getAppIdStatus(appid, getLibraryFolders());
        }

        public static InstallationStatus getAppIdStatus(int appid, HashSet<String> libraryFolders)
        {
            foreach (String folder in libraryFolders)
            {
                String filename = folder + "/SteamApps/appmanifest_" + appid + ".acf";
                if (File.Exists(filename))
                {
                    String stateFlags = getKeyValue("StateFlags", filename);
                    String installDir = folder + @"\SteamApps\common\" + getKeyValue("installdir", filename);

                    if (stateFlags == "4") return new InstallationStatus(true, false, installDir); //Flags: 4
                    return new InstallationStatus(true, true, installDir); //Flags: 2, 512, 1024
                }
            }
            return new InstallationStatus(false, false, null);
        }

        private static String getKeyValue(String key, String filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    //Regex that matches line that contain a library folder specificiation.
                    String keyRegx = "^\"" + key + "\"( *\t*)*";
                    String valueRegx = "\".*\"$";

                    Regex regex = new Regex(keyRegx + valueRegx);
                    if (regex.IsMatch(line))
                    {
                        String value = Regex.Replace(line, keyRegx, "").Replace("\"", "").Replace(@"\\", "\\");
                        return value;
                    }
                }
            }
            return null;
        }
    }

    public class InstallationStatus
    {
        private static bool installed;
        private static bool updating;
        private static String installationDirectory;

        public InstallationStatus(bool isInstalled, bool isUpdating, String InstallationDirectory)
        {
            isInstalled = installed;
            isUpdating = installed ? updating : false; //If it is not installed it cannot be updating so set the flag to false.
            InstallationDirectory = installationDirectory;
        }

        public bool isInstalled()
        {
            return installed;
        }

        public bool isUpdating()
        {
            return updating;
        }

        public String getInstallationDirectory()
        {
            return installationDirectory;
        }
    }
}
