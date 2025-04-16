# PMart.Enumeration.EFCore

This is the package to add EF Core support for the __Enumeration classes__ (more information in the [main page](../../README.md)).

In EF Core, adding a property of type `Enumeration` or `EnumerationDynamic` to an entity requires setting the conversion to store the value of the enumeration on the database.
The NuGet package `PMart.Enumeration.EFCore` has the required converters, you just need to add them to your model configuration.

# Installation

Add the package to your project:
```bash
dotnet add package PMart.Enumeration.EFCore
```

# Usage

You need to add the converters to the properties of type `Enumeration` or `EnumerationDynamic`, using the `.HasConvertion()` method of the model builder.

Check this [sample](../../samples/Enumeration.EFCore.Sample/DbContext/SampleDbContext.cs):

For this entity:

 ```c#
public class CommunicationRecord
{
    public Guid Id { get; set; }
    
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;

    public CommunicationType? CommunicationType { get; set; }

    public CommunicationTypeDynamic? CommunicationTypeDynamic { get; set; }
}
```

You need to configure your entity type (on model creating of your `DbContext`, for instance) this way:

 ```c#
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
```

An usage [sample](../../samples/Enumeration.EFCore.Sample/Samples/CommunicationUsingEFCoreSample.cs):

```c#
public async Task<IEnumerable<CommunicationRecord>> GetCommunicationRecordsByType(CommunicationType communicationType)
{
    var records = await _context.CommunicationRecords
        .Where(r => r.Type == communicationType)
        .ToListAsync();

    return records;
}
```

> __Note:__ In a query, the case sensitivity is determined by the database provider.
E.g., if you save the record using an `EnumerationDynamic` with value `"Email"`, and then query the database using another instance of `EnumerationDynamic` with value `"EMAIL"`, it is possible you get no results, depending on the database.
For example, __MS SQL Server__ is, by default, case-insensitive, so you would get the result.