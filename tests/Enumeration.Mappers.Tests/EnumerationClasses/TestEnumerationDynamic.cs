using PMart.Enumeration;

namespace Enumeration.Mappers.Tests.EnumerationClasses;

internal class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
{
    public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

    public TestEnumerationDynamic()
    {
    }

    private TestEnumerationDynamic(string value) : base(value)
    {
    }
}