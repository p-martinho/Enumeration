using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationNullableSourceModel
{
    public TestEnumeration TestEnumToNullableEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToNullableStringProperty { get; set; } = null!;
    
    public string TestStringToNullableEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToDifferentNullableEnumProperty { get; set; } = null!;
    
    public TestEnumeration? TestNullableEnumToEnumProperty { get; set; }
    
    public TestEnumeration? TestNullableEnumToStringProperty { get; set; }
    
    public string? TestNullableStringToEnumProperty { get; set; }
    
    public TestDifferentEnumeration? TestNullableEnumToDifferentEnumProperty { get; set; }
    
    public TestEnumeration? TestNullableEnumToNullableEnumProperty { get; set; }
    
    public TestEnumeration? TestNullableEnumToNullableStringProperty { get; set; }
    
    public string? TestNullableStringToNullableEnumProperty { get; set; }
    
    public TestDifferentEnumeration? TestNullableEnumToDifferentNullableEnumProperty { get; set; }
}