using AutoMapper;
using HospitalBackend.AppServices.Contexts.Users.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.AppServices.Services;
using HospitalBackend.Contracts.Users;
using HospitalBackend.Domain.Roles;

namespace HospitalBackend.AppServices.Contexts.Users.Services;

///<inheritdoc cref="IUserService"/>
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Создаёт экземпляр <see cref="UserService"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="jwtService">Сервис для создания jwt.</param>
    /// <param name="mapper">Маппер.</param>
    public UserService(IUserRepository repository, IJwtService jwtService, IMapper mapper)
    {
        _repository = repository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    ///<inheritdoc/>
    public async Task<Guid> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        if (await IsUniqueLoginAsync(request.Login, cancellationToken))
        {
            var user = _mapper.Map<UserDto>(request);
            user.Id = Guid.NewGuid();
            var userId =  await _repository.AddAsync(user, cancellationToken);
            
            return userId;
        }
        else
        {
            throw new LoginAlreadyExistsException();
        }
    }

    ///<inheritdoc/>
    public async Task<string> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        request.Password = request.Password;
        UserDto user;
        try
        {
            user = await _repository.LoginAsync(request, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            throw new InvalidLoginDataException();
        }
        
        return _jwtService.GetToken(request, user.Id, user.Role);
    }

    ///<inheritdoc/>
    public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(userId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsUniqueLoginAsync(string login, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.GetByLoginAsync(login, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return true;
        }
        return false;
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(userId, cancellationToken);
    }
    
    ///<inheritdoc/>
    public async Task UpdateUserAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(id, cancellationToken);
        user.Password = request.Password;
        user.Login = request.Login;
        user.Role = request.Role;
        user.Telephone = request.Telephone;
        user.FIO = request.FIO;
        
        await _repository.UpdateUserAsync(user, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<UserDto>> GetUsersByFioAsync(string fio, CancellationToken cancellationToken)
    {
        return await _repository.GetUsersByFioAsync(fio, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsUserExistsAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.GetByIdAsync(userId, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }

    ///<inheritdoc/>
    public async Task<bool> IsUserDoctorAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(userId, cancellationToken);
        if (user.Role == Role.Doctor) return true;
        return false;
    }
}