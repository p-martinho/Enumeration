namespace PMart.Enumeration.Mappers.Extensions;

/// <summary>
/// The extensions to map to/from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>.
/// </summary>
public static class EnumerationExtensions
{
    /// <summary>
    /// Maps from a <c>string</c> value to a <see cref="Enumeration{TTarget}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <typeparam name="TTarget">The target type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
    /// <returns>The <see cref="Enumeration{TTarget}"/> with the value, or <c>null</c> if not found or if the value is <c>null</c>.</returns>
    public static TTarget? MapToEnumeration<TTarget>(this string? sourceString) where TTarget : Enumeration<TTarget>
    {
        return Enumeration<TTarget>.GetFromValueOrDefault(sourceString);
    }
    
    /// <summary>
    /// Maps from a <c>string</c> value to a <see cref="EnumerationDynamic{TTarget}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <typeparam name="TTarget">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
    /// <returns>The <see cref="EnumerationDynamic{TTarget}"/> with the value, or <c>null</c> if the value is <c>null</c>.</returns>
    public static TTarget? MapToEnumerationDynamic<TTarget>(this string? sourceString) where TTarget : EnumerationDynamic<TTarget>, new()
    {
        return EnumerationDynamic<TTarget>.GetFromValueOrNew(sourceString);
    }
    
    /// <summary>
    /// Maps from a <see cref="Enumeration{TSource}"/> to a different type of <see cref="Enumeration{TTarget}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The enumeration to map from.</param>
    /// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
    /// <typeparam name="TTarget">The target type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
    /// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="MapToEnumerationDynamic{TSource, TTarget}"/> instead.</remarks>
    /// <returns>The <see cref="Enumeration{TTarget}"/> with the value of the source enumeration, or <c>null</c> if not found or if source enumeration is <c>null</c>.</returns>
    public static TTarget? MapToEnumeration<TSource, TTarget>(this TSource? sourceEnumeration)
        where TSource : Enumeration<TSource>
        where TTarget : Enumeration<TTarget>
    {
        return Enumeration<TTarget>.GetFromValueOrDefault(sourceEnumeration?.Value);
    }
    
    /// <summary>
    /// Maps from a type of <see cref="Enumeration{TSource}"/> or <see cref="EnumerationDynamic{TSource}"/> to a different type of <see cref="EnumerationDynamic{TTarget}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The enumeration to map from.</param>
    /// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
    /// <typeparam name="TTarget">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
    /// <returns>The <see cref="EnumerationDynamic{TTarget}"/> with the value of the source enumeration, or <c>null</c> if source enumeration is <c>null</c>.</returns>
    public static TTarget? MapToEnumerationDynamic<TSource, TTarget>(this TSource? sourceEnumeration)
        where TSource : Enumeration<TSource>
        where TTarget : EnumerationDynamic<TTarget>, new()
    {
        return Enumeration<TTarget>.GetFromValueOrDefault(sourceEnumeration?.Value);
    }
}