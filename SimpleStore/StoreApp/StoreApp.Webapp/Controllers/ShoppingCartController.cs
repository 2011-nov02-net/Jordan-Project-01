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
            String cartItems = "";
            // grab the data from the cart
            try
            {
                if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Cart")))
                    cartItems = HttpContext.Session.GetString("Cart");
            }
            catch
            {
                TempData["Message"] = "Cart Is Empty";

            }
            // grab the data and unserialize it.
            var data = new Serialize(cartItems, _repository);
            try
            {
                //DataAccess.BusinessModels.Database db = new DataAccess.BusinessModels.Database(new Store(data.SerializedOrder));
                _repository.AddCustomerOrder(data.SerializedOrder);

            }
            catch
            {
                TempData["Message"] = "Something went wrong";
            }
            // log the user out and empty cart
            HttpContext.Session.SetString("Name", "");
            HttpContext.Session.SetString("Cart", "");

            return Redirect("~/");
        }

    }
}
