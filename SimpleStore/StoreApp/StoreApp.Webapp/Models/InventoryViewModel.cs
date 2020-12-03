using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DataAccess.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Webapp.Models
{
    public class InventoryViewModel
    {
        [Required]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [Range(0, 20)]
        public int QuantityPurchase { get; set; }


        public InventoryViewModel() { }
        public InventoryViewModel(int id, Product item)
        {
            StoreId = id;
            ProductId = item.ProductID;
            Name = item.Name;
            Quantity = item.Quantity;
            Price = item.Price;
        }
        public InventoryViewModel(Store store)
        {
            StoreId = store.StoreId;
            StoreName = store.Name;
            ProductId = store.Inventory[0].ProductID;
            Name = store.Inventory[0].Name;
            Quantity = store.Inventory[0].Quantity;
            Price = store.Inventory[0].Price;
        }

    }
}
