using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.Repositores;
using StoreApp.DataAccess.BusinessModels;
using StoreApp.Webapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRepository _repository;

        public ShoppingCartController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            // grab all the items from the cart
            String cartItems = HttpContext.Session.GetString("Cart");
            // grab the data and unserialize it.
            var data = new Serialize(cartItems, _repository);
                return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout()
        {
            // grab the data from the cart
            String cartItems = HttpContext.Session.GetString("Cart");
            // grab the data and unserialize it.
            var data = new Serialize(cartItems, _repository);
            DataAccess.BusinessModels.Database db = new DataAccess.BusinessModels.Database(new Store(data.StoreId)) ;
            _repository.AddCustomerOrder(db);

            HttpContext.Session.SetString("Name", "");
            HttpContext.Session.SetString("Cart", "");

            return Redirect("~/");
        }

    }
}
