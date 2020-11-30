using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.EfModels
{
    public partial class ProductOrdered
    {
        public int TransactionNumber { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual CustomerOrder TransactionNumberNavigation { get; set; }
    }
}
