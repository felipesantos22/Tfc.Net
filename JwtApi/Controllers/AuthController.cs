using JwtApi.Domain.Entities;
using JwtApi.Infra.Repository;
using JwtApi.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers;

[ApiController]
[Route("api/user/auth")]
public class AuthController : ControllerBase
{
    
    private readonly AuthRepository _authRepository;

    public AuthController(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Users>> AuthUser([FromBody] Users user)
    {
        var obj = await _authRepository.AuthUser(user.Email, user.Password);
        if (obj == null)
        {
            return BadRequest(new { message = "Email or password not found." });
        }
        var token = TokenService.GenerateToken(obj);
        return Ok(new { Token = token });
    }
}