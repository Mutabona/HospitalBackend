using System.Net;
using HospitalBackend.API.Base;
using HospitalBackend.AppServices.Contexts.Users.Services;
using HospitalBackend.Contracts.Users;
using HospitalBackend.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBackend.API.Controllers;

/// <summary>
/// Учетные записи.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
[ProducesResponseType((int)HttpStatusCode.Conflict)]
public class AccountController(IUserService userService) : BaseController
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="model">Модель регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор нового пользователя.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequest model, CancellationToken cancellationToken)
    {
        var id = await userService.RegisterAsync(model, cancellationToken);
        
        return StatusCode((int)HttpStatusCode.Created, id.ToString());
    }

    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    /// <param name="model">Запрос на аутентификацию.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>JWT</returns>
    [HttpPost("auth-token")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest model, CancellationToken cancellationToken)
    {
        var token = await userService.LoginAsync(model, cancellationToken);
       
        return Ok(token);
    }
}