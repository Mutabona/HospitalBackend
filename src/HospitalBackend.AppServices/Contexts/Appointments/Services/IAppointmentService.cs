using HospitalBackend.Contracts.Appointments;

namespace HospitalBackend.AppServices.Contexts.Appointments.Services;

/// <summary>
/// Сервис для работы с назначениями.
/// </summary>
public interface IAppointmentService
{
    /// <summary>
    /// Добавляет назначение по меодели запроса.
    /// </summary>
    /// <param name="examinationId">Осмотр, на котором сделано назначение.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного назначения.</returns>
    Task<Guid> AddAsync(Guid examinationId, AddAppointmentRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает назначение по идентификатору.
    /// </summary>
    /// <param name="appointmentId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель назначения.</returns>
    Task<AppointmentDto> GetByIdAsync(Guid appointmentId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает назначения по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей назначений.</returns>
    Task<ICollection<AppointmentDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
}