using System.Text.Json;
using System.Text.Json.Serialization;

namespace PM.Enumeration.SystemTextJson.Generic;

/// <summary>
/// The converter for System.Text.Json to convert to/from <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
/// <remarks>For classes of type <see cref="EnumerationDynamic{T}"/> use the <see cref="EnumerationDynamicConverter{T}"/> instead.</remarks>
public class EnumerationConverter<T> : JsonConverter<T> where T : Enumeration<T>
{
    /// <inheritdoc />
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enumeration<T>.GetFromValueOrDefault(reader.GetString());
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}