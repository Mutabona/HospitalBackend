using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Analyzes.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Analyzes;
using HospitalBackend.Domain.Analyzes;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Analyzes;

/// <inheritdoc cref="IAnalysisRepository"/>
public class AnalysisRepository(IRepository<Analysis> repository, IMapper mapper) : IAnalysisRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(AnalysisDto analysisDto, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(mapper.Map<Analysis>(analysisDto), cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<AnalysisDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var analysis = await repository.GetByIdAsync(id, cancellationToken);
        return mapper.Map<AnalysisDto>(analysis);
    }

    ///<inheritdoc/>
    public async Task<ICollection<AnalysisDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        var analyzes = await repository
            .GetAll()
            .Where(a => a.HistoryId == historyId)
            .ProjectTo<AnalysisDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return analyzes;
    }

    ///<inheritdoc/>
    public async Task<AnalysisDto> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var analysis = await repository
            .GetAll()
            .Where(a => a.AppointmentId == appointmentId)
            .ProjectTo<AnalysisDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (analysis == null) throw new EntityNotFoundException();
        
        return analysis;
    }
}