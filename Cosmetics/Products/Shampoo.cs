namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Common;
    
    class Shampoo : Product, IShampoo
    {

        private const string InvalidVolume = "Milliliters should be positive number!";
        private const string InvalidUsageType = "Invalid usage type!";  // an identical constant is defined as private in the Engine so it is not accessible 

        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            CalcTotalPrice();
        }
        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {               
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("price", InvalidVolume);
                else
                    this.milliliters = value;                                
            }
        }
        
        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                // There is a check for correct usage type in the engine, but just in case
                if (Enum.IsDefined(typeof(UsageType), value.ToString()))
                    this.usage = value;
                else
                    throw new ArgumentException(InvalidUsageType);
            }
            
        }

        private void CalcTotalPrice()
        {
            this.price *= this.Milliliters;
        }
        public override string Print()
        {
            string baseDisplay = base.Print();
            StringBuilder shampooDisplay = new StringBuilder();
            shampooDisplay.Append(baseDisplay);
            shampooDisplay.AppendLine(String.Format("  * Quantity: {0} ml", this.Milliliters));
            shampooDisplay.AppendLine(String.Format("  * Usage: {0}", this.Usage));

            return shampooDisplay.ToString().Trim();
        }
    }
}