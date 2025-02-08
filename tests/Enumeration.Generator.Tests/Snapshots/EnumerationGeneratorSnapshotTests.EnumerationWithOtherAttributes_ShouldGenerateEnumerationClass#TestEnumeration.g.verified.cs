//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(ValueForCodeA);
    public static readonly TestEnumeration CodeB = new(CodeBb);

    private TestEnumeration(string value) : base(value)
    {
    }
}