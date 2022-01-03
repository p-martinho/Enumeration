using System.Text.Json;
using Enumeration.SystemTextJson.Tests.EnumerationClasses;
using PM.Enumeration.SystemTextJson;
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
        var serializerOptions = new JsonSerializerOptions
        {
            Converters = {new EnumerationConverterFactory()}
        };

        // Act
        var result = JsonSerializer.Serialize(test, serializerOptions);

        // Assert
        Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
    }

    [Fact]
    public void Serialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var test = new TestClass {Test = null};
        var serializerOptions = new JsonSerializerOptions
        {
            Converters = {new EnumerationConverterFactory()}
        };

        // Act
        var result = JsonSerializer.Serialize(test, serializerOptions);

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
        var serializerOptions = new JsonSerializerOptions
        {
            Converters = {new EnumerationConverterFactory()}
        };

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, serializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Same(instance, result!.Test);
    }

    [Fact]
    public void Deserialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var json = "{\"Test\":null}";
        var serializerOptions = new JsonSerializerOptions
        {
            Converters = {new EnumerationConverterFactory()}
        };

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, serializerOptions);

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