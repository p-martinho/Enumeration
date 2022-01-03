using Newtonsoft.Json;
using PM.Enumeration.Extensions;

namespace PM.Enumeration.JsonNet;

/// <summary>
/// The converter for Json.NET to convert to/from <see cref="Enumeration{T}"/>.
/// </summary>
/// <remarks>If the object type is derived from <see cref="EnumerationDynamic{T}"/>, it will use the method <see cref="EnumerationDynamic{T}.GetFromValueOrNew"/>.</remarks>
public class EnumerationConverter : JsonConverter
{
    private const string EnumerationGetFromValueOrDefaultMethodName = "GetFromValueOrDefault";
    private const string EnumerationDynamicGetFromValueOrNewMethodName = "GetFromValueOrNew";

    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsAssignableToEnumeration();
    }

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return reader.TokenType switch
        {
            JsonToken.Null => null,
            JsonToken.String => GetEnumerationFromValue((string?) reader.Value, objectType),
            _ => throw new JsonSerializationException(
                $"Unexpected token {reader.TokenType} when parsing an Enumeration.")
        };
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }

    private object? GetEnumerationFromValue(string? value, Type objectType)
    {
        try
        {
            var enumerationType = objectType.IsAssignableToEnumerationDynamic()
                ? typeof(EnumerationDynamic<>)
                : typeof(Enumeration<>);

            var methodName = enumerationType == typeof(Enumeration<>)
                ? EnumerationGetFromValueOrDefaultMethodName
                : EnumerationDynamicGetFromValueOrNewMethodName;

            var methodInfo = enumerationType
                .MakeGenericType(objectType)
                .GetMethod(methodName);

            return methodInfo!.Invoke(null, new object?[] {value});
        }
        catch (Exception ex)
        {
            throw new JsonSerializationException($"Error converting the value '{value}' to an Enumeration of type {objectType}.", ex);
        }
    }
}