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
        public async Task<ActionResult> Index(string searchString)
        {
            // get all customers from teh database
            Database db = new Database(await _repository.GetAllCustomersAsync());
            var customers = db.GetCustomerByName(searchString);
            // creeate a new set of customers
            List<CustomerViewModel> model_customers = new List<CustomerViewModel>();
            // add the customer to a list of customers
            foreach(var customer in customers)
            {
                model_customers.Add(new CustomerViewModel(customer));
            }
            // send the customers to the database
            return View(model_customers);
        }

        // GET: CustomersController/SignIn/
        public ActionResult SignIn(int customerid, string name)
        {
            // set the customer id for session
            HttpContext.Session.SetInt32("Customer", customerid);
            HttpContext.Session.SetString("Name", name);

            // after sign in send them back to the home screen
            return Redirect("~/");
        }
        public ActionResult HistoryDetails(int id)
        {
            Order order = _repository.GetOrder(id).Stores[0].Orders[0];
            return View(order);
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/History
        public ActionResult History()
        {
            try
            {
                int customerId = (int)HttpContext.Session.GetInt32("Customer");
                Customer customer = _repository.GetOrderHistoryOfCustomer(customerId);
                return View(customer);
            }
            catch
            {
                TempData["Message"] = "Please choose a customer you want to get the order history of.";
                return RedirectToAction("Index");
            }
        }
        

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = new CustomerViewModel(await _repository.FindCustomer(id));
            if (id == 0 || model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _repository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
