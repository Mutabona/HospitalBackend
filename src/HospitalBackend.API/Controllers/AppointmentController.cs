using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Appointments.Services;
using HospitalBackend.Contracts.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Назначения.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class AppointmentController(IAppointmentService service) : BaseController
{
    /// <summary>
    /// Добавляет назначение по модели запроса.
    /// </summary>
    /// <param name="examinationId">Осмотр, на котором сделано назначение.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного назначения.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpPost("/Examination/{examinationId}/Appointment")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> AddAppointmentAsync(Guid examinationId, AddAppointmentRequest request, CancellationToken cancellationToken)
    {
        var id = await service.AddAsync(examinationId, request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, id);
    }

    /// <summary>
    /// Получает назначение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отменыю</param>
    /// <returns>Модель назначения.</returns>
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppointmentDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var appointment = await service.GetByIdAsync(id, cancellationToken);
        return StatusCode((int)HttpStatusCode.OK, appointment);
    }

    /// <summary>
    /// Получает назначение по идентификатору истории болезни.
    /// </summary>
    /// <param name="id">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей назначений.</returns>
    [Authorize]
    [HttpGet("/History/{id}/Appointment")]
    [ProducesResponseType(typeof(ICollection<AppointmentDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetByHistoryIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var appointments = await service.GetByHistoryIdAsync(id, cancellationToken);
        return Ok(appointments);
    }
}