using System;
using System.Collections.Immutable;
using System.Linq;
using Enumeration.Tests.EnumerationClasses;
using Xunit;

namespace Enumeration.Tests;

public class EnumerationDynamicTests
{
    #region GetFromValueOrNew Tests

    [Fact]
    public void GetFromValueOrNew_WhenNewValue_ShouldReturnNewInstance()
    {
        // Arrange
        var newTestType = "newTestType";

        // Act
        var instance = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

        // Assert
        Assert.NotNull(instance);
        Assert.Equal(newTestType, instance.Value);
    }

    [Fact]
    public void GetFromValueOrNew_WhenExistentValue_ShouldReturnInstanceWithValue()
    {
        // Arrange
        var existentValue = TestEnumerationDynamic.CodeA.Value;

        // Act
        var instance = TestEnumerationDynamic.GetFromValueOrNew(existentValue);

        // Assert
        Assert.NotNull(instance);
        Assert.Same(TestEnumerationDynamic.CodeA, instance);
    }

    [Fact]
    public void GetFromValueOrNew_ShouldBeCaseInsensitive()
    {
        // Arrange
        var existentValue = TestEnumerationDynamic.CodeA.Value;
        var existentValueInDifferentCase = existentValue.ToUpper();

        // Act
        var instance = TestEnumerationDynamic.GetFromValueOrNew(existentValueInDifferentCase);

        // Assert
        Assert.Same(TestEnumerationDynamic.CodeA, instance);
    }

    [Fact]
    public void GetFromValueOrNew_WhenValueIsNull_ShouldReturnNull()
    {
        // Arrange
        string? nullValue = null;

        // Act
        var instance = TestEnumerationDynamic.GetFromValueOrNew(nullValue);

        // Assert
        Assert.Null(instance);
    }

    #endregion

    #region GetMembers Tests

    [Fact]
    public void GetMembers_ShouldReturnOnlyTheDefaults()
    {
        // Arrange
        var newTestType = "newTestType";
        var instanceWithDynamicValue = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

        // Act
        var members = TestEnumerationDynamic.GetMembers().ToList();

        // Assert
        Assert.Single(members);
        Assert.DoesNotContain(instanceWithDynamicValue, members);
    }

    [Fact]
    public void GetMembers_ShouldNotBePossibleToChangeMembersList()
    {
        // Arrange
        var newMember = TestEnumerationDynamic.GetFromValueOrNew("newCode");

        // Act
        var membersList = (ImmutableHashSet<TestEnumerationDynamic>) TestEnumerationDynamic.GetMembers();
        membersList = membersList.Add(newMember!);
        var originalMembersList = TestEnumerationDynamic.GetMembers();

        // Assert
        Assert.Contains(newMember, membersList!);
        Assert.DoesNotContain(newMember, originalMembersList);
    }

    #endregion

    #region HasValue Tests

    [Fact]
    public void HasValue_WithDynamicValue_ShouldReturnFalse()
    {
        // Arrange
        var newTestType = "newTestType";
        var instanceWithDynamicValue = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

        // Act
        var result = TestEnumerationDynamic.HasValue(newTestType);

        // Assert
        Assert.False(result);
        Assert.Equal(newTestType, instanceWithDynamicValue?.Value);
    }

    #endregion

    #region Tests with sub-classes

    [Fact]
    public void GetFromValueOrNew_WhenExistentValueOnSubClass_ReturnsNewInstanceButThatIsEqual()
    {
        // Arrange
        var existentValueFromSubClass = SubTypeWithEnumerationsDeclared.SubTypeCodeA.Value;

        // Act
        var instance = SubTypeWithEnumerationsDeclared.GetFromValueOrNew(existentValueFromSubClass);

        // Assert
        Assert.NotNull(instance);
        Assert.NotSame(SubTypeWithEnumerationsDeclared.SubTypeCodeA, instance);
        Assert.Equal(SubTypeWithEnumerationsDeclared.SubTypeCodeA, instance);
    }

    [Fact]
    public void GetFromValueOrNew_UsingBaseClassMethod_WhenExistentValueOnSubClass_ReturnsNewInstanceButThatIsEqual()
    {
        // Arrange
        var existentValueFromSubClass = SubTypeWithEnumerationsDeclared.SubTypeCodeA.Value;

        // Act
        var instance = TestEnumerationDynamicWithSubClasses.GetFromValueOrNew(existentValueFromSubClass);

        // Assert
        Assert.NotNull(instance);
        Assert.NotSame(SubTypeWithEnumerationsDeclared.SubTypeCodeA, instance);
        Assert.Equal(SubTypeWithEnumerationsDeclared.SubTypeCodeA, instance);
    }

    [Fact]
    public void GetFromValueOrNew_UsingSubClassMethod_WhenExistentValue_ShouldReturnInstanceWithValue()
    {
        // Arrange
        var existentValue = TestEnumerationDynamicWithSubClasses.CodeA.Value;

        // Act
        var instance = SubTypeWithEnumerationsDeclared.GetFromValueOrNew(existentValue);

        // Assert
        Assert.NotNull(instance);
        Assert.Same(TestEnumerationDynamicWithSubClasses.CodeA, instance);
    }

    #endregion

    #region Instatition Tests

    [Fact]
    public void Instantiate_WhenNullValue_ShouldThrow()
    {
        // Act
        var result = TestEnumerationDynamic.IncorrectInstantiation;

        // Assert
        Assert.Throws<ArgumentNullException>(result);
    }

    #endregion
}