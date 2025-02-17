using System.Diagnostics.CodeAnalysis;
using PMart.Enumeration.Generator.Attributes;

namespace PMart.Enumeration.Generator.Helpers;

/// <summary>
/// The collection of error IDs.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class ErrorIds
{
    /// <summary>
    /// The ID for the error "invalid member name".
    /// </summary>
    public const string InvalidMemberName = "ENUM0001";
    
    /// <summary>
    /// The ID for the error "member and constant has same name".
    /// </summary>
    public const string MemberHasSameNameAsConstant = "ENUM0002";
    
    /// <summary>
    /// The ID for error "other member with same name already declared".
    /// </summary>
    public const string MemberWithSameNameAlreadyDeclared = "ENUM0003";
    
    /// <summary>
    /// The ID for the error "member name duplicated".
    /// </summary>
    public const string MemberNameDuplicated = "ENUM0004";

    /// <summary>
    /// Gets the error message for the error ID provided.
    /// </summary>
    /// <param name="errorId">The error ID</param>
    /// <returns>The error message.</returns>
    public static string GetErrorMessage(string errorId)
    {
        return errorId switch
        {
            InvalidMemberName => $"Invalid name for the Enumeration member in the {nameof(EnumerationMemberAttribute)}",
            MemberHasSameNameAsConstant => "The name '{0}' of the Enumeration member is the same as the field name",
            MemberWithSameNameAlreadyDeclared => "A member with the name '{0}' is already declared",
            MemberNameDuplicated => "The name '{0}' for the Enumeration member is duplicated",
            _ => string.Empty
        };
    }
}