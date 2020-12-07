using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DataAccess;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.BusinessModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StoreApp.DataAccess.Repositores
{
    public class StoreRepository : IRepository
    {
        private readonly StoreDBContext _context;
        private readonly ILogger _logger;

        public StoreRepository(StoreDBContext context, ILoggerFactory logFactor)
        {
            _context = context;
        }
        /// <summary>
        /// Connect to the database and grab tables
        /// </summary>
        /// <returns>a Task List of Business Models</returns>
        public async Task<List<BusinessModels.Store>> GetAllStoresAsync()
        {
            // query from DB to async
            var entity = await _context.Stores.ToListAsync();
            var table = entity.Select(e => new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip)).ToList();
            return table;
        }
        /// <summary>
        /// Connect to the database and grab tables.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessModels.Store> GetAllStores()
        {
            // query from DB
            List<EfModels.Store> entities = _context.Stores.ToList();

            return entities.Select(e => new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip));
        }
        async Task IRepository.AddStoreAsync(BusinessModels.Store store)
        {
            EfModels.Store newStore = new EfModels.Store()
            {
                Name = store.Name,
                State = store.State,
                Street = store.Street,
                City = store.City,
                Zip = store.Zip
            };
            await _context.AddAsync(newStore);
            await _context.SaveChangesAsync();
        }
        async Task IRepository.AddCustomer(BusinessModels.Customer customer)
        {
            // pass in all the values of customer and place them in.
            EfModels.Customer newCustomer = new EfModels.Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };

            // add customer to context
            await _context.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
        }
        public async Task<BusinessModels.Store> FindStoreAsync(int StoreId)
        {
            EfModels.Store e = await _context.Stores.FindAsync(StoreId);
            return new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip);
        }
        public BusinessModels.Store FindStore(int StoreId)
        {
            EfModels.Store e =  _context.Stores.Find(StoreId);
            return new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip);
        }
        async Task IRepository.DeleteStore(int StoreId)
        {
            EfModels.Store store = await _context.Stores.FindAsync(StoreId);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

        }

        async Task<List<BusinessModels.Customer>> IRepository.GetAllCustomersAsync()
        {
            //var entity = await _context.Stores.ToListAsync();
            //var table = entity.Select(e => new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip)).ToList();
            //return table;
            // query from DB
            List<EfModels.Customer> entities = await _context.Customers.ToListAsync();
            var table = entities.Select(e => new BusinessModels.Customer(e.CustomerId, e.FirstName, e.LastName, e.Email, e.Phone)).ToList();
            return table;
        }

        async Task<BusinessModels.Customer> IRepository.FindCustomer(int CustomerId)
        {
            EfModels.Customer e = await _context.Customers.FindAsync(CustomerId);
            return new BusinessModels.Customer(e.CustomerId , e.FirstName, e.LastName, e.Email, e.Phone);
        }
        async Task IRepository.DeleteCustomer(int CustomerId)
        {
            EfModels.Customer store = await _context.Customers.FindAsync(CustomerId);
            _context.Customers.Remove(store);
            await _context.SaveChangesAsync();
        }





        void IRepository.RemoveCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        Task<List<BusinessModels.Product>> IRepository.GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }


        void IRepository.AddProduct(BusinessModels.Product product)
        {
            throw new NotImplementedException();
        }

        void IRepository.RemoveProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IRepository.GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IRepository.GetAllOrders()
        {
            throw new NotImplementedException();
        }

        void IRepository.AddProduct(Order product)
        {
            throw new NotImplementedException();
        }

        void IRepository.RemoveOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessModels.Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        BusinessModels.Store IRepository.GetAllProducts(int id)
        {
            var dbInventory = _context.Inventories.Include(i => i.Product).ThenInclude(i => i.Prices);

            var store = new BusinessModels.Store(id, "Walmart");

            foreach (var inventory in dbInventory)
            {
                // wont let me do .First i'll have to ask nick why
                if (inventory.StoreId == id)
                {
                    // turn the price datatype to a list
                    var PriceList = inventory.Product.Prices.ToList();
                    // should grab the newest price in price list
                    var price = PriceList[PriceList.Count - 1].Price1;
                    // add to the Inventory class
                    store.AddInventory(new BusinessModels.Product(inventory.Product.ProductId, inventory.Product.Name, (int)inventory.Quantity, (double)price));
                }
            }

            return store;
        }

        async Task<BusinessModels.Store> IRepository.GetProductAsync(int StoreId, int ProductId)
        {
            {
                // get the store id
                var store = await FindStoreAsync(StoreId);
                var dbInventory = await _context.Inventories.Include(i => i.Product).ThenInclude(i => i.Prices).FirstOrDefaultAsync(i => i.StoreId == StoreId && i.ProductId==ProductId);
                var price = dbInventory.Product.Prices;
                var list = price.ToList();
                decimal cost = list[0].Price1;
                store.Inventory.Add(new BusinessModels.Product(dbInventory.ProductId, dbInventory.Product.Name, Convert.ToInt32(dbInventory.Quantity), (double)cost));
                //int productID, string name, int quantity, double price
                return store;
            }
        }
         public BusinessModels.Store GetProduct(int StoreId, int ProductId)
        {
            var store = FindStore(StoreId);
            var dbInventory = _context.Inventories.Include(i => i.Product).ThenInclude(i => i.Prices).FirstOrDefault(i => i.StoreId == StoreId && i.ProductId == ProductId);
            var price = dbInventory.Product.Prices;
            var list = price.ToList();
            decimal cost = list[0].Price1;
            store.Inventory.Add(new BusinessModels.Product(dbInventory.ProductId, dbInventory.Product.Name, Convert.ToInt32(dbInventory.Quantity), (double)cost));
            //int productID, string name, int quantity, double price
            return store;
        }
         async Task<int> IRepository.AddCustomerOrder(DataAccess.BusinessModels.Database db)
        {
            Order order = db.Customers[0].CustomerOrders[0];
            // pass in all the values in Customer Order
            CustomerOrder newOrder = new CustomerOrder()
            {
                StoreId = order.StoreId,
                CustomerId = order.CustomerId
            };
            // add the order and save   
            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            int id = newOrder.TransactionNumber; // Grab the transacction Number
            await AddCustomerItems(id, order);
            return id;
        }
        public async Task AddCustomerItems(int id, Order order)
        {
            // commit each item to the sql file.
            foreach (var trans in order.Items)
            {
                ProductOrdered newItem = new ProductOrdered()
                {
                    TransactionNumber = id,
                    ProductId = trans.ProductID,
                    Quantity = trans.Quantity
                };
                await _context.AddAsync(newItem);

                // update inventory
                var dbInvetory = _context.Inventories.First(i => i.ProductId == trans.ProductID && i.StoreId == order.StoreId);
                dbInvetory.Quantity -= trans.Quantity;
            }
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Returns the order History by Store ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessModels.Store GetOrderHistoryOfStore(int id)
        {
            var dbOrderHitory = _context.CustomerOrders.Include(c => c.Customer);
            var stores = new BusinessModels.Store(id);
            foreach (var order in dbOrderHitory)
            {
                if (order.StoreId == id)
                {
                    var time = order.TransactionTime;
                    stores.Orders.Add(new Order(order.TransactionNumber, id, order.CustomerId, order.Customer.FirstName, order.Customer.LastName, order.TransactionTime.ToString()));
                }
            }
            return stores;
        }
        /// <summary>
        /// Get Order History of Custoemr
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returns a Database with the history of cutsomers</returns>
        BusinessModels.Customer IRepository.GetOrderHistoryOfCustomer(int id)
        {
            var dbOrderHitory = _context.CustomerOrders.Include(c => c.Customer);
            BusinessModels.Customer customer = new BusinessModels.Customer(id);
            int i = 0;
            foreach (var order in dbOrderHitory)
            {
                if (order.CustomerId == id)
                {
                    if(i==0)
                    {
                        customer.FirstName = order.Customer.FirstName;
                        customer.LastName = order.Customer.LastName;
                        customer.Phone = order.Customer.Phone;
                        customer.CustomerId = order.Customer.CustomerId;
                        customer.Email = order.Customer.Email;
                    }
                    var time = order.TransactionTime.ToString();
                    customer.CustomerOrders.Add(new Order(order.TransactionNumber, id, order.CustomerId, order.Customer.FirstName, order.Customer.LastName, time));
                    i++;
                }
            }

            return customer;
        }

        BusinessModels.Database IRepository.GetOrder(int id)
        {
            var dbOrderHitory = _context.CustomerOrders.Include(c => c.ProductOrdereds)
                .ThenInclude(c => c.Product)
                .ThenInclude(c => c.Prices);

            var db = new BusinessModels.Database(new BusinessModels.Store(id));
            foreach (var orders in dbOrderHitory)
            {
                if (orders.TransactionNumber == id)
                {
                    var x = orders.TransactionTime.ToString();
                    BusinessModels.Order order = new BusinessModels.Order(id, orders.StoreId, orders.CustomerId, x);
                    foreach (var item in orders.ProductOrdereds)
                    {
                        var price = item.Product.Prices.ToList();
                        var tPrice = price[0].Price1;
                        order.addItem(new BusinessModels.Product(item.ProductId, item.Product.Name, (int)item.Quantity, (double)tPrice));
                    }

                    db.Stores[0].Orders.Add(order);
                }
            }
            return db;
        }
    }
}
