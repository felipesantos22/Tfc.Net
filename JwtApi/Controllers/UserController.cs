using JwtApi.Domain.Entities;
using JwtApi.Infra.Repository;
using JwtApi.Services.Validations;
using Microsoft.AspNetCore.Mvc;


namespace JwtApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    
    private readonly UserRepository _userRepository;
    private readonly UserValidate _userValidate;
    
    public UserController(UserRepository userRepository, UserValidate userValidate)
    {
        _userRepository = userRepository;
        _userValidate = userValidate;
    }
    
    [HttpPost]
    public async Task<ActionResult<Users>> Create([FromBody] Users users)
    {
        var userName = _userValidate.UserNameExists(users.UserName);
        if (userName)
        {
            return BadRequest(new {message = "UserName already registered." });
        }
        users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
        var newLogin = await _userRepository.Create(users);
        return Ok(newLogin);
    }


    [HttpGet]
    public async Task<ActionResult<List<Users>>> Index()
    {
        var users = await _userRepository.Index();
        return Ok(users);
    }
    
}