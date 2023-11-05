using Enumeration.Mappers.Tests.EnumerationClasses;
using PMart.Enumeration.Mappers.Extensions;
using Xunit;

namespace Enumeration.Mappers.Tests.Extensions;

public class EnumerationExtensionsTests
{
    #region MapToEnumeration from string tests
    
    [Fact]
    public void MapToEnumeration_FromString_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        var sourceString = enumeration.Value;
        
        // Act
        var result = sourceString.MapToEnumeration<TestEnumeration>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Same(enumeration, result);
    }
    
    [Fact]
    public void MapToEnumeration_FromString_WhenStringIsNull_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = null;
        
        // Act
        var result = sourceString.MapToEnumeration<TestEnumeration>();
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumeration_FromString_WhenNotExistentValue_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = "someValue";
        
        // Act
        var result = sourceString.MapToEnumeration<TestEnumeration>();
        
        // Assert
        Assert.Null(result);
    }
    
    #endregion
    
    #region MapToEnumerationDynamic from string tests
    
    [Fact]
    public void MapToEnumerationDynamic_FromString_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumerationDynamic.CodeA;
        var sourceString = enumeration.Value;
        
        // Act
        var result = sourceString.MapToEnumerationDynamic<TestEnumerationDynamic>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Same(enumeration, result);
    }
    
    [Fact]
    public void MapToEnumerationDynamic_FromString_WhenStringIsNull_ShouldReturnNull()
    {
        // Arrange
        const string? sourceString = null;
        
        // Act
        var result = sourceString.MapToEnumerationDynamic<TestEnumerationDynamic>();
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumerationDynamic_FromString_WhenNotExistentValue_ShouldReturnNewEnumerationDynamic()
    {
        // Arrange
        const string? sourceString = "someValue";
        
        // Act
        var result = sourceString.MapToEnumerationDynamic<TestEnumerationDynamic>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(sourceString, result.Value);
    }

    #endregion
    
    #region MapToEnumeration from Enumeration tests
    
    [Fact]
    public void MapToEnumeration_FromEnumeration_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        
        // Act
        var result = enumeration.MapToEnumeration<TestEnumeration, TestDifferentEnumeration>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
        Assert.Same(TestDifferentEnumeration.CodeA, result);
    }
    
    [Fact]
    public void MapToEnumeration_FromEnumeration_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumeration? enumeration = null;
        
        // Act
        var result = enumeration.MapToEnumeration<TestEnumeration, TestDifferentEnumeration>();
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumeration_FromEnumeration_WhenNotExistentValue_ShouldReturnNull()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeB;
        
        // Act
        var result = enumeration.MapToEnumeration<TestEnumeration, TestDifferentEnumeration>();
        
        // Assert
        Assert.Null(result);
    }

    #endregion
    
    #region MapToEnumerationDynamic from Enumeration tests
    
    [Fact]
    public void MapToEnumerationDynamic_FromEnumeration_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        
        // Act
        var result = enumeration.MapToEnumerationDynamic<TestEnumeration, TestDifferentEnumerationDynamic>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
        Assert.Same(TestDifferentEnumerationDynamic.CodeA, result);
    }
    
    [Fact]
    public void MapToEnumerationDynamic_FromEnumeration_WhenEnumerationIsNull_ShouldReturnNull()
    {
        // Arrange
        TestEnumeration? enumeration = null;
        
        // Act
        var result = enumeration.MapToEnumerationDynamic<TestEnumeration, TestDifferentEnumerationDynamic>();
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void MapToEnumerationDynamic_FromEnumeration_WhenNotExistentValue_ShouldReturnNewEnumerationDynamic()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeB;
        
        // Act
        var result = enumeration.MapToEnumerationDynamic<TestEnumeration, TestDifferentEnumerationDynamic>();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(enumeration.Value, result.Value);
    }

    #endregion
}