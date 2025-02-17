namespace PMart.Enumeration.Generator.Models;

/// <summary>
/// An equatable dictionary, with <c>string</c> keys and <c>string</c> values.
/// </summary>
/// <seealso cref="Dictionary{TKey,TValue}"/>
/// <seealso cref="IEquatable{T}"/>
public class EquatableStringDictionary : Dictionary<string, string>, IEquatable<EquatableStringDictionary>
{
    /// <inheritdoc/>
    public bool Equals(EquatableStringDictionary? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (Count != other.Count)
        {
            return false;
        }

        foreach (var keyValuePair in this)
        {
            if (!other.TryGetValue(keyValuePair.Key, out var otherValue) ||
                !string.Equals(otherValue, keyValuePair.Value, StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is EquatableStringDictionary other && Equals(other);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        HashCode hashCode = default;

        foreach (var item in this.OrderBy(kvp => kvp.Key))
        {
            hashCode.Add(item.Key);
            hashCode.Add(item.Value);
        }

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Checks whether two <see cref="EquatableStringDictionary"/> values are the same.
    /// </summary>
    /// <param name="left">The first <see cref="EquatableStringDictionary"/> value.</param>
    /// <param name="right">The second <see cref="EquatableStringDictionary"/> value.</param>
    /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are equal.</returns>
    public static bool operator ==(EquatableStringDictionary? left, EquatableStringDictionary? right)
    {
        return (left is null && right is null) || (left is not null && left.Equals(right));
    }

    /// <summary>
    /// Checks whether two <see cref="EquatableStringDictionary"/> values are not the same.
    /// </summary>
    /// <param name="left">The first <see cref="EquatableStringDictionary"/> value.</param>
    /// <param name="right">The second <see cref="EquatableStringDictionary"/> value.</param>
    /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are not equal.</returns>
    public static bool operator !=(EquatableStringDictionary? left, EquatableStringDictionary? right)
    {
        return (left is null && right is not null) || (left is not null && !left.Equals(right));
    }
}