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
        public List<Order> _customerOrders = new List<Order>();
        public List<Order> CustomerOrders => _customerOrders;

        public string getCustomer
        {
            get
            {
                return $"ID: {CustomerId} | First Name: {FirstName} | Last Name: {LastName} | Email: {Email} | Phone: {Phone}";
            }
        }
        public IEnumerable<Order> OrderEnumberable
        {
            get
            {
                List<Order> orders = CustomerOrders;
                return orders;
            }
        }
        public Customer(int customerId, string firstName, string lastName, string email, string phone)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
        public Customer(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public Customer(int id)
        {
            CustomerId = id;
        }
        public string PrintOrderHistory
        {
            get
            {
                string orderString = "";

                foreach (var order in CustomerOrders)
                {
                    orderString += order.ToString() +"\n";
                }
                if (CustomerOrders.Count == 0)
                {
                    return ("There are no Orders to be printed.");
                }
            return orderString;
            }
        }
    }
}