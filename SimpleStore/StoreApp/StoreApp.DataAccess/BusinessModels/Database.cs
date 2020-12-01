using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Database : IDatabase
    {
        public ICollection<Customer> Customers { get; set; }
        public ICollection<IStore> Stores { get; set; }

        public Database()
        {
            /* Do Nothing*/
        }

        /// <summary>
        /// Initialize a Database with a Customer
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="stores"></param>
        public Database(ICollection<Customer> customers, ICollection<IStore> stores)
        {
            Customers = customers;
            IStores = stores;
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
        /// Returns the amount of stores in the database
        /// </summary>
        public int StoreCount() => IStores.Count();

        /// <summary>
        /// Returns the amount of Customers in the database
        /// </summary>
        /// <returns></returns>
        public int CustomerCount() => ICustomers.Count();
    }
}