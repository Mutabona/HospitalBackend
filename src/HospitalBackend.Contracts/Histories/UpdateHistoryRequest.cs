namespace HospitalBackend.Contracts.Histories;

/// <summary>
/// Запрос на обновление истории.
/// </summary>
public class UpdateHistoryRequest
{
    /// <summary>
    /// Диагноз
    /// </summary>
    public string? Diagnosis { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Дата выписки
    /// </summary>
    public DateOnly? DepartureDate { get; set; }
    
    /// <summary>
    /// Анамнез жизни
    /// </summary>
    public string LifeAnamnesis { get; set; }
    
    /// <summary>
    /// Анамнез болезни
    /// </summary>
    public string DiseaseAnamnesis { get; set; }
    
    /// <summary>
    /// Эпикриз
    /// </summary>
    public string? Epicrisis { get; set; }
    
    /// <summary>
    /// Жалобы
    /// </summary>
    public string Complaints { get; set; }
}