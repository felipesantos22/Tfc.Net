namespace JwtApi.Domain.Entities;

public class Users: BaseEntity
{
    public string? UserName { get; set; }
    public string? Role { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
}