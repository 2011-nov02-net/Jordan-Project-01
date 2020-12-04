using System.Collections.Generic;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Customer(int customerId, string firstName, string lastName, string email, string phone)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
        public Customer(string firstName, string lastName, string email, string phone) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public Customer()
        {
            // do nothing
        }

        public virtual ICollection<Order> CustomerOrders { get; set; }
    }
}