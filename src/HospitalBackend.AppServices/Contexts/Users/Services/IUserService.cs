using HospitalBackend.Contracts.Users;

namespace HospitalBackend.AppServices.Contexts.Users.Services;

/// <summary>
/// Сервис для работы с пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Регистрирует пользователя.
    /// </summary>
    /// <param name="request">Запрос на регистрацию.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор зарегистрированного пользователя.</returns>
    Task<Guid> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Запрос на авторизацию пользователя.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>JWT</returns>
    Task<string> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Проверяет уникальность почты.
    /// </summary>
    /// <param name="email">Почта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если почта уникальная, иначе false.</returns>
    Task<bool> IsUniqueLoginAsync(string email, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пользователя.</returns>
    Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет пользователя по модели запроса.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task UpdateUserAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает пользователей по фио.
    /// </summary>
    /// <param name="fio">ФИО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей пользователей.</returns>
    Task<ICollection<UserDto>> GetUsersByFioAsync(string fio, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли такой работник.
    /// </summary>
    /// <param name="userId">Идентификатор работника.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsUserExistsAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, является ли пользователь доктором.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если является, false, если нет.</returns>
    Task<bool> IsUserDoctorAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает всех докторов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция врачей.</returns>
    Task<ICollection<UserDto>> GetDoctorsAsync(CancellationToken cancellationToken);
}