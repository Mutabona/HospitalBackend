using HospitalBackend.Contracts.Patients;

namespace HospitalBackend.AppServices.Contexts.Patients.Services;

/// <summary>
/// Сервис для работы с пациентами
/// </summary>
public interface IPatientService
{
    /// <summary>
    /// Получает пациентов по фио.
    /// </summary>
    /// <param name="fio">ФИО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей пациентов.</returns>
    Task<ICollection<PatientDto>> GetPatientsByFioAsync(string fio, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает пациента по идентификатору.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Моедбль пациента.</returns>
    Task<PatientDto> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет пациента по модели запроса.
    /// </summary>
    /// <param name="patient">Пациент.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пользователя.</returns>
    Task<Guid> AddPatientAsync(AddPatientRequest patient, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли такой пациент.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsPatientExistsAsync(Guid patientId, CancellationToken cancellationToken);
}