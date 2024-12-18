﻿using HospitalBackend.Contracts.Histories;

namespace HospitalBackend.AppServices.Contexts.Histories.Repositories;

/// <summary>
/// Репозиторий для работы с историями болезни.
/// </summary>
public interface IHistoryRepository
{
    /// <summary>
    /// Добавление истории.
    /// </summary>
    /// <param name="history">История.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор созданной истории.</returns>
    Task<Guid> AddAsync(HistoryDto history, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновляет истории.
    /// </summary>
    /// <param name="history">История.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task UpdateAsync(HistoryDto history, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает истории по идентификатору пациента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей историй.</returns>
    Task<ICollection<HistoryDto>> GetByPatientIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает историю по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель истории.</returns>
    Task<HistoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}