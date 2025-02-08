using PMart.Enumeration.Generator.Models;

namespace Enumeration.Generator.Tests.Models;

public class EquatableStringDictionaryTests
{
    #region Equals Tests
    
    [Fact]
    public void Equals_WhenDictionariesHaveSameKeysAndValues_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Equals_WhenDictionariesHaveSameKeysAndValuesWithDifferentOrder_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "2", "two" },
            { "1", "one" }
        };
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Equals_WhenDictionariesHaveSameKeysButDifferentValues_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two_different" }
        };
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void Equals_WhenDictionariesHaveSameValuesButDifferentKeys_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2_different", "two" }
        };
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void Equals_WhenDictionariesHaveSameKeysAndValuesWithNullValues_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", null! }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", null! }
        };
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Equals_WhenTheOtherDictionaryIsNull_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void Equals_WhenSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = dic1;
        
        // Act
        var result = dic1.Equals(dic2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Equals_WhenDifferentNumberOfKeys_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var resultLeft = dic1.Equals(dic2);
        var resultRight = dic2.Equals(dic1);
        
        // Assert
        Assert.False(resultLeft);
        Assert.False(resultRight);
    }
    
    #endregion

    #region EqualityOperator Tests
    
    [Fact]
    public void EqualityOperator_WhenDictionariesHaveSameKeysAndValues_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var result = dic1 == dic2;
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void EqualityOperator_WhenOneDictionaryIsNull_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var resultLeft = dic1 == dic2;
        var resultRight = dic2 == dic1;
        
        // Assert
        Assert.False(resultLeft);
        Assert.False(resultRight);
    }
    
    [Fact]
    public void EqualityOperator_WhenSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = dic1;
        
        // Act
        var result = dic1 == dic2;
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void EqualityOperator_WhenDictionariesAreBothNull_ShouldReturnTrue()
    {
        // Arrange
        EquatableStringDictionary? dic1 = null;
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var result = dic1 == dic2;
        
        // Assert
        Assert.True(result);
    }
    
    #endregion

    #region InequalityOperator Tests
    
    [Fact]
    public void InequalityOperator_WhenDictionariesHaveSameKeysAndValues_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var result = dic1 != dic2;
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void InequalityOperator_WhenOneDictionaryIsNull_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var resultLeft = dic1 != dic2;
        var resultRight = dic2 != dic1;
        
        // Assert
        Assert.True(resultLeft);
        Assert.True(resultRight);
    }
    
    [Fact]
    public void InequalityOperator_WhenSameInstance_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = dic1;
        
        // Act
        var result = dic1 != dic2;
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void InequalityOperator_WhenDictionariesAreBothNull_ShouldReturnFalse()
    {
        // Arrange
        EquatableStringDictionary? dic1 = null;
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var result = dic1 != dic2;
        
        // Assert
        Assert.False(result);
    }
    
    #endregion

    #region Equals(object) Tests

    [Fact]
    public void EqualsToObject_WhenIsDictionaryWithSameKeysAndValues_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var result = dic1.Equals((object)dic2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void EqualsToObject_WhenIsDictionaryButDifferent_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two_different" }
        };
        
        // Act
        var result = dic1.Equals((object)dic2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void EqualsToObject_WhenTheObjectIsSameTypeButNull_ShouldReturnFalse()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        EquatableStringDictionary? dic2 = null;
        
        // Act
        var result = dic1.Equals((object?)dic2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void EqualsToObject_WhenSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = dic1;
        
        // Act
        var result = dic1.Equals((object)dic2);
        
        // Assert
        Assert.True(result);
    }

    #endregion

    #region GetHashCode Tests

    [Fact]
    public void GetHashCode_WhenDictionariesHaveSameKeysAndValues_ShouldHaveSameHashCode()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        
        // Act
        var result1 = dic1.GetHashCode();
        var result2 = dic2.GetHashCode();
        
        // Assert
        var defaultHashCode = default(HashCode).ToHashCode();
        Assert.NotEqual(defaultHashCode, result1);
        Assert.NotEqual(defaultHashCode, result2);
        Assert.Equal(result1, result2);
    }
    
    [Fact]
    public void GetHashCode_WhenDictionariesHaveSameKeysAndValuesWithDifferentOrder_ShouldHaveSameHashCode()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "2", "two" },
            { "1", "one" }
        };
        
        // Act
        var result1 = dic1.GetHashCode();
        var result2 = dic2.GetHashCode();
        
        // Assert
        var defaultHashCode = default(HashCode).ToHashCode();
        Assert.NotEqual(defaultHashCode, result1);
        Assert.NotEqual(defaultHashCode, result2);
        Assert.Equal(result1, result2);
    }
    
    [Fact]
    public void GetHashCode_WhenDictionariesHaveSameKeysButDifferentValues_ShouldHaveDifferentHashCode()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two_different" }
        };
        
        // Act
        var result1 = dic1.GetHashCode();
        var result2 = dic2.GetHashCode();
        
        // Assert
        var defaultHashCode = default(HashCode).ToHashCode();
        Assert.NotEqual(defaultHashCode, result1);
        Assert.NotEqual(defaultHashCode, result2);
        Assert.NotEqual(result1, result2);
    }
    
    [Fact]
    public void GetHashCode_WhenDictionariesHaveSameValuesButDifferentKeys_ShouldHaveDifferentHashCode()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", "two" }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2_different", "two" }
        };
        
        // Act
        var result1 = dic1.GetHashCode();
        var result2 = dic2.GetHashCode();
        
        // Assert
        var defaultHashCode = default(HashCode).ToHashCode();
        Assert.NotEqual(defaultHashCode, result1);
        Assert.NotEqual(defaultHashCode, result2);
        Assert.NotEqual(result1, result2);
    }
    
    [Fact]
    public void GetHashCode_WhenDictionariesHaveSameKeysAndValuesWithNullValues_ShouldHaveSameHashCode()
    {
        // Arrange
        var dic1 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", null! }
        };
        var dic2 = new EquatableStringDictionary
        {
            { "1", "one" },
            { "2", null! }
        };
        
        // Act
        var result1 = dic1.GetHashCode();
        var result2 = dic2.GetHashCode();
        
        // Assert
        var defaultHashCode = default(HashCode).ToHashCode();
        Assert.NotEqual(defaultHashCode, result1);
        Assert.NotEqual(defaultHashCode, result2);
        Assert.Equal(result1, result2);
    }

    #endregion
}