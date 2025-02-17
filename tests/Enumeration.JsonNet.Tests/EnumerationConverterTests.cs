using Enumeration.JsonNet.Tests.EnumerationClasses;
using Newtonsoft.Json;
using PMart.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Tests;

public class EnumerationConverterTests
{
    #region Serialize Tests

    [Fact]
    public void Serialize_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        var enumerationDynamicValue = "newValue";
        var enumerationDynamic = TestEnumerationDynamic.GetFromValueOrNew(enumerationDynamicValue);
        var test = new TestClass {Test = enumeration, TestDynamic = enumerationDynamic};

        // Act
        var result = JsonConvert.SerializeObject(test, new EnumerationConverter());

        // Assert
        Assert.Equal("{\"Test\":\"" + enumeration.Value + "\",\"TestDynamic\":\"" + enumerationDynamicValue + "\"}",
            result);
    }

    [Fact]
    public void Serialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var test = new TestClass {Test = null, TestDynamic = null};

        // Act
        var result = JsonConvert.SerializeObject(test, new EnumerationConverter());

        // Assert
        Assert.Equal("{\"Test\":null,\"TestDynamic\":null}", result);
    }

    #endregion

    #region Deserialize Tests

    [Fact]
    public void Deserialize_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        var enumerationDynamicValue = "newValue";
        var json = "{\"Test\":\"" + enumeration.Value + "\",\"TestDynamic\":\"" + enumerationDynamicValue + "\"}";

        // Act
        var result = JsonConvert.DeserializeObject<TestClass>(json, new EnumerationConverter());

        // Assert
        Assert.NotNull(result);
        Assert.Same(enumeration, result.Test);
        Assert.Equal(enumerationDynamicValue, result.TestDynamic?.Value);
    }

    [Fact]
    public void Deserialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var json = "{\"Test\":null,\"TestDynamic\":null}";

        // Act
        var result = JsonConvert.DeserializeObject<TestClass>(json, new EnumerationConverter());

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Test);
        Assert.Null(result.TestDynamic);
    }

    [Fact]
    public void Deserialize_WhenNotValid_ShouldFail()
    {
        // Arrange
        var json = "{\"Test\":1}";

        // Act
        var result = () => JsonConvert
            .DeserializeObject<TestClass>(json, new EnumerationConverter());

        // Assert
        Assert.Throws<JsonSerializationException>(result);
    }

    [Fact]
    public void Deserialize_WhenAttributeIncorrectlyAdded_ShouldFail()
    {
        // Arrange
        var json = "{\"Test\":\"CodeA\"}";

        // Act
        var result = () => JsonConvert
            .DeserializeObject<TestClassWithIncorrectAttribute>(json);

        // Assert
        Assert.Throws<JsonSerializationException>(result);
    }

    #endregion

    #region Private classes for testing

    private class TestClass
    {
        public TestEnumeration? Test { get; init; }

        public TestEnumerationDynamic? TestDynamic { get; init; }
    }

    private class TestClassWithIncorrectAttribute
    {
        [JsonConverter(typeof(EnumerationConverter))]
        public string? Test { get; init; }
    }

    #endregion
}