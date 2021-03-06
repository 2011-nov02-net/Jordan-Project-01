﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Models
{
    public class StoreViewModel
    {
        [Display(Name="Store ID")]
        public int StoreId { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }

        public StoreViewModel(StoreApp.DataAccess.BusinessModels.Store store)
        {
            StoreId = store.StoreId;
            Name = store.Name;
            Street = store.Street;
            City = store.City;
            State = store.State;
            Zip = store.Zip;
        }
    }
}
