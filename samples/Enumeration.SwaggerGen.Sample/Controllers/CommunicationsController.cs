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
    /// Gets all communication records.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of all communication records.</returns>
    /// <response code="200">Returns the list of all communication records.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CommunicationRecord>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetSampleResponseAsync();

        return Ok(response);
    }

    private Task<IEnumerable<CommunicationRecord>> GetSampleResponseAsync()
    {
        return Task.FromResult<IEnumerable<CommunicationRecord>>([
            new CommunicationRecord
            {
                To = "sample@email.com",
                SentAt = DateTime.UtcNow,
                Type = CommunicationType.Email
            }
        ]);
    }
}