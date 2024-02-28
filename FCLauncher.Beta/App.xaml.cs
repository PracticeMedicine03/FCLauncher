using System;
using Squirrel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.IO;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        //static string[] args = Environment.GetCommandLineArgs();
        

        protected override async void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += CrashHandler;

            base.OnStartup(e);

            if(!Directory.Exists("./squirrel/lambdagon.fclauncher/update"))
            {
                Directory.CreateDirectory("./squirrel/lambdagon.fclauncher/update");
            }
            else
            {
                using (var mgr = new UpdateManager("./squirrel/lambdagon.fclauncher/update"))
                {
                    Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue("[FCLAUNCHER SQURRIEL]: Checking for updates");
                    await mgr.UpdateApp();
                }
            }
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
