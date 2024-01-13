// Don't use CEFSharp as its been replaced by Microsoft Edge WebView2
//#define ENABLE_CEF
//#define ENABLE_CEF_MENU

#if ENABLE_CEF
using CefSharp;
using CefSharp.WinForms;
#endif

using Lambdagon.FCLauncher.Core;
using Lambdagon.FCLauncher.Core.CommandLine;

// CefSharp has been replaced by Microsoft Edge WebView2
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lambdagon.FCLauncher.Core.Functions;
using PracticeMedicine.SourceModInstaller;

namespace FCLauncher
{
    public partial class MainForm : Form
    {
        #if ENABLE_CEF_MENU
        public static ChromiumWebBrowser browser;
        #endif

        public MainForm()
        {
            InitializeComponent();
            
#if ENABLE_CEF_MENU
            InitializeBrowser();
#endif
            Lambdagon.FCLauncher.Core.Core.FindFC();
            
            if (!File.Exists(Core.MainModPath))
            {
                launchButton.Enabled = false;
                //installButton.Enabled = false;
                updateButton.Enabled = false;
            }

            wikiWebView.NavigationStarting += EnsureIsHTTPS;
            
            FinalInitialization();
        }

        private void EnsureIsHTTPS(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                MessageBox.Show(
                    "The website entered inside the webview of the launcher is not secure and may cause security issues with FCLauncher.\nPlease contact the FCLauncher (or FC) developers about this problem.\nFCLauncher is supposed to be very-secure with their webview contents.",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                args.Cancel = true;
            }
        }

        // private void InitializeWebView2()
        // {
        //     // https://stackoverflow.com/questions/73840363/how-do-i-capture-text-from-a-html-element-given-its-id-from-a-webview2-in-vb/73846538#73846538
        //     IntializeCoreWebView2Async(wikiWebView, "https://github.com/Lambdagon/fc/wiki",null);
        // }

        // https://stackoverflow.com/questions/73840363/how-do-i-capture-text-from-a-html-element-given-its-id-from-a-webview2-in-vb/73846538#73846538
        private async void IntializeCoreWebView2Async(WebView2 wv, string url, string userDataFolder)
        {
            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
            CoreWebView2Environment webView2Environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, options);

            if (string.IsNullOrEmpty(userDataFolder))
            {
                userDataFolder = Path.Combine(Path.GetTempPath(),
                    Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
            
            await wv.EnsureCoreWebView2Async(webView2Environment);

            LauncherConsole.WriteLineBlue($"[FCLAUNCHER WEBVIEW2] UserDataFolder has been set to: {userDataFolder}");
            lblStatus.Text = $"UserDataFolder has been set to: {userDataFolder}";

            LauncherConsole.WriteLineDarkBlue($"[FCLAUNCHER WEBVIEW2] Loading {wv}...");
            lblStatus.Text = $"Loading {wv}";

            try
            {
                wv.CoreWebView2.Navigate(url);
                LauncherConsole.WriteLineSuccess($"[FCLAUNCHER WEBVIEW2] Loaded {wv}!");
                lblStatus.Text = $"Loaded {wv}!";
            }
            catch (Exception ex)
            {
                LauncherConsole.WriteLineError(1, "[FCLAUNCHER WEBVIEW2 ERROR] An exception has occured while loading the wiki page.");
                LauncherConsole.WriteLineError(1, "[FCLAUNCHER WEBVIEW2 ERROR] Exception details below this line.");
                LauncherConsole.WriteLineWarning(1, "-----------------------------------------------------------------");
                LauncherConsole.WriteLineError(6, $"{ex.InnerException}\n{ex.Message}\n{ex.StackTrace}\n{ex.Source}");
            }
            
            lblStatus.Text = "Ready!";
        }
        
        private void FinalInitialization()
        {
            // InitializeWebView2();
            IntializeCoreWebView2Async(wikiWebView, "https://github.com/Lambdagon/fc/wiki",null);

            if (!File.Exists("./launcher_cfg.txt"))
            {
                LauncherConsole.WriteLineBlue("[FCLAUNCHER] launcher_cfg.txt doesn't exist. Make a configuration on the settings page!");
            }
            else
            {
                using (StreamReader reader = new StreamReader("./launcher_cfg.txt"))
                {
                    launchBox.Text = reader.ReadLine();
                    reader.Close();
                }
            }

            Core.InitializeCore();

            lblStatus.Text = "Ready!";
        }
        
#if ENABLE_CEF_MENU
        /// <summary>
                /// This class is used by the browser (CEF) because this class is being registered by
                /// CefSharp's Javascript Binding
                /// </summary>
                public class FCLauncherJS
                {
                    public void findFC()
                    {
                        if(Main.GameInfoExists == false)
                        {
                            MessageBox.Show("The launcher directory was placed on the wrong directory and must be placed on the root of the mod's (fc) folder (where gameinfo.txt was placed)", "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
        
                    public void updateFC()
                    { 
                        if(Main.GameInfoExists == false)
                        {
                            LauncherConsole.WriteLineError("[FCLAUNCHER CORE] Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.");
                            MessageBox.Show(
                                "Cannot update FC because Fortress Connected is NOT installed. Installing FC will give the exact latest version.\n(The launcher must be placed on the root of the 'fc' directory.)",
                                "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Git.Pull(true, Main.FCSModPath);
                        }
                    }
        
                    public void launchFC()
                    {
                        if (Main.GameInfoExists == false)
                        {
                            MessageBox.Show(
                                "Cannot launch FC because Fortress Connected is NOT installed. \n(The launcher must be placed on the root of the 'fc' directory.)",
                                "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Main.Source2013MPExists == true)
                            {
                                if (Main.TFExists == true)
                                {
                                    if (Steam.isSteamInstalled())
                                    {
                                        Steam.startAppId(243750, "-game " + Main.FCSModPath);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Cannot launch FC because the base tool/game isn't installed.\nPlease make sure that 440 (Team Fortress 2) is installed.",
                                        "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Cannot launch FC because the base tool/game isn't installed.\nPlease make sure that 243750 (Source SDK 2013 Multiplayer) is installed.",
                                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
#endif
        

#if ENABLE_CEF_MENU
        private void InitializeBrowser()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);

            string menuPage = string.Format(@"{0}\ui\index.html", Application.StartupPath);

            browser = new ChromiumWebBrowser(menuPage);

            this.pContainer.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            // bind the FCLauncherJS class
            browser.JavascriptObjectRepository.Register("fcLauncherJS", new FCLauncherJS(), true, options: BindingOptions.DefaultBinder);

            browser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                Debug.WriteLine($"Class/Object {e.ObjectName} was registered succesfully.");
            };

            browser.FrameLoadEnd += (sender, args) =>
            {
                //Wait for the MainFrame to finish loading
                if (args.Frame.IsMain)
                {
                    if (Main.GameInfoExists == false)
                    {
                        browser.ExecuteScriptAsync("showAlert('warning', 'The launcher is placed on the wrong directory and must be placed on the root of the mod's folder');");
                    }
                }
            };
        }
#endif
        private void launchButton_Click(object sender, EventArgs e)
        {
            launchButton.Enabled = false;
            updateButton.Enabled = false;
            if (launchBox.Text.Contains("-console"))
            {
                DialogResult devConsoleEnabled = MessageBox.Show(
                    "You are trying to run Fortress Connected with -console on your extra launch arguments.\nThis means that your running FC with the developer console and may grant you access to convars that can break the game.\nAre you sure do you want to run the mod with the console?\n(It is recommended to run the mod normally)",
                    "FCLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (devConsoleEnabled == DialogResult.Yes)
                {
                    Core.LaunchFC(launchBox.Text);
                }
            }
            else if (launchBox.Text.Contains("-dev"))
            {
                DialogResult developerMode = MessageBox.Show(
                    "You are trying to run Fortress Connected with -dev on your extra launch arguments.\nThis means that your running FC with developer mode and may grant you access to developer only convars\nthat can break the game.\nAre you sure do you want to run the mod with developer mode?\n(It is recommended to run the mod normally)",
                    "FCLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (developerMode == DialogResult.Yes)
                {
                    Core.LaunchFC(launchBox.Text);
                }
            }
            else 
            {
                Core.LaunchFC(launchBox.Text);
            }
            launchButton.Enabled = true;
            updateButton.Enabled = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            launchButton.Enabled = false;
            //installButton.Enabled = false;
            updateButton.Enabled = false;
            try
            {
                lblStatus.Text = "Setting up Git.";
                Git.SetupGitConfig();
                lblStatus.Text = "Updating FC";
                Core.UpdateFC();
                
            }
            catch (Exception ex)
            {
                launchButton.Enabled = true;
                //installButton.Enabled = true;
                updateButton.Enabled = true;
                LauncherConsole.WriteLineError(5, "[FCLAUNCHER ERROR] An exception has occured in this application.");
                LauncherConsole.WriteLineError(5, "[FCLAUNCHER ERROR] Exception details below this line.");
                LauncherConsole.WriteLineWarning(4, "-----------------------------------------------------------------");
                LauncherConsole.WriteLineError(6, $"{ex.InnerException}\n{ex.Message}\n{ex.StackTrace}\n{ex.Source}");
                MessageBox.Show(
                    "There's an error occured during the update procedure.\nUse --console on your launch arguments for FCLauncher for more information.",
                    "FCLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            launchButton.Enabled = true;
            updateButton.Enabled = true;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("./launcher_cfg.txt"))
            {
                writer.WriteLine(launchBox.Text);
                // writer.WriteLine("launcher_cfg");
                // writer.WriteLine("{");
                // writer.WriteLine("      ");
                // writer.WriteLine("      settings");
                // writer.WriteLine("      {");
                // writer.WriteLine($"          launch_args     '{launchBox.Text}'");
                // writer.WriteLine("      }");
                // writer.WriteLine("}");
                writer.Close();
            }
        }

        private void btnDevTools_Click(object sender, EventArgs e)
        {
            wikiWebView.CoreWebView2.OpenDevToolsWindow();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Lambdagon/fc/issues");
        }
    }
}
