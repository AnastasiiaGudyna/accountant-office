using Microsoft.AspNetCore.Authorization;

namespace AccountantOffice.Api;

/// <summary>
/// Configuration of Authorization policies used for accessing resources
/// </summary>
public static class AuthorizationPolicies
{
    /// <summary>
    /// Name of the "Read" authorization policy
    /// </summary>
    public const string Read = "read";
    
    /// <summary>
    /// Name of the "Change" authorization policy
    /// </summary>
    public const string Change = "change";
    
    /// <summary>
    /// Name of the "Delete" authorization policy
    /// </summary>
    public const string Delete = "delete";
    
    /// <summary>
    /// Configuration of <see cref="AuthorizationOptions"/>
    /// for <see cref="Microsoft.Extensions.DependencyInjection.PolicyServiceCollectionExtensions"/> AddAuthorization middleware
    /// </summary>
    /// <param name="options"></param>
    public static void ConfigurePolicies (AuthorizationOptions options)
    {
        options.AddPolicy(Read, policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.read", "admin");
        });
        options.AddPolicy(Change, policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.write", "admin");
        });
        options.AddPolicy(Delete, policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "accountant_office.delete", "admin");
        });
    }
}