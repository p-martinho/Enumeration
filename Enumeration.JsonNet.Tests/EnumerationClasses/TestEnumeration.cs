using Newtonsoft.Json;
using PM.Enumeration;
using PM.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Tests.EnumerationClasses;

[JsonConverter(typeof(EnumerationConverter<TestEnumeration>))]
internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));

    private TestEnumeration(string value) : base(value)
    {
    }
}