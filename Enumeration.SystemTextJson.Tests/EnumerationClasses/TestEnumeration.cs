using System.Text.Json.Serialization;
using PM.Enumeration;
using PM.Enumeration.SystemTextJson;

namespace Enumeration.SystemTextJson.Tests.EnumerationClasses;

[JsonConverter(typeof(EnumerationConverterFactory))]
internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));

    private TestEnumeration(string value) : base(value)
    {
    }
}