using Newtonsoft.Json;
using PM.Enumeration;
using PM.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Tests.EnumerationClasses;

[JsonConverter(typeof(EnumerationDynamicConverter<TestEnumerationDynamic>))]
internal class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
{
    public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

    public TestEnumerationDynamic()
    {
    }

    private TestEnumerationDynamic(string value) : base(value)
    {
    }
}