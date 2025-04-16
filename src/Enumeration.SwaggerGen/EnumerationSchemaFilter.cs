using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PMart.Enumeration.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PMart.Enumeration.SwaggerGen;

/// <summary>
/// Implements <see cref="ISchemaFilter"/> to transform <see cref="Enumeration{T}"/> schema to <see cref="Enum"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EnumerationSchemaFilter : ISchemaFilter
{
    private const string PropertyValueName = "Value";

    /// <inheritdoc />
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsAssignableToEnumeration())
        {
            return;
        }

        var enumerationMembers = context.Type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(field => field.FieldType == context.Type);

        var enumerationMembersValues = enumerationMembers
            .Select(GetValueFromEnumerationMember)
            .Where(v => v is not null);

        schema.Enum = enumerationMembersValues.Select(v => new OpenApiString(v)).ToList<IOpenApiAny>();
        schema.Type = "string";
        schema.AllOf = null;
        schema.Properties = null;
    }

    private static string? GetValueFromEnumerationMember(FieldInfo fieldInfo)
    {
        var propertyInfo = typeof(Enumeration<>)
            .MakeGenericType(fieldInfo.FieldType)
            .GetProperty(PropertyValueName);

        if (propertyInfo is null)
        {
            return null;
        }

        var enumerationMember = fieldInfo.GetValue(null);

        return propertyInfo.GetValue(enumerationMember) as string;
    }
}