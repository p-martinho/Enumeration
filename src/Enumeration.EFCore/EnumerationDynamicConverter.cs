using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PMart.Enumeration.EFCore;

/// <summary>
/// The converter for EFCore to convert to/from <see cref="EnumerationDynamic{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
public class EnumerationDynamicConverter<T> : ValueConverter<T?, string?> where T : EnumerationDynamic<T>, new()
{
    /// <summary>
    /// Initializes a new instance of the class <see cref="EnumerationDynamicConverter{T}"/>.
    /// </summary>
    public EnumerationDynamicConverter() : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    private static Expression<Func<T?, string?>> GetConvertToProviderExpression()
    {
        return item => item == null ? null : item.Value;
    }

    private static Expression<Func<string?, T?>> GetConvertFromProviderExpression()
    {
        return key => EnumerationDynamic<T>.GetFromValueOrNew(key!);
    }
}