using System.Text.Json;
using Enumeration.SystemTextJson.Tests.EnumerationClasses;
using PMart.Enumeration.SystemTextJson;

namespace Enumeration.SystemTextJson.Tests;

public class EnumerationDynamicConverterTests
{
    private readonly JsonSerializerOptions _serializerOptions;

    public EnumerationDynamicConverterTests()
    {
        _serializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationConverterFactory() }
        };
    }

    #region Serialize Tests

    [Fact]
    public void Serialize_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumerationDynamic.CodeA;
        var test = new TestClass { Test = instance };

        // Act
        var result = JsonSerializer.Serialize(test, _serializerOptions);

        // Assert
        Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
    }

    [Fact]
    public void Serialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var test = new TestClass { Test = null };

        // Act
        var result = JsonSerializer.Serialize(test, _serializerOptions);

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

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, _serializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Same(instance, result.Test);
    }

    [Fact]
    public void Deserialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var json = "{\"Test\":null}";

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, _serializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Test);
    }

    [Fact]
    public void Deserialize_WithUnknownValue_ShouldCreateNewInstance()
    {
        // Arrange
        var newCode = "unknownCode";
        var json = "{\"Test\":\"" + newCode + "\"}";

        // Act
        var result = JsonSerializer.Deserialize<TestClass>(json, _serializerOptions);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Test);
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