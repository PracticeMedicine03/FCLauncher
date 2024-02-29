using System;
using Squirrel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Interop;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        static string[] args = Environment.GetCommandLineArgs();

        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += CrashHandler;

            base.OnStartup(e);

            if (args.Contains("--console") || args.Contains("-con"))
                AllocConsole();
        }

        protected void CrashHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO: log the error

            // show the custom crash reporter dialog
            CrashInfoWindow f = new CrashInfoWindow();
            f.errLogTxt.Text = e.Exception.InnerException + "\n" + e.Exception.Message + "\n" + e.Exception.StackTrace;
            f.ShowDialog();

            // signal that you handled the exception -> application will not be terminated automatically
            e.Handled = true;
        }
    }
}
