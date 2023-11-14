using PMart.Enumeration;

namespace Enumeration.Mappers.Tests.EnumerationClasses;

internal class TestDifferentEnumerationDynamic : EnumerationDynamic<TestDifferentEnumerationDynamic>
{
    public static readonly TestDifferentEnumerationDynamic CodeA = new(nameof(CodeA));

    public TestDifferentEnumerationDynamic()
    {
    }
    
    private TestDifferentEnumerationDynamic(string value) : base(value)
    {
    }
}