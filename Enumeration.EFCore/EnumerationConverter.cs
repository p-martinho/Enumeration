using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PM.Enumeration.EFCore
{
    public class EnumerationConverter<T> : ValueConverter<T?, string?> where T : Enumeration<T>
    {
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
}