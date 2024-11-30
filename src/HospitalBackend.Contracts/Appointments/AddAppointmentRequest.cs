namespace HospitalBackend.Contracts.Appointments;

/// <summary>
/// Запрос на добавление назначения.
/// </summary>
public class AddAppointmentRequest
{
    /// <summary>
    /// Содержание
    /// </summary>
    public string Content { get; set; }
}