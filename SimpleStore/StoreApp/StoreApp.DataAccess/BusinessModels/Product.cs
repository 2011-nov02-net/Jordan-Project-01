using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string Name { get; private set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public Product(int productID, string name, int quantity, double price)
        {
            ProductID = productID;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Clonining a product with a call to the quantity.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        public Product(Product item, int quantity)
        {
            this.ProductID = item.ProductID;
            this.Name = item.Name;
            this.Quantity = quantity;
            this.Price = item.Price;
        }
    }
}
