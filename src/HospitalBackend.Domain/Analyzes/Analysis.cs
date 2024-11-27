using HospitalBackend.Domain.Appointments;
using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Histories;

namespace HospitalBackend.Domain.Analyzes;

/// <summary>
/// Анализ
/// </summary>
public class Analysis : BaseEntity
{
    /// <summary>
    /// Тип анализа
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Дата анализа
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Результаты анализа
    /// </summary>
    public string Result { get; set; }
    
    /// <summary>
    /// Идентификатор истории болезни
    /// </summary>
    public Guid HistoryId { get; set; }
    
    /// <summary>
    /// История болезни
    /// </summary>
    public virtual History History { get; set; }
    
    /// <summary>
    /// Идентификатор назначения
    /// </summary>
    public Guid AppointmentId { get; set; }
    
    /// <summary>
    /// Назначение
    /// </summary>
    public virtual Appointment Appointment { get; set; }
}