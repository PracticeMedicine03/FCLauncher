using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lambdagon.FCLauncher.Core;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using PracticeMedicine.SourceModInstaller;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("./launcher_cfg.txt"))
            {
                using (StreamReader reader = new StreamReader("./launcher_cfg.txt"))
                {
                    this.argsTxt.Text = reader.ReadLine();
                    reader.Close();
                }
            }

            if(Directory.Exists(Steam.getSourcemodsFolder() + "/fc"))
            {
                this.btnInstall.IsEnabled = false;
            }
            else
            {
                this.btnLaunch.IsEnabled = false;
                this.btnUpdate.IsEnabled = false;
            }
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            Core.InstallFC();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Core.UpdateFC();
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            Core.LaunchFC(this.argsTxt.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("./launcher_cfg.txt"))
            {
                writer.WriteLine(this.argsTxt.Text);
                writer.Close();
            }
        }
    }
}
