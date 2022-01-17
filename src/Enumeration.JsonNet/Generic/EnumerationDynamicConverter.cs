using Newtonsoft.Json;

namespace PMart.Enumeration.JsonNet.Generic;

/// <summary>
/// The converter for Json.NET to convert to/from <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
public class EnumerationDynamicConverter<T> : JsonConverter<T> where T : EnumerationDynamic<T>, new()
{
    /// <inheritdoc />
    public override bool CanRead => true;

    /// <inheritdoc />
    public override bool CanWrite => true;

    /// <inheritdoc />
    public override T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return reader.TokenType switch
        {
            JsonToken.Null => null,
            JsonToken.String => EnumerationDynamic<T>.GetFromValueOrNew((string?) reader.Value!),
            _ => throw new JsonSerializationException(
                $"Unexpected token {reader.TokenType} when parsing an Enumeration.")
        };
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.Value);
    }
}