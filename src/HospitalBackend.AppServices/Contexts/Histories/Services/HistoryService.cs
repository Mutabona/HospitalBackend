using AutoMapper;
using HospitalBackend.AppServices.Contexts.Histories.Repositories;
using HospitalBackend.AppServices.Contexts.Patients.Services;
using HospitalBackend.AppServices.Contexts.Users.Services;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Histories;

namespace HospitalBackend.AppServices.Contexts.Histories.Services;

/// <inheritdoc cref="IHistoryService"/>
public class HistoryService(IHistoryRepository repository, IMapper mapper, IPatientService patientService, IUserService userService) : IHistoryService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid patientId, Guid userId, AddHistoryRequest history, CancellationToken cancellationToken)
    {
        if (!(await patientService.IsPatientExistsAsync(patientId, cancellationToken)))
            throw new ConflictException("Такого пациента не существует.");
        var historyEntity = mapper.Map<HistoryDto>(history);
        historyEntity.PatientId = patientId;
        historyEntity.UserId = userId;
        historyEntity.Id = Guid.NewGuid();
        return await repository.AddAsync(historyEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task UpdateAsync(Guid historyId, UpdateHistoryRequest history, CancellationToken cancellationToken)
    {
        var historyEntity = await repository.GetByIdAsync(historyId, cancellationToken);
        if (!(await userService.IsUserExistsAsync(history.UserId, cancellationToken)))
            throw new ConflictException("Такого работника не существует.");
        if (!(await userService.IsUserDoctorAsync(history.UserId, cancellationToken)))
            throw new ConflictException("Этот пользователь не является доктором.");
        historyEntity.UserId = history.UserId;
        historyEntity.Diagnosis = history.Diagnosis;
        historyEntity.DepartureDate = history.DepartureDate;
        historyEntity.LifeAnamnesis = history.LifeAnamnesis;
        historyEntity.DiseaseAnamnesis = history.DiseaseAnamnesis;
        historyEntity.Epicrisis = history.Epicrisis;
        historyEntity.Complaints = history.Complaints;
        await repository.UpdateAsync(historyEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<HistoryDto>> GetByPatientIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await repository.GetByPatientIdAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<HistoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsHistoryExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await repository.GetByIdAsync(id, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }
}