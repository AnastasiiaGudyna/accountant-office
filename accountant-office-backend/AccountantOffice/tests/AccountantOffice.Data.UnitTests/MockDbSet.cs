using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.UnitTests;

public static class MockDbSet
{
    public static DbSet<T> GetQueryableMockDbSet<T>(IEnumerable<T> sourceList) where T : class
    {
        var queryable = sourceList.AsQueryable();

        var dbSet = Substitute.For<DbSet<T>, IQueryable<T>>();
        var queryableDbSet = (IQueryable)dbSet;
        queryableDbSet.Provider.Returns(queryable.Provider);
        queryableDbSet.Expression.Returns(queryable.Expression);
        queryableDbSet.ElementType.Returns(queryable.ElementType);
        queryableDbSet.GetEnumerator().Returns(queryable.GetEnumerator());

        return dbSet;
    }
}