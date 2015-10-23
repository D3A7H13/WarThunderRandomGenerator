using System;
using System.Linq;
using System.Windows.Media;

namespace WarThunderRandomGenerator
{
    public class Vehicles
    {
        public Vehicles(string fullName, string country, int tier, string vType)
        {
            this.ImagePath = new Uri($"pack://application:,,,/Images/{vType}/{fullName}");
            this.VehicleType = vType;
            this.Country = country;
            this.Tier = tier;
            this.Premium = SetPremium(fullName);
            this.VehicleClass = SetVehicleClass(fullName);
            this.PlaneName = SetName(fullName);
        }

        private string SetVehicleClass(string fullName)
        {
            if (fullName.Contains("(Fighter)"))
            {
                return "Figter";
            }
            else if (fullName.Contains("(Attacker)"))
            {
                return "Attacker";
            }
            else
            {
                return "Bomber";
            }
        }

        static private string SetName(string fullName)
        {
            int fileExtPos = fullName.IndexOf("(") - 1;
            string name = string.Empty;

            if (fileExtPos >= 0)
            {
                name = fullName.Substring(0, fileExtPos);
            }

            return name;
        }

        private bool SetPremium(string fullName)
        {
            bool isPrem;

            if (fullName.Contains("(Prem)"))
            {
                isPrem = true;
                this.PremiumLabel = "Premium";
            }
            else
            {
                isPrem = false;
                this.PremiumLabel = string.Empty;
            }
            return isPrem;
        }

        //public double BattleRating { get; set; }
        public int Tier { get; set; }
        public string Country { get; set; }
        public bool Premium { get; set; }
        public string PremiumLabel { get; set; }
        public Uri ImagePath { get; set; }
        public string PlaneName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleClass { get; set; }

        public override string ToString()
        {
            return ($"{this.PlaneName} Tier {this.Tier} {this.Country} {this.PremiumLabel}");
        }
    }
}
