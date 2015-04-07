namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Common;


    // used to provide abstraction about all functionality that conncers storage of products
    public abstract class ProductContainer
    {
        protected IList<IProduct> productsContainer;

        protected ProductContainer()
        {
            this.productsContainer = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {

            Validator.CheckIfNull(product,
                string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.productsContainer.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product,
                 string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.productsContainer.Remove(product);
        }
    }
}
