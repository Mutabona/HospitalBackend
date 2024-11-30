using HospitalBackend.Contracts.Examinations;

namespace HospitalBackend.AppServices.Contexts.Examinations.Repositories;

/// <summary>
/// Репозиторий для работы с осмотрами.
/// </summary>
public interface IExaminationRepository
{
    /// <summary>
    /// Добавляет осмотр.
    /// </summary>
    /// <param name="examinationDto">Осмотр.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного осмотра.</returns>
    Task<Guid> AddAsync(ExaminationDto examinationDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает осмотр по идентификатору.
    /// </summary>
    /// <param name="examinationId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель осмотра.</returns>
    Task<ExaminationDto> GetByIdAsync(Guid examinationId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает осмотры по идентификатору пациента.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция осмотров.</returns>
    Task<ICollection<ExaminationDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
    
     /// <summary>
     /// Изменяет осмотр.
     /// </summary>
     /// <param name="examinationDto">Осмотр.</param>
     /// <param name="cancellationToken">Токен отмены.</param>
     /// <returns></returns>
    Task UpdateAsync(ExaminationDto examinationDto, CancellationToken cancellationToken);
     
    /// <summary>
    /// Удаляет осмотр по идентификатору.
    /// </summary>
    /// <param name="examinationId">Идентификатор осмотра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid examinationId, CancellationToken cancellationToken);
}