using ChariTov.Models;
using System.Security.Claims;
using ChariTov.DataModels;

public interface IRoleService
{
}

public class RoleService : IRoleService
{ 
    public Role GetRoleFromClaim(ClaimsPrincipal user)
    {
        var roleClaim = user.FindFirst(ClaimTypes.Role)?.Value;
        if (Enum.TryParse(roleClaim, out Role role))
        {
            return role;
        }
        throw new Exception("Role claim is not valid.");
    }
}