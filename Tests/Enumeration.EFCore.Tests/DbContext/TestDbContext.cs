using Microsoft.EntityFrameworkCore;
using PMart.Enumeration.EFCore;

namespace Enumeration.EFCore.Tests.DbContext;

public class TestDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<TestEntity> TestEntities { get; set; } = null!;

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TestEntity>(e =>
        {
            e.Property(p => p.Test)
                .HasConversion(new EnumerationConverter<TestEnumeration>());

            e.Property(p => p.TestDynamic)
                .HasConversion(new EnumerationDynamicConverter<TestEnumerationDynamic>());
        });
    }
}