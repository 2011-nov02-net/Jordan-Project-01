using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StoreApp.DataAccess.BusinessModels
{
    public class Store : IStore
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

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<IOrder> Orders { get; set; }
    }
}
