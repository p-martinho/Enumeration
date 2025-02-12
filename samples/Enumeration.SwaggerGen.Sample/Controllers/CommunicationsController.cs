using Enumeration.SwaggerGen.Sample.Enumerations;
using Enumeration.SwaggerGen.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Enumeration.SwaggerGen.Sample.Controllers;

/// <summary>
/// Communications
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CommunicationsController : ControllerBase
{
    /// <summary>
    /// Gets all communication records by type.
    /// </summary>
    /// <param name="type">The communication type.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of all communication records.</returns>
    /// <response code="200">Returns the list of all communication records.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CommunicationRecord>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? type = null,
        CancellationToken cancellationToken = default)
    {
        var communicationTypes = GetCommunicationTypesToFilter(type);

        var response = await GetSampleResponseAsync(communicationTypes);

        return Ok(response);
    }

    private static IEnumerable<CommunicationType> GetCommunicationTypesToFilter(string? requestedType)
    {
        if (requestedType is null)
        {
            return CommunicationType.GetMembers();
        }

        var communicationType = CommunicationType.GetFromValueOrDefault(requestedType);

        return communicationType is null ? [] : [communicationType];
    }

    private static Task<IEnumerable<CommunicationRecord>> GetSampleResponseAsync(
        IEnumerable<CommunicationType> communicationTypes)
    {
        return Task.FromResult(GetAllCommunicationRecords()
            .Where(c => communicationTypes.Contains(c.Type)));
    }

    private static IEnumerable<CommunicationRecord> GetAllCommunicationRecords()
    {
        return
        [
            new CommunicationRecord
            {
                To = "sample@email.com",
                SentAt = DateTime.UtcNow,
                Type = CommunicationType.Email
            },
            new CommunicationRecord
            {
                To = "123456",
                SentAt = DateTime.UtcNow,
                Type = CommunicationType.Sms
            },
            new CommunicationRecord
            {
                To = "sample@email.com",
                SentAt = DateTime.UtcNow,
                Type = CommunicationType.PushNotification
            }
        ];
    }
}