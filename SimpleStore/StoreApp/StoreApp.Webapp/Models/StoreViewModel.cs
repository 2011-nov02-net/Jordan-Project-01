using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Webapp.Models
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
