using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationDynamicSourceModel
{
    public TestEnumerationDynamic TestEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToStringProperty { get; set; } = null!;
    
    public string TestStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
}