//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class TestEnumeration : EnumerationDynamic<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(ValueForCodeA);

    public TestEnumeration()
    {
    }

    private TestEnumeration(string value) : base(value)
    {
    }
}