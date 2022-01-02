using System.Text.Json;
using Enumeration.SystemTextJson.Tests.EnumerationClasses;
using Xunit;

namespace Enumeration.SystemTextJson.Tests;

public class EnumerationConverterTests
{
    #region Serialize Tests

    [Fact]
    public void Serialize_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var test = new TestClass {Test = instance};

        // Act
        var result = JsonSerializer.Serialize(test);

        // Assert
        Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
    }

    [Fact]
    public void Serialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var test = new TestClass {Test = null};

        // Act
        var result = JsonSerializer.Serialize(test);

        // Assert
        Assert.Equal("{\"Test\":null}", result);
    }

    #endregion

    #region Deserialize Tests

    [Fact]
    public void Deserialize_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var json = "{\"Test\":\"" + instance.Value + "\"}";

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Same(instance, result!.Test);
    }

    [Fact]
    public void Deserialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var json = "{\"Test\":null}";

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result!.Test);
    }

    #endregion

    #region Private classes for testing

    private class TestClass
    {
        public TestEnumeration? Test { get; init; }
    }

    #endregion
}