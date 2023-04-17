using AutoMapper;
using Duende.IdentityServer.Stores;
using IdentityServer.Data.DbContexts;
using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data.OperationalStores;

public class SigningKeyStore : ISigningKeyStore 
{
    const string Use = "signing";

    /// <summary>
    /// The DbContext.
    /// </summary>
    private readonly OperationalDataContext context;

    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="SigningKeyStore"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="mapper">The mapper.</param>
    public SigningKeyStore(OperationalDataContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    
    /// <summary>
    /// Loads all keys from store.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<DuendeKey>> LoadKeysAsync()
    {
        return Task.Run(() =>
        {
            var entities = context
                .Keys
                .Where(x => x.Use == Use)
                .AsNoTracking();
            return mapper.ProjectTo<DuendeKey>(entities).AsEnumerable();
        });
    }

    /// <summary>
    /// Persists new key in store.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async Task StoreKeyAsync(DuendeKey key)
    {
        var entity = mapper.Map<Key>(key);
        entity.Use = Use;
        await context.Keys.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes key from storage.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteKeyAsync(string id)
    {
        return DeleteKeyAsync(Guid.Parse(id));
    }
    
    private async Task DeleteKeyAsync(Guid id)
    {
        var item = await context.Keys.Where(x => x.Use == Use && x.Id == id)
            .FirstOrDefaultAsync();
        if (item != null)
        {
            try
            {
                context.Keys.Remove(item);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach(var entity in ex.Entries)
                {
                    entity.State = EntityState.Detached;
                }
            }
        }
    }
}