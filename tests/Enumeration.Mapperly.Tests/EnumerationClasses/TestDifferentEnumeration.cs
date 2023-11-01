using PMart.Enumeration;

namespace Enumeration.Mapperly.Tests.EnumerationClasses;

internal class TestDifferentEnumeration : Enumeration<TestDifferentEnumeration>
{
    public static readonly TestDifferentEnumeration CodeA = new(nameof(CodeA));

    private TestDifferentEnumeration(string value) : base(value)
    {
    }
}