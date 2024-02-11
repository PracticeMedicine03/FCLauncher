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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for CrashInfoWindow.xaml
    /// </summary>
    public partial class CrashInfoWindow : Window
    {
        public CrashInfoWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
