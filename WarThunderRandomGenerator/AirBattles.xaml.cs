using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

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
            ReadFile(new string[] {"Aircraft"});

        }

        private void ReadFile(string[] vTypes)
        {
            List<string> lines = new List<string>();
            try
            {
                for (int i = 0; i < vTypes.Length; i++)
                {
                    using (StreamReader sr = new StreamReader($"{vTypes[i]}.txt"))
                    {
                        String line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                    LoadVehicles(lines, vTypes[i]);
                }
            }
            catch (Exception o)
            {
                MessageBox.Show("Unable to read from the RNG files. Please send this error to D3A7H -> \n" + o.Message);
            }

        }

        private void LoadVehicles(List<string> lines, string vType)
        {
            int x = -1, y = 0, z = 0;
            string[] countries = new string[] {"USA", "Germany", "USSR", "Britain", "Japan"};

            foreach (string line in lines)
            {
                if (line.Equals("USA") || line.Equals("Germany") || line.Equals("USSR") || line.Equals("Britain") || line.Equals("Japan"))
                {
                    x++;
                    y = 0;
                    continue;
                }
                else if (line.Contains("Tier 1") || line.Contains("Tier 2") || line.Contains("Tier 3") || line.Contains("Tier 4") || line.Contains("Tier 5"))
                {
                    y++;
                    z = 0;
                }
                else
                {
                    VehicleList.Add(new Vehicles(line, countries[x], y, vType));
                    z++;
                }
            }
        }
    }
}