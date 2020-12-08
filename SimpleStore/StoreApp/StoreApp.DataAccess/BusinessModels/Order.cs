using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        public Order(int transactionNumber, int storeId, int customerId, string firstName, string lastName, string time)
        {
            TransactionNumber = transactionNumber;
            StoreId = storeId;
            TimeStamp = time;
            FirstName = firstName;
            LastName = lastName;
            CustomerId = CustomerId;
            
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
        public Order()
        {
            // do nothing //
        }
        public int TransactionNumber { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public string TimeStamp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TransactionTime { get; set; }
        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                double _cost = 0;
                foreach (Product item in Items)
                {
                    _cost += item.Price * item.Quantity;
                }
                return _cost;
            }
        }
        public List<Product> _items = new List<Product>();
        public List<Product> Items { get
            {
                return _items;
            }
        }
        public IEnumerable<Product> EnumerableItems
        {
            get
            {
                return Items;
            }
        }

        public string Info
        {
            get
            {
                string data = "";
                data = $"Store: {StoreId} | Transaction Number: {TransactionNumber} | Time {TimeStamp} ";
                foreach (var item in Items)
                {
                    data += "\n    " + item.ToString();
                }
                return data;
            }
        }
    }
}
