using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using IdentityServer.Data.DbContexts;

namespace IdentityServer.Data.ConfigurationStores;

public class AddIdentityProviderStore : IIdentityProviderStore
{
    private readonly ConfigurationDataContext context;
    public AddIdentityProviderStore(ConfigurationDataContext context)
    {
        this.context = context;
    }
    public Task<IEnumerable<IdentityProviderName>> GetAllSchemeNamesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IdentityProvider> GetBySchemeAsync(string scheme)
    {
        throw new NotImplementedException();
    }
}