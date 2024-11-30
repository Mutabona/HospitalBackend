using AutoMapper;
using HospitalBackend.AppServices.Contexts.Examinations.Repositories;
using HospitalBackend.AppServices.Contexts.Histories.Services;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Examinations;

namespace HospitalBackend.AppServices.Contexts.Examinations.Services;

/// <inheritdoc cref="IExaminationService"/>
public class ExaminationService(IExaminationRepository repository, IMapper mapper, IHistoryService historyService) : IExaminationService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid historyId, AddExaminationRequest request, CancellationToken cancellationToken)
    {
        if (!(await historyService.IsHistoryExistsAsync(historyId, cancellationToken)))
            throw new ConflictException("Такой истории болезни не существует.");
        var examination = mapper.Map<ExaminationDto>(request);
        examination.HistoryId = historyId;
        examination.Id = Guid.NewGuid();
        return await repository.AddAsync(examination, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task UpdateAsync(Guid examinationId, UpdateExaminationRequest request, CancellationToken cancellationToken)
    {
        var examination = await repository.GetByIdAsync(examinationId, cancellationToken);
        examination.UserId = request.UserId;
        examination.Conclusion = request.Conclusion;
        examination.Date = request.Date;
        await repository.UpdateAsync(examination, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(Guid examinationId, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(examinationId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<ExaminationDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        return await repository.GetByHistoryIdAsync(historyId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ExaminationDto> GetByIdAsync(Guid examinationId, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(examinationId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsExaminationExistsAsync(Guid examinationId, CancellationToken cancellationToken)
    {
        try
        {
            await repository.GetByIdAsync(examinationId, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }
}