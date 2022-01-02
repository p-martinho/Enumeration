namespace PM.Enumeration.Extensions;

public static class EnumerationExtensions
{
    /// <summary>
    /// Indicates whether the specified type is derived, directly or indirectly, from <see cref="Enumeration{T}"/> type.
    /// </summary>
    /// <param name="typeToEvaluate">The type to evaluate for.</param>
    /// <returns>
    /// <c>true</c> if the specified type is derived from <see cref="Enumeration{T}"/>; <c>false</c> otherwise.
    /// </returns>
    public static bool IsAssignableToEnumeration(this Type? typeToEvaluate)
    {
        return typeToEvaluate.IsAssignableToGenericType(typeof(Enumeration<>));
    }
    
    /// <summary>
    /// Indicates whether the specified type is derived, directly or indirectly, from <see cref="EnumerationDynamic{T}"/> type.
    /// </summary>
    /// <param name="typeToEvaluate">The type to evaluate for.</param>
    /// <returns>
    /// <c>true</c> if the specified type is derived from <see cref="EnumerationDynamic{T}"/>; <c>false</c> otherwise.
    /// </returns>
    public static bool IsAssignableToEnumerationDynamic(this Type? typeToEvaluate)
    {
        return typeToEvaluate.IsAssignableToGenericType(typeof(EnumerationDynamic<>));
    }
    
    private static bool IsAssignableToGenericType(this Type? typeToEvaluate, Type genericType)
    {
        if (typeToEvaluate == null)
        {
            return false;
        }
        
        if (typeToEvaluate.IsGenericType && typeToEvaluate.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }

        var baseType = typeToEvaluate.BaseType;

        if (baseType == null)
        {
            return false;
        }

        return baseType.IsAssignableToGenericType(genericType);
    }
}