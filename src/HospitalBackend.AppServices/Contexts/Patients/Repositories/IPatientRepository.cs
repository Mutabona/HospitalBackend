using HospitalBackend.Contracts.Patients;

namespace HospitalBackend.AppServices.Contexts.Patients.Repositories;

/// <summary>
/// Репозиторий для работы с пациентами.
/// </summary>
public interface IPatientRepository
{
    /// <summary>
    /// Получает пациентов по фио.
    /// </summary>
    /// <param name="fio">ФИО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей пациентов.</returns>
    Task<ICollection<PatientDto>> GetPatientsByFioAsync(string? fio, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает пациента по идентификатору.
    /// </summary>
    /// <param name="patientId">Идентификатор пациента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пациента.</returns>
    Task<PatientDto> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет пациента по модели запроса.
    /// </summary>
    /// <param name="patient">Пациент.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданного пользователя.</returns>
    Task<Guid> AddPatientAsync(PatientDto patient, CancellationToken cancellationToken);
}