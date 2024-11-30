namespace HospitalBackend.Contracts.Appointments;

/// <summary>
/// Модель назначения.
/// </summary>
public class AppointmentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Содержание
    /// </summary>
    public string Content { get; set; }
    
    /// <summary>
    /// Дата назначения.
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Идентификатор осмотра
    /// </summary>
    public Guid ExaminationId { get; set; }
    
    /// <summary>
    /// Фио пациента.
    /// </summary>
    public string PatientFio { get; set; }
    
    /// <summary>
    /// Фио доктора.
    /// </summary>
    public string DoctorFio { get; set; }
    
    /// <summary>
    /// Отметка о выполнении.
    /// </summary>
    public bool? IsMarked { get; set; }
    
    /// <summary>
    /// Дата выполнения.
    /// </summary>
    public DateOnly? MarkDate { get; set; }
    
    /// <summary>
    /// Фио того, кто отметил назначение, как выполненное.
    /// </summary>
    public string? FioMarkedBy { get; set; }
}