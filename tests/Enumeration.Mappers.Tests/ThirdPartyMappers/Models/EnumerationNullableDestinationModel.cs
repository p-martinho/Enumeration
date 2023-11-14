using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationNullableDestinationModel
{
    public TestEnumeration? TestEnumToNullableEnumProperty { get; set; }
    
    public string? TestEnumToNullableStringProperty { get; set; }
    
    public TestEnumeration? TestStringToNullableEnumProperty { get; set; }
    
    public TestDifferentEnumeration? TestEnumToDifferentNullableEnumProperty { get; set; }
    
    public TestEnumeration TestNullableEnumToEnumProperty { get; set; } = null!;
    
    public string TestNullableEnumToStringProperty { get; set; } = null!;
    
    public TestEnumeration TestNullableStringToEnumProperty { get; set; } = null!;
    
    public TestDifferentEnumeration TestNullableEnumToDifferentEnumProperty { get; set; } = null!;
    
    public TestEnumeration? TestNullableEnumToNullableEnumProperty { get; set; }
    
    public string? TestNullableEnumToNullableStringProperty { get; set; }
    
    public TestEnumeration? TestNullableStringToNullableEnumProperty { get; set; }
    
    public TestDifferentEnumeration? TestNullableEnumToDifferentNullableEnumProperty { get; set; }
}