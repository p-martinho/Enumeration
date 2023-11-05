using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
/// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="EnumerationDynamicMapper{TSource, TTarget}"/> instead.</remarks>
public static class EnumerationMapper<TSource, TTarget>
    where TSource : Enumeration<TSource>
    where TTarget : Enumeration<TTarget>
{
    /// <summary>
    /// Maps from a <see cref="Enumeration{T}"/> to a different type of <see cref="Enumeration{T}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The enumeration to map from.</param>
    /// <returns>The <see cref="Enumeration{TTarget}"/> with the value of the source enumeration, or <c>null</c> if not found or if source enumeration is <c>null</c>.</returns>
    public static TTarget MapToEnumeration(TSource sourceEnumeration) =>
        sourceEnumeration.MapToEnumeration<TSource, TTarget>()!;
}