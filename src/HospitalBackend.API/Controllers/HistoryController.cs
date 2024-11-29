using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Histories.Services;
using HospitalBackend.Contracts.Histories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Истории болезни.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class HistoryController(IHistoryService service) : BaseController
{
    /// <summary>
    /// Создаёт историю болезни по модели запроса.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пользователя.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpPost("/Patient/{patientId}/History")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> AddHistoryAsync(Guid patientId, AddHistoryRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        var historyId = await service.AddAsync(patientId, userId, request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, historyId.ToString());
    }

    /// <summary>
    /// Получает истории болезни по идентификатору пациента.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей историй болезни.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpGet("/Patient/{patientId}/History")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ICollection<HistoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByPatientIdAsync(Guid patientId, CancellationToken cancellationToken)
    {
        var histories = await service.GetByPatientIdAsync(patientId, cancellationToken);
        return Ok(histories);
    }

    /// <summary>
    /// Получает историю по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель истории.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(HistoryDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var history = await service.GetByIdAsync(id, cancellationToken);
        return Ok(history);
    }

    /// <summary>
    /// Обновляет историю по модели запроса.
    /// </summary>
    /// <param name="id">Идентификатор истории.</param>
    /// <param name="request">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Doctor")]
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateHistoryRequest request, CancellationToken cancellationToken)
    {
        await service.UpdateAsync(id, request, cancellationToken);
        return NoContent();
    }
}