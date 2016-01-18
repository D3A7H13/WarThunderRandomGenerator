using System;

namespace WarThunderRandomGenerator
{
    public class Vehicle
    {
        private int tier;
        private string country;
        private bool premium;
        private string premiumLabel;
        private Uri imagePath;
        private string vehicleName;
        private string vehicleType;
        private string vehicleClass;

        public Vehicle(string fullName, string country, int tier, string vType)
        {
            this.ImagePath = new Uri($"pack://application:,,,/Images/{vType}/{fullName}");
            this.VehicleType = vType;
            this.Country = country;
            this.Tier = tier;
            this.Premium = GetPremium(fullName);
            this.VehicleClass = GetVehicleClass(fullName);
            this.VehicleName = GetName(fullName);
        }

        public Vehicle() { }

        //public double BattleRating { get; set; }

        public int Tier
        {
            get { return this.tier; }
            set { this.tier = value; }
        }

        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        public bool Premium
        {
            get { return this.premium; }
            set { this.premium = value; }
        }

        public string PremiumLabel
        {
            get { return this.premiumLabel; }
            set { this.premiumLabel = value; }
        }

        public Uri ImagePath
        {
            get { return this.imagePath; }
            set { this.imagePath = value; }
        }

        public string VehicleName
        {
            get { return this.vehicleName; }
            set { this.vehicleName = value; }
        }

        public string VehicleType
        {
            get { return this.vehicleType; }
            set { this.vehicleType = value; }
        }

        public string VehicleClass
        {
            get { return this.vehicleClass; }
            set { this.vehicleClass = value; }
        }

        private string GetVehicleClass(string fullName)
        {
            if (fullName.Contains("(Fighter)"))
            {
                return "Fighter";
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

        private string GetName(string fullName)
        {
            int fileExtPos = fullName.IndexOf("(") - 1;
            string name = string.Empty;

            if (fileExtPos >= 0)
            {
                name = fullName.Substring(0, fileExtPos);
            }

            return name;
        }

        private bool GetPremium(string fullName)
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

        public override string ToString()
        {
            return ($"{this.VehicleName} Tier {this.Tier} {this.Country} {this.PremiumLabel}");
        }
    }
}