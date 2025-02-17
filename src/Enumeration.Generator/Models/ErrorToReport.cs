using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using PMart.Enumeration.Generator.Helpers;

namespace PMart.Enumeration.Generator.Models;

/// <summary>
/// The error to report.
/// </summary>
[ExcludeFromCodeCoverage]
internal readonly record struct ErrorToReport
{
    /// <summary>
    /// The error location.
    /// </summary>
    public readonly Location? Location;
    
    /// <summary>
    /// The error ID.
    /// </summary>
    public readonly string ErrorId = string.Empty;
    
    /// <summary>
    /// The error message.
    /// </summary>
    public readonly string Message = string.Empty;
    
    /// <summary>
    /// The member name where the error is located.
    /// </summary>
    public readonly string? MemberName;

    /// <summary>
    /// initializes a new instance of the class <see cref="ErrorToReport"/>.
    /// </summary>
    /// <param name="location">The error location.</param>
    /// <param name="errorId">The error ID.</param>
    /// <param name="memberName">The member name where the error is located (optional).</param>
    public ErrorToReport(Location? location, string errorId, string? memberName = null)
    {
        Location = location;
        ErrorId = errorId;
        Message = ErrorIds.GetErrorMessage(errorId);
        MemberName = memberName;
    }
}