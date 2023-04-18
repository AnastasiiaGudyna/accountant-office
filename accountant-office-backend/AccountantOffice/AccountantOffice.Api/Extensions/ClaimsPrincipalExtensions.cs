using System.Linq;
using System.Security.Claims;

namespace AccountantOffice.Api.Extensions;

/// <summary>
/// Extensions for <see cref="ClaimsPrincipal"/> class
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Claims Principal extension to check if the authenticated user has access to view employee's salary
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static bool CanViewSalary(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(claim => claim.Type == "salary_visible" && claim.Value == "true") is not null;
    }
}