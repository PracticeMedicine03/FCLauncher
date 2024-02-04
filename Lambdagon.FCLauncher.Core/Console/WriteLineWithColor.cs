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
        public static void WriteLineSuccess(string message, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void WriteLineWarning(int level, string message, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null, bool ShowLevel = true)
        {
            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (ShowLevel)
                        Console.WriteLine(message + " - wnLVL: 1", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (ShowLevel)
                        Console.WriteLine(message + " - wnLVL: 2", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (ShowLevel)
                        Console.WriteLine(message + " - wnLVL: 3", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (ShowLevel)
                        Console.WriteLine(message + " - wnLVL: 4", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (ShowLevel)
                        Console.WriteLine(message + " - wnLVL: 5", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            if (level == 5)
            {
                WriteLineError(6, $"[ ERROR ] The following warning level: {level} is being treated as a error and the app needs to be closed immediately.", false);
            }
        }

        public static void WriteLineError(int level, string message, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null, bool ShowLevel = true)
        {
            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if(ShowLevel)    
                        Console.WriteLine(message + " - errLVL: 1", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ShowLevel)
                        Console.WriteLine(message + " - errLVL: 2", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ShowLevel)
                        Console.WriteLine(message + " - errLVL: 3", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ShowLevel)
                        Console.WriteLine(message + " - errLVL: 4", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ShowLevel)
                        Console.WriteLine(message + " - errLVL: 5", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ShowLevel)
                        Console.WriteLine(message + " - errLVL: 6", arg0, arg1, arg2, arg3, arg4);
                    else
                        Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    Application.Exit();
                    break;
            }
        }

        public static void WriteLineBlue(string message, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteLineDarkBlue(string message, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message, arg0, arg1, arg2, arg3, arg4);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
