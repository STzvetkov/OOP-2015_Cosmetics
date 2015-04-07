namespace Cosmetics.Products
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Common;

    class Category:ProductContainer, ICategory
    {
        private const int MinimumNameLength = 2;
        private const int MaximumNameLength = 15;
        private const string ProductDoesNotExist = "Product {0} does not exist in category {1}!";

        private string name;

        public Category(string name)
            :base()
        {
            this.Name = name;            
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));               
                Validator.CheckIfStringLengthIsValid(value, MaximumNameLength, MinimumNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                        "Category name",
                        MinimumNameLength,
                        MaximumNameLength));
                name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            base.AddProduct(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            try
            {
                base.RemoveProduct(cosmetics);
            }
            catch (ArgumentException)  // check for existence is specific for Category
            {
                throw new ArgumentException(string.Format(ProductDoesNotExist, cosmetics.Name, this.name));
            }
            
        }

        public string Print()
        {
            // sorts products before displaying them
            var sortedProducts = this.productsContainer.OrderBy(f => f.Brand).ThenByDescending(f => f.Price);

            StringBuilder categoryDisplay = new StringBuilder();
            // add header            
            categoryDisplay.AppendLine(String.Format("{0} category - {1} {2} in total",
                                         this.Name,
                                         this.productsContainer.Count,
                                         this.productsContainer.Count == 1 ? "product" : "products"));
            // add info for each product
            foreach (var product in sortedProducts)
            {
                categoryDisplay.AppendLine(product.Print());
            }

            return categoryDisplay.ToString().Trim();
        }
    }
}