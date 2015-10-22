using System;

namespace WarThunderRandomGenerator
{
    class Vehicle
    {
        public Vehicle(string fullName, string country, int tier, string vType)
        {
            this.ImagePath = new Uri($"pack://application:,,,/Images/{vType}/{fullName}");
            this.VehicleType = vType;
            this.Country = country;
            this.Tier = tier;
            this.Premium = IsPremium(fullName);
            this.PlaneName = GetName(fullName);
        }

        static private string GetName(string fullName)
        {
            int fileExtPos = fullName.LastIndexOf(".");
            string name = string.Empty;

            if (fileExtPos >= 0)
            {
                name = fullName.Substring(0, fileExtPos);
            }

            return name;
        }

        private bool IsPremium(string fullName)
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

    }
}
