using AutoMapper;
using HospitalBackend.AppServices.Contexts.Patients.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Patients;

namespace HospitalBackend.AppServices.Contexts.Patients.Services;

/// <inheritdoc cref="IPatientService"/>
public class PatientService(IPatientRepository repository, IMapper mapper) : IPatientService
{
    ///<inheritdoc/>
    public async Task<ICollection<PatientDto>> GetPatientsByFioAsync(string? fio, CancellationToken cancellationToken)
    {
        return await repository.GetPatientsByFioAsync(fio, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<PatientDto> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken)
    {
        return await repository.GetPatientByIdAsync(patientId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<Guid> AddPatientAsync(AddPatientRequest patient, CancellationToken cancellationToken)
    {
        var patientDto = mapper.Map<PatientDto>(patient);
        patientDto.Id = Guid.NewGuid();
        return await repository.AddPatientAsync(patientDto, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsPatientExistsAsync(Guid patientId, CancellationToken cancellationToken)
    {
        try
        {
            await repository.GetPatientByIdAsync(patientId, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }
}