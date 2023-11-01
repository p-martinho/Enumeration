namespace PMart.Enumeration.Mapperly;

/// <summary>
/// The mapper for Mapperly convert from <c>string</c> to <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="T">The target type.</typeparam>
public static class StringToEnumerationDynamicMapper<T>
    where T : EnumerationDynamic<T>, new()
{
    /// <summary>
    /// Maps the <c>string</c> to <see cref="EnumerationDynamic{T}"/>.
    /// </summary>
    /// <param name="sourceString">The value to convert.</param>
    /// <returns>The enumeration.</returns>
    public static T MapEnumerationDynamic(string sourceString) =>
        EnumerationDynamic<T>.GetFromValueOrNew(sourceString)!;
}