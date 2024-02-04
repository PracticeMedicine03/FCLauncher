using Lambdagon.FCLauncher.Core;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectBranchWindow.xaml
    /// </summary>
    public partial class InstallWindow : Window
    {
        public InstallWindow()
        {
            InitializeComponent();

            if(this.branchCombo.SelectedItem != null)
            {
                this.btnInstall.IsEnabled = true;
            }
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            if (this.branchCombo.SelectedIndex == 0)
            {
                this.Height = 201;
                if(Core.IsGoingToReinstall())
                    Core.ReinstallFC("main");
                else
                    Core.InstallFC("main");
                this.Close();
            }
            else if (this.branchCombo.SelectedIndex == 1)
            {
                this.Height = 201;
                if (Core.IsGoingToReinstall())
                    Core.ReinstallFC("dev");
                else
                    Core.InstallFC("dev");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a branch first.", "Install FC", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
