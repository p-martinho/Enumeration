//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source.InnerNamespace.MostInnerNamespace;

public partial class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(ValueForCodeA);

    private TestEnumeration(string value) : base(value)
    {
    }
}