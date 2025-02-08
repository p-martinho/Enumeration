//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(ValueForCodeA);
    public static readonly TestEnumeration CodeB = new(ValueForCodeB);
    public static readonly TestEnumeration CodeC = new(ValueForCodeC);

    private TestEnumeration(string value) : base(value)
    {
    }
}