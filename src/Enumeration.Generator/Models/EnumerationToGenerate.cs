using System.Diagnostics.CodeAnalysis;

namespace PMart.Enumeration.Generator.Models;

/// <summary>
/// The enumeration to generate.
/// </summary>
[ExcludeFromCodeCoverage]
internal readonly record struct EnumerationToGenerate
{
    /// <summary>
    /// The name for the Enumeration class.
    /// </summary>
    public readonly string? Name;
    
    /// <summary>
    /// The namespace.
    /// </summary>
    public readonly string? Namespace;
    
    /// <summary>
    /// The accessibility level.
    /// </summary>
    public readonly string? AccessibilityLevel;
    
    /// <summary>
    /// The value indicating if the Enumeration to generate is EnumerationDynamic.
    /// </summary>
    public readonly bool IsDynamic;
    
    /// <summary>
    /// The members to add to the Enumeration class.
    /// </summary>
    public readonly EquatableStringDictionary? Members;
    
    /// <summary>
    /// The error to report.
    /// </summary>
    public readonly ErrorToReport? ErrorToReport;

    /// <summary>
    /// initializes a new instance of the class <see cref="EnumerationToGenerate"/>.
    /// </summary>
    /// <param name="name">The name for the Enumeration class.</param>
    /// <param name="nameSpace">The namespace.</param>
    /// <param name="accessibilityLevel">The accessibility level.</param>
    /// <param name="isDynamic">The value indicating if the Enumeration to generate is EnumerationDynamic.</param>
    /// <param name="members">The members to add to the Enumeration class.</param>
    public EnumerationToGenerate(
        string name,
        string? nameSpace,
        string accessibilityLevel,
        bool isDynamic,
        EquatableStringDictionary members)
    {
        Name = name;
        Namespace = nameSpace;
        AccessibilityLevel = accessibilityLevel;
        IsDynamic = isDynamic;
        Members = members;
    }
    
    /// <summary>
    /// initializes a new instance of the class <see cref="EnumerationToGenerate"/> with error.
    /// </summary>
    /// <param name="errorToReport">The error to report.</param>
    public EnumerationToGenerate(ErrorToReport errorToReport)
    {
        ErrorToReport = errorToReport;
    }
}