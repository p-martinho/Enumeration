using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMart.Enumeration;
using PMart.Enumeration.EFCore;
using Xunit;

namespace Enumeration.EFCore.Tests;

public class EnumerationDynamicConverterTests
{
    private readonly ValueConverter _converter;

    public EnumerationDynamicConverterTests()
    {
        _converter = new EnumerationDynamicConverter<TestEnumerationDynamic>();
    }

    [Fact]
    public void ConvertToProvider_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumerationDynamic.CodeA;
        
        // Act
        var result = _converter.ConvertToProvider(enumeration) as string;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(TestEnumerationDynamic.CodeA.Value, result);
    }
    
    [Fact]
    public void ConvertToProvider_WhenNull_ShouldConvertToNull()
    {
        // Arrange
        var enumeration = (TestEnumerationDynamic?)null;
        
        // Act
        var result = _converter.ConvertToProvider(enumeration);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void ConvertToProvider_WhenDynamicValue_ShouldSucceed()
    {
        // Arrange
        var newValue = "newValue";
        var enumeration = TestEnumerationDynamic.GetFromValueOrNew(newValue);
        
        // Act
        var result = _converter.ConvertToProvider(enumeration) as string;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newValue, result);
    }
    
    [Fact]
    public void ConvertFromProvider_ShouldSucceed()
    {
        // Arrange
        var valueToConvertFrom = TestEnumerationDynamic.CodeA.Value;
        
        // Act
        var result = _converter.ConvertFromProvider(valueToConvertFrom) as TestEnumerationDynamic;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(TestEnumerationDynamic.CodeA, result);
    }
    
    [Fact]
    public void ConvertFromProvider_WhenNull_ShouldConvertToNull()
    {
        // Arrange
        var valueToConvertFrom = (string?)null;
        
        // Act
        var result = _converter.ConvertFromProvider(valueToConvertFrom);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void ConvertFromProvider_WhenDynamicValue_ShouldConvertToNull()
    {
        // Arrange
        var newValue = "newValue";

        // Act
        var result = _converter.ConvertFromProvider(newValue) as TestEnumerationDynamic;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newValue, result!.Value);
    }
    
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
}