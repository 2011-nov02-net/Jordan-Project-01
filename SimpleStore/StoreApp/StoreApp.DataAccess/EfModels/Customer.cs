using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.EfModels
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
