using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Analyzes.Services;
using HospitalBackend.Contracts.Analyzes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Анализы.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
[ProducesResponseType((int)HttpStatusCode.Conflict)]
public class AnalysisController(IAnalysisService service) : BaseController
{
    /// <summary>
    /// Добавляет анализ по модели запроса.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения, в котором содержится анализ.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного анализа.</returns>
    [Authorize(Roles = "Sister")]
    [HttpPost("/Appointment/{appointmentId}/Analysis")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> AddAnalysisAsync(Guid appointmentId, AddAnalysisRequest request, CancellationToken cancellationToken)
    {
        var analysis = await service.AddAnalysisAsync(appointmentId, request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, analysis);
    }

    /// <summary>
    /// Получает анализ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель анализа.</returns>
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(AnalysisDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var analysis = await service.GetByIdAsync(id, cancellationToken);
        return Ok(analysis);
    }

    /// <summary>
    /// Получает анализы по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция анализов.</returns>
    [Authorize]
    [HttpGet("/History/{historyId}/Analysis")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ICollection<AnalysisDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        var analyzes = await service.GetAnalysesByHistoryIdAsync(historyId, cancellationToken);
        return Ok(analyzes);
    }

    /// <summary>
    /// Получает анализ по идентификатору назначения.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель анализа.</returns>
    [Authorize]
    [HttpGet("/Appointment/{appointmentId}/Analysis")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(AnalysisDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var analysis = await service.GetByAppointmentIdAsync(appointmentId, cancellationToken);
        return Ok(analysis);
    }
}