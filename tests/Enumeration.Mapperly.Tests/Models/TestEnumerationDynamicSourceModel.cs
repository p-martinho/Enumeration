using Enumeration.Mapperly.Tests.EnumerationClasses;

namespace Enumeration.Mapperly.Tests.Models;

internal class TestEnumerationDynamicSourceModel
{
    public TestEnumerationDynamic TestEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToStringProperty { get; set; } = null!;
    
    public string TestStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
}