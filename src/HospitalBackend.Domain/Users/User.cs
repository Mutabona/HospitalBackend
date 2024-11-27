using HospitalBackend.Domain.Base;
using HospitalBackend.Domain.Examinations;
using HospitalBackend.Domain.Histories;
using HospitalBackend.Domain.Marks;
using HospitalBackend.Domain.Roles;

namespace HospitalBackend.Domain.Users;

/// <summary>
/// Пользователь
/// </summary>
public class User : BaseEntity
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
    
    /// <summary>
    /// Истории, которые ведёт врач
    /// </summary>
    public virtual ICollection<History> Histories { get; set; }
    
    /// <summary>
    /// Отметки о выполнении, которые сделала медсестра
    /// </summary>
    public virtual ICollection<Mark> Marks { get; set; }
    
    /// <summary>
    /// Осмотры, которые провёл врач
    /// </summary>
    public virtual ICollection<Examination> Examinations { get; set; }
}