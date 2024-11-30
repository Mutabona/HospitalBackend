using HospitalBackend.Contracts.Analyzes;

namespace HospitalBackend.AppServices.Contexts.Analyzes.Repositories;

/// <summary>
/// Репозиторий для работы с анализами.
/// </summary>
public interface IAnalysisRepository
{
    /// <summary>
    /// Добавляет анализ.
    /// </summary>
    /// <param name="analysisDto">Анализ.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного анализа.</returns>
    Task<Guid> AddAsync(AnalysisDto analysisDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает анализ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор анализа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель налаиза.</returns>
    Task<AnalysisDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает анализы по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей анализов.</returns>
    Task<ICollection<AnalysisDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
}