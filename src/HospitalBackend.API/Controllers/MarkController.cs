using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Marks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Отметки о выполнении назначений.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
[ProducesResponseType((int)HttpStatusCode.Conflict)]
public class MarkController(IMarkService service) : BaseController
{
    /// <summary>
    /// Помечает назначение, как выполненное.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной отметки.</returns>
    [Authorize(Roles = "Sister")]
    [HttpPost("/Appointment/{appointmentId}/Mark")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> MarkAsDoneAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        var id = await service.AddAsync(userId, appointmentId, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, id);
    }
}