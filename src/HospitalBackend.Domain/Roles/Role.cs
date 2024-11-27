namespace HospitalBackend.Domain.Roles;

/// <summary>
/// Роль пользователя.
/// </summary>
public enum Role
{
    /// <summary>
    /// Неопределённая роль
    /// </summary>
    Undefined = 0,
    
    /// <summary>
    /// Администратор
    /// </summary>
    Admin = 1,
    
    /// <summary>
    /// Доктор
    /// </summary>
    Doctor = 2,
    
    /// <summary>
    /// Медсестра
    /// </summary>
    Sister = 3
}