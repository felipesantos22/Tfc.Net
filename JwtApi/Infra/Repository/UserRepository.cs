using JwtApi.Domain.Entities;
using JwtApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Infra.Repository;

public class UserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Users> Create(Users users)
    {
        await _dataContext.Users.AddAsync(users);
        await _dataContext.SaveChangesAsync();
        return users;
    }
    
    public async Task<List<Users>> Index()
    {
        var users = await _dataContext.Users.Select(l => new Users()
        {
            Id = l.Id,
            UserName = l.UserName,
            Role = l.Role,
            Email = l.Email,
            Password = l.Password
        }).ToListAsync();
        return users;
    }

}