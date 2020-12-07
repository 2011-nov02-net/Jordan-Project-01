using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using StoreApp.Webapp.Models;

namespace StoreApp.Webapp.Services
{
    public class CartList
    {
        // create a list for our carts
        private List<CartModel> _cart = new List<CartModel>();
        public List<CartModel> Cart { get { return _cart; } set { _cart = value; } }

    }
}
