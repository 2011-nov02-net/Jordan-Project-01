using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.Repositores;
using StoreApp.Webapp.Models;
using StoreApp.Webapp.Services;

namespace StoreApp.Webapp.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly IRepository _repository;
        public InventoriesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Inventories/Index/1
        public IActionResult Index(int id)
        {
            var inventory = _repository.GetAllProducts(id);
            List<InventoryViewModel> p = new List<InventoryViewModel>();
            foreach(var item in inventory.Inventory)
            {
                p.Add(new InventoryViewModel(id, item));
            }
            return View(p);
        }

        public async Task<IActionResult> Add(int store, int product)
        {
            var StoreGotten = await _repository.GetProductAsync(store, product);

            InventoryViewModel model = new InventoryViewModel(StoreGotten);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(InventoryViewModel inventory)
        {
            try
            {
                // get the values of what's in session
                int? customerid = HttpContext.Session.GetInt32("Customer");
                var tempCart = HttpContext.Session.GetString("Cart");

                // make a cart
                var cart2 = new CartModel(inventory.StoreId, customerid, inventory.ProductId, inventory.QuantityPurchase);

                CartList cartlist = new CartList();

                if (!String.IsNullOrEmpty(tempCart))
                    cartlist = (CartList)JsonConvert.DeserializeObject(tempCart);

                cartlist.Cart.Add(cart2);

                string cartString = JsonConvert.SerializeObject(cartlist);
                // if our cart is valid set the strings
                if (cart2.Valid())
                {
                    HttpContext.Session.SetString("Cart", cartString);
                }
                else
                {
                    HttpContext.Session.SetString("Cart", tempCart+ cartString);
                }
                return RedirectToAction("Index", new { id = inventory.StoreId });
            }
            catch
            {
                TempData["Messages"] = "User Not signed in";
                TempData.Peek("Messages");
                return Redirect("~/");

            }
        }

        }
}
