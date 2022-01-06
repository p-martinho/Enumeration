using System.Text.Json;
using Enumeration.SystemTextJson.Tests.EnumerationClasses;
using PM.Enumeration.SystemTextJson;
using Xunit;

namespace Enumeration.SystemTextJson.Tests;

public class EnumerationDynamicConverterTests
{
    #region Serialize Tests

    [Fact]
    public void Serialize_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumerationDynamic.CodeA;
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
        var instance = TestEnumerationDynamic.CodeA;
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

    [Fact]
    public void Deserialize_WithUnknownValue_ShouldCreateNewInstance()
    {
        // Arrange
        var newCode = "unknownCode";
        var json = "{\"Test\":\"" + newCode + "\"}";
        var serializerOptions = new JsonSerializerOptions
        {
            Converters = {new EnumerationConverterFactory()}
        };

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, serializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result!.Test);
        Assert.Equal(newCode, result.Test!.Value);
    }

    #endregion

    #region Private classes for testing

    private class TestClass
    {
        public TestEnumerationDynamic? Test { get; init; }
    }

    #endregion
}