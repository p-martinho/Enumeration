using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PMart.Enumeration.EFCore;

/// <summary>
/// The converter for EFCore to convert to/from <see cref="Enumeration{T}"/>.
/// </summary>
/// <typeparam name="T">The type to convert.</typeparam>
/// <remarks>For classes of type <see cref="EnumerationDynamic{T}"/> use the <see cref="EnumerationDynamicConverter{T}"/> instead.</remarks>
public class EnumerationConverter<T> : ValueConverter<T?, string?> where T : Enumeration<T>
{
    /// <summary>
    /// Initializes a new instance of the class <see cref="EnumerationConverter{T}"/>.
    /// </summary>
    public EnumerationConverter() : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    private static Expression<Func<T?, string?>> GetConvertToProviderExpression()
    {
        return item => item == null ? null : item.Value;
    }

    private static Expression<Func<string?, T?>> GetConvertFromProviderExpression()
    {
        return key => Enumeration<T>.GetFromValueOrDefault(key);
    }
}