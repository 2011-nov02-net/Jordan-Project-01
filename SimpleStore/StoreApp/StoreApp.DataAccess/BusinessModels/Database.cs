using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Database : IDatabase
    {
        public List<ICustomer> Customers { get; set; }
        public List<IStore> Stores { get; set; }

        public Database()
        {
            /* Do Nothing*/
        }

        /// <summary>
        /// Initialize a Database with a Customer
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="stores"></param>
        public Database(List<ICustomer> customers, List<IStore> stores)
        {
            Customers = customers;
            Stores = stores;
        }
        public void addStore(IStore store)
        {
            Stores.Add(store);
        }

        /// <summary>
        /// return customer by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICustomer GetCustomerById(int id) => Customers.FirstOrDefault(x => x.CustomerId == id);

        /// <summary>
        /// return store by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IStore GetStoreById(int id) => Stores.FirstOrDefault(x => x.StoreId == id);

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