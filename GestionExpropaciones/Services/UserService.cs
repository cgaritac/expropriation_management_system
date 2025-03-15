using System.Security.Claims;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ClaimsPrincipal _user;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _user = _httpContextAccessor.HttpContext?.User ??
                throw new InvalidOperationException(Constants.NoUserFoundError);
    }

    public string GetUserEmail()
    {
        var email = _user?.FindFirst(ClaimTypes.Email)?.Value;

        return email ?? Constants.UnknownUserText;
    }
}