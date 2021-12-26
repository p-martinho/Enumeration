using System.Text.Json;
using System.Text.Json.Serialization;
using Enumeration;
using Enumeration.JsonConverters;
using Xunit;

namespace EnumerationTests.JsonConverters
{
    public class EnumerationJsonConverterTests
    {
        #region Serialize Tests
    
        [Fact]
        public void Serialize_ShouldSucceed()
        {
            // Arrange
            var instance = TestEnumeration.CodeA;
            var test = new TestClass { Test = instance };
    
            // Act
            var result = JsonSerializer.Serialize(test);
    
            // Assert
            Assert.Equal("{\"Test\":\"" + instance.Value + "\"}", result);
        }
        
        [Fact]
        public void Serialize_WhenNull_ShouldSucceed()
        {
            // Arrange
            var test = new TestClass { Test = null };
    
            // Act
            var result = JsonSerializer.Serialize(test);
    
            // Assert
            Assert.Equal("{\"Test\":null}", result);
        }
        
        #endregion
        
        #region Serialize Tests
    
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
    
        #region Private Enumeration classes for testing
        
        private class TestClass
        {
            public TestEnumeration? Test { get; set; }
        }
        
        [JsonConverter(typeof(EnumerationJsonConverterFactory))]
        private class TestEnumeration : Enumeration<TestEnumeration>
        {
            public static readonly TestEnumeration CodeA = new(nameof(CodeA));
    
            private TestEnumeration(string value) : base(value)
            {
            }
        }
        
        #endregion
    }
}