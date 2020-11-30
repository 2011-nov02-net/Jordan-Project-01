using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.EfModels
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Prices = new HashSet<Price>();
            ProductOrdereds = new HashSet<ProductOrdered>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductOrdered> ProductOrdereds { get; set; }
    }
}
