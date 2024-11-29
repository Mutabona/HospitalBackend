namespace HospitalBackend.Contracts.Patients;

/// <summary>
/// Запрос на добавление пациента
/// </summary>
public class AddPatientRequest
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
}