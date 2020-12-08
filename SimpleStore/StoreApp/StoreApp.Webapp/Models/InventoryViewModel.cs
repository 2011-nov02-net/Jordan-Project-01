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
        [Display(Name="Store ID")]
        public int StoreId { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Display(Name = "Product ID")]

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(1, 20, ErrorMessage ="Need to order at least one and Cant have more than 20")]
        [Display(Name = "Quanity Purchasing")]
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
    public class QuantityCheck : Attribute
    {
        public bool check { get; set; }
    }

}
