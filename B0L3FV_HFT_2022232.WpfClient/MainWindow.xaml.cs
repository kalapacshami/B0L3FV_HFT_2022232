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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace B0L3FV_HFT_2022232.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ClickAVGMission(object sender, RoutedEventArgs e)
        {
            AVGMissionWindow aVGMissionWindow = new AVGMissionWindow();
            aVGMissionWindow.ShowDialog();           

        }

        private void Button_Click_MissionStatus(object sender, RoutedEventArgs e)
        {
            MissionStatusWindow missionStatusWindow = new MissionStatusWindow();
            missionStatusWindow.ShowDialog();
        }

        private void Button_Click_AVGWork(object sender, RoutedEventArgs e)
        {
            AVGWorkWindow aVGWorkWindow = new AVGWorkWindow();
            aVGWorkWindow.ShowDialog();
        }

        private void Button_Click_AVGGoblin(object sender, RoutedEventArgs e)
        {
            AVGGoblinWindow aVGGoblinWindow = new AVGGoblinWindow();
            aVGGoblinWindow.ShowDialog();
        }

        private void Button_Click_KillCounts(object sender, RoutedEventArgs e)
        {
            KillCountWindow killCountWindow = new KillCountWindow();
            killCountWindow.ShowDialog();
        }
    }
}
