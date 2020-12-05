using StoreApp.DataAccess.BusinessModels;
using StoreApp.DataAccess.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Services
{
    public class Serialize
    {

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public Order order { get; set; }
        public Serialize(string productInfoArray, IRepository repository) 
        {
            string[] productInfo = productInfoArray.Split('|');
            foreach(var item in productInfo)
            {
                var info = item.Split(",");
                var store = repository.GetProduct(Int32.Parse(info[0]), Int32.Parse(info[2]));
                order.Items.Add(new Product(store.Inventory[0], Quantity= Int32.Parse(info[3])));
                order.CustomerId = Int32.Parse(info[1]);

            }
        }
    }
}
