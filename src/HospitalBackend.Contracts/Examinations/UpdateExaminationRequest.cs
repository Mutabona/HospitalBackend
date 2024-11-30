namespace HospitalBackend.Contracts.Examinations;

/// <summary>
/// Запрос на обновление осмотра.
/// </summary>
public class UpdateExaminationRequest
{
    /// <summary>
    /// Дата осмотра
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Заключение
    /// </summary>
    public string? Conclusion { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid UserId { get; set; }
}