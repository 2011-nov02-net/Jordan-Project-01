using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DataAccess.Repositores;
using StoreApp.DataAccess.BusinessModels;
using StoreApp.Webapp.Models;

namespace StoreApp.Webapp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository _repository;

        public CustomersController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: CustomersController
        public async Task<ActionResult> IndexAsync(string searchString)
        {
            Database db = new Database(await _repository.GetAllCustomersAsync());
            var customers = db.GetCustomerByName(searchString);
            List<CustomerViewModel> model_customers = new List<CustomerViewModel>();
            foreach(var customer in customers)
            {
                model_customers.Add(new CustomerViewModel(customer));
            }
            return View(model_customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult SignIn(int customerid, string name)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                HttpContext.Session.SetString("Name", name);
                HttpContext.Session.SetInt32("Customer", customerid);
            }
            var Name = HttpContext.Session.GetString("Name");
            var Age = HttpContext.Session.GetInt32("Customer");
            return Redirect("~/");
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerViewModel customer)
        {
            try
            {
                await _repository.AddCustomer(new DataAccess.BusinessModels.Customer(customer.FirstName, customer.LastName, customer.Email, customer.Phone));
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
