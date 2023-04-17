using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using IdentityServer.Data.DbContexts;

namespace IdentityServer.Data.ConfigurationStores;

public class ClientStore : IClientStore
{
    private readonly ConfigurationDataContext context;

    public ClientStore(ConfigurationDataContext context)
    {
        this.context = context;
    }

    public Task<Client> FindClientByIdAsync(string clientId)
    {
        throw new NotImplementedException();
    }
}