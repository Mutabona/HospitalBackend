namespace HospitalBackend.Contracts.Analyzes;

/// <summary>
/// Модель анализа.
/// </summary>
public class AnalysisDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Тип анализа
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Дата анализа
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Результаты анализа
    /// </summary>
    public string Result { get; set; }
    
    /// <summary>
    /// Идентификатор истории болезни
    /// </summary>
    public Guid HistoryId { get; set; }
    
    /// <summary>
    /// Идентификатор назначения
    /// </summary>
    public Guid AppointmentId { get; set; }
}