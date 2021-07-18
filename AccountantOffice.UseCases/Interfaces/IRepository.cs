using System;
using System.Linq;
using System.Linq.Expressions;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetList(uint page, uint items);
        IQueryable<T> GetList(Expression<Func<T, bool>> condition, uint page, uint items);
        T GetItemById(Guid id);
        Guid CreateItem(T item);
        Guid UpdateItem(T item);
        Guid DeleteItem(T item);
    }
}