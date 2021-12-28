using Newtonsoft.Json;

namespace PM.Enumeration.JsonNet;

/// <summary>
/// The converter for Json.NET to convert to/from <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
/// <remarks>For classes of type <see cref="EnumerationDynamic{T}"/> use the <see cref="EnumerationDynamicConverter{T}"/> instead.</remarks>
public class EnumerationConverter<T> : JsonConverter<T> where T : Enumeration<T>
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
            JsonToken.String => Enumeration<T>.GetFromValueOrDefault((string) reader.Value!),
            _ => throw new JsonSerializationException(
                $"Unexpected token {reader.TokenType} when parsing an enumeration.")
        };
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteValue(value.Value);
        }
    }
}