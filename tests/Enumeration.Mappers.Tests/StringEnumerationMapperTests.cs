using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers;
using Xunit;

namespace Enumeration.Mappers.Tests;

public class StringEnumerationMapperTests
{
    [Fact]
    public void MapToString_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;

        // Act
        var result = StringEnumerationMapper<TestEnumeration>.MapToString(enumeration);

        // Assert
        Assert.Equal(enumeration.Value, result);
    }

    [Fact]
    public void MapToString_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumeration enumeration = null!;

        // Act
        var result = StringEnumerationMapper<TestEnumeration>.MapToString(enumeration);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumeration_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        var sourceString = enumeration.Value;

        // Act
        var result = StringEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString);

        // Assert
        Assert.NotNull(result);
        Assert.Same(enumeration, result);
    }

    [Fact]
    public void MapToEnumeration_WhenStringIsNull_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = null;

        // Act
        var result = StringEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString!);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MapToEnumeration_WhenNotExistentValue_ShouldReturnNull()
    {
        // Arrange
        const string sourceString = "someValue";

        // Act
        var result = StringEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString);

        // Assert
        Assert.Null(result);
    }
}