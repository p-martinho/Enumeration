using PMart.Enumeration.Mappers.Extensions;

namespace PMart.Enumeration.Mappers;

/// <summary>
/// The mapper to convert from <c>string</c> to <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="TTarget">The target type (must be derived from <see cref="EnumerationDynamic{T}"/>).</typeparam>
public static class StringToEnumerationDynamicMapper<TTarget>
    where TTarget : EnumerationDynamic<TTarget>, new()
{
    /// <summary>
    /// Maps from a <c>string</c> value to a <see cref="EnumerationDynamic{TTarget}"/>.
    /// </summary>
    /// <param name="sourceString">The <c>string</c> value to convert.</param>
    /// <returns>The <see cref="EnumerationDynamic{TTarget}"/> with the value, or <c>null</c> if the value is <c>null</c>.</returns>
    public static TTarget MapToEnumerationDynamic(string sourceString) =>
        sourceString.MapToEnumerationDynamic<TTarget>()!;
}