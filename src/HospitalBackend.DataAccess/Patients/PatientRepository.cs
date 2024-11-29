using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Patients.Repositories;
using HospitalBackend.Contracts.Patients;
using HospitalBackend.Domain.Patients;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Patients;

///<inheritdoc cref="IPatientRepository"/>
public class PatientRepository(IRepository<Patient> repository, IMapper mapper) : IPatientRepository
{
    ///<inheritdoc/>
    public async Task<ICollection<PatientDto>> GetPatientsByFioAsync(string fio, CancellationToken cancellationToken)
    {
        var patients = await repository
            .GetAll()
            .Where(s => s.FIO.ToLower().Contains(fio.ToLower()))
            .ProjectTo<PatientDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return patients;
    }

    ///<inheritdoc/>
    public async Task<PatientDto> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken)
    {
        var patient = await repository.GetByIdAsync(patientId, cancellationToken);
        return mapper.Map<PatientDto>(patient);
    }

    ///<inheritdoc/>
    public async Task<Guid> AddPatientAsync(PatientDto patient, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(mapper.Map<Patient>(patient), cancellationToken);
    }
}