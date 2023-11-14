using Enumeration.Mappers.Tests.EnumerationClasses;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Models;

internal class EnumerationSourceModel
{
    public TestEnumeration TestEnumToEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToStringProperty { get; set; } = null!;
    
    public string TestStringToEnumProperty { get; set; } = null!;
    
    public TestEnumeration TestEnumToDifferentEnumProperty { get; set; } = null!;
}