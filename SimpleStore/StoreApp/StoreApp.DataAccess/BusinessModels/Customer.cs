using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Customer
    {
        [Display(Name ="Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Phone")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public string Phone { get; set; }
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
        public Customer()
        {

        }

        public Customer(int id)
        {
            CustomerId = id;
        }
        public bool isValid()
        {
            if (CustomerId!=0)
            {
                return true;
            }
            return false;
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