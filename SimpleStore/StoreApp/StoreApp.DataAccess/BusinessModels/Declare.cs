using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Declare
    {
        public static IStore CreateStore()
        {
            return new Store();
        }

        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }
        public static IDatabase CreateDatabase()
        {
            return new Database();
        }
        public static IOrder CreateOrder()
        {
            return new Order();
        }
    }
}
