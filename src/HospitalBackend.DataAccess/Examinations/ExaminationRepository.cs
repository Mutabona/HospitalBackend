using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Examinations.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Examinations;
using HospitalBackend.Domain.Examinations;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Examinations;

/// <inheritdoc cref="IExaminationRepository"/>
public class ExaminationRepository(IRepository<Examination> repository, IMapper mapper) : IExaminationRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(ExaminationDto examinationDto, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(mapper.Map<Examination>(examinationDto), cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ExaminationDto> GetByIdAsync(Guid examinationId, CancellationToken cancellationToken)
    {
        var examination = await repository
            .GetAll()
            .Include(x => x.User)
            .Include(x => x.History)
            .Include(x => x.History.Patient)
            .Where(x => x.Id == examinationId)
            .ProjectTo<ExaminationDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (examination == null) throw new EntityNotFoundException();
        
        return examination;
    }

    ///<inheritdoc/>
    public async Task<ICollection<ExaminationDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        var examinations = await repository
            .GetAll()
            .Include(x => x.User)
            .Include(x => x.History)
            .Include(x => x.History.Patient)
            .Where(x => x.History.Id == historyId)
            .ProjectTo<ExaminationDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return examinations;
    }

    ///<inheritdoc/>
    public async Task UpdateAsync(ExaminationDto examinationDto, CancellationToken cancellationToken)
    {
        var examination = mapper.Map<Examination>(examinationDto);
        await repository.UpdateAsync(examination, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(Guid examinationId, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(examinationId, cancellationToken);
    }
}