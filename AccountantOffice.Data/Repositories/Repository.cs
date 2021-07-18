using System;
using System.Linq;
using System.Linq.Expressions;
using AccountantOffice.Core.Entities;
using AccountantOffice.Data.DBContext;
using AccountantOffice.UseCases.Interfaces;

namespace AccountantOffice.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    where T : Entity
    {
        private readonly AccountantContext context;
        public Repository(AccountantContext context)
        {
            this.context = context;
        }
        
        public IQueryable<T> GetList(uint page, uint items)
        {
            return context.Set<T>().Skip((int) (page*items)).Take((int) items);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> condition, uint page, uint items)
        {
            return context.Set<T>().Where(condition).Skip((int) (page*items)).Take((int) items);
        }

        public T GetItemById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public Guid CreateItem(T item)
        {
            item.CreateDate = DateTimeOffset.UtcNow;
            var entry = context.Add(item);
            context.SaveChanges();
            return entry.Entity.Id;
        }

        public Guid UpdateItem(T item)
        {
            var entry = context.Update(item);
            context.SaveChanges();
            return entry.Entity.Id;
        }

        public Guid DeleteItem(T item)
        {
            var entry = context.Remove(item);
            context.SaveChanges();
            return entry.Entity.Id;
        }
    }
}