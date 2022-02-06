using PMart.Enumeration;

namespace Enumeration.Tests.EnumerationClasses;

internal class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
{
    public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

    public static TestEnumerationDynamic IncorrectInstantiation() => new() { Value = null! };

    public TestEnumerationDynamic()
    {
    }

    private TestEnumerationDynamic(string value) : base(value)
    {
    }
}