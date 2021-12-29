using System.Linq;
using PM.Enumeration;
using Xunit;

namespace Enumeration.Tests;

public class EnumerationTests
{
    #region Value Tests

    [Fact]
    public void Value_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var valueA = TestEnumeration.CodeA.Value;
        var valueB = TestEnumeration.CodeB.Value;

        // ASSERT
        Assert.Equal(nameof(TestEnumeration.CodeA), valueA);
        Assert.Equal(nameof(TestEnumeration.CodeB), valueB);
    }

    #endregion

    #region GetMembers Tests

    [Fact]
    public void GetMembers_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var members = TestEnumeration.GetMembers().ToList();

        // ASSERT
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
        // ARRANGE
        var existentValue = TestEnumeration.CodeB.Value;

        // ACT
        var instance = TestEnumeration.GetFromValueOrDefault(existentValue);

        // ASSERT
        Assert.Same(TestEnumeration.CodeB, instance);
    }

    [Fact]
    public void GetFromValueOrDefault_WhenValueDoesNotExist_ShouldReturnNull()
    {
        // ARRANGE
        var unknownValue = "unknownValue";

        // ACT
        var instance = TestEnumeration.GetFromValueOrDefault(unknownValue);

        // ASSERT
        Assert.Null(instance);
    }

    [Fact]
    public void GetFromValueOrDefault_ShouldBeCaseInsensitive()
    {
        // ARRANGE
        var existentValue = TestEnumeration.CodeB.Value;
        var existentValueInDifferentCase = existentValue.ToUpper();

        // ACT
        var instance = TestEnumeration.GetFromValueOrDefault(existentValueInDifferentCase);

        // ASSERT
        Assert.Same(TestEnumeration.CodeB, instance);
    }

    #endregion

    #region GetValues Tests

    [Fact]
    public void GetValues_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var values = TestEnumeration.GetValues().ToList();

        // ASSERT
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
        // ARRANGE
        var unknownValue = "unknownValue";

        // ACT
        var result = TestEnumeration.HasValue(unknownValue);

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void HasValue_WhenHasValue_ShouldReturnTrue()
    {
        // ARRANGE
        var value = nameof(TestEnumeration.CodeA);

        // ACT
        var result = TestEnumeration.HasValue(value);

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void HasValue_ShouldBeCaseInsensitive()
    {
        // ARRANGE
        var value = nameof(TestEnumeration.CodeB).ToUpper();

        // ACT
        var result = TestEnumeration.HasValue(value);

        // ASSERT
        Assert.True(result);
    }

    #endregion

    #region Tests with sub-classes

    [Fact]
    public void Value_WithSubClass_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var valueA = TestEnumerationWithSubClasses.CodeA.Value;
        var valueB = TestEnumerationWithSubClasses.CodeB.Value;

        // ASSERT
        Assert.Equal(nameof(TestEnumerationWithSubClasses.CodeA), valueA);
        Assert.Equal(nameof(TestEnumerationWithSubClasses.CodeB), valueB);
    }

    [Fact]
    public void GetMembers_WithSubClass_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var members = TestEnumerationWithSubClasses.GetMembers().ToList();

        // ASSERT
        Assert.Equal(2, members.Count);
        Assert.Contains(TestEnumerationWithSubClasses.CodeA, members);
        Assert.Contains(TestEnumerationWithSubClasses.CodeB, members);
    }

    [Fact]
    public void HasValue_WithSubClass_ShouldSucceed()
    {
        // ARRANGE
        var unknownValue = "unknownValue";
        var existentValue = nameof(TestEnumerationWithSubClasses.CodeB);

        // ACT
        var resultWithUnknownValue = TestEnumerationWithSubClasses.HasValue(unknownValue);
        var resultWithExistentValue = TestEnumerationWithSubClasses.HasValue(existentValue);

        // ASSERT
        Assert.False(resultWithUnknownValue);
        Assert.True(resultWithExistentValue);
    }

    [Fact]
    public void CustomPropertyOnSubClass_ShouldSucceed()
    {
        // ARRANGE

        // ACT
        var hasATheCodeB = TestEnumerationWithSubClasses.CodeA.IsCodeB;
        var hasBTheCodeB = TestEnumerationWithSubClasses.CodeB.IsCodeB;

        // ASSERT
        Assert.False(hasATheCodeB);
        Assert.True(hasBTheCodeB);
    }

    #endregion

    #region ToString Tests

    [Fact]
    public void ToString_ShouldReturnValue()
    {
        // ARRANGE
        var value = TestEnumeration.CodeA.Value;

        // ACT
        var result = TestEnumeration.CodeA.ToString();

        // ASSERT
        Assert.Equal(value, result);
    }

    #endregion

    #region Equals Tests

    [Fact]
    public void Equals_WhenSameInstance_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // ACT
        var result = instance1.Equals(instance2);

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenNotSameValue_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenOneIsNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenBothAreNull_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenSameValueButNotSameType_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumerationWithSubClasses.CodeA;

        // ACT
        var result = Equals(instance1, instance2);

        // ASSERT
        Assert.False(result);
    }

    #endregion

    #region == operator Tests

    [Fact]
    public void EqualsOperator_WhenSameInstance_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperator_WhenNotSameValue_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperator_WhenOneIsNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperator_WhenBothAreNull_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = instance1 == instance2;

        // ASSERT
        Assert.True(result);
    }

    #endregion

    #region != operator Tests

    [Fact]
    public void NotEqualsOperator_WhenSameInstance_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeA;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.False(result);
    }
    
    [Fact]
    public void NotEqualsOperator_WhenDifferentInstanceButSameValue_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAClone;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.False(result);
    }
    
    [Fact]
    public void NotEqualsOperator_WhenSameValueWithDifferentCase_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeAUpper;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenNotSameValue_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = TestEnumeration.CodeB;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenOneIsNull_ShouldReturnTrue()
    {
        // ARRANGE
        var instance1 = TestEnumeration.CodeA;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperator_WhenBothAreNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance1 = (TestEnumeration?) null;
        var instance2 = (TestEnumeration?) null;

        // ACT
        var result = instance1 != instance2;

        // ASSERT
        Assert.False(result);
    }

    #endregion

    #region == operator with string Tests

    [Fact]
    public void EqualsOperatorWithString_WhenSameValue_ShouldReturnTrue()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenSameValueWithDifferentCase_ShouldReturnTrue()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value.ToUpper();

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenNotSameValue_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeB.Value;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenStringIsNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = (string?) null;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.False(result);
    }
    
    [Fact]
    public void EqualsOperatorWithString_WhenEnumerationIsNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = (TestEnumeration?) null;
        var value = TestEnumeration.CodeA.Value;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void EqualsOperatorWithString_WhenBothAreNull_ShouldReturnTrue()
    {
        // ARRANGE
        var instance = (TestEnumeration?) null;
        var value = (TestEnumeration?) null;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.True(result);
    }

    #endregion

    #region != operator Tests

    [Fact]
    public void NotEqualsOperatorWithString_WhenSameValue_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value;

        // ACT
        var result = value != instance;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenSameValueWithDifferentCase_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeA.Value.ToUpper();

        // ACT
        var result = value != instance;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenNotSameValue_ShouldReturnTrue()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = TestEnumeration.CodeB.Value;

        // ACT
        var result = value != instance;

        // ASSERT
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenStringIsNull_ShouldReturnTrue()
    {
        // ARRANGE
        var instance = TestEnumeration.CodeA;
        var value = (string?) null;

        // ACT
        var result = value != instance;

        // ASSERT
        Assert.True(result);
    }
    
    [Fact]
    public void NotEqualsOperatorWithString_WhenEnumerationIsNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = (TestEnumeration?) null;
        var value = TestEnumeration.CodeA.Value;

        // ACT
        var result = value == instance;

        // ASSERT
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsOperatorWithString_WhenBothAreNull_ShouldReturnFalse()
    {
        // ARRANGE
        var instance = (TestEnumeration?) null;
        var value = (string?) null;

        // ACT
        var result = value != instance;

        // ASSERT
        Assert.False(result);
    }

    #endregion

    #region Private Enumeration classes for testing

    private class TestEnumeration : Enumeration<TestEnumeration>
    {
        public static readonly TestEnumeration CodeA = new(nameof(CodeA));
        public static readonly TestEnumeration CodeAClone = new(nameof(CodeA));
        public static readonly TestEnumeration CodeAUpper = new(nameof(CodeA).ToUpper());
        public static readonly TestEnumeration CodeB = new(nameof(CodeB));

        private TestEnumeration(string value) : base(value)
        {
        }
    }

    private abstract class TestEnumerationWithSubClasses : Enumeration<TestEnumerationWithSubClasses>
    {
        public static readonly TestEnumerationWithSubClasses CodeA = new CodeAType();
        public static readonly TestEnumerationWithSubClasses CodeB = new CodeBType();

        public abstract bool IsCodeB { get; }

        private TestEnumerationWithSubClasses(string value) : base(value)
        {
        }

        private class CodeAType : TestEnumerationWithSubClasses
        {
            public CodeAType() : base(nameof(CodeA))
            {
            }

            public override bool IsCodeB => false;
        }

        private class CodeBType : TestEnumerationWithSubClasses
        {
            public CodeBType() : base(nameof(CodeB))
            {
            }

            public override bool IsCodeB => true;
        }
    }

    #endregion
}