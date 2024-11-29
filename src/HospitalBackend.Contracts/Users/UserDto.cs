using HospitalBackend.Domain.Roles;

namespace HospitalBackend.Contracts.Users;

/// <summary>
/// Модель пользователя
/// </summary>
public class UserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
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