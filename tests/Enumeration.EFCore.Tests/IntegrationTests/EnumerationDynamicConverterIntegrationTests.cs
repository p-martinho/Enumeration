using System.Linq;
using System.Threading.Tasks;
using Enumeration.EFCore.Tests.IntegrationTests.DbContext;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Enumeration.EFCore.Tests.IntegrationTests;

public class EnumerationDynamicConverterIntegrationTests : EfCoreBaseTest
{
    [Fact]
    public async Task SaveAndRetrieveData_ShouldSucceed()
    {
        // Arrange
        var entity = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.CodeA
        };

        // Act
        Context.Add(entity);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entities = await Context.TestEntities.ToListAsync();
        Assert.Single(entities);
        Assert.Equal(TestEnumerationDynamic.CodeA, entities.Single().TestDynamic);
    }

    [Fact]
    public async Task SaveAndRetrieveData_WhenNull_ShouldSucceed()
    {
        // Arrange
        var entity = new TestEntity
        {
            TestDynamic = null
        };

        // Act
        Context.Add(entity);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entities = await Context.TestEntities.ToListAsync();
        Assert.Single(entities);
        Assert.Null(entities.Single().TestDynamic);
    }

    [Fact]
    public async Task SaveAndRetrieveData_WhenDynamicValue_ShouldSucceed()
    {
        // Arrange
        var newCode = "newCode";
        var entity = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.GetFromValueOrNew(newCode)
        };

        // Act
        Context.Add(entity);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entities = await Context.TestEntities.ToListAsync();
        Assert.Single(entities);
        Assert.Equal(newCode, entities.Single().TestDynamic?.Value);
    }
    
    [Fact]
    public async Task QueryingData_ShouldSucceed()
    {
        // Arrange
        var entity1 = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.CodeA
        };
        var entity2 = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.CodeB
        };

        // Act
        Context.Add(entity1);
        Context.Add(entity2);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entityWithCodeA = await Context.TestEntities
            .FirstOrDefaultAsync(e => e.TestDynamic == TestEnumerationDynamic.CodeA);
        Assert.NotNull(entityWithCodeA);
        Assert.Equal(entityWithCodeA.TestDynamic, TestEnumerationDynamic.CodeA);
    }
    
    [Fact]
    public async Task QueryingData_WhenNull_ShouldSucceed()
    {
        // Arrange
        var entity1 = new TestEntity
        {
            TestDynamic = null
        };
        var entity2 = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.CodeB
        };

        // Act
        Context.Add(entity1);
        Context.Add(entity2);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entityWithCodeNull = await Context.TestEntities
            .FirstOrDefaultAsync(e => e.TestDynamic == null);
        Assert.NotNull(entityWithCodeNull);
        Assert.Null(entityWithCodeNull.TestDynamic);
    }
    
    [Fact]
    public async Task QueryingData_WhenDynamicValue_ShouldSucceed()
    {
        // Arrange
        var newCode = "newCode";
        var entity1 = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.GetFromValueOrNew(newCode)
        };
        var entity2 = new TestEntity
        {
            TestDynamic = TestEnumerationDynamic.CodeB
        };

        // Act
        Context.Add(entity1);
        Context.Add(entity2);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var newEnumerationDynamicInstance = TestEnumerationDynamic.GetFromValueOrNew(newCode);
        var entityWithNewCode = await Context.TestEntities
            .FirstOrDefaultAsync(e => e.TestDynamic == newEnumerationDynamicInstance);
        Assert.NotNull(entityWithNewCode);
        Assert.Equal(newEnumerationDynamicInstance, entityWithNewCode.TestDynamic);
    }
}