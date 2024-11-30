namespace HospitalBackend.AppServices.Contexts.Marks.Services;

/// <summary>
/// Сервис для работы с отметками о выполнении назначений.
/// </summary>
public interface IMarkService
{
    /// <summary>
    /// Помечает назначение, как выполненное.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя, который выполнил назначение.</param>
    /// <param name="appointmentId">Идентификатор назначения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной отметки.</returns>
    Task<Guid> AddAsync(Guid userId, Guid appointmentId, CancellationToken cancellationToken);
}