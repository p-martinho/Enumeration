using PMart.Enumeration;

namespace Enumeration.Mapperly.Tests.EnumerationClasses;

internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));

    private TestEnumeration(string value) : base(value)
    {
    }
}