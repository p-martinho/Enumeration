namespace PMart.Enumeration.Generator.Attributes;

/// <summary>
/// The Enumeration ignore attribute. Marks a field that should be ignored and should not trigger the generation of an Enumeration member.
/// It should be used for fields that are eligible for creating an Enumeration member, but the user don't want that behavior for that field.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
[System.Diagnostics.Conditional("ENUMERATION_ATTRIBUTES_SCOPE_RUNTIME")]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public class EnumerationIgnoreAttribute : System.Attribute
{
}