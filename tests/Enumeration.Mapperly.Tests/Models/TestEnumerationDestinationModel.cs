using Enumeration.Mapperly.Tests.EnumerationClasses;

namespace Enumeration.Mapperly.Tests.Models;

internal class TestEnumerationDestinationModel
{
    public TestEnumeration TestEnumToEnumProperty { get; set; } = null!;
    
    public string TestEnumToStringProperty { get; set; } = null!;
    
    public TestEnumeration TestStringToEnumProperty { get; set; } = null!;
    
    public TestDifferentEnumeration TestEnumToDifferentEnumProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public string TestEnumDynamicToStringProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestDifferentEnumerationDynamic TestEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
}