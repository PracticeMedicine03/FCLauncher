using Lambdagon.FCLauncher.Core;
using PracticeMedicine.SourceModInstaller;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FCLauncher.Beta
{
    /// <summary>
    /// Interaction logic for ResetFilesWindows.xaml
    /// </summary>
    public partial class ResetFilesWindows : Window
    {
        public ResetFilesWindows()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if(binariesCheck.IsChecked == true)
            {
                MainWindow mainMenu = new MainWindow();
                if(mainMenu.branchComboSttgs.SelectedIndex == 0)
                {
                    File.Delete(Core.FCSModPath + "/bin/client.dll");
                    File.Delete(Core.FCSModPath + "/bin/discord-rpc.dll");
                    File.Delete(Core.FCSModPath + "/bin/game_shader_dx9.dll");
                    File.Delete(Core.FCSModPath + "/bin/server.dll");
                    Git.Restore(true, Core.FCSModPath, "main", "bin/client.dll");
                    Git.Restore(true, Core.FCSModPath, "main", "bin/discord-rpc.dll");
                    Git.Restore(true, Core.FCSModPath, "main", "bin/game_shader_dx9.dll");
                    Git.Restore(true, Core.FCSModPath, "main", "bin/server.dll");
                }
                else if (mainMenu.branchComboSttgs.SelectedIndex == 1)
                {
                    Git.Restore(true, Core.FCSModPath, "dev", "bin/client.dll");
                    Git.Restore(true, Core.FCSModPath, "dev", "bin/discord-rpc.dll");
                    Git.Restore(true, Core.FCSModPath, "dev", "bin/game_shader_dx9.dll");
                    Git.Restore(true, Core.FCSModPath, "dev", "bin/server.dll");
                }
            }

            if (configCheck.IsChecked == true)
            {
                MainWindow mainMenu = new MainWindow();
                if (mainMenu.branchComboSttgs.SelectedIndex == 0)
                {
                    File.Delete(Core.FCSModPath + "/cfg/config.cfg");
                    File.Delete(Core.FCSModPath + "/cfg/config_default.cfg");

                    // Restore the config_default.cfg incase if someone actually screwing around this default config file.
                    Git.Restore(true, Core.FCSModPath, "main", "cfg/config_default.cfg");
                }
                else if (mainMenu.branchComboSttgs.SelectedIndex == 1)
                {
                    File.Delete(Core.FCSModPath + "/cfg/config.cfg");
                    File.Delete(Core.FCSModPath + "/cfg/config_default.cfg");

                    // Restore the config_default.cfg incase if someone actually screwing around this default config file.
                    Git.Restore(true, Core.FCSModPath, "dev", "cfg/config_default.cfg");
                }
            }

            if (hl2MapsCheck.IsChecked == true)
            {
                MainWindow mainMenu = new MainWindow();
                if (mainMenu.branchComboSttgs.SelectedIndex == 0)
                {
                    // Point Insertion
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_04.bsp");

                    // "Red Letter Day"
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_06.bsp");

                    // Route Kanal
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_05.bsp");

                    // Water Hazard
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_10.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_13.bsp");

                    // Black Mesa East
                    File.Delete(Core.FCSModPath + "/maps/d1_eli_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_eli_02.bsp");

                    // "We don't go to Ravenholm"
                    File.Delete(Core.FCSModPath + "/maps/d1_town_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_01a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_02a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_05.bsp");

                    // Highway 17
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_07_p2.bsp");

                    // Sandtraps
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_10.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_01.bsp");

                    // Nova Prospekt
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_05.bsp");

                    // Entanglement
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_01.bsp");

                    // Anticitizen One
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_06a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_06b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_08.bsp");

                    // "Follow Freeman!"
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_10a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_10b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_12b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_13.bsp");

                    // Our Benefactors
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_05.bsp");

                    // Dark Energy
                    File.Delete(Core.FCSModPath + "/maps/d3_breen_01.bsp");

                    // Point Insertion
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_04.bsp");

                    // "Red Letter Day"
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_trainstation_06.bsp");

                    // Route Kanal
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_05.bsp");

                    // Water Hazard
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_10.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_canals_13.bsp");

                    // Black Mesa East
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_eli_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_eli_02.bsp");

                    // "We don't go to Ravenholm"
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_town_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_town_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_town_02a.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_town_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d1_town_05.bsp");

                    // Highway 17
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_07_p2.bsp");

                    // Sandtraps
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_10.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_coast_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_01.bsp");

                    // Nova Prospekt
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_05.bsp");

                    // Entanglement
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d2_prison_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_01.bsp");

                    // Anticitizen One
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_06a.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_06b.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_08.bsp");

                    // "Follow Freeman!"
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_10a.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_10b.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_12b.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_c17_13.bsp");

                    // Our Benefactors
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_citadel_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_citadel_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_citadel_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_citadel_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_citadel_05.bsp");

                    // Dark Energy
                    Git.Restore(true, Core.FCSModPath, "main", "maps/d3_breen_01.bsp");
                }
                else if (mainMenu.branchComboSttgs.SelectedIndex == 1)
                {
                    // Point Insertion
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_04.bsp");

                    // "Red Letter Day"
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_trainstation_06.bsp");

                    // Route Kanal
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_05.bsp");

                    // Water Hazard
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_10.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_canals_13.bsp");

                    // Black Mesa East
                    File.Delete(Core.FCSModPath + "/maps/d1_eli_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_eli_02.bsp");

                    // "We don't go to Ravenholm"
                    File.Delete(Core.FCSModPath + "/maps/d1_town_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_01a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_02a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d1_town_05.bsp");

                    // Highway 17
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_07_p2.bsp");

                    // Sandtraps
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_10.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_coast_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_01.bsp");

                    // Nova Prospekt
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_05.bsp");

                    // Entanglement
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_06.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d2_prison_08.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_01.bsp");

                    // Anticitizen One
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_05.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_06a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_06b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_07.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_08.bsp");

                    // "Follow Freeman!"
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_09.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_10a.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_10b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_11.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_12.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_12b.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_c17_13.bsp");

                    // Our Benefactors
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_01.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_02.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_03.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_04.bsp");
                    File.Delete(Core.FCSModPath + "/maps/d3_citadel_05.bsp");

                    // Dark Energy
                    File.Delete(Core.FCSModPath + "/maps/d3_breen_01.bsp");

                    // Point Insertion
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_04.bsp");

                    // "Red Letter Day"
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_trainstation_06.bsp");

                    // Route Kanal
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_05.bsp");

                    // Water Hazard
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_10.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_canals_13.bsp");

                    // Black Mesa East
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_eli_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_eli_02.bsp");

                    // "We don't go to Ravenholm"
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_town_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_town_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_town_02a.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_town_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d1_town_05.bsp");

                    // Highway 17
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_07_p2.bsp");

                    // Sandtraps
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_10.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_coast_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_01.bsp");

                    // Nova Prospekt
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_05.bsp");

                    // Entanglement
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_06.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d2_prison_08.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_01.bsp");

                    // Anticitizen One
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_05.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_06a.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_06b.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_07.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_08.bsp");

                    // "Follow Freeman!"
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_09.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_10a.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_10b.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_11.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_12.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_12b.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_c17_13.bsp");

                    // Our Benefactors
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_citadel_01.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_citadel_02.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_citadel_03.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_citadel_04.bsp");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_citadel_05.bsp");

                    // Dark Energy
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/d3_breen_01.bsp");
                }
            }

            if(mapAddCheck.IsChecked == true)
            {
                MainWindow mainMenu = new MainWindow();
                if (mainMenu.branchComboSttgs.SelectedIndex == 0)
                {
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_canals_01.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_canals_01_underwater.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_03.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_04.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_05.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_06.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_canals_01.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_canals_01_underwater.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_trainstation_03.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_trainstation_04.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_trainstation_05.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "maps/mapadd/d1_trainstation_06.txt");
                }
                else if (mainMenu.branchComboSttgs.SelectedIndex == 1)
                {
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_canals_01.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_canals_01_underwater.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_03.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_04.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_05.txt");
                    File.Delete(Core.FCSModPath + "/maps/mapadd/d1_trainstation_06.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_canals_01.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_canals_01_underwater.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_trainstation_03.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_trainstation_04.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_trainstation_05.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "maps/mapadd/d1_trainstation_06.txt");
                }
            }

            if(engLocalCheck.IsChecked == true)
            {
                MainWindow mainMenu = new MainWindow();
                if (mainMenu.branchComboSttgs.SelectedIndex == 0)
                {
                    File.Delete(Core.FCSModPath + "/resource/fc_english.txt");
                    Git.Restore(true, Core.FCSModPath, "main", "resource/fc_english.txt");
                }
                else if (mainMenu.branchComboSttgs.SelectedIndex == 1)
                {
                    File.Delete(Core.FCSModPath + "/resource/fc_english.txt");
                    Git.Restore(true, Core.FCSModPath, "dev", "resource/fc_english.txt");
                }
            }

            MessageBox.Show("Successfully resetted Fortress Connected.\nSome of them might need to restart Steam, some of them don't need to.", "Reset Fortress Connected", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
