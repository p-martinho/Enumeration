using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PM.Enumeration.EFCore
{
    public class EnumerationDynamicConverter<T> : ValueConverter<T?, string?> where T : EnumerationDynamic<T>, new()
    {
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
}