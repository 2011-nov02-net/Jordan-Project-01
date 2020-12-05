using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Order
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
            TransactionNumber = 9999;
        }
        public void addItem(Product item)
        {
            Items.Add(item);
        }

        public Order(int transactionNumber, int storeId, int CustomerId, string firstName, string lastName, string time)
        {
            TransactionNumber = transactionNumber;
            StoreId = storeId;
            
        }
        /// <summary>
        /// A cunstructor for orders taht are read
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="custFirstName"></param>
        /// <param name="custLastName"></param>
        /// <param name="time"></param>
        public Order(int storeId, int customerId, int transaction, string time)
        {
            StoreId = storeId;
            CustomerId = customerId;
            TransactionNumber = transaction;
            TimeStamp = time;

        }
        public int TransactionNumber { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public string TimeStamp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? TransactionTime { get; set; }
        public List<Product> Items = new List<Product>();


        //public virtual ICollection<ProductOrdered> Transaction { get; set; }
    }
}
