using HospitalBackend.Contracts.Examinations;

namespace HospitalBackend.AppServices.Contexts.Examinations.Services;

/// <summary>
/// Сервис для работы с осмотрами.
/// </summary>
public interface IExaminationService
{
    /// <summary>
    /// Добавляет осмотр по модели запроса.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной истории.</returns>
    Task<Guid> AddAsync(Guid historyId, AddExaminationRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновляет осмотр по модели запроса.
    /// </summary>
    /// <param name="examinationId">Идентификатор осмотра.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task UpdateAsync(Guid examinationId, UpdateExaminationRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет осмотр.
    /// </summary>
    /// <param name="examinationId">Идентификатор осмотра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid examinationId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает осмотры по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор истории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей осмотров.</returns>
    Task<ICollection<ExaminationDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает осмотр по идентификатору.
    /// </summary>
    /// <param name="examinationId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель осмотра.</returns>
    Task<ExaminationDto> GetByIdAsync(Guid examinationId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли осмотр.
    /// </summary>
    /// <param name="examinationId">Идентификатор осмотра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsExaminationExistsAsync(Guid examinationId, CancellationToken cancellationToken);
}