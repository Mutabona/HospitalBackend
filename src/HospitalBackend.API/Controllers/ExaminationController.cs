using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Examinations.Services;
using HospitalBackend.Contracts.Examinations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Осмотры.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
[ProducesResponseType((int)HttpStatusCode.Conflict)]
public class ExaminationController(IExaminationService service) : BaseController
{
    /// <summary>
    /// Создаёт осмотр по модели запроса.
    /// </summary>
    /// <param name="historyId">История болезни, к которой добавляется осмотр.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного осмотра.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpPost("/History/{historyId}/Examination")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddExaminationAsync(Guid historyId, AddExaminationRequest request, CancellationToken cancellationToken)
    {
        var id = await service.AddAsync(historyId, request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, id);
    }

    /// <summary>
    /// Удаляет осмотр по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор осмотра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Doctor")]
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteExaminationAsync(Guid id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Получает осмотры по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей осмотров.</returns>
    [Authorize]
    [HttpGet("/History/{historyId}/Examination")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ICollection<ExaminationDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetExaminationsByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        var examinations = await service.GetByHistoryIdAsync(historyId, cancellationToken);
        return Ok(examinations);
    }

    /// <summary>
    /// Получает осмотр по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель осмотра.</returns>
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ExaminationDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetExaminationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var examination = await service.GetByIdAsync(id, cancellationToken);
        return Ok(examination);
    }

    /// <summary>
    /// Изменяет осмотр по модели запроса.
    /// </summary>
    /// <param name="id">Идентификатор осмотра.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Doctor")]
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateExaminationAsync(Guid id, UpdateExaminationRequest request, CancellationToken cancellationToken)
    {
        await service.UpdateAsync(id, request, cancellationToken);
        return NoContent();
    }
}