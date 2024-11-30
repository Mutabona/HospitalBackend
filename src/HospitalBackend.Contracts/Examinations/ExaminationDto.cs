namespace HospitalBackend.Contracts.Examinations;

/// <summary>
/// Модель осмотра.
/// </summary>
public class ExaminationDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Дата осмотра
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Заключение
    /// </summary>
    public string? Conclusion { get; set; }
    
    /// <summary>
    /// Идентификатор истории болезни
    /// </summary>
    public Guid HistoryId { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Фио пациента
    /// </summary>
    public string PatientFio { get; set; }
    
    /// <summary>
    /// Фио доктора
    /// </summary>
    public string DoctorFio { get; set; }
}