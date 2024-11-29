namespace HospitalBackend.Contracts.Histories;

/// <summary>
/// Модель истории.
/// </summary>
public class HistoryDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Диагноз
    /// </summary>
    public string? Diagnosis { get; set; }
    
    /// <summary>
    /// Дата поступления
    /// </summary>
    public DateOnly ArriveDate { get; set; }
    
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    public Guid PatientId { get; set; }
    
    /// <summary>
    /// ФИО пациента 
    /// </summary>
    public string PatientFio { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// ФИО Врача
    /// </summary>
    public string DoctorFio { get; set; }
    
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