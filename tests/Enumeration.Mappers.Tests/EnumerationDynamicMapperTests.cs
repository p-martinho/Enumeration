using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers;

namespace Enumeration.Mappers.Tests;

public class EnumerationDynamicMapperTests
{
    [Fact]
    public void MapToEnumerationDynamic_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;

        // Act
        var result =
            EnumerationDynamicMapper<TestEnumeration, TestDifferentEnumerationDynamic>.MapToEnumerationDynamic(
                enumeration);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
        Assert.Same(TestDifferentEnumerationDynamic.CodeA, result);
    }

    [Fact]
    public void MapToEnumerationDynamic_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumeration enumeration = null!;

        // Act
        var result =
            EnumerationDynamicMapper<TestEnumeration, TestDifferentEnumerationDynamic>.MapToEnumerationDynamic(
                enumeration);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MapToEnumerationDynamic_WhenNotExistentValue_ShouldReturnNewEnumerationDynamic()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeB;

        // Act
        var result =
            EnumerationDynamicMapper<TestEnumeration, TestDifferentEnumerationDynamic>.MapToEnumerationDynamic(
                enumeration);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
    }
}