using PM.Enumeration;

namespace Enumeration.SystemTextJson.Tests.EnumerationClasses;

internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));

    private TestEnumeration(string value) : base(value)
    {
    }
}