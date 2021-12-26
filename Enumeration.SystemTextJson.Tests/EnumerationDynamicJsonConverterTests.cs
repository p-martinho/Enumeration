using System.Text.Json;
using System.Text.Json.Serialization;
using PM.Enumeration;
using PM.Enumeration.SystemTextJson;
using Xunit;

namespace Enumeration.SystemTextJson.Tests
{
    public class EnumerationDynamicJsonConverterTests
    {
        #region Serialize Tests

        [Fact]
        public void Serialize_ShouldSucceed()
        {
            // Arrange
            var instance = TestEnumerationDynamic.CodeA;
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
            var instance = TestEnumerationDynamic.CodeA;
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

        [Fact]
        public void Deserialize_WithUnknownValue_ShouldCreateNewInstance()
        {
            // Arrange
            var newCode = "unknownCode";
            var json = "{\"Test\":\"" + newCode + "\"}";

            // Act
            var result = JsonSerializer.Deserialize<TestClass>(json);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result!.Test);
            Assert.Equal(newCode, result.Test!.Value);
        }

        #endregion

        #region Private Enumeration classes for testing

        private class TestClass
        {
            public TestEnumerationDynamic? Test { get; set; }
        }

        [JsonConverter(typeof(EnumerationJsonConverterFactory))]
        private class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
        {
            public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

            public TestEnumerationDynamic()
            {
            }

            private TestEnumerationDynamic(string value) : base(value)
            {
            }
        }

        #endregion
    }
}