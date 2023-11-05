using Enumeration.Mappers.Tests.EnumerationClasses;
using Enumeration.Mappers.Tests.Models;
using PMart.Enumeration.Mappers;
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mappers.Tests.Mappers.Mapperly;

[Mapper]
[UseStaticMapper(typeof(StringToEnumerationMapper<TestEnumeration>))]
[UseStaticMapper(typeof(EnumerationMapper<TestEnumeration, TestDifferentEnumeration>))]
[UseStaticMapper(typeof(StringToEnumerationDynamicMapper<TestEnumerationDynamic>))]
[UseStaticMapper(typeof(EnumerationDynamicMapper<TestEnumerationDynamic, TestDifferentEnumerationDynamic>))]
internal partial class TestEnumerationModelMapper
{
    public partial TestEnumerationDestinationModel SourceToDestination(TestEnumerationSourceModel sourceModel);
}