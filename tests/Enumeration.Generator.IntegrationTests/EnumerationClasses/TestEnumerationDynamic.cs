using PMart.Enumeration.Generator;

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration(IsDynamic = true)]
public partial class TestEnumerationDynamic
{
    private static readonly string ValueForCodeA = "CodeA";
}