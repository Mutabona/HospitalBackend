using HospitalBackend.Contracts.Appointments;

namespace HospitalBackend.AppServices.Contexts.Appointments.Repositories;

/// <summary>
/// Репозиторий для работы с назначениями.
/// </summary>
public interface IAppointmentRepository
{
    /// <summary>
    /// Добавляет назначение.
    /// </summary>
    /// <param name="appointment">Назначение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного назначения.</returns>
    Task<Guid> AddAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken);
    
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
    /// <returns>Коллекция назначений.</returns>
    Task<ICollection<AppointmentDto>> GetAppointmentsByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает идентификатор истории болезни по идентификатору назначения.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор истории болезни.</returns>
    Task<Guid> GetHistoryIdByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken);
}