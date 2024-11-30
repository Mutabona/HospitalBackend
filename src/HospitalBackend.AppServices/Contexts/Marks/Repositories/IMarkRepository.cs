using HospitalBackend.Contracts.Marks;

namespace HospitalBackend.AppServices.Contexts.Marks.Repositories;

/// <summary>
/// Репозиторий для работы с отметками о выполнении назначений.
/// </summary>
public interface IMarkRepository
{
    /// <summary>
    /// Добавляет отметку о выполнении назначения.
    /// </summary>
    /// <param name="markDto">Отметка.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной отметки.</returns>
    Task<Guid> AddAsync(MarkDto markDto, CancellationToken cancellationToken);
}