using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.BusinessModels;
using StoreApp.DataAccess.EfModels;

namespace StoreApp.DataAccess.Repositores
{
    public interface IRepository
    {
        Task<List<BusinessModels.Store>> GetAllStoresAsync();
        IEnumerable<BusinessModels.Store> GetAllStores();
        Task AddStoreAsync(BusinessModels.Store store);
        Task DeleteStore(int StoreId);
        Task<BusinessModels.Store> FindStoreAsync(int StoreId); 
        BusinessModels.Store FindStore(int StoreId);

        Task<BusinessModels.Store> GetProductAsync(int StoreId, int ProductId);
        BusinessModels.Store GetProduct(int StoreId, int ProductId);

        Task<List<BusinessModels.Customer>> GetAllCustomersAsync();
        Task <BusinessModels.Customer> FindCustomer(int CustomerId);
        Task AddCustomer(BusinessModels.Customer customer);
        void RemoveCustomer(int CustomerId);

        Task<List<BusinessModels.Product>> GetAllProductsAsync();
        BusinessModels.Store GetAllProducts(int id);
        void AddProduct(BusinessModels.Product product);
        void RemoveProduct(int ProductId);

        Task<List<BusinessModels.Order>> GetAllOrdersAsync();
        IEnumerable<BusinessModels.Order> GetAllOrders();
        void AddProduct(BusinessModels.Order product);
        void RemoveOrder(int OrderId);
        Task DeleteCustomer(int StoreId);
        Task<int> AddCustomerOrder(Database db);
        BusinessModels.Customer GetOrderHistoryOfCustomer(int id);
        Database GetOrder(int id);
        BusinessModels.Store GetOrderHistoryOfStore(int id);
    }
}
