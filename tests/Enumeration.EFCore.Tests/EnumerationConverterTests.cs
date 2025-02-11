using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMart.Enumeration;
using PMart.Enumeration.EFCore;

namespace Enumeration.EFCore.Tests;

public class EnumerationConverterTests
{
    private readonly ValueConverter _converter;

    public EnumerationConverterTests()
    {
        _converter = new EnumerationConverter<TestEnumeration>();
    }

    [Fact]
    public void ConvertToProvider_ShouldSucceed()
    {
        // Arrange
        var enumeration = TestEnumeration.CodeA;
        
        // Act
        var result = _converter.ConvertToProvider(enumeration) as string;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(TestEnumeration.CodeA.Value, result);
    }
    
    [Fact]
    public void ConvertToProvider_WhenNull_ShouldConvertToNull()
    {
        // Arrange
        var enumeration = (TestEnumeration?)null;
        
        // Act
        var result = _converter.ConvertToProvider(enumeration);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void ConvertFromProvider_ShouldSucceed()
    {
        // Arrange
        var valueToConvertFrom = TestEnumeration.CodeA.Value;
        
        // Act
        var result = _converter.ConvertFromProvider(valueToConvertFrom) as TestEnumeration;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(TestEnumeration.CodeA, result);
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
    public void ConvertFromProvider_WhenInvalidValue_ShouldConvertToNull()
    {
        // Arrange
        var valueToConvertFrom = "someValue";
        
        // Act
        var result = _converter.ConvertFromProvider(valueToConvertFrom);

        // Assert
        Assert.Null(result);
    }
    
    private class TestEnumeration : Enumeration<TestEnumeration>
    {
        public static readonly TestEnumeration CodeA = new(nameof(CodeA));

        private TestEnumeration(string value) : base(value)
        {
        }
    }
}