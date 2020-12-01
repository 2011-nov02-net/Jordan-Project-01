using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Order : IOrder
    {
        /// <summary>
        /// Create an Order, Every Order has a storeId and a customerId
        /// </summary>
        /// <param name="_storeId"></param>
        /// <param name="_customerId"></param>
        public Order(int _storeId, int _customerId)
        {
            StoreId = _storeId;
            CustomerId = _customerId;
        }
        public Order() { //do nothing}
        public int TransactionNumber { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? TransactionTime { get; set; }



        //public virtual ICollection<ProductOrdered> Transaction { get; set; }
    }
}
