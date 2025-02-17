namespace PMart.Enumeration.Generator.Attributes;

/// <summary>
/// The Enumeration attribute. Marks a partial class as an Enumeration class to generate.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class)]
[System.Diagnostics.Conditional("ENUMERATION_ATTRIBUTES_SCOPE_RUNTIME")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public class EnumerationAttribute : System.Attribute
{
    /// <summary>
    /// Value indicating if the Enumeration class should be of subtype <c>EnumerationDynamic</c> instead of <c>Enumeration</c>.
    /// </summary>
    public bool IsDynamic { get; set; }
}