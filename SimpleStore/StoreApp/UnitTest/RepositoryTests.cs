using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.EfModels;
using StoreApp.DataAccess.Repositores;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class RepositoryTests
    {
        private IRepository _repository;

        [Fact]
        public async Task Store_Inserts()
        {
            using var connection = new SqliteConnection("Data Source=:memory:");
            var options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite(connection).Options;
            connection.Open();

            // set up customer 
            var custTest = new StoreApp.DataAccess.BusinessModels.Customer(1);
            // call the database and save
            using (var context = new StoreDBContext(options))
            {
                context.Database.EnsureCreated();
                _repository = new StoreRepository(context);
                // act
                await _repository.AddCustomer(custTest);

            }

            //set up db again
            using var context2 = new StoreDBContext(options);
            var customer = context2.Customers.ToListAsync();

            Assert.Equal(0,customer.Id);
        }
    }
}