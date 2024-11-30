using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Users.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Users;
using HospitalBackend.Domain.Users;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Users;

///<inheritdoc cref="IUserRepository"/>
public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Создаёт экземпляр <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Маппер.</param>
    public UserRepository(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    ///<inheritdoc/>
    public async Task<Guid> AddAsync(UserDto user, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(user);
        return await _repository.AddAsync(userEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<UserDto> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetAll()
            .Where(s => s.Login == request.Login && s.Password == request.Password)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new EntityNotFoundException();
        return user;
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(userId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetByLoginAsync(string login, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetAll()
            .Where(s => s.Login == login)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new EntityNotFoundException();
        return user;
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAll().Where(s => s.Id == userId)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        
        if (user == null) throw new EntityNotFoundException();
        return _mapper.Map<UserDto>(user);
    }

    ///<inheritdoc/>
    public async Task UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(userDto);
        await _repository.UpdateAsync(user, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<UserDto>> GetUsersByFioAsync(string fio, CancellationToken cancellationToken)
    {
        var users = await _repository
            .GetAll()
            .Where(s => s.FIO.ToLower().Contains(fio.ToLower()))
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return users;
    }
}