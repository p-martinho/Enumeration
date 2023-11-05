using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers;
using Xunit;

namespace Enumeration.Mappers.Tests;

public class EnumerationMapperTests
{
    [Fact]
    public void MapToEnumeration_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;

        // Act
        var result = EnumerationMapper<TestEnumeration, TestDifferentEnumeration>.MapToEnumeration(enumeration);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
        Assert.Same(TestDifferentEnumeration.CodeA, result);
    }

    [Fact]
    public void MapToEnumeration_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumeration? enumeration = null;

        // Act
        var result = EnumerationMapper<TestEnumeration, TestDifferentEnumeration>.MapToEnumeration(enumeration);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MapToEnumeration_WhenNotExistentValue_ShouldReturnNull()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeB;

        // Act
        var result = EnumerationMapper<TestEnumeration, TestDifferentEnumeration>.MapToEnumeration(enumeration);

        // Assert
        Assert.Null(result);
    }
}