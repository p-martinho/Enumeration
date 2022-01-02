using System.Collections.Immutable;
using System.Reflection;

namespace PM.Enumeration;

/// <summary>
/// A base class to implement enumeration classes.
/// </summary>
/// <typeparam name="T">The type that is inheriting from this class.</typeparam>
public abstract class Enumeration<T> : IEquatable<Enumeration<T>> where T : Enumeration<T>
{
    private static readonly Lazy<ImmutableHashSet<T>> MembersLazy = new(BuildMembersHashSet);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <value>
    /// A <see cref="String"/> that is the value held by the instance of <see cref="T"/>.
    /// </value>
    public string Value { get; init; } = null!;

    /// <summary>
    /// Initializes a new instance of the class <see cref="Enumeration{T}"/>.
    /// </summary>
    protected Enumeration()
    {
    }

    /// <summary>
    /// Initializes a new instance of the class <see cref="Enumeration{T}"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    protected Enumeration(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets a collection containing all the declared instances of <see cref="T"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="IEnumerable{T}"/> containing all the declared instances of <see cref="T"/>.
    /// </returns>
    /// <remarks>
    /// Retrieves the instances referenced by public static read-only fields in the <see cref="T"/> class.
    /// </remarks>
    public static IEnumerable<T> GetMembers() => MembersLazy.Value;

    /// <summary>
    /// Gets the instance of type <see cref="T"/> with the specified value, or <c>null</c> if not found.
    /// </summary>
    /// <param name="value">The value of the instance to get.</param>
    /// <returns>
    /// The declared instance of type <see cref="T"/> with the specified value, or <c>null</c> if not found.
    /// </returns>
    public static T? GetFromValueOrDefault(string? value)
    {
        return GetMembers().FirstOrDefault(i => AreValuesEquals(i.Value, value));
    }

    /// <summary>
    /// Gets a collection containing all the values of the declared instances of <see cref="T"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="IEnumerable{String}"/> containing all the values of the declared instances of <see cref="T"/>.
    /// </returns>
    /// /// <remarks>
    /// Retrieves the values of the instances referenced by public static read-only fields in the <see cref="T"/> class.
    /// </remarks>
    public static IEnumerable<string> GetValues()
    {
        return GetMembers().Select(i => i.Value);
    }

    /// <summary>
    /// Indicates whether the class <see cref="T"/> has any declared instance that holds the specified value.
    /// </summary>
    /// <param name="value">The value to evaluate for.</param>
    /// <returns>
    /// <c>true</c> if the specified value is held by any declared instance of <see cref="T"/>; <c>false</c> otherwise.
    /// </returns>
    public static bool HasValue(string value)
    {
        return GetMembers().Any(i => AreValuesEquals(i.Value, value));
    }

    /// <inheritdoc />
    public override string ToString() => Value;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return (obj is Enumeration<T> other) && Equals(other);
    }

    /// <inheritdoc />
    public bool Equals(Enumeration<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return AreValuesEquals(Value, other.Value);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Value == null! ? 0 : Value.GetHashCode();
    }

    /// <summary>
    /// Overrides the == operator behaviour.
    /// </summary>
    /// <param name="lhs">Left value.</param>
    /// <param name="rhs">Right value.</param>
    /// <returns>Returns true if are equal, false otherwise.</returns>
    public static bool operator ==(Enumeration<T>? lhs, Enumeration<T>? rhs)
    {
        if (lhs is null)
        {
            return rhs is null;
        }

        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Overrides the != operator behaviour.
    /// </summary>
    /// <param name="lhs">Left value.</param>
    /// <param name="rhs">Right value.</param>
    /// <returns>Returns true if aren't equal, false otherwise.</returns>
    public static bool operator !=(Enumeration<T>? lhs, Enumeration<T>? rhs)
    {
        return !(lhs == rhs);
    }

    /// <summary>
    /// Overrides the == operator behaviour between string and Enumeration.
    /// </summary>
    /// <param name="lhs">Left value.</param>
    /// <param name="rhs">Right value.</param>
    /// <returns>Returns true if the string is equal to the Enumeration value, false otherwise.</returns>
    public static bool operator ==(string? lhs, Enumeration<T>? rhs)
    {
        return AreValuesEquals(lhs, rhs?.Value);
    }

    /// <summary>
    /// Overrides the != operator behaviour between string and Enumeration.
    /// </summary>
    /// <param name="lhs">Left value.</param>
    /// <param name="rhs">Right value.</param>
    /// <returns>Returns true if the string is not equal to the Enumeration value, false otherwise.</returns>
    public static bool operator !=(string? lhs, Enumeration<T>? rhs)
    {
        return !(lhs == rhs);
    }

    private static ImmutableHashSet<T> BuildMembersHashSet()
    {
        return typeof(T).GetFields(BindingFlags.Public |
                                   BindingFlags.Static |
                                   BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>()
            .ToImmutableHashSet();
    }

    private static bool AreValuesEquals(string? value1, string? value2)
    {
        return string.Equals(value1, value2, StringComparison.OrdinalIgnoreCase);
    }
}