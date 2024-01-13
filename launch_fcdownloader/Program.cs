using System;
using Octokit;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace launch_fcdownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(".\\launcher_bin\\fclauncher.exe"))
            {
                Console.WriteLine("Cannot run the main launcher. Make sure FCLauncher exists in the root of the FC directory");
                Console.ReadLine();
            }
            else
            {
                if (args.Contains("-enable-console"))
                {
                    Console.WriteLine("Launching FCLauncher with console logs enabled...");
                    Process.Start(".\\launcher_bin\\fclauncher.exe", "--console");
                }
                else
                {
                    Console.WriteLine("Launching FCLauncher...");
                    Process.Start(".\\launcher_bin\\fclauncher.exe");
                }
            }
        }
    }
}
