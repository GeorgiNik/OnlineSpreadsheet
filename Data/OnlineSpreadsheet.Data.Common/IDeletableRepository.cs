namespace OnlineSpreadsheet.Data.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDeletableRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);

        void ActualDelete(int id);

        void ActualDelete(Expression<Func<T, bool>> conditions);
    }
}
