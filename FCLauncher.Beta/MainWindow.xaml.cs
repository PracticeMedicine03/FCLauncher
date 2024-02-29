using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lambdagon.FCLauncher.Core;
using PracticeMedicine.SourceModInstaller;
using NLua;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Remoting.Activation;
using Lambdagon.FCLauncher.Core.CommandLine;
using Squirrel;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DiscordRpcClient client;
        public static Lua lua;
        public static string appID = "1203189446670028891";
        public MainWindow()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/PracticeMedicine03/FCLauncher"))
                {
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
                    catch (Exception ex)
                    {
                        Lambdagon.FCLauncher.Core.CommandLine.LauncherConsole.WriteLineWarning(3, $"[FCLAUNCHER SQUIRREL]: There is an issue while trying to update.\nMessage:\n{ex.Message}");
                    }
                }

                GC.WaitForFullGCComplete();

            });

            lua = new Lua();

            if(Directory.Exists(Steam.getSourcemodsFolder() + "/fc"))
            {
                this.btnInstall.IsEnabled = false;
            }
            else
            {
                this.btnReinstall.IsEnabled = false;
                this.btnLaunch.IsEnabled = false;
                this.btnUpdate.IsEnabled = false;
                this.btnReset.IsEnabled = false;
            }

            if(!Directory.Exists(Core.FCSModPath + "/.git"))
            {
                MessageBoxResult result = MessageBox.Show("FCLauncher has detected that the Git configuration folder (.git) does NOT exist.\nYou cannot update your mod when '.git' doesn't exist.\nDo you wanna reinstall Fortress Connected?\nThere are common reasons on why this message occurs:\n1. Downloaded FC as an archive (.zip)\n2. Deleted the .git folder. (somehow)\n", "FCLauncher", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if(result == MessageBoxResult.Yes)
                {
                    Core.PostSetupReinstall();
                    InstallWindow reInstallWindow = new InstallWindow();
                    reInstallWindow.Show();
                    reInstallWindow.btnInstall.Content = "Reinstall";
                    reInstallWindow.Topmost = true;
                }
            }

            lua.LoadCLRPackage();
            lua.DoString("");

            InitRPC("Main Menu", "Self-explanatory.", null, "idk", null);

            InstallWindow installWindow = new InstallWindow();
            if (installWindow.branchCombo.SelectedIndex == 0)
            {
                this.branchComboSttgs.SelectedIndex = 0;
            }
            else if (installWindow.branchCombo.SelectedIndex == 1)
            {
                this.branchComboSttgs.SelectedIndex = 1;
            }
        }

        public static void InitRPC(string details, string state, string largeimage, string largeimagetext, string smallimage)
        {
            client = new DiscordRpcClient(appID);
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                LauncherConsole.WriteLineSuccess("[FCLAUNCHER DISCORD]: Recieved 'ready' from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                LauncherConsole.WriteLineSuccess("[FCLAUNCHER DISCORD]: Received an precense update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = largeimage,
                    LargeImageText = largeimagetext,
                    SmallImageKey = smallimage
                }
            });

            client.OnClose += (sender, e) =>
            {
                LauncherConsole.WriteLineError(4, "[FCLAUNCHER DISCORD]: The connection to the user's Discord client has been lost. Trying to reconnect.", true);
            };
        }

        public static void ChangeRPCPresence(string details, string state, string largeimage, string largeimagetext, string smallimage)
        {
            if (!client.IsInitialized)
            {
                LauncherConsole.WriteLineWarning(3, "[FCLAUNCHER DISCORD]: The Discord RPC client has not been initialized. Please inititalize the client first before changing the current presence.", false);
            }
            else
            {
                client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeimage,
                        LargeImageText = largeimagetext,
                        SmallImageKey = smallimage
                    }
                });
            }
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            InstallWindow installWindow = new InstallWindow();
            installWindow.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            InstallWindow installWindow = new InstallWindow();
            if(installWindow.branchCombo.SelectedIndex == 0)
            {
                Core.UpdateFC("main");
            }
            else if (installWindow.branchCombo.SelectedIndex == 1)
            {
                Core.UpdateFC("dev");
            }
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            ChangeRPCPresence("Launching Fortress Connected...", "", null, "idk", null);
            LaunchWindow launchWindow = new LaunchWindow();
            launchWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(client.IsInitialized)
                client.Deinitialize();
            Application.Current.Shutdown();
        }

        private void branchComboSttgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.branchComboSttgs.SelectedIndex == 0)
            {
                Git.Checkout(true, Core.FCSModPath, "main");
            }
            else if (this.branchComboSttgs.SelectedIndex == 1)
            {
                Git.Checkout(true, Core.FCSModPath, "dev");
            }
        }

        private void btnReinstall_Click(object sender, RoutedEventArgs e)
        {
            Core.PostSetupReinstall();
            InstallWindow reInstallWindow = new InstallWindow();
            reInstallWindow.Show();
            reInstallWindow.btnInstall.Content = "Reinstall";
            reInstallWindow.Topmost = true;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetFilesWindows resetFCWindow = new ResetFilesWindows();
            resetFCWindow.Show();
            resetFCWindow.Topmost = true;
        }

        private void btnThrowException_Click(object sender, RoutedEventArgs e)
        {
            throw new PracticeMedicine.SourceModInstaller.Exceptions.GitException("bruh");
        }
    }
}
