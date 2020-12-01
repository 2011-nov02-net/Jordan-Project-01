﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.EfModels;

namespace StoreApp.DataAccess.Repositores
{
    public interface IRepository
    {
        Task<List<BusinessModels.Store>> GetAllStoresAsync();
        IEnumerable<BusinessModels.Store> GetAllStores();
        Task AddStoreAsync(BusinessModels.Store store);
        Task DeleteStore(int StoreId);
        Task<BusinessModels.Store> FindStore(int StoreId);

        Task<List<BusinessModels.Customer>> GetAllCustomersAsync();
        IEnumerable<BusinessModels.Customer> GetAllCustomers();
        void AddCustomer(BusinessModels.Customer customer);
        void RemoveCustomer(int CustomerId);

        Task<List<BusinessModels.Product>> GetAllProductsAsync();
        IEnumerable<BusinessModels.Product> GetAllProducts();
        void AddProduct(BusinessModels.Product product);
        void RemoveProduct(int ProductId);

        Task<List<BusinessModels.Order>> GetAllOrdersAsync();
        IEnumerable<BusinessModels.Order> GetAllOrders();
        void AddProduct(BusinessModels.Order product);
        void RemoveOrder(int OrderId);
    }
}
