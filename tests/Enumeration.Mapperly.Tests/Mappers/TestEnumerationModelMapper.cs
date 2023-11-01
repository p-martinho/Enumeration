using Enumeration.Mapperly.Tests.EnumerationClasses;
using Enumeration.Mapperly.Tests.Models;
using PMart.Enumeration.Mapperly;
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mapperly.Tests.Mappers;

[Mapper]
[UseStaticMapper(typeof(StringToEnumerationMapper<TestEnumeration>))]
[UseStaticMapper(typeof(EnumerationMapper<TestEnumeration, TestDifferentEnumeration>))]
[UseStaticMapper(typeof(StringToEnumerationDynamicMapper<TestEnumerationDynamic>))]
[UseStaticMapper(typeof(EnumerationDynamicMapper<TestEnumerationDynamic, TestDifferentEnumerationDynamic>))]
internal partial class TestEnumerationModelMapper
{
    public partial TestEnumerationDestinationModel SourceToDestination(TestEnumerationSourceModel sourceModel);
}