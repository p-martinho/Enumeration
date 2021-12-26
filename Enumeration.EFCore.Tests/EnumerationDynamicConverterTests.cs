using System.Linq;
using System.Threading.Tasks;
using Enumeration.EFCore.Tests.DbContext;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Enumeration.EFCore.Tests
{
    public class EnumerationDynamicConverterTests : EfCoreBaseTest
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
            
            // Assert
            var entities = await Context.TestEntities.ToListAsync();
            Assert.Single(entities);
            Assert.Equal(newCode, entities.Single().TestDynamic?.Value);
        }
    }
}