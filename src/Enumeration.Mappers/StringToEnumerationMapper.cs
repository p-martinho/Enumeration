using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert from <c>string</c> to a <see cref="Enumeration{TTarget}"/>.
/// </summary>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
/// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="StringToEnumerationDynamicMapper{T}"/> instead.</remarks>
public static class StringToEnumerationMapper<TTarget>
    where TTarget : Enumeration<TTarget>
{
    /// <summary>
    /// Maps from a <c>string</c> value to a <see cref="Enumeration{TTarget}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <returns>The <see cref="Enumeration{TTarget}"/> with the value, or <c>null</c> if not found or if value is <c>null</c>.</returns>
    public static TTarget MapToEnumeration(string sourceString) => sourceString.MapToEnumeration<TTarget>()!;
}