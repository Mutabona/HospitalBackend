using HospitalBackend.Domain.Analyzes;
using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Examinations;
using HospitalBackend.Domain.Patients;
using HospitalBackend.Domain.Users;

namespace HospitalBackend.Domain.Histories;

/// <summary>
/// История болезни
/// </summary>
public class History : BaseEntity
{
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
    /// Пациент
    /// </summary>
    public virtual Patient Patient { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Врач
    /// </summary>
    public virtual User User { get; set; }
    
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
    
    /// <summary>
    /// Анализы
    /// </summary>
    public virtual ICollection<Analysis> Analyzes { get; set; }
    
    /// <summary>
    /// Осмотры
    /// </summary>
    public virtual ICollection<Examination> Examinations { get; set; }
}