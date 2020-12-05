using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.Repositores;
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
            String cartItems = HttpContext.Session.GetString("Cart");
            var data = new Serialize(cartItems, _repository);
                return View(data);
        }
    }
}
