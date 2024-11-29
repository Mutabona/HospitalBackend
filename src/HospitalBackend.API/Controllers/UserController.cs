using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Users.Services;
using HospitalBackend.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Пользователи.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Получает информацию о пользователе по иденификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пользователя.</returns>
    [Authorize(Roles = "Admin")]
    [HttpGet("Id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByIdAsync(id, cancellationToken);
        return Ok(user);
    }
    
    /// <summary>
    /// Получает пользователей по ФИО.
    /// </summary>
    /// <param name="fio">ФИО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей пользователей.</returns>
    [Authorize(Roles = "Admin")]
    [HttpGet("Fio/{fio}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetUsersByFioAsync(string fio, CancellationToken cancellationToken)
    {
        var users = await userService.GetUsersByFioAsync(fio, cancellationToken);
        return Ok(users);
    }

    /// <summary>
    /// Удаляет пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpDelete("Id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await userService.DeleteUserAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Обновляет пользователя по модели запроса.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPut("Id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateUserAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        await userService.UpdateUserAsync(id, request, cancellationToken);
        return NoContent();
    }
}