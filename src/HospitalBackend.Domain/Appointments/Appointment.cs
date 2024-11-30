using HospitalBackend.Domain.Analyzes;
using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Examinations;
using HospitalBackend.Domain.Marks;

namespace HospitalBackend.Domain.Appointments;

/// <summary>
/// Назначение
/// </summary>
public class Appointment : BaseEntity
{
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
    /// Осмотр
    /// </summary>
    public virtual Examination Examination { get; set; }
    
    /// <summary>
    /// Анализы
    /// </summary>
    public virtual ICollection<Analysis> Analyzes { get; set; }
    
    /// <summary>
    /// Отметка о выполнении
    /// </summary>
    public virtual Mark? Mark { get; set; }
}