using Enumeration.Mapperly.Tests.EnumerationClasses;
using Enumeration.Mapperly.Tests.Mappers;
using Enumeration.Mapperly.Tests.Models;
using Xunit;

namespace Enumeration.Mapperly.Tests;

public class UnitTest1
{
    private readonly TestEnumerationModelMapper _mapper = new();

    [Fact]
    public void Test1()
    {
        // Arrange
        var sourceModel = new TestEnumerationSourceModel
        {
            TestEnumToEnumProperty = TestEnumeration.CodeA,
            TestEnumToStringProperty = TestEnumeration.CodeA,
            TestStringToEnumProperty = TestEnumeration.CodeA.Value,
            TestEnumToDifferentEnumProperty = TestEnumeration.CodeA,
            TestEnumDynamicToEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestEnumDynamicToStringProperty = TestEnumerationDynamic.CodeA,
            TestStringToEnumDynamicProperty = "CodeB",//TestEnumerationDynamic.CodeA.Value,
            TestEnumDynamicToDifferentEnumDynamicProperty = TestEnumerationDynamic.GetFromValueOrNew("CodeB")!//TestEnumerationDynamic.CodeA
        };

        // Act
        var result = _mapper.SourceToDestination(sourceModel);

        // Assert
        Assert.NotNull(result);
    }
}