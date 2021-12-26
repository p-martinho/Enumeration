using System.Text.Json;
using System.Text.Json.Serialization;

namespace PM.Enumeration.SystemTextJson
{
    public class EnumerationJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var result = IsAssignableToGenericType(typeToConvert, typeof(Enumeration<>));

            return result;
        }

        public override JsonConverter CreateConverter(Type typeToConvert,
            JsonSerializerOptions options)
        {
            var converterType = IsAssignableToGenericType(typeToConvert, typeof(EnumerationDynamic<>))
                ? typeof(EnumerationDynamicJsonConverter<>)
                : typeof(EnumerationJsonConverter<>);

            return (JsonConverter)Activator.CreateInstance(converterType.MakeGenericType(typeToConvert))!;
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
}