using Enumeration.Mappers.Tests.EnumerationClasses;
using Enumeration.Mappers.Tests.ThirdPartyMappers.Models;
using PMart.Enumeration.Mappers;
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Mapperly.Mappers;

[Mapper]
[UseStaticMapper(typeof(StringEnumerationMapper<TestEnumeration>))]
[UseStaticMapper(typeof(EnumerationMapper<TestEnumeration, TestDifferentEnumeration>))]
internal partial class EnumerationNullableModelMapper
{
    public partial EnumerationNullableDestinationModel SourceToDestination(EnumerationNullableSourceModel sourceModel);
}