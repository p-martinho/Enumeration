using System.Text.Json;
using System.Text.Json.Serialization;

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
        var result = IsAssignableToGenericType(typeToConvert, typeof(Enumeration<>));

        return result;
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert,
        JsonSerializerOptions options)
    {
        var converterType = IsAssignableToGenericType(typeToConvert, typeof(EnumerationDynamic<>))
            ? typeof(EnumerationDynamicConverter<>)
            : typeof(EnumerationConverter<>);

        return (JsonConverter) Activator.CreateInstance(converterType.MakeGenericType(typeToConvert))!;
    }

    private bool IsAssignableToGenericType(Type givenType, Type genericType)
    {
        if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }

        var baseType = givenType.BaseType;

        if (baseType == null)
        {
            return false;
        }

        return IsAssignableToGenericType(baseType, genericType);
    }
}