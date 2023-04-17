using System.Linq;
using System.Security.Claims;

namespace AccountantOffice.Api.Extensions;

public static class ClaimsPrincipalExtension
{
    public static bool CanViewSalary(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(claim => claim.Type == "salary_visible" && claim.Value == "true") is not null;
    }
}