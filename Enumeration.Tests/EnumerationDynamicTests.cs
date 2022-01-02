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
    public void GetFromValueOrDefault_ShouldBeCaseInsensitive()
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
    public void GetFromValueOrDefault_WhenValueIsNull_ShouldReturnNewInstanceWithNullValue()
    {
        // Arrange
        string? nullValue = null;

        // Act
        var instance = TestEnumerationDynamic.GetFromValueOrNew(nullValue!);

        // Assert
        Assert.NotNull(instance);
        Assert.Null(instance.Value);
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
        membersList = membersList.Add(newMember);
        var originalMembersList = TestEnumerationDynamic.GetMembers();

        // Assert
        Assert.Contains(newMember, membersList);
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
        Assert.Equal(newTestType, instanceWithDynamicValue.Value);
    }

    #endregion

    #region Equals Tests

    [Fact]
    public void Equals_WhenBothValuesAreNull_ShouldReturnTrue()
    {
        // Arrange
        var instance1 = TestEnumerationDynamic.GetFromValueOrNew(null!);
        var instance2 = TestEnumerationDynamic.GetFromValueOrNew(null!);

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
    {
        // Arrange
        var newTestType = "newTestType";
        var instance1 = TestEnumerationDynamic.GetFromValueOrNew(newTestType);
        var instance2 = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

        // Act
        var result = Equals(instance1, instance2);

        // Assert
        Assert.True(result);
    }

    #endregion
}