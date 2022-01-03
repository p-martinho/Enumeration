using System.Text.Json;
using System.Text.Json.Serialization;
using PM.Enumeration.Extensions;
using PM.Enumeration.SystemTextJson.Generic;

namespace PM.Enumeration.SystemTextJson;

/// <summary>
/// The converter factory for System.Text.Json to convert to/from <see cref="Enumeration{T}"/>.
/// </summary>
/// <remarks>Deserializing to <see cref="EnumerationDynamic{T}"/> will create a new instance if there is not any declared instance with the value.</remarks>
public class EnumerationConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableToEnumeration();
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert,
        JsonSerializerOptions options)
    {
        var converterType = typeToConvert.IsAssignableToEnumerationDynamic()
            ? typeof(EnumerationDynamicConverter<>)
            : typeof(EnumerationConverter<>);

        return (JsonConverter) Activator.CreateInstance(converterType.MakeGenericType(typeToConvert))!;
    }
}