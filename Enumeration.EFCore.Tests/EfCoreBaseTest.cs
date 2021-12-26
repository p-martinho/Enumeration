using System;
using Enumeration.EFCore.Tests.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Enumeration.EFCore.Tests
{
    public abstract class EfCoreBaseTest : IDisposable
    {
        private const string ConnectionString = "DataSource=:memory:";
        
        protected readonly TestDbContext Context;
        
        protected EfCoreBaseTest()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlite(ConnectionString)
                .Options;

            Context = new TestDbContext(options);

            Context.Database.OpenConnection();
            
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}