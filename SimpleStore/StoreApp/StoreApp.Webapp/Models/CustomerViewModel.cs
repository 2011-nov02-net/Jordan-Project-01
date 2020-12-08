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
        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]

        [Display(Name = "Last Name :")]
        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
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
