using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationDynamicNullableSourceModel
{
    public TestEnumerationDynamic TestEnumDynamicToNullableEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToNullableStringProperty { get; set; } = null!;
    
    public string TestStringToNullableEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToDifferentNullableEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToStringProperty { get; set; }
    
    public string? TestNullableStringToEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToDifferentEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToNullableEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToNullableStringProperty { get; set; }
    
    public string? TestNullableStringToNullableEnumDynamicProperty { get; set; }
    
    public TestEnumerationDynamic? TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty { get; set; }
}