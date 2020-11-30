using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        ICollection<IOrder> CustomerOrders { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
    }
}