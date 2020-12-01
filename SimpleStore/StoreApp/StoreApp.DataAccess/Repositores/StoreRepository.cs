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
        async Task<BusinessModels.Store> IRepository.FindStore(int StoreId)
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

        Task<List<BusinessModels.Customer>> IRepository.GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BusinessModels.Customer> IRepository.GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        void IRepository.AddCustomer(BusinessModels.Customer customer)
        {
            // pass in all the values of customer and place them in.
            BusinessModels.Customer newCustomer = new BusinessModels.Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };

            // add customer to context
            _context.Add(newCustomer);
            _context.SaveChanges();
        }


        void IRepository.RemoveCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        Task<List<BusinessModels.Product>> IRepository.GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BusinessModels.Product> IRepository.GetAllProducts()
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


    }
}
