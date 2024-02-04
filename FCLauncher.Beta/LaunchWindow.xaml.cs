using Lambdagon.FCLauncher.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for LaunchWindow.xaml
    /// </summary>
    public partial class LaunchWindow : Window
    {
        public LaunchWindow()
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
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            Core.LaunchFC(this.argsTxt.Text);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
