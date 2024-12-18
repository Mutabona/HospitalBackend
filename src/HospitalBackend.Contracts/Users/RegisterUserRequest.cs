﻿using HospitalBackend.Domain.Roles;

namespace HospitalBackend.Contracts.Users;

/// <summary>
/// Запрос на регистрацию пользователя
/// </summary>
public class RegisterUserRequest
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