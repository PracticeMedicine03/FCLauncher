using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCLauncher
{
    public static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Contains("--console"))
            {
                AllocConsole();
            }
            else if (args.Contains("-c"))
            {
                AllocConsole();
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
