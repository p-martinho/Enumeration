using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationDynamicNullableDestinationModel
{
    public TestEnumerationDynamic? TestEnumDynamicToNullableEnumDynamicProperty { get; set; }
    
    public string? TestEnumDynamicToNullableStringProperty { get; set; }
    
    public TestEnumerationDynamic? TestStringToNullableEnumDynamicProperty { get; set; }
    
    public TestDifferentEnumerationDynamic? TestEnumDynamicToDifferentNullableEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic TestNullableEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public string TestNullableEnumDynamicToStringProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestNullableStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestDifferentEnumerationDynamic TestNullableEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToNullableEnumDynamicProperty { get; set; }
    
    public string? TestNullableEnumDynamicToNullableStringProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableStringToNullableEnumDynamicProperty { get; set; }
    
    public TestDifferentEnumerationDynamic? TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty { get; set; }
}