using System.Text.Json;
using System.Text.Json.Serialization;

namespace PM.Enumeration.SystemTextJson;

/// <summary>
/// The converter for System.Text.Json to convert to/from <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
internal class EnumerationDynamicConverter<T> : JsonConverter<T> where T : EnumerationDynamic<T>, new()
{
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return EnumerationDynamic<T>.GetFromValueOrNew(reader.GetString()!);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}