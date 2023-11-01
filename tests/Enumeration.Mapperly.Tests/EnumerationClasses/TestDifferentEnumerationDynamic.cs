using PMart.Enumeration;

namespace Enumeration.Mapperly.Tests.EnumerationClasses;

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