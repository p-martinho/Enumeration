using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.Models;

internal class TestEnumerationDynamicDestinationModel
{
    public TestEnumerationDynamic TestEnumDynamicToEnumDynamicProperty { get; set; } = null!;
    
    public string TestEnumDynamicToStringProperty { get; set; } = null!;
    
    public TestEnumerationDynamic TestStringToEnumDynamicProperty { get; set; } = null!;
    
    public TestDifferentEnumerationDynamic TestEnumDynamicToDifferentEnumDynamicProperty { get; set; } = null!;
}