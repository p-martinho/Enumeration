using System.Text.Json;
using System.Text.Json.Serialization;

namespace PM.Enumeration.SystemTextJson
{
    internal class EnumerationDynamicJsonConverter<T> : JsonConverter<T> where T : EnumerationDynamic<T>, new()
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return EnumerationDynamic<T>.GetFromValueOrNew(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}