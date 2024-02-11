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
    /// Interaction logic for NullArgumentHelpWindow.xaml
    /// </summary>
    public partial class NullArgumentHelpWindow : Window
    {
        public NullArgumentHelpWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow f = new MainWindow();
            f.Show();
        }
    }
}
