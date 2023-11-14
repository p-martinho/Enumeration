using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert between <c>string</c> and <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="T">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
public static class StringEnumerationDynamicMapper<T>
    where T : EnumerationDynamic<T>, new()
{
    /// <summary>
    /// Maps from a <see cref="EnumerationDynamic{T}"/> to a <c>string</c>.
    /// </summary>
    /// <param name="sourceEnumeration">The <see cref="EnumerationDynamic{T}"/> to convert.</param>
    /// <returns>The <c>string</c> value, or <c>null</c> if enumeration is <c>null</c>.</returns>
    public static string MapToString(T sourceEnumeration) => sourceEnumeration.MapToString()!;
    
    /// <summary>
    /// Maps from a <c>string</c> value to a <see cref="EnumerationDynamic{T}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <returns>The <see cref="EnumerationDynamic{T}"/> with the value, or <c>null</c> if the value is <c>null</c>.</returns>
    public static T MapToEnumerationDynamic(string sourceString) => sourceString.MapToEnumerationDynamic<T>()!;
}