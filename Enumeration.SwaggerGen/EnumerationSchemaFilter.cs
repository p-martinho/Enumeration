using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PM.Enumeration.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PM.Enumeration.SwaggerGen;

/// <summary>
/// Implements <see cref="ISchemaFilter"/> to transform <see cref="Enumeration{T}"/> schema to <see cref="Enum"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EnumerationSchemaFilter : ISchemaFilter
{
    /// <inheritdoc />
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsAssignableToEnumeration())
        {
            return;
        }

        var fields = context.Type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.Name)
            .ToList();

        schema.Enum = fields.ConvertAll<IOpenApiAny>(fieldName => new OpenApiString(fieldName));
        schema.Type = "string";
        schema.AllOf = null;
        schema.Properties = null;
    }
}