using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Histories.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Histories;
using HospitalBackend.Domain.Histories;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Histories;

/// <inheritdoc cref="IHistoryRepository"/>
public class HistoryRepository(IRepository<History> repository, IMapper mapper) : IHistoryRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(HistoryDto history, CancellationToken cancellationToken)
    {
        var historyEntity = mapper.Map<History>(history);
        return await repository.AddAsync(historyEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task UpdateAsync(HistoryDto history, CancellationToken cancellationToken)
    {
        var historyEntity = mapper.Map<History>(history);
        await repository.UpdateAsync(historyEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<HistoryDto>> GetByPatientIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var histories = await repository
            .GetAll()
            .Include(h => h.Patient)
            .Include(h => h.User)
            .Where(h => h.PatientId == id)
            .ProjectTo<HistoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (histories.Count == 0) throw new EntityNotFoundException();
        
        return histories;
    }

    ///<inheritdoc/>
    public async Task<HistoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var history = await repository
            .GetAll()
            .Include(h => h.Patient)
            .Include(h => h.User)
            .Where(h => h.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (history == null) throw new EntityNotFoundException();

        return mapper.Map<HistoryDto>(history);
    }
}