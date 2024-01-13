using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambdagon.FCLauncher.Core.CommandLine
{
    public class LauncherConsole
    {
        public static void WriteLineSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void WriteLineWarning(int level, string message)
        {
            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message + " - wnLVL: 1");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message + " - wnLVL: 2");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message + " - wnLVL: 3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message + " - wnLVL: 4");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message + " - wnLVL: 5");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            if (level == 5)
            {
                WriteLineError(6, $"[ ERROR ] The following warning level: {level} is being treated as a error and the app needs to be closed immediately.");
            }
        }

        public static void WriteLineError(int level, string message)
        {
            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 1");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 2");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 4");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 5");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message + " - errLVL: 6");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    Application.Exit();
                    break;
            }
        }

        public static void WriteLineBlue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteLineDarkBlue(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
