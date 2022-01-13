using System;
using Enumeration.Tests.EnumerationClasses;
using PMart.Enumeration.Extensions;
using Xunit;

namespace Enumeration.Tests.Extensions;

public class EnumerationExtensionsTests
{
    #region IsAssignableToEnumeration Tests

    [Fact]
    public void IsAssignableToEnumeration_WhenTypeIsDerivedFromEnumeration_ShouldReturnTrue()
    {
        // Arrange
        var type = TestEnumeration.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumeration();
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsAssignableToEnumeration_WhenTypeIsDerivedFromEnumerationDynamic_ShouldReturnTrue()
    {
        // Arrange
        var type = TestEnumerationDynamic.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumeration();
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsAssignableToEnumeration_WhenTypeIsSubClassDerivedFromEnumeration_ShouldReturnTrue()
    {
        // Arrange
        var type = TestEnumerationWithSubClasses.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumeration();
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsAssignableToEnumeration_WhenTypeIsNotDerivedFromEnumeration_ShouldReturnFalse()
    {
        // Arrange
        var type = typeof(int);
        
        // Act
        var result = type.IsAssignableToEnumeration();
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsAssignableToEnumeration_WhenTypeIsNull_ShouldReturnFalse()
    {
        // Arrange
        var type = (Type?)null;
        
        // Act
        var result = type.IsAssignableToEnumeration();
        
        // Assert
        Assert.False(result);
    }
    
    #endregion
    
    #region IsAssignableToEnumerationDynamic Tests

    [Fact]
    public void IsAssignableToEnumerationDynamic_WhenTypeIsDerivedFromEnumerationDynamic_ShouldReturnTrue()
    {
        // Arrange
        var type = TestEnumerationDynamic.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumerationDynamic();
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAssignableToEnumerationDynamic_WhenTypeIsSubClassDerivedFromEnumerationDynamic_ShouldReturnTrue()
    {
        // Arrange
        var type = TestEnumerationDynamicWithSubClasses.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumerationDynamic();
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsAssignableToEnumerationDynamic_WhenTypeIsNotDerivedFromEnumerationDynamic_ShouldReturnFalse()
    {
        // Arrange
        var type = TestEnumeration.CodeA.GetType();
        
        // Act
        var result = type.IsAssignableToEnumerationDynamic();
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsAssignableToEnumerationDynamic_WhenTypeIsNull_ShouldReturnFalse()
    {
        // Arrange
        var type = (Type?)null;
        
        // Act
        var result = type.IsAssignableToEnumerationDynamic();
        
        // Assert
        Assert.False(result);
    }
    
    #endregion
}