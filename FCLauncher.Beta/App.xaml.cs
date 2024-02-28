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

            Task.Run(async () =>
             {
                 using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/PracticeMedicine03/FCLauncher"))
                 {
                     mgr.Dispose();

                     try
                     {
                         Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue("[FCLAUNCHER SQURRIEL]: Checking for updates");
                         var updateInfo = await mgr.Result.CheckForUpdate();

                         if (updateInfo.ReleasesToApply.Any())
                         {
                             var versionCount = updateInfo.ReleasesToApply.Count;
                             Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineBlue($"[FCLAUNCHER SQUIRREL]: {versionCount} update(s) found.");

                             var versionWord = versionCount > 1 ? "versions" : "version";
                             var message = new StringBuilder().AppendLine($"FCLauncher is {versionCount}").
                                                               AppendLine("If you choose to update, changes won't take affect until FCLauncher is restarted.").
                                                               AppendLine("Would you like to download and install them?").
                                                               ToString();
                             var result = MessageBox.Show(message, "FCLauncher Update", MessageBoxButton.YesNo);
                             if (result != MessageBoxResult.Yes)
                             {
                                 Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue("Update declined by user.");
                                 return;
                             }

                             Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue("[FCLAUNCHER SQUIRREL]: Downloading update...");
                             var updateResult = await mgr.Result.UpdateApp();
                             Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue($"[FCLAUNCHER SQUIRREL]: Download complete. Version {updateResult.Version} will take effect when FCLauncher is restarted");
                         }
                         else
                         {
                             Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineDarkBlue("[FCLAUNCHER SQUIRREL]: There are no updates.");
                         }
                     }
                     catch(Exception ex)
                     {
                         Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineWarning(3, $"[FCLAUNCHER SQUIRREL]: There is an issue while trying to update.\nMessage:\n{ex.Message}");
                     }
                 }

                 GC.WaitForFullGCComplete();

             });

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
