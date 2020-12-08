using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.Repositores;
using StoreApp.Webapp.Models;

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
                int? customerid = HttpContext.Session.GetInt32("Customer");

                if (customerid == 0 || customerid==null)
                {
                    TempData["Messages"] = "User Not signed in";
                    TempData.Peek("Messages");
                    return Redirect("~/");
                }
                // create an array to be serialized later
                int[] cartmodel = { inventory.StoreId, (int)customerid, inventory.ProductId, inventory.QuantityPurchase};
                // join the array so we can pass it onto a temp cart
                var cart = String.Join(",", cartmodel);
                var tempCart = HttpContext.Session.GetString("Cart");

                // place the cart in the session
                if (String.IsNullOrEmpty(tempCart))
                {
                    HttpContext.Session.SetString("Cart", cart);
                }
                else
                {
                    HttpContext.Session.SetString("Cart", tempCart+ "|" +cart);
                }
                return RedirectToAction("Index", new { id = inventory.StoreId });
            }
            // catch anything we couldn't catch in the if statements
            catch
            {
                TempData["Messages"] = "Something went wrong";
                TempData.Peek("Messages");
                return Redirect("~/");

            }
        }

        }
}
