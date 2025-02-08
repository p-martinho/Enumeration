//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeAa = new(ValueForCodeA);
    public static readonly TestEnumeration CodeBb = new(CodeB);

    private TestEnumeration(string value) : base(value)
    {
    }
}