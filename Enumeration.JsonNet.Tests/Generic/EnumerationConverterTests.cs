using Enumeration.JsonNet.Tests.EnumerationClasses;
using Newtonsoft.Json;
using PM.Enumeration.JsonNet.Generic;
using Xunit;

namespace Enumeration.JsonNet.Tests.Generic;

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
        var result = JsonConvert.SerializeObject(test);

        // Assert
        Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
    }

    [Fact]
    public void Serialize_WithoutAttribute_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var test = new TestClassWithoutAttribute {Test = instance};

        // Act
        var result = JsonConvert
            .SerializeObject(test, new EnumerationConverter<TestEnumeration>());

        // Assert
        Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
    }

    [Fact]
    public void Serialize_WhenNull_ShouldSucceed()
    {
        // Arrange
        var test = new TestClass {Test = null};

        // Act
        var result = JsonConvert.SerializeObject(test);

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
        var result = JsonConvert.DeserializeObject<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Same(instance, result!.Test);
    }

    [Fact]
    public void Deserialize_WithoutAttribute_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumeration.CodeA;
        var json = "{\"Test\":\"" + instance.Value + "\"}";

        // Act
        var result = JsonConvert
            .DeserializeObject<TestClassWithoutAttribute>(json, new EnumerationConverter<TestEnumeration>());

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
        var result = JsonConvert.DeserializeObject<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result!.Test);
    }
    
    [Fact]
    public void Deserialize_WhenNotValid_ShouldFail()
    {
        // Arrange
        var json = "{\"Test\":1}";

        // Act
        var result = () => JsonConvert.DeserializeObject<TestClass>(json);

        // Assert
        Assert.Throws<JsonSerializationException>(result);
    }

    #endregion

    #region Private classes for testing

    private class TestClass
    {
        [JsonConverter(typeof(EnumerationConverter<TestEnumeration>))]
        public TestEnumeration? Test { get; init; }
    }
    
    private class TestClassWithoutAttribute
    {
        public TestEnumeration? Test { get; init; }
    }

    #endregion
}