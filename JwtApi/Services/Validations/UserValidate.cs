using JwtApi.Infra.Context;

namespace JwtApi.Services.Validations;

public class UserValidate
{
    private readonly DataContext _dataContext;

    public UserValidate(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public bool UserNameExists(string? userName)
    {
        return _dataContext.Users.Any(p => p.UserName == userName);
    } 
}