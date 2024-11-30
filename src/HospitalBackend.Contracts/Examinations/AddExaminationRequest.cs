namespace HospitalBackend.Contracts.Examinations;

/// <summary>
/// Запрос на добавление осмотра.
/// </summary>
public class AddExaminationRequest
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