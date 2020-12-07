using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.Repositores;
using StoreApp.DataAccess.BusinessModels;

using StoreApp.Webapp.Models;
using Microsoft.AspNetCore.Http;

namespace StoreApp.Webapp.Controllers
{
    public class StoresController : Controller
    {
        private readonly IRepository _repository;

        public StoresController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Stores
        public async Task<IActionResult> Index(string searchString)
        {
            Database db = new Database(await _repository.GetAllStoresAsync());
            var stores = db.GetStoresByName(searchString);
            return View(stores);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel store)
        {
            if (ModelState.IsValid)
            {
                // add store to the context
                await _repository.AddStoreAsync(new DataAccess.BusinessModels.Store(store.Name, store.Street, store.State, store.City, store.Zip));
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int id=0)
        {
            var store = await _repository.FindStoreAsync(id);
            if (id==0|| store == null)
            {
                return NotFound();
            }
            return View(store );

        }
        public IActionResult History(int id = 1)
        {
            try
            {
                var store = _repository.GetOrderHistoryOfStore(id);
                return View(store);
            }
            catch
            {
                TempData["Message"] = "Please choose a Store you want to get the order history of.";
                return RedirectToAction("Index");
            }
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteStore(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
