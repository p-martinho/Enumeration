namespace PMart.Enumeration.Generator.Attributes;

/// <summary>
/// The Enumeration member attribute. Marks a field to be used to generate as an Enumeration member, with the configuration provided (e.g. the name).
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
[System.Diagnostics.Conditional("ENUMERATION_ATTRIBUTES_SCOPE_RUNTIME")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public class EnumerationMemberAttribute : System.Attribute
{
    /// <summary>
    /// The name of the Enumeration member.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the class <see cref="EnumerationMemberAttribute"/>.
    /// </summary>
    /// <param name="memberName">The name for the Enumeration member.</param>
    public EnumerationMemberAttribute(string memberName)
    {
        Name = memberName;
    }
}