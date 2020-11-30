using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.EfModels
{
    public partial class Store
    {
        public Store()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
