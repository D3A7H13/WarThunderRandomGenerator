using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace WarThunderRandomGenerator
{
    public partial class AirBattles : Window
    {
        public MainWindow CreatingWindow { get; set; }
        public List<Vehicles> VehicleList = new List<Vehicles>();
        public AirBattles()
        {
            InitializeComponent();
            Loaded += AirBattlesLoaded;
        }

        private void AirBattlesLoaded(object sender, RoutedEventArgs e)
        {
            CreatingWindow.Close();
            string vehicles = File.ReadAllText("VehicleList.json");
            VehicleList = JsonConvert.DeserializeObject<List<Vehicles>>(vehicles);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}