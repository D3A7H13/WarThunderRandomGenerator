using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WarThunderRandomGenerator
{
    public partial class AirBattles : Window
    {
        public MainWindow CreatingWindow { get; set; }

        public AirBattles()
        {
            InitializeComponent();
            Loaded += AirBattlesLoaded;
        }

        private void AirBattlesLoaded(object sender, RoutedEventArgs e)
        {
            CreatingWindow.Close();
            List<Vehicle> planes = new List<Vehicle>();
            
        }
    }
}