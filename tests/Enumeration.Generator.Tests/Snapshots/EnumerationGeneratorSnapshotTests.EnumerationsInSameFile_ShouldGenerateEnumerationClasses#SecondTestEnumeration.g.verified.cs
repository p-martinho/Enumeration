//HintName: SecondTestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class SecondTestEnumeration : Enumeration<SecondTestEnumeration>
{
    public static readonly SecondTestEnumeration CodeA = new(ValueForCodeA);

    private SecondTestEnumeration(string value) : base(value)
    {
    }
}