using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Context;

namespace OwnerPropertyManagement.Test.Mocks
{
    public class DatabaseFixture : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private  SqliteConnection _connection;
        private  DatabaseFixture _dbContextMock;
        private  OwnerPropertyDbContext _dbContext;

        public DatabaseFixture()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<OwnerPropertyDbContext>()
                .UseSqlite(_connection)
                .Options;
            _dbContext = new OwnerPropertyDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
           // _dbContext = null;
            _dbContext.Dispose();
            // ... clean up test data from the database ...
        }

        public OwnerPropertyDbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}
