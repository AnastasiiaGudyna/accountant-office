using Microsoft.AspNetCore.Authorization;

namespace AccountantOffice.Api;

public static class AuthorizationPolicies
{
    public static void ConfigurePolicies (AuthorizationOptions options)
    {
        options.AddPolicy("read", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.read", "admin");
        });
        options.AddPolicy("change", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.write", "admin");
        });
        options.AddPolicy("delete", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.delete", "admin");
        });
    }
}