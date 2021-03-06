﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataAccess.BusinessModels
{
    public class Database
    {
        public List<Customer> _customers = new List<Customer>();
        public List<Store> _stores = new List<Store>();
        public List<Order> _orders = new List<Order>();
        public List<Store> Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                _stores = value;
            }
        }
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }
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
        public Database(List<Store> stores)
        {
            Stores = stores;
        }
        public Database(List<Customer> customers)
        {
            Customers = customers;
        }

        /// <summary>
        /// Initialize a Database with a Customer
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="stores"></param>
        public Database(List<Customer> customers, List<Store> stores)
        {
            Customers = customers;
            Stores = stores;
        }

        public Database(Store store)
        {
            Stores.Add(store);
        
        }

        /// <summary>
        /// return customer by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int id) => Customers.FirstOrDefault(x => x.CustomerId == id);
        /// <summary>
        /// return store by the id passed by the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Store GetStoreById(int id) => Stores.FirstOrDefault(x => x.StoreId == id);
        /// <summary>
        /// Get a list of stores by a search string.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<Store> GetStoresByName(string searchString)
        {
            List<Store> _stores = new List<Store>();
            if (!String.IsNullOrEmpty(searchString))
            {
                var p = from store in Stores
                        where store.Name.Contains(searchString)
                        select store;
                _stores = p.ToList();
                return _stores;
            }
            return Stores;
        }
        public List<Customer> GetCustomerByName(string searchString)
        {
            List<Customer> _stores = new List<Customer>();
            if (!String.IsNullOrEmpty(searchString))
            {
                var p = from store in Customers
                        where store.FirstName.Contains(searchString)
                        select store;
                _stores = p.ToList();
                return _stores;
            }
            return Customers;
        }

    /// <summary>
    /// Returns the amount of stores in the database
    /// </summary>
        public int StoreCount() => Stores.Count();
        /// <summary>
        /// Returns the amount of Customers in the database
        /// </summary>
        /// <returns></returns>
        public int CustomerCount() => Customers.Count();
       
        
    }
}