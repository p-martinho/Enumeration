﻿using Enumeration.JsonNet.Tests.EnumerationClasses;
using Newtonsoft.Json;
using PMart.Enumeration.JsonNet.Generic;

namespace Enumeration.JsonNet.Tests.Generic;

public class EnumerationDynamicConverterTests
{
    #region Serialize Tests

    [Fact]
    public void Serialize_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumerationDynamic.CodeA;
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
        var instance = TestEnumerationDynamic.CodeA;
        var test = new TestClassWithoutAttribute {Test = instance};

        // Act
        var result = JsonConvert
            .SerializeObject(test, new EnumerationDynamicConverter<TestEnumerationDynamic>());

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
        var instance = TestEnumerationDynamic.CodeA;
        var json = "{\"Test\":\"" + instance.Value + "\"}";

        // Act
        var result = JsonConvert.DeserializeObject<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Same(instance, result.Test);
    }

    [Fact]
    public void Deserialize_WithoutAttribute_ShouldSucceed()
    {
        // Arrange
        var instance = TestEnumerationDynamic.CodeA;
        var json = "{\"Test\":\"" + instance.Value + "\"}";

        // Act
        var result = JsonConvert
            .DeserializeObject<TestClassWithoutAttribute>(json,
                new EnumerationDynamicConverter<TestEnumerationDynamic>());

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
        var result = JsonConvert.DeserializeObject<TestClass>(json);

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
        var result = JsonConvert.DeserializeObject<TestClass>(json);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Test);
        Assert.Equal(newCode, result.Test!.Value);
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
        [JsonConverter(typeof(EnumerationDynamicConverter<TestEnumerationDynamic>))]
        public TestEnumerationDynamic? Test { get; init; }
    }

    private class TestClassWithoutAttribute
    {
        public TestEnumerationDynamic? Test { get; init; }
    }

    #endregion
}