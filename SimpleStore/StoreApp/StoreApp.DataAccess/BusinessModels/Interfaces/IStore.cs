using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public interface IStore
    {
        string City { get; set; }
        string Name { get; set; }
        ICollection<IOrder> Orders { get; set; }
        string State { get; set; }
        int StoreId { get; set; }
        string Street { get; set; }
        string Zip { get; set; }

        bool isValid();
    }
}