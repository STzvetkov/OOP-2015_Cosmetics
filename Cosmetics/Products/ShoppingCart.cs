namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Common;

    class ShoppingCart:ProductContainer, IShoppingCart
    {
        public ShoppingCart():base()
        {

        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(product,
                string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            return this.productsContainer.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in this.productsContainer)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
