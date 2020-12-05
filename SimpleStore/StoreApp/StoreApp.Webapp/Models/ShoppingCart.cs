using StoreApp.DataAccess.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Models
{
    public class ShoppingCart
    {
        public int ProductID { get; private set; }
        public string Name { get; private set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        ShoppingCart(Product product) {
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
        }
    }
}
