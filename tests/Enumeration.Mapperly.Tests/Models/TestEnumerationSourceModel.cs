using Enumeration.Mapperly.Tests.EnumerationClasses;

namespace Enumeration.Mapperly.Tests.Models;

internal class TestEnumerationSourceModel
{
    public TestEnumeration TestEnumToEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToStringProperty { get; set; } = null!;
    
    public string TestStringToEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToDifferentEnumProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToStringProperty { get; set; } = null!;
    
    public string TestStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
}