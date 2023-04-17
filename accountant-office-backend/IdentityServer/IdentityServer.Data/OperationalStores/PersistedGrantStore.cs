using AutoMapper;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Stores;
using IdentityServer.Data.DbContexts;
using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.String;

namespace IdentityServer.Data.OperationalStores;

public class PersistedGrantStore: IPersistedGrantStore
{
    private readonly OperationalDataContext context;
    private readonly IMapper mapper;
    private readonly ILogger<PersistedGrantStore> logger;

    public PersistedGrantStore(OperationalDataContext context, IMapper mapper, ILogger<PersistedGrantStore> logger)
    {
        this.context = context;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task StoreAsync(DuendePersistedGrant token)
    {
        var existing = context
            .PersistedGrants
            .SingleOrDefault(x => x.Key == token.Key);
        if (existing == null)
        {
            logger.LogDebug("{PersistedGrantKey} not found in database", token.Key);

            var persistedGrant = mapper.Map<PersistedGrant>(token);
            context.PersistedGrants.Add(persistedGrant);
        }
        else
        {
            logger.LogDebug("{PersistedGrantKey} found in database", token.Key);
            
            mapper.Map(token, existing);
        }

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogWarning("exception updating {PersistedGrantKey} persisted grant in database: {Error}", token.Key, ex.Message);
        }
    }

    public Task<DuendePersistedGrant?> GetAsync(string key)
    {
        return Task.Run(() =>
        {
            var persistedGrant = context
                .PersistedGrants
                .AsNoTracking()
                .SingleOrDefault(x => x.Key == key);
            var model = mapper.Map<DuendePersistedGrant>(persistedGrant);

            logger.LogDebug("{PersistedGrantKey} found in database: {PersistedGrantKeyFound}", key, model != null);

            return model;
        });
    }

    public Task<IEnumerable<DuendePersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
    {
        return Task.Run(() =>
        {
            filter.Validate();

            var persistedGrants = Filter(context.PersistedGrants, filter);
            persistedGrants = Filter(persistedGrants, filter);//?????

            var model = mapper.ProjectTo<DuendePersistedGrant>(persistedGrants);

            logger.LogDebug(
                "{PersistedGrantCount} persisted grants found for {@Filter}",
                persistedGrants.Count(),
                filter);

            return model.AsEnumerable();
        });
    }

    public async Task RemoveAsync(string key)
    {
        var persistedGrant = context
            .PersistedGrants
            .SingleOrDefault(x => x.Key == key);
        if (persistedGrant!= null)
        {
            logger.LogDebug("removing {PersistedGrantKey} persisted grant from database", key);

            context.PersistedGrants.Remove(persistedGrant);

            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                logger.LogInformation("exception removing {PersistedGrantKey} persisted grant from database: {Error}", key, ex.Message);
            }
        }
        else
        {
            logger.LogDebug("no {PersistedGrantKey} persisted grant found in database", key);
        }
    }

    public async Task RemoveAllAsync(PersistedGrantFilter filter)
    {
        filter.Validate();

        var persistedGrants = Filter(context.PersistedGrants, filter);
        persistedGrants = Filter(persistedGrants, filter);

        logger.LogDebug("removing {PersistedGrantCount} persisted grants from database for {@Filter}", persistedGrants.Count(), filter);

        context.PersistedGrants.RemoveRange(persistedGrants);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogInformation("removing {PersistedGrantCount} persisted grants from database for subject {@Filter}: {Error}", persistedGrants.Count(), filter, ex.Message);
        }
    }
    
    private IQueryable<PersistedGrant> Filter(IQueryable<PersistedGrant> query, PersistedGrantFilter filter)
    {
        if (filter.ClientIds != null)
        {
            var ids = filter.ClientIds.ToList();
            if (!IsNullOrWhiteSpace(filter.ClientId))
            {
                ids.Add(filter.ClientId);
            }
            query = query.Where(x => ids.Contains(x.ClientId));
        }
        else if (!IsNullOrWhiteSpace(filter.ClientId))
        {
            query = query.Where(x => x.ClientId == filter.ClientId);
        }

        if (!IsNullOrWhiteSpace(filter.SessionId))
        {
            query = query.Where(x => x.SessionId == filter.SessionId);
        }
        if (!IsNullOrWhiteSpace(filter.SubjectId))
        {
            query = query.Where(x => x.SubjectId == filter.SubjectId);
        }

        if (filter.Types != null)
        {
            var types = filter.Types.ToList();
            if (!IsNullOrWhiteSpace(filter.Type))
            {
                types.Add(filter.Type);
            }
            query = query.Where(x => types.Contains(x.Type));
        }
        else if (!IsNullOrWhiteSpace(filter.Type))
        {
            query = query.Where(x => x.Type == filter.Type);
        }

        return query;
    }
}