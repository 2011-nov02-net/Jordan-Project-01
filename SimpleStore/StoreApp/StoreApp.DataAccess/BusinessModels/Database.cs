using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Database
    {
        public ICollection<Customer> Customers { get; set; }
        public List<Store> Stores { get; set; }

        public Database()
        {
            /* Do Nothing*/
        }
        public Database(List<Store> stores)
        {
            Stores = stores;
        }

        /// <summary>
        /// Initialize a Database with a Customer
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="stores"></param>
        public Database(ICollection<Customer> customers, List<Store> stores)
        {
            Customers = customers;
            Stores = stores;
        }
        /// <summary>
        /// return customer by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int id) => Customers.FirstOrDefault(x => x.CustomerId == id);
        /// <summary>
        /// return store by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Store GetStoreById(int id) => Stores.FirstOrDefault(x => x.StoreId == id);
        /// <summary>
        /// Get a list of stores by a search string.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<Store> GetStoresByName(string searchString)
        {
            List<Store> _stores = new List<Store>();
            if (!String.IsNullOrEmpty(searchString))
            {
                var p = from store in Stores
                        where store.Name.Contains(searchString)
                        select store;
                _stores = p.ToList();
                return _stores;
            }
            return Stores;
        }
    /// <summary>
    /// Returns the amount of stores in the database
    /// </summary>
    public int StoreCount() => Stores.Count();
        /// <summary>
        /// Returns the amount of Customers in the database
        /// </summary>
        /// <returns></returns>
        public int CustomerCount() => Customers.Count();
       
        
    }
}