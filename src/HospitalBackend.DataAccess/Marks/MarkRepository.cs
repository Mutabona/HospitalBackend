using AutoMapper;
using HospitalBackend.AppServices.Contexts.Marks.Repositories;
using HospitalBackend.Contracts.Marks;
using HospitalBackend.Domain.Marks;
using HospitalBackend.Infrastructure.Repository;

namespace HospitalBackend.DataAccess.Marks;

/// <inheritdoc cref="IMarkRepository"/>
public class MarkRepository(IRepository<Mark> repository, IMapper mapper) : IMarkRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(MarkDto markDto, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(mapper.Map<Mark>(markDto), cancellationToken);
    }
}