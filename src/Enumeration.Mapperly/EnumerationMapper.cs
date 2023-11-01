namespace PMart.Enumeration.Mapperly;

/// <summary>
/// The mapper for Mapperly convert from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="TSource">The source type (must be derived from <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/>).</typeparam>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="Enumeration{T}"/>).</typeparam>
/// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="EnumerationDynamicMapper{TSource, TTarget}"/> instead.</remarks>
public static class EnumerationMapper<TSource, TTarget>
    where TSource : Enumeration<TSource>
    where TTarget : Enumeration<TTarget>
{
    /// <summary>
    /// Maps from one type of <see cref="Enumeration{T}"/> or <see cref="EnumerationDynamic{T}"/> to a different type of <see cref="Enumeration{T}"/>.
    /// </summary>
    /// <param name="sourceEnumeration">The source enumeration to convert.</param>
    /// <returns>The converted enumeration.</returns>
    public static TTarget MapEnumeration(TSource sourceEnumeration) =>
        Enumeration<TTarget>.GetFromValueOrDefault(sourceEnumeration.Value)!;
}