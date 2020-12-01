using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public interface IDatabase
    {
        List<ICustomer> Customers { get; set; }
        List<IStore> Stores { get; set; }
        public void addStore(IStore store);
        int CustomerCount();
        ICustomer GetCustomerById(int id);
        IStore GetStoreById(int id);
        int StoreCount();
    }
}