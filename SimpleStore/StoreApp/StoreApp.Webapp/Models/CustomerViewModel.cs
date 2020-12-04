using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DataAccess.BusinessModels;

namespace StoreApp.Webapp.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomerViewModel(Customer e)
        {
            CustomerId = e.CustomerId;
            FirstName = e.FirstName;
            LastName = e.LastName;
            Email = e.Email;
            Phone = e.Phone;
        }

        public CustomerViewModel() { }

    }
}
