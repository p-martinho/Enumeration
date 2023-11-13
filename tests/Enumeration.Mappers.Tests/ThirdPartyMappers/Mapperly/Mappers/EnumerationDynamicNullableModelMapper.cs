using Enumeration.Mappers.Tests.EnumerationClasses;
using Enumeration.Mappers.Tests.ThirdPartyMappers.Models;
using PMart.Enumeration.Mappers;
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Mapperly.Mappers;

[Mapper]
[UseStaticMapper(typeof(StringEnumerationDynamicMapper<TestEnumerationDynamic>))]
[UseStaticMapper(typeof(EnumerationDynamicMapper<TestEnumerationDynamic, TestDifferentEnumerationDynamic>))]
internal partial class EnumerationDynamicNullableModelMapper
{
    public partial EnumerationDynamicNullableDestinationModel SourceToDestination(EnumerationDynamicNullableSourceModel sourceModel);
}