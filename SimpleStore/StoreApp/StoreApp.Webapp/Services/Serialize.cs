using StoreApp.DataAccess.BusinessModels;
using StoreApp.DataAccess.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StoreApp.Webapp.Services
{
    public class Serialize
    {
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public Order _order = new Order();
        public Order SerializedOrder {
            get
            {
                return _order;
            }
        }
        [DataType(DataType.Currency)]
        public double Cost { 
            get
            {
                double _cost = 0;
                foreach (Product item in SerializedOrder.Items)
                {
                    _cost += item.Price * item.Quantity;
                }
                return _cost;
            } 
        }
        public Serialize(string productInfoArray, IRepository repository)
        {
            if (!String.IsNullOrEmpty(productInfoArray)) { 
            // split the array by the key letter
            string[] productInfo = productInfoArray.Split('|');
                for(int i =0; i< productInfo.Length; i++)
                {

                    var info = productInfo[i].Split(",");
                    
                    // set the parsed info to the corresponding values
                    int _storeId = Int32.Parse(info[0]);
                    int _customerId = Int32.Parse(info[1]);
                    int ProductId = Int32.Parse(info[2]);
                    int Quantity = Int32.Parse(info[3]);

                    // get store information
                    var store = repository.GetProduct(_storeId, ProductId);

                    // get product inventory 
                    var product = store.Inventory[0];
                    product.Quantity = Quantity;

                    // add item to the serialized order
                    SerializedOrder.addItem(product);
                    SerializedOrder.CustomerId = _customerId;

                    // set the property while we're at it.
                    if (i == 0)
                    {
                        StoreId = _storeId;
                        CustomerId = _customerId;

                        SerializedOrder.StoreId = StoreId;
                        SerializedOrder.CustomerId = CustomerId;
                    }
                }
            }
        }
        public IEnumerable<Product> OrderEnumberable
        {
            get
            {
                List<Product> products = SerializedOrder.Items;
                return products;
            }
        }
    }
}