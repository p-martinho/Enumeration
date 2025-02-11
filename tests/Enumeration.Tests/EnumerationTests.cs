using Enumeration.Tests.EnumerationClasses;

namespace Enumeration.Tests;

public class EnumerationTests
{
    #region Value Tests

    [Fact]
    public void Value_ShouldSucceed()
    {
        // Arrange

        // Act
        var valueA = TestEnumeration.CodeA.Value;
        var valueB = TestEnumeration.CodeB.Value;

        // Assert
        Assert.Equal(nameof(TestEnumeration.CodeA), valueA);
        Assert.Equal(nameof(TestEnumeration.CodeB), valueB);
    }

    #endregion

    #region GetMembers Tests

    [Fact]
    public void GetMembers_ShouldSucceed()
    {
        // Arrange

        // Act
        var members = TestEnumeration.GetMembers().ToList();

        // Assert
        // GetMembers use an HashSet, that does not allow more than one member with exactly same value.
        Assert.Equal(3, members.Count);
        Assert.Contains(TestEnumeration.CodeA, members);
        Assert.Contains(TestEnumeration.CodeB, members);
        Assert.Contains(TestEnumeration.CodeAClone, members);
        Assert.Contains(TestEnumeration.CodeAUpper, members);
    }

    #endregion

    #region GetFromValueOrDefault Tests

    [Fact]
    public void GetFromValueOrDefault_ShouldSucceed()
    {
        // Arrange
        var existentValue = TestEnumeration.CodeB.Value;

        // Act
        var instance = TestEnumeration.GetFromValueOrDefault(existentValue);

        // Assert
        Assert.Same(TestEnumeration.CodeB, instance);
    }

    [Fact]
    public void GetFromValueOrDefault_WhenValueDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var unknownValue = "unknownValue";

        // Act
        var instance = TestEnumeration.GetFromValueOrDefault(unknownValue);

        // Assert
        Assert.Null(instance);
    }

    [Fact]
    public void GetFromValueOrDefault_ShouldBeCaseInsensitive()
    {
        // Arrange
        var existentValue = TestEnumeration.CodeB.Value;
        var existentValueInDifferentCase = existentValue.ToUpper();

        // Act
        var instance = TestEnumeration.GetFromValueOrDefault(existentValueInDifferentCase);

        // Assert
        Assert.Same(TestEnumeration.CodeB, instance);
    }

    #endregion

    #region GetValues Tests

    [Fact]
    public void GetValues_ShouldSucceed()
    {
        // Arrange

        // Act
        var values = TestEnumeration.GetValues().ToList();

        // Assert
        Assert.Equal(3, values.Count);
        Assert.Contains(TestEnumeration.CodeA.Value, values);
        Assert.Contains(TestEnumeration.CodeB.Value, values);
        Assert.Contains(TestEnumeration.CodeAClone.Value, values); // Same value as CodeA
        Assert.Contains(TestEnumeration.CodeAUpper.Value, values);
    }

    #endregion

    #region HasValue Tests

    [Fact]
    public void HasValue_WhenDoesNotHaveValue_ShouldReturnFalse()
    {
        // Arrange
        var unknownValue = "unknownValue";

        // Act
        var result = TestEnumeration.HasValue(unknownValue);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasValue_WhenHasValue_ShouldReturnTrue()
    {
        // Arrange
        var value = nameof(TestEnumeration.CodeA);

        // Act
        var result = TestEnumeration.HasValue(value);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasValue_ShouldBeCaseInsensitive()
    {
        // Arrange
        var value = nameof(TestEnumeration.CodeB).ToUpper();

        // Act
        var result = TestEnumeration.HasValue(value);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Tests with sub-classes

    [Fact]
    public void Value_WithSubClass_ShouldSucceed()
    {
        // Arrange

        // Act
        var valueA = TestEnumerationWithSubClasses.CodeA.Value;
        var valueB = TestEnumerationWithSubClasses.CodeB.Value;

        // Assert
        Assert.Equal(nameof(TestEnumerationWithSubClasses.CodeA), valueA);
        Assert.Equal(nameof(TestEnumerationWithSubClasses.CodeB), valueB);
    }

    [Fact]
    public void GetMembers_WithSubClass_ShouldSucceed()
    {
        // Arrange

        // Act
        var members = TestEnumerationWithSubClasses.GetMembers().ToList();

        // Assert
        Assert.Equal(2, members.Count);
        Assert.Contains(TestEnumerationWithSubClasses.CodeA, members);
        Assert.Contains(TestEnumerationWithSubClasses.CodeB, members);
    }

    [Fact]
    public void HasValue_WithSubClass_ShouldSucceed()
    {
        // Arrange
        var unknownValue = "unknownValue";
        var existentValue = nameof(TestEnumerationWithSubClasses.CodeB);

        // Act
        var resultWithUnknownValue = TestEnumerationWithSubClasses.HasValue(unknownValue);
        var resultWithExistentValue = TestEnumerationWithSubClasses.HasValue(existentValue);

        // Assert
        Assert.False(resultWithUnknownValue);
        Assert.True(resultWithExistentValue);
    }

    [Fact]
    public void CustomPropertyOnSubClass_ShouldSucceed()
    {
        // Arrange

        // Act
        var hasATheCodeB = TestEnumerationWithSubClasses.CodeA.IsCodeB;
        var hasBTheCodeB = TestEnumerationWithSubClasses.CodeB.IsCodeB;

        // Assert
        Assert.False(hasATheCodeB);
        Assert.True(hasBTheCodeB);
    }

    #endregion

    #region ToString Tests

    [Fact]
    public void ToString_ShouldReturnValue()
    {
        // Arrange
        var value = TestEnumeration.CodeA.Value;

        // Act
        var result = TestEnumeration.CodeA.ToString();

        // Assert
        Assert.Equal(value, result);
    }

    #endregion

    #region Equals Tests

    [Fact]
    public void Equals_WhenSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenNotSameValue_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenOneIsNull_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenBothAreNull_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenSameValueButNotSameType_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumerationWithSubClasses.CodeA;

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region == operator Tests

    [Fact]
    public void EqualsOperator_WhenSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenNotSameValue_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperator_WhenOneIsNull_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperator_WhenBothAreNull_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = instance1 == instance2;

        // Assert
        Assert.True(result);
    }

    #endregion

    #region != operator Tests

    [Fact]
    public void NotEqualsOperator_WhenSameInstance_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void NotEqualsOperator_WhenDifferentInstanceButSameValue_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void NotEqualsOperator_WhenSameValueWithDifferentCase_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenNotSameValue_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenOneIsNull_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenBothAreNull_ShouldReturnFalse()
    {
        // Arrange
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // Act
        var result = instance1 != instance2;

        // Assert
        Assert.False(result);
    }

    #endregion

    #region == operator with string Tests

    [Fact]
    public void EqualsOperatorWithString_WhenSameValue_ShouldReturnTrue()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value;

        // Act
        var result = value == instance;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value.ToUpper();

        // Act
        var result = value == instance;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenNotSameValue_ShouldReturnFalse()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeB.Value;

        // Act
        var result = value == instance;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenStringIsNull_ShouldReturnFalse()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = (string?) null;

        // Act
        var result = value == instance;

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void EqualsOperatorWithString_WhenEnumerationIsNull_ShouldReturnFalse()
    {
        // Arrange
        var instance = (TestEnumeration?) null;
        var value = TestEnumeration.CodeA.Value;

        // Act
        var result = value == instance;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenBothAreNull_ShouldReturnTrue()
    {
        // Arrange
        var instance = (TestEnumeration?) null;
        var value = (TestEnumeration?) null;

        // Act
        var result = value == instance;

        // Assert
        Assert.True(result);
    }

    #endregion

    #region != operator Tests

    [Fact]
    public void NotEqualsOperatorWithString_WhenSameValue_ShouldReturnFalse()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value;

        // Act
        var result = value != instance;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenSameValueWithDifferentCase_ShouldReturnFalse()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value.ToUpper();

        // Act
        var result = value != instance;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenNotSameValue_ShouldReturnTrue()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeB.Value;

        // Act
        var result = value != instance;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenStringIsNull_ShouldReturnTrue()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var value = (string?) null;

        // Act
        var result = value != instance;

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void NotEqualsOperatorWithString_WhenEnumerationIsNull_ShouldReturnFalse()
    {
        // Arrange
        var instance = (TestEnumeration?) null;
        var value = TestEnumeration.CodeA.Value;

        // Act
        var result = value == instance;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenBothAreNull_ShouldReturnFalse()
    {
        // Arrange
        var instance = (TestEnumeration?) null;
        var value = (string?) null;

        // Act
        var result = value != instance;

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Instantiation Tests

    [Fact]
    public void Instantiate_WhenNullValue_ShouldThrow()
    {
        // Act
        var result = TestEnumeration.IncorrectInstantiation;
        
        // Assert
        Assert.Throws<ArgumentNullException>(result);
    }

    #endregion
}