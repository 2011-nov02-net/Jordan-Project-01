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
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllStoresAsync());
        }
        
        // GET: Stores/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var store = await _context.Stores
        //        .FirstOrDefaultAsync(m => m.StoreId == id);
        //    if (store == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(store);
        //}

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

        //// GET: Stores/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var store = await _context.Stores.FindAsync(id);
        //    if (store == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(store);
        //}

        //// POST: Stores/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("StoreId,Name,Street,State,City,Zip")] Store store)
        //{
        //    if (id != store.StoreId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(store);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StoreExists(store.StoreId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(store);
        //}

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int id=0)
        {
            var store = await _repository.FindStore(id);
            if (id==0|| store == null)
            {
                return NotFound();
            }
            return View(store );

        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteStore(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool StoreExists(int id)
        //{
        //    return _context.Stores.Any(e => e.StoreId == id);
        //}
        //        */

    }
}
