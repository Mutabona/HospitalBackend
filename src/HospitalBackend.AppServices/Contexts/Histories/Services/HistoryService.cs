using AutoMapper;
using HospitalBackend.AppServices.Contexts.Histories.Repositories;
using HospitalBackend.Contracts.Histories;

namespace HospitalBackend.AppServices.Contexts.Histories.Services;

/// <inheritdoc cref="IHistoryService"/>
public class HistoryService(IHistoryRepository repository, IMapper mapper) : IHistoryService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid patientId, Guid userId, AddHistoryRequest history, CancellationToken cancellationToken)
    {
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
}