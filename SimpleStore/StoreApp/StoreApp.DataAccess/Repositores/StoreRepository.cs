using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DataAccess;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.BusinessModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Repositores
{
    public class StoreRepository : IRepository
    {
        private readonly StoreDBContext _context;
        public StoreRepository(StoreDBContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
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
        public async Task<BusinessModels.Store> FindStore(int StoreId)
        {
            EfModels.Store e = await _context.Stores.FindAsync(StoreId);
            return new BusinessModels.Store(e.StoreId, e.Name, e.Street, e.State, e.City, e.Zip);
        }

        async Task IRepository.DeleteStore(int StoreId)
        {
            EfModels.Store store = await _context.Stores.FindAsync(StoreId);
            _context.Stores.Remove(store);
            _context.SaveChanges();

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

        IEnumerable<BusinessModels.Customer> IRepository.GetAllCustomers()
        {
            throw new NotImplementedException();
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

        async Task<BusinessModels.Store> IRepository.GetProduct(int StoreId, int ProductId)
        {
            {
                // get the store id
                var store = await FindStore(StoreId);
                var dbInventory = await _context.Inventories.Include(i => i.Product).ThenInclude(i => i.Prices).FirstOrDefaultAsync(i => i.StoreId == StoreId && i.ProductId==ProductId);
                var price = dbInventory.Product.Prices;
                var list = price.ToList();
                decimal cost = list[0].Price1;
                store.Inventory.Add(new BusinessModels.Product(dbInventory.ProductId, dbInventory.Product.Name, Convert.ToInt32(dbInventory.Quantity), (double)cost));
                //int productID, string name, int quantity, double price
                return store;
            }
        }
    }
}
