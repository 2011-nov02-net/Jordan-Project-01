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
    public class CustomerControllTest
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

            // create a moq that returns store
            mockRepository.Setup(r => r.GetAllStoresAsync()).ReturnsAsync(GetTestSessions());

            // make a using my mock
            var controller = new StoresController(mockRepository.Object);

            // ACT
            var result = await controller.Index("");

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void TestHistoryDetails()
        {   
            // ARRANGE

            var mockRepository = new Mock<IRepository>();
            var controller = new CustomersController(mockRepository.Object);

            // create a moq that returns order
            mockRepository.Setup(r => r.GetOrder(0)).Returns(GetDatabaseSession());

            IActionResult actionResult = controller.HistoryDetails(1);

            // assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(actionResult);
            var locations = Assert.IsAssignableFrom<IEnumerable<Order>>(viewResult.Model);
            var locationList = locations.ToList();

            Assert.Equal(1, locationList[0].CustomerId);
            Assert.Equal(2, locationList[0].StoreId);
        }
        [Fact]
        public async Task Create_Customer()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            var custTest = new StoreApp.DataAccess.BusinessModels.Customer(1);
            custTest.FirstName = "Jordan";
            custTest.LastName = "garcia";
            custTest.Phone = "9992221111";
            var viewmodel = new CustomerViewModel(custTest);
            var controller = new CustomersController(mockRepo.Object);

            // Act
            var result = await controller.Create(viewmodel);
            // Assert

            Assert.True(controller.ModelState.IsValid);
        }
        [Fact]
        public void ValidCustomer()
        {
            // Arrange
            var custTest = new StoreApp.DataAccess.BusinessModels.Customer(1);
            custTest.FirstName = "Jordan";
            custTest.LastName = "garcia";
            custTest.Phone = "9992221111";

            // Act

            bool CustomerId = custTest.isValid();

            // Assert

            Assert.True(CustomerId);
        }
        private List<StoreApp.DataAccess.BusinessModels.Store> GetTestSessions()
        {
            var sessions = new List<StoreApp.DataAccess.BusinessModels.Store>();
            sessions.Add(new StoreApp.DataAccess.BusinessModels.Store()
            {
                StoreId = 1,
                Name = "Walmart"
            });
            sessions.Add(new StoreApp.DataAccess.BusinessModels.Store()
            {
                StoreId = 2,
                Name = "Target"
            }) ;
            return sessions;
        }
        private Database GetDatabaseSession()
        {
            Database db = new Database(new StoreApp.DataAccess.BusinessModels.Store(1));
            db.Stores[0].Orders.Add(new Order(1,1));
            return db;
        }


    }
}
