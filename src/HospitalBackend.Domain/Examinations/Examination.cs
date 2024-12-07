using HospitalBackend.Domain.Appointments;
using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Histories;
using HospitalBackend.Domain.Users;

namespace HospitalBackend.Domain.Examinations;

/// <summary>
/// Осмотр
/// </summary>
public class Examination : BaseEntity
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
    /// Идентификатор истории болезни
    /// </summary>
    public Guid HistoryId { get; set; }
    
    /// <summary>
    /// История болезни
    /// </summary>
    public virtual History History { get; set; }
    
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// Врач
    /// </summary>
    public virtual User? User { get; set; }
    
    /// <summary>
    /// Назначения
    /// </summary>
    public virtual ICollection<Appointment> Appointments { get; set; }
}