using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
public static class EnumerationDynamicMapper<TSource, TTarget>
    where TSource : Enumeration<TSource>
    where TTarget : EnumerationDynamic<TTarget>, new()
{
    /// <summary>
    /// Maps from a type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="EnumerationDynamic{T}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The enumeration to map from.</param>
    /// <returns>The <see cref="EnumerationDynamic{TTarget}"/> with the value of the source enumeration, or <c>null</c> if source enumeration is <c>null</c>.</returns>
    public static TTarget? MapToEnumerationDynamic(TSource? sourceEnumeration) =>
        sourceEnumeration.MapToEnumerationDynamic<TSource, TTarget>();
}