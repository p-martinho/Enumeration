using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers;
using Xunit;

namespace Enumeration.Mappers.Tests;

public class StringToEnumerationMapperTests
{
    [Fact]
    public void MapToEnumeration_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        var sourceString = enumeration.Value;

        // Act
        var result = StringToEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString);

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
        var result = StringToEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MapToEnumeration_WhenNotExistentValue_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = "someValue";

        // Act
        var result = StringToEnumerationMapper<TestEnumeration>.MapToEnumeration(sourceString);

        // Assert
        Assert.Null(result);
    }
}