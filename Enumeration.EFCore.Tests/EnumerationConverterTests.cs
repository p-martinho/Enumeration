using System.Linq;
using System.Threading.Tasks;
using Enumeration.EFCore.Tests.DbContext;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Enumeration.EFCore.Tests
{
    public class EnumerationConverterTests : EfCoreBaseTest
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
            
            // Assert
            var entities = await Context.TestEntities.ToListAsync();
            Assert.Single(entities);
            Assert.Null(entities.Single().Test);
        }
    }
}