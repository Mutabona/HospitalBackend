using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Patients.Services;
using HospitalBackend.Contracts.Patients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Пациенты.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class PatientController(IPatientService service) : BaseController
{
    /// <summary>
    /// Добавляет пациента по модели запроса.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пациента.</returns>
    [HttpPost]
    [Authorize(Roles = "Doctor")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> AddPatientAsync(AddPatientRequest request, CancellationToken cancellationToken)
    {
        var patientId = await service.AddPatientAsync(request, cancellationToken);
        return Ok(patientId);
    }

    /// <summary>
    /// Получает пациентов по фио.
    /// </summary>
    /// <param name="fio">ФИО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей пациентов.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpGet("Fio/{fio}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetPatientsByFioAsync(string fio, CancellationToken cancellationToken)
    {
        var patients = await service.GetPatientsByFioAsync(fio, cancellationToken);
        return Ok(patients);
    }

    /// <summary>
    /// Получает пациента по идентификатору.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пациента.</returns>
    [Authorize(Roles = "Doctor")]
    [HttpGet("{patientId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken)
    {
        var patient = await service.GetPatientByIdAsync(patientId, cancellationToken);
        return Ok(patient);
    }
}