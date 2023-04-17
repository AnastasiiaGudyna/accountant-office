using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityServer.Api.Constants;
using IdentityServer.Data.Models;
using IdentityServer.Data.OperationalStores;

namespace IdentityServer.Api.Services;

public class UserProfileService : IProfileService
{
    private readonly UserStore store;

    public UserProfileService(UserStore store)
    {
        this.store = store;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = Guid.Parse(context.Subject.GetSubjectId());
        var user = await store.GetUserById(sub);
        AddRequestedClaims(context, user);
    }

    private void AddRequestedClaims(ProfileDataRequestContext context, User user)
    {
        if (context.RequestedClaimTypes.Any())
        {
            var claims = new List<Claim>
            {
                new(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new(JwtClaimTypes.GivenName, user.FirstName),
                new(JwtClaimTypes.FamilyName, user.LastName),
                new(JwtClaimTypes.Email, user.Email),
                new(CustomClaimTypes.Department, "Administration"),
                new(CustomClaimTypes.CanChange, "true"),
                new(CustomClaimTypes.SalaryVisible, "false")
            };
            context.IssuedClaims.AddRange(context.FilterClaims(claims));
        }
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.Run(() => context.IsActive = true);
    }
}