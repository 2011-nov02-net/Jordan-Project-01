using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.DataAccess.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Webapp.Models
{
    public class CustomerViewModel
    {
        [Display(Name="Customer ID:")]
        public int CustomerId { get; set; }
        [Display(Name = "First Name:")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name :")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
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
