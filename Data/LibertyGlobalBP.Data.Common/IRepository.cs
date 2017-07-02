namespace LibertyGlobalBP.Data.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);

        void Add(T entity);

        bool All(Expression<Func<T, bool>> conditions);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> conditions);

        void Delete(int id);

        T Get(int id);

        T Get(Guid id);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> conditions);

        bool Any(Expression<Func<T, bool>> conditions);

        void Detach(T entity);

        IQueryable<T> Where(Expression<Func<T, bool>> conditions);

        int SaveChanges();

        int Count(Expression<Func<T, bool>> conditions);
    }
}
