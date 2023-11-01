namespace PMart.Enumeration.Mapperly;

/// <summary>
/// The mapper for Mapperly convert from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
public static class EnumerationDynamicMapper<TSource, TTarget>
    where TSource : Enumeration<TSource>
    where TTarget : EnumerationDynamic<TTarget>, new()
{
    /// <summary>
    /// Maps from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="EnumerationDynamic{T}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The source enumeration to convert.</param>
    /// <returns>The converted enumeration.</returns>
    public static TTarget MapEnumerationDynamic(TSource sourceEnumeration) =>
        EnumerationDynamic<TTarget>.GetFromValueOrNew(sourceEnumeration.Value)!;
}