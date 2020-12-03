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
        public Store(int _storeId, string _name)
        {
            StoreId = _storeId;
            Name = _name;
        }
        /// <summary>
        /// Returns a true if all the required files are in the database.
        /// </summary>
        /// <returns></returns>
        public bool isValid()
        {
            // if the string is empty return false
            if (String.IsNullOrEmpty(Name) || StoreId == 0)
                return false;

            // otherwise return true
            return true;
        }
        public void AddInventory(Product product)
        {
            Inventory.Add(product);
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        private List<Product>_inventory = new List<Product>();


        public List<Product> Inventory
        {
            get {
                return _inventory;
            }
            set {
                Inventory = value;
            }
        }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
