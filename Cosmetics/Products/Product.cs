namespace Cosmetics.Products
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Common;

    public abstract class Product : IProduct
    {
        private const int MinimumProductNameLength = 3;
        private const int MaximumProductNameLength = 10;
        private const int MinimumBrandNameLength = 2;
        private const int MaximumBrandNameLength = 10;
        private const string InvalidPrice = "Price should be positive number!";
        private const string InvalidGenderType = "Invalid gender type!";  // an identical constant is defined as private in the Engine so it is not accessible 

        protected string name;
        protected string brand;
        protected GenderType gender;
        protected decimal price;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(value, MaximumProductNameLength, MinimumProductNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                        "Product name",
                        MinimumProductNameLength,
                        MaximumProductNameLength));
                name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(value, MaximumBrandNameLength, MinimumBrandNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                        "Product brand",
                        MinimumBrandNameLength,
                        MaximumBrandNameLength));   
                brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("price", InvalidPrice);
                else
                    this.price = value;                 
            }
        }

        public Common.GenderType Gender
        {
            get 
            {
                return this.gender;
            }
            set
            {
                // There is a check for correct gender type in the engine, but just in case
                if (Enum.IsDefined(typeof(GenderType), value.ToString()))
                    this.gender = value;
                else
                    throw new ArgumentException(InvalidGenderType);
            }
        }

        public virtual string Print()
        {
            StringBuilder productDisplay = new StringBuilder();
            // add header            
            productDisplay.AppendLine(String.Format("- {0} - {1}:",
                                         this.Brand,
                                         this.Name));
            // add details
            productDisplay.AppendLine(String.Format("  * Price: ${0}", this.Price));
            productDisplay.AppendLine(String.Format("  * For gender: {0}", this.Gender));

            return productDisplay.ToString();
        }
    }
}