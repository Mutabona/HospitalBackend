using HospitalBackend.Contracts.Appointments;

namespace HospitalBackend.AppServices.Contexts.Appointments.Services;

/// <summary>
/// Сервис для работы с назначениями.
/// </summary>
public interface IAppointmentService
{
    /// <summary>
    /// Добавляет назначение по модели запроса.
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
    
    /// <summary>
    /// Получает идентификатор истории болезни по идентификатору назначения.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор истории болезни.</returns>
    Task<Guid> GetHistoryIdByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли назначение.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsAppointmentExistsAsync(Guid appointmentId, CancellationToken cancellationToken);
}