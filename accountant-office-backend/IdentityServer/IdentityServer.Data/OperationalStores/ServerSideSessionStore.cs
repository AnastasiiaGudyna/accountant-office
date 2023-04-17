using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace IdentityServer.Data.OperationalStores;

public class ServerSideSessionStore: IServerSideSessionStore
{
    public Task<ServerSideSession> GetSessionAsync(string key, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task CreateSessionAsync(ServerSideSession session, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task UpdateSessionAsync(ServerSideSession session, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task DeleteSessionAsync(string key, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ServerSideSession>> GetSessionsAsync(SessionFilter filter, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task DeleteSessionsAsync(SessionFilter filter, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ServerSideSession>> GetAndRemoveExpiredSessionsAsync(int count, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<ServerSideSession>> QuerySessionsAsync(SessionQuery filter = null, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}