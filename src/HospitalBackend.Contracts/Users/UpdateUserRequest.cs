using HospitalBackend.Domain.Roles;

namespace HospitalBackend.Contracts.Users;

/// <summary>
/// Запрос на изменение пользователя.
/// </summary>
public class UpdateUserRequest
{
    /// <summary>
    /// ФИО
    /// </summary>
    public string FIO { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Telephone { get; set; }
    
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public Role Role { get; set; }
}