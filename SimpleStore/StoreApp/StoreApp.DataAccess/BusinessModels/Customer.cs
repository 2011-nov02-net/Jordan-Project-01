using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<IOrder> CustomerOrders { get; set; }
    }
}