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
            Process p = new Process();
            p.StartInfo.Arguments = args;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.WorkingDirectory = @".\bin\git\cmd";
            p.StartInfo.FileName = "git.exe";
            p.Start();
            p.WaitForExit();

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
        
        public static void Clone(bool IsShallow, string link, string branch, string directory)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("clone " + "--depth 1 " + "-b " + branch + " --single-branch " + link + " " + directory);
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Clone' has IsShallow set to false! This may cause issues.");
                StartGit("clone " + "-b " + branch + " --single-branch " + link + " " + directory);
            }
        }
        
        public static void Pull(bool IsShallow, string directory, string branch)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("-C " + directory + " fetch " + "--depth 1");
                StartGit("-C " + directory + " reset " + "--hard " + "origin/" + branch);
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Pull' has IsShallow set to false! This may cause issues.");
                StartGit("-C " + directory + " fetch " + "--depth 1");
                StartGit("-C " + directory + " reset " + "--hard " + "origin/" + branch);
            }
        }
    }
}
