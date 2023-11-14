using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert between <c>string</c> and <see cref="Enumeration{TTarget}"/>.
/// </summary>
/// <typeparam name="T">The enumeration type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
/// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="StringEnumerationDynamicMapper{T}"/> instead.</remarks>
public static class StringEnumerationMapper<T>
    where T : Enumeration<T>
{
    /// <summary>
    /// Maps from a <see cref="Enumeration{T}"/> to a <c>string</c>.
    /// </summary>
    /// <param name="sourceEnumeration">The <see cref="Enumeration{T}"/> to convert.</param>
    /// <returns>The <c>string</c> value, or <c>null</c> if enumeration is <c>null</c>.</returns>
    public static string MapToString(T sourceEnumeration) => sourceEnumeration.MapToString()!;
    
    /// <summary>
    /// Maps from a <c>string</c> to a <see cref="Enumeration{T}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <returns>The <see cref="Enumeration{T}"/> with the value, or <c>null</c> if not found or if value is <c>null</c>.</returns>
    public static T MapToEnumeration(string sourceString) => sourceString.MapToEnumeration<T>()!;
}