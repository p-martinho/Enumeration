using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers;
using Xunit;

namespace Enumeration.Mappers.Tests;

public class StringEnumerationDynamicMapperTests
{
    [Fact]
    public void MapToString_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumerationDynamic.CodeA;

        // Act
        var result = StringEnumerationDynamicMapper<TestEnumerationDynamic>.MapToString(enumeration);

        // Assert
        Assert.Equal(enumeration.Value, result);
    }

    [Fact]
    public void MapToString_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumerationDynamic enumeration = null!;

        // Act
        var result = StringEnumerationDynamicMapper<TestEnumerationDynamic>.MapToString(enumeration);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumerationDynamic_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumerationDynamic.CodeA;
        var sourceString = enumeration.Value;

        // Act
        var result = StringEnumerationDynamicMapper<TestEnumerationDynamic>.MapToEnumerationDynamic(sourceString);

        // Assert
        Assert.NotNull(result);
        Assert.Same(enumeration, result);
    }

    [Fact]
    public void MapToEnumerationDynamic_WhenStringIsNull_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = null;

        // Act
        var result = StringEnumerationDynamicMapper<TestEnumerationDynamic>.MapToEnumerationDynamic(sourceString!);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MapToEnumerationDynamic_WhenNotExistentValue_ShouldReturnNewEnumerationDynamic()
    {
        // Arrange
        const string sourceString = "someValue";

        // Act
        var result = StringEnumerationDynamicMapper<TestEnumerationDynamic>.MapToEnumerationDynamic(sourceString);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(sourceString, result.Value);
    }
}