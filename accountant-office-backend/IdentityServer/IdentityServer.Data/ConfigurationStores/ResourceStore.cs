using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using IdentityServer.Data.DbContexts;

namespace IdentityServer.Data.ConfigurationStores;

public class ResourceStore : IResourceStore
{
    private readonly ConfigurationDataContext context;

    public ResourceStore(ConfigurationDataContext context)
    {
        this.context = context;
    }

    public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
    {
        throw new NotImplementedException();
    }

    public Task<Resources> GetAllResourcesAsync()
    {
        throw new NotImplementedException();
    }
}