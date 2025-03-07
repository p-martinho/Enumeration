﻿using Enumeration.EFCore.Tests.IntegrationTests.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Enumeration.EFCore.Tests.IntegrationTests;

public class EnumerationConverterIntegrationTests : EfCoreBaseTest
{
    [Fact]
    public async Task SaveAndRetrieveData_ShouldSucceed()
    {
        // Arrange
        var entity = new TestEntity
        {
            Test = TestEnumeration.CodeA
        };

        // Act
        Context.Add(entity);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entities = await Context.TestEntities.ToListAsync();
        Assert.Single(entities);
        Assert.Equal(TestEnumeration.CodeA, entities.Single().Test);
    }

    [Fact]
    public async Task SaveAndRetrieveData_WhenNull_ShouldSucceed()
    {
        // Arrange
        var entity = new TestEntity
        {
            Test = null
        };

        // Act
        Context.Add(entity);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entities = await Context.TestEntities.ToListAsync();
        Assert.Single(entities);
        Assert.Null(entities.Single().Test);
    }

    [Fact]
    public async Task QueryingData_ShouldSucceed()
    {
        // Arrange
        var entity1 = new TestEntity
        {
            Test = TestEnumeration.CodeA
        };
        var entity2 = new TestEntity
        {
            Test = TestEnumeration.CodeB
        };

        // Act
        Context.Add(entity1);
        Context.Add(entity2);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entityWithCodeA = await Context.TestEntities
            .FirstOrDefaultAsync(e => e.Test == TestEnumeration.CodeA);
        Assert.NotNull(entityWithCodeA);
        Assert.Equal(entityWithCodeA.Test, TestEnumeration.CodeA);
    }

    [Fact]
    public async Task QueryingData_WhenNull_ShouldSucceed()
    {
        // Arrange
        var entity1 = new TestEntity
        {
            Test = null
        };
        var entity2 = new TestEntity
        {
            Test = TestEnumeration.CodeB
        };

        // Act
        Context.Add(entity1);
        Context.Add(entity2);
        await Context.SaveChangesAsync();
        DetachAllEntries();

        // Assert
        var entityWithCodeNull = await Context.TestEntities
            .FirstOrDefaultAsync(e => e.Test == null);
        Assert.NotNull(entityWithCodeNull);
        Assert.Null(entityWithCodeNull.Test);
    }
}