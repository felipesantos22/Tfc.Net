using JwtApi.Domain.Entities;
using JwtApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Infra.Repository;

public class AuthRepository
{
    private readonly DataContext _dataContext;

    public AuthRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Users?> AuthUser(string? email, string? password)
    {
        var existingLogin = await _dataContext.Users
            .FirstOrDefaultAsync(e => e.Email == email);

        if (existingLogin == null)
        {
            return null;
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, existingLogin.Password);
        return isPasswordValid ? existingLogin : null;
    }
}