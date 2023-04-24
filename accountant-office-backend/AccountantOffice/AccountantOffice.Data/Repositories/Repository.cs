using System;
using System.Linq;
using System.Linq.Expressions;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.Repositories;

public class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    private readonly DbContext context;
    public Repository(TContext context)
    {
        this.context = context;
    }
        
    public IQueryable<TEntity> GetList()
    {
        return context.Set<TEntity>();
    }
        
    public IQueryable<TEntity> GetList(int page, int items)
    {
        return context.Set<TEntity>().Skip(page*items).Take(items);
    }

    public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> condition, int page, int items)
    {
        return context.Set<TEntity>().Where(condition).Skip(page*items).Take(items);
    }

    public TEntity GetItemById(Guid id)
    {
        return context.Set<TEntity>().Find(id);
    }

    public Guid CreateItem(TEntity item)
    {
        item.CreateDate = DateTime.UtcNow;
        var entry = context.Add(item);
        context.SaveChanges();
        return entry.Entity.Id;
    }

    public Guid UpdateItem(TEntity item)
    {
        var entry = context.Update(item);
        context.SaveChanges();
        return entry.Entity.Id;
    }

    public Guid DeleteItem(TEntity item)
    {
        var entry = context.Remove(item);
        context.SaveChanges();
        return entry.Entity.Id;
    }
}