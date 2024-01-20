using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMedicine.SourceModInstaller
{
    public class Git
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);
        //public static string GitProcessPath = ".\\bin\\git\\cmd\\git.exe";
        private static bool gitsetup;
        private static bool gitrunning;
        public Git(bool gitsetup, bool gitrunning)
        {
            gitsetup = Git.gitsetup;
            gitrunning = Git.gitrunning;
        }

        public static Git StartGit(string args)
        {
            ProcessStartInfo git = new ProcessStartInfo();
            git.Arguments = args;
            git.CreateNoWindow = false;
            git.UseShellExecute = true;
            git.WorkingDirectory = @".\bin\git\cmd";
            git.FileName = "git.exe";
            git.RedirectStandardError = true;
            git.RedirectStandardInput = true;
            git.RedirectStandardOutput = true;
            Process.Start(git);
            

            // Process[] gitID = Process.GetProcesses();
            //
            // foreach (Process process in gitID)
            // {
            //     // Check if the process path matches the one we're looking for
            //     if (process.MainModule.FileName == "./bin/git/cmd/git.exe")
            //     {
            //         AttachConsole(process.Id);
            //     }
            // }

            return new Git(true, true);
        }

        public static Git SetupGitConfig()
        {
            StartGit("config " + "--global " + "http.postBuffer 524288000");
            StartGit("config " + "--global " + "http.maxRequestbuffer 524288000");
            StartGit("config " + "--global " + "core.compression 9");
            StartGit("config " + "--global " + "credential.helper manager-core");

            return new Git(true, false);
        }
        
        public static bool IsGitSetup()
        {
            return gitsetup;
        }

        public static bool IsGitRunning()
        {
            return gitrunning;
        }
        
        public static void Clone(bool IsShallow, string link, string directory)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("clone " + "--depth 1 " + link + " " + directory);
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Clone' has IsShallow set to false! This may cause issues.");
                StartGit("clone " + link + " " + directory);
            }
//             if (IsGitSetup())
//             {
//                 if (IsShallow == true)
//                 {
//                     Process.Start(GitProcessPath, "clone " + "--depth 1 " + link + " " + directory);
//                 }
//                 else
//                 {
//                     LauncherConsole.WriteLineWarning(
//                         "[FCLAUNCHER CORE] Function 'Clone' has IsShallow set to false! This may cause issues.");
//                     Process.Start(GitProcessPath, "clone " + link + " " + directory);
//                 }
//             }
//             else
//             {
// #if DEBUG
//                 throw new WarningException(
//                     "Git has not been configured by 'public static Git SetupGitConfig()' and may cause issue if without the FCLauncher Git configurations (this includes shallow cloning and pulling)");
// #else
//                 MessageBox.Show("Git has not been configured by Lambdagon.FCLauncher.Core's Git class.\nThis may cause issues if the FCLauncher Git configurations are not loaded.\n(includes shallow cloning and pulling)\nContact a developer!");
// #endif
//            }
        }
        
        public static void Pull(bool IsShallow, string directory)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("-C " + directory + " fetch " + "--depth 1");
                StartGit("-C " + directory + " reset " + "--hard " + "origin/HEAD");
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Pull' has IsShallow set to false! This may cause issues.");
                StartGit("-C " + directory + " fetch " + "--depth 1");
                StartGit("-C " + directory + " reset " + "--hard " + "origin/HEAD");
            }
            
//             if (IsGitSetup())
//             {
//                 if (IsShallow == true)
//                 {
//                     Process.Start(GitProcessPath, "-C " + directory + " fetch " + "--depth 1");
//                     Process.Start(GitProcessPath, "-C " + directory + " reset " + "--hard " + "origin/HEAD");
//                 }
//                 else
//                 {
//                     LauncherConsole.WriteLineWarning(
//                         "[FCLAUNCHER CORE] Function 'Pull' has IsShallow set to false! This may cause issues.");
//                     Process.Start(GitProcessPath, "-C " + directory + " fetch " + "--depth 1");
//                     Process.Start(GitProcessPath, "-C " + directory + " reset " + "--hard " + "origin/HEAD");
//                 }
//             }
//             else
//             {
// #if DEBUG
//                 throw new WarningException(
//                     "Git has not been configured by 'public static Git SetupGitConfig()' and may cause issue if without the FCLauncher Git configurations (this includes shallow cloning and pulling)");
// #else
//                 MessageBox.Show("Git has not been configured by Lambdagon.FCLauncher.Core's Git class.\nThis may cause issues if the FCLauncher Git configurations are not loaded.\n(includes shallow cloning and pulling)\nContact a developer!");
// #endif                
//             }
        }
    }
}
