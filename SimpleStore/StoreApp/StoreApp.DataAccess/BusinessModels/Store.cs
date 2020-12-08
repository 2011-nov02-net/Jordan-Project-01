using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StoreApp.DataAccess.BusinessModels
{
    public class Store
    {

        /// <summary>
        /// Initialize a store with given parameters. A store must have an Id and a name
        /// </summary>
        /// <param name="_storeId"></param>
        /// <param name="_name"></param>
        /// <param name="_street"></param>
        /// <param name="_state"></param>
        /// <param name="_city"></param>
        /// <param name="_zip"></param>
        public Store(int _storeId, string _name, string _street = "", string _state = "", string _city = "", string _zip = "")
        {
            StoreId = _storeId;
            Name = _name;
            State = _state;
            Street = _street;
            City = _city;
            Zip = _zip;
        }
        public Store(string _name, string _street = "", string _state = "", string _city = "", string _zip = "")
        {
            Name = _name;
            State = _state;
            Street = _street;
            City = _city;
            Zip = _zip;
        }
        public Store(int storeId, string _name)
        {
            StoreId = storeId;
            Name = _name;
        }
        public Store(int storeId)
        {
            StoreId = storeId;
        }
        public Store()
        { }
        /// <summary>
        /// Returns a true if all the required files are in the database.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            // if the string is empty return false
            return !String.IsNullOrEmpty(Name) && StoreId != 0;
        }
        public void AddInventory(Product product)
        {
            Inventory.Add(product);
        }
        [Display(Name="Store Id")]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        private List<Product> _inventory = new List<Product>();


        public List<Product> Inventory
        {
            get {
                return _inventory;
            }
            set {
                Inventory = value;
            }
        }
        public List<Order> _orders = new List<Order>();

        public List<Order> Orders
        {
            get 
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }
        // use this is we want to use our orders in a view
        public IEnumerable<Order> OrderEnumerable => _orders;
    }
}
