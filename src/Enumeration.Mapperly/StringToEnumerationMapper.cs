namespace PMart.Enumeration.Mapperly;

/// <summary>
/// The mapper for Mapperly convert from <c>string</c> to <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="T">The target type.</typeparam>
/// <remarks>For enumerations of type <see cref="EnumerationDynamic{T}"/> use the <see cref="StringToEnumerationDynamicMapper{T}"/> instead.</remarks>
public static class StringToEnumerationMapper<T>
    where T : Enumeration<T>
{
    /// <summary>
    /// Maps the <c>string</c> to <see cref="Enumeration{T}"/>.
    /// </summary>
    /// <param name="sourceString">The value to convert.</param>
    /// <returns>The enumeration.</returns>
    public static T MapEnumeration(string sourceString) =>
        Enumeration<T>.GetFromValueOrDefault(sourceString)!;
}