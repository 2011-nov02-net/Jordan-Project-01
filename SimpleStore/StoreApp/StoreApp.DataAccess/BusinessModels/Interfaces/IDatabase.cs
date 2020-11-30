using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public interface IDatabase
    {
        ICollection<ICustomer> Customers { get; set; }
        ICollection<IStore> Stores { get; set; }

        int CustomerCount();
        ICustomer GetCustomerById(int id);
        IStore GetStoreById(int id);
        int StoreCount();
    }
}