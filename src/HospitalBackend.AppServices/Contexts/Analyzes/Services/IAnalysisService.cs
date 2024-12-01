using HospitalBackend.Contracts.Analyzes;

namespace HospitalBackend.AppServices.Contexts.Analyzes.Services;

/// <summary>
/// Сервис для работы с анализами.
/// </summary>
public interface IAnalysisService
{
    /// <summary>
    /// Добавляет анализ по модели запроса.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения, в котором назначен анализ.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного анализа.</returns>
    Task<Guid> AddAnalysisAsync(Guid appointmentId, AddAnalysisRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает анализа по идентификатору истории болезни.
    /// </summary>
    /// <param name="historyId">Идентификатор истории болезни.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей анализов.</returns>
    Task<ICollection<AnalysisDto>> GetAnalysesByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает анализ по идентификатору.
    /// </summary>
    /// <param name="analysisId">Идентификатор анализа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель анализа.</returns>
    Task<AnalysisDto> GetByIdAsync(Guid analysisId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает анализ по идентификатору назначения.
    /// </summary>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель анализа.</returns>
    Task<AnalysisDto> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken);
}