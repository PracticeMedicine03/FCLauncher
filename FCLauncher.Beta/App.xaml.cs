using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += CrashHandler;

            base.OnStartup(e);
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
