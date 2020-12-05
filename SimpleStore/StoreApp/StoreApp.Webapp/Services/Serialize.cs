﻿using StoreApp.DataAccess.BusinessModels;
using StoreApp.DataAccess.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StoreApp.Webapp.Services
{
    public class Serialize
    {

        public Order _order = new Order();
        public Order SerializedOrder {
            get
            {
                return _order;
            }
        }
        [DataType(DataType.Currency)]
        public double Cost { 
            get
            {
                double _cost = 0;
                foreach (Product item in SerializedOrder.Items)
                {
                    _cost += item.Price * item.Quantity;
                }
                return _cost;
            } 
        }
        public Serialize(string productInfoArray, IRepository repository)
        {
            if (!String.IsNullOrEmpty(productInfoArray)) { 
            string[] productInfo = productInfoArray.Split('|');
                for(int i =0; i< productInfo.Length; i++)
                {
                    var info = productInfo[i].Split(",");
                    int StoreId = Int32.Parse(info[0]);
                    int CustomerId = Int32.Parse(info[1]);
                    int ProductId = Int32.Parse(info[2]);
                    int Quantity = Int32.Parse(info[3]);
                    var store = repository.GetProduct(StoreId, ProductId);
                    var product = store.Inventory[0];
                    product.Quantity = Quantity;
                    SerializedOrder.addItem(product);
                    SerializedOrder.CustomerId = CustomerId;
                }
            }
        }
        public IEnumerable<Product> OrderEnumberable
        {
            get
            {
                List<Product> products = SerializedOrder.Items;
                return products;
            }
        }
    }
}