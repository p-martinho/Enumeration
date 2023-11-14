using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationDestinationModel
{
    public TestEnumeration TestEnumToEnumProperty { get; set; } = null!;
    
    public string TestEnumToStringProperty { get; set; } = null!;
    
    public TestEnumeration TestStringToEnumProperty { get; set; } = null!;
    
    public TestDifferentEnumeration TestEnumToDifferentEnumProperty { get; set; } = null!;
    
    public TestEnumeration? TestNullableEnumToEnumProperty { get; set; } = null!;
    
    public string? TestNullableEnumToStringProperty { get; set; } = null!;
    
    public TestEnumeration? TestNullableStringToEnumProperty { get; set; } = null!;
    
    public TestDifferentEnumeration? TestNullableEnumToDifferentEnumProperty { get; set; } = null!;
}