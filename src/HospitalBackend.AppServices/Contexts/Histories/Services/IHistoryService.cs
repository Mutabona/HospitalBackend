using HospitalBackend.Contracts.Histories;

namespace HospitalBackend.AppServices.Contexts.Histories.Services;

/// <summary>
/// Сервис для работы с историями болезни.
/// </summary>
public interface IHistoryService
{
    /// <summary>
    /// Добавление истории по модели запроса.
    /// </summary>
    /// <param name="userId">Идентификатор врача.</param>
    /// <param name="history">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <returns>Идентификатор созданной истории.</returns>
    Task<Guid> AddAsync(Guid patientId, Guid userId, AddHistoryRequest history, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет историю по модели запроса.
    /// </summary>
    /// <param name="historyId">Идентификатор истории.</param>
    /// <param name="history">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task UpdateAsync(Guid historyId, UpdateHistoryRequest history, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает истории по идентификатору пациента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей историй.</returns>
    Task<ICollection<HistoryDto>> GetByPatientIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает историю по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель истории.</returns>
    Task<HistoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли такая история болезни.
    /// </summary>
    /// <param name="id">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsHistoryExistsAsync(Guid id, CancellationToken cancellationToken);
}