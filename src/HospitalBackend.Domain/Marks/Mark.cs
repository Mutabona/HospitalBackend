using HospitalBackend.Domain.Appointments;
using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Users;

namespace HospitalBackend.Domain.Marks;

/// <summary>
/// Отметка о выполнении назначения
/// </summary>
public class Mark : BaseEntity
{
    /// <summary>
    /// Флаг выполнения
    /// </summary>
    public bool IsDone { get; set; }
    
    /// <summary>
    /// Дата выполнения
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Идентификатор работника, который выполнил
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// Работник, который выполнил
    /// </summary>
    public virtual User? User { get; set; }
    
    /// <summary>
    /// Идентификатор назначения
    /// </summary>
    public Guid AppointmentId { get; set; }
    
    /// <summary>
    /// Назначение
    /// </summary>
    public virtual Appointment Appointment { get; set; }
}