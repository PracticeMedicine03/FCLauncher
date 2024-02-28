using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeMedicine.SourceModInstaller
{
    public class Git
    {
        //[DllImport("kernel32", SetLastError = true)]
        //static extern bool AttachConsole(int dwProcessId);
        //public static string GitProcessPath = ".\\bin\\git\\cmd\\git.exe";
        private static bool gitsetup;
        private static bool gitrunning;

        public static string git_output_standard = "";
        public static string git_output_error = "";

        public Git(bool gitsetup, bool gitrunning)
        {
            gitsetup = Git.gitsetup;
            gitrunning = Git.gitrunning;
        }

        public static string GitProcess()
        {
            if (!File.Exists($"{Application.StartupPath}/git/cmd/git.exe"))
                return $"{Application.StartupPath}/git/cmd/git.exe";
            else
                return null;
        }

        public static string GitProcess(string manual_path)
        {
            if (!File.Exists($"{Application.StartupPath}/git/cmd/git.exe"))
                return $"{Application.StartupPath}/git/cmd/git.exe";
            else if (manual_path != null)
                if (!File.Exists(manual_path))
                    return manual_path;
                else
                    return null;
            else
                return null;
        }

        public static Git StartGit(string args1 = null, string args2 = null, string args3 = null, string args4 = null, string args5 = null, string args6 = null, string args7 = null, string args8 = null, string args9 = null, string args10 = null, string args11 = null, string args12 = null)
        {
            Process p = new Process();
            p.StartInfo.Arguments = args1 + " " + args2 + " " + args3 + " " + args4 + " " + args5 + " " + args6 + " " + args7 + " " + args8 + " " + args9 + " " + args10 + " " + args11 + " " + args12;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "./git/cmd/git.exe";
            p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            git_output_error = p.StandardError.ReadToEnd();
            git_output_standard = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            /*
            Process[] gitID = Process.GetProcesses();
            

            foreach (Process process in gitID)
            {
                 // Check if the process path matches the one we're looking for
                 if (process.MainModule.FileName == GitProcess())
                 {
                     AttachConsole(process.Id);
                 }
            }*/

            Console.WriteLine(git_output_error);
            Console.WriteLine(git_output_standard);

            return new Git(true, true);
        }

        public static Git SetupGitConfig()
        {
            Console.WriteLine("Setting up Git...");
            StartGit("config " + "--global " + "http.postBuffer 524288000");
            StartGit("config " + "--global " + "http.maxRequestbuffer 524288000");
            StartGit("config " + "--global " + "core.compression 9");
            StartGit("config " + "--global " + "credential.helper manager-core");
            Console.WriteLine("Setted up Git configurations!");

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

        public static void Checkout(bool IsShallow, string directory, string branch, string extraArgs = null)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("-C " + $@"""{directory}""" + " fetch " + "-v " + "--depth 1 " + "--quiet");
                StartGit("-C " + $@"""{directory}""" + " checkout "+ "--quiet " + branch);

                //if(git_output_error != null)
                //    MessageBox.Show("There is an error while trying to switch branches.", "PracticeMedicine's SourceModInstaller Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Pull' has IsShallow set to false! This may cause issues.");
                StartGit("-C " + $@"""{directory}""" + " fetch " + "--progress");
                StartGit("-C " + $@"""{directory}""" + " checkout " + "--progress " + branch);

                //if (git_output_error != null)
                //    MessageBox.Show("There is an error while trying to switch branches.", "PracticeMedicine's SourceModInstaller Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void Clone(bool IsShallow, string link, string branch, string directory, string extraArgs = null)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("clone " + "--quiet " + "--depth 1 " + "-b " + branch + " " + extraArgs + " " + link + " " + $@"""{directory}""");
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Clone' has IsShallow set to false! This may cause issues.");
                StartGit("clone " + "-b " + branch + " " + extraArgs + " " + link + " " + $@"""{directory}""");
            }
        }
        
        public static void Pull(bool IsShallow, string directory, string branch, string extraArgs = null)
        {
            SetupGitConfig();
            if (IsShallow == true)
            {
                StartGit("-C " + $@"""{directory}""" + " fetch " + "--depth 1 " + "--quiet");
                StartGit("-C " + $@"""{directory}""" + " checkout " + "--quiet " + branch);
                StartGit("-C " + $@"""{directory}""" + " reset " + extraArgs + " --hard " + "origin/" + branch);

                //if(git_output_error != null)
                //    MessageBox.Show("There is an error while trying to call the Pull function.", "PracticeMedicine's SourceModInstaller Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //LauncherConsole.WriteLineWarning(4,
                //    "[FCLAUNCHER CORE] Function 'Pull' has IsShallow set to false! This may cause issues.");
                StartGit("-C " + $@"""{directory}""" + " fetch " + "--quiet");
                StartGit("-C " + $@"""{directory}""" + " checkout " + "--quiet " + branch);
                StartGit("-C " + $@"""{directory}""" + " reset " + "--quiet " + extraArgs + " --hard " + "origin/" + branch);

                //if (git_output_error != null)
                //    MessageBox.Show("There is an error while trying to call the Pull function.", "PracticeMedicine's SourceModInstaller Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Restore(bool IsShallow, string directory, string branch, string file, string extraArgs = null)
        {
            SetupGitConfig();
            if(IsShallow == true)
            {
                StartGit("-C", directory, "fetch", "--depth 1", "--quiet");
                StartGit("-C", directory, "restore", "-s", branch, directory + "/" + file, " --quiet " + extraArgs);
            }
        }
    }
}
