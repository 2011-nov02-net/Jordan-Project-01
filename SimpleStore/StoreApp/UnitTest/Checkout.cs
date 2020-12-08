using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.BusinessModels;
using StoreApp.DataAccess.Repositores;
using StoreApp.Webapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Linq;
using StoreApp.Webapp.Models;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Checkout
        // doesn't work needs to impliment sessions
    {   [Fact]
        public void CheckoutTest()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddCustomerOrder(new Order(1,1)));

            var controller = new ShoppingCartController(mockRepository.Object);

            // Act
            var result = controller.Checkout();
            // Assert false becasue cart is empty
            Assert.False(controller.ModelState.IsValid);
        }

    }
}
