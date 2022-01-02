using System.Text.Json.Serialization;
using PM.Enumeration;
using PM.Enumeration.SystemTextJson;

namespace Enumeration.SystemTextJson.Tests.EnumerationClasses;

[JsonConverter(typeof(EnumerationConverterFactory))]
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