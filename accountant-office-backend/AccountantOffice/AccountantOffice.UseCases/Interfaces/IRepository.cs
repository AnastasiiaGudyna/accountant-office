using System;
using System.Linq;
using System.Linq.Expressions;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetList();
        IQueryable<T> GetList(int page, int items);
        IQueryable<T> GetList(Expression<Func<T, bool>> condition, int page, int items);
        T GetItemById(Guid id);
        Guid CreateItem(T item);
        Guid UpdateItem(T item);
        Guid DeleteItem(T item);
    }
}