using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Histories;

namespace HospitalBackend.Domain.Patients;

/// <summary>
/// Пациент
/// </summary>
public class Patient : BaseEntity
{
    /// <summary>
    /// ФИО
    /// </summary>
    public string FIO { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Telephone { get; set; }
    
    /// <summary>
    /// Серия и номер пасспорта
    /// </summary>
    public string Passport { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
    
    /// <summary>
    /// Адрес проживания
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Истории болезни
    /// </summary>
    public virtual ICollection<History> Histories { get; set; }
}