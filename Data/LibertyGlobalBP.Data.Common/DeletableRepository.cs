namespace LibertyGlobalBP.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using LibertyGlobalBP.Data.Models;
    using LibertyGlobalBP.Data.Models.Entities;

    /// <summary>
    /// Generic repository where the delete action sets the flag 'IsDeleted' to true.
    /// The GetAll method returns records that are not marked as deleted.
    /// Contains method ActualDelete which removes selected entity from the database.
    /// In order for this to work, the database models which we want to keep forever need to inherit AuditInfo and implement IDeletableEntity.
    /// All the methods from the original repository must be overwriten in order to get relevant data
    /// </summary>
    public class DeletableRepository<T> : Repository<T>, IDeletableRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return base.GetAll().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.GetAll();
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public override void Detach(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public override T FirstOrDefault()
        {
            return this.GetAll().FirstOrDefault();
        }

        public override T FirstOrDefault(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().FirstOrDefault(conditions);
        }

        public override bool Any(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Any(conditions);
        }

        public override bool All(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().All(conditions);
        }

        public override int Count(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Count(conditions);
        }

        public override IQueryable<T> Where(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Where(conditions);
        }

        public void ActualDelete(T entity)
        {
            base.Delete(entity);
        }

        public void ActualDelete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.ActualDelete(entity);
            }
        }

        public void ActualDelete(Expression<Func<T, bool>> conditions)
        {
            foreach (var item in this.AllWithDeleted().Where(conditions))
            {
                this.ActualDelete(item);
            }
        }
    }
}
