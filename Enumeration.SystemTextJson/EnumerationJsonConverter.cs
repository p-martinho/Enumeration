using System.Text.Json;
using System.Text.Json.Serialization;

namespace PM.Enumeration.SystemTextJson
{
    public class EnumerationJsonConverter<T> : JsonConverter<T> where T : Enumeration<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Enumeration<T>.GetFromValueOrDefault(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}