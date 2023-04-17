using Duende.IdentityServer.Services;
using IdentityServer.Data.DbContexts;

namespace IdentityServer.Data.ConfigurationStores;

public class CorsPolicyService : ICorsPolicyService
{
    private readonly ConfigurationDataContext context;

    public CorsPolicyService(ConfigurationDataContext context)
    {
        this.context = context;
    }

    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        throw new NotImplementedException();
    }
}