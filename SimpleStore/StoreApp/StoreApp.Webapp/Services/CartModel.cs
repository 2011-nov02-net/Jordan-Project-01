using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Models
{
    public class CartModel
    {
        public int StoreId { get; set; }
        public int? customerid { get; set; }
        public int ProductId{get;set;}
        public int QuantityPurchase { get; set; }
        public CartModel(int _StoreId=0, int? _customerid=0, int _ProductId=0, int _QuantityPurchase=0)
        {
            StoreId = _StoreId;
            customerid = _customerid;
            ProductId = _ProductId;
            QuantityPurchase = _QuantityPurchase;
        }

        /// <summary>
        /// Tells the user they have a valid cart
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            return (StoreId != 0 & customerid != 0 & ProductId != 0 & QuantityPurchase != 0);
        }
        public string Jsonify()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// turns a json file into a cart
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public CartModel ReadJson(string jsonString)
        {
            // return nothing if null or empty
            if (String.IsNullOrEmpty(jsonString))
                return new CartModel();
            // return the cartlist if not null or empty
            return JsonSerializer.Deserialize<CartModel>(jsonString);
        }
    }
}
