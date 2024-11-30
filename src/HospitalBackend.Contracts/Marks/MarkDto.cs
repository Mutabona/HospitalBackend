namespace HospitalBackend.Contracts.Marks;

/// <summary>
/// Отметка о выполнении назначения.
/// </summary>
public class MarkDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
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
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Идентификатор назначения
    /// </summary>
    public Guid AppointmentId { get; set; }
}