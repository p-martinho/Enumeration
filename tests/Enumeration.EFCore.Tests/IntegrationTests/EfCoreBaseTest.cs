using Enumeration.EFCore.Tests.IntegrationTests.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Enumeration.EFCore.Tests.IntegrationTests;

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

    protected void DetachAllEntries()
    {
        foreach (var entry in Context.ChangeTracker.Entries())
        {
            Context.Entry(entry.Entity).State = EntityState.Detached;
        }
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}