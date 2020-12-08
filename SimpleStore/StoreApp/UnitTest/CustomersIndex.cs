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
    public class CustomersIndex
    {
        [Fact]
        public async Task Index_DisplayStores()
        {
            // wanted to test out sql connection but maybe later
            // using var connection = new SqliteConnection("Data Source=:memory:");
            // var options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite(connection).Options; 
            //connection.Open();

            // ARRANGE

            var mockRepository = new Mock<IRepository>();

            // create a moq that returns customer
            mockRepository.Setup(r => r.GetAllCustomersAsync()).ReturnsAsync(GetTestSessions());

            // make a using my mock
            var controller = new CustomersController(mockRepository.Object);

            // ACT
            var result = await controller.Index("");

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task Customer_Delete_NotFound()
        {
            //ARRANGE
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.FindCustomer(1)).ReturnsAsync(GetTestSessions()[0]);
            // make a using my mock
            var controller = new CustomersController(mockRepository.Object);
            // ACT
            var result = await controller.Delete(1);

            //Assert should be a 404
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task Valid()
        {
            //ARRANGE
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddCustomerOrder(new Order(1, 1))).ReturnsAsync(1);
            // make a using my mock

        }
            private List<StoreApp.DataAccess.BusinessModels.Customer> GetTestSessions()
        {
            var sessions = new List<StoreApp.DataAccess.BusinessModels.Customer>();
            sessions.Add(new StoreApp.DataAccess.BusinessModels.Customer(1)
            {
                FirstName = "Jordan"
            });
            sessions.Add(new StoreApp.DataAccess.BusinessModels.Customer(2)
            {
                FirstName = "Sasha"
            });
            return sessions;
        }
    }
}
