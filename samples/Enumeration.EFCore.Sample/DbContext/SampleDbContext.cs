using Enumeration.EFCore.Sample.Entities;
using Enumeration.EFCore.Sample.Enumerations;
using Microsoft.EntityFrameworkCore;
using PMart.Enumeration.EFCore;

namespace Enumeration.EFCore.Sample.DbContext;

public class SampleDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<CommunicationRecord> CommunicationRecords { get; set; } = null!;

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CommunicationRecord>(e =>
        {
            e.Property(p => p.Type)
                .HasConversion<EnumerationConverter<CommunicationType>>();

            e.Property(p => p.TypeDynamic)
                .HasConversion<EnumerationDynamicConverter<CommunicationTypeDynamic>>();
        });
    }
}