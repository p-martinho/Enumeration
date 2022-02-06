using PMart.Enumeration;

namespace Enumeration.Tests.EnumerationClasses;

internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));
    public static readonly TestEnumeration CodeAClone = new(nameof(CodeA));
    public static readonly TestEnumeration CodeAUpper = new(nameof(CodeA).ToUpper());
    public static readonly TestEnumeration CodeB = new(nameof(CodeB));

    private TestEnumeration(string value) : base(value)
    {
    }
}