using Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Origin.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext.OriginDbContext _ctx;

        public Repository(DatabaseContext.OriginDbContext ctx)
        {
            this._ctx = ctx;
        }

        private static IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties,
                                                       IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<T> Members

        public IQueryable<T> AsQueryable()
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = AsQueryable();
            return query;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public T Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();

            query = PerformInclusions(includeProperties, query);

            return query.FirstOrDefault(where);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);

            _ctx.SaveChanges();
        }

        public void Insert(T entity)
        {
            DateTime timestamp = DateTime.Now;

            if (entity is IAuditableCreateUpdate)
            {
                var audit = (IAuditableCreateUpdate)entity;
                audit.DateAdded = timestamp;
                audit.DateUpdated = timestamp;
                //audit.UserAdded = db.UserId;
            }
            else if (entity is IAuditableCreate)
            {
                var audit = (IAuditableCreate)entity;
                audit.DateAdded = timestamp;
                //audit.UserAdded = db.UserId;
            }

            _ctx.Set<T>().Add(entity);

            _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            DateTime timestamp = DateTime.Now;

            if (entity is IAuditableCreateUpdate)
            {
                var audit = (IAuditableCreateUpdate)entity;
                audit.DateUpdated = timestamp;
                //audit.UserAdded = db.UserId;
            }

            _ctx.Set<T>().Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;

            _ctx.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            DateTime timestamp = DateTime.Now;

            foreach (var e in entities)
            {
                if (e is IAuditableCreateUpdate)
                {
                    var audit = (IAuditableCreateUpdate)e;
                    audit.DateAdded = timestamp;
                    audit.DateUpdated = timestamp;
                    //audit.UserAdded = db.UserId;
                }
                else if (e is IAuditableCreate)
                {
                    var audit = (IAuditableCreate)e;
                    audit.DateAdded = timestamp;
                    //audit.UserAdded = db.UserId;
                }

                _ctx.Entry(e).State = EntityState.Added;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            DateTime timestamp = DateTime.Now;

            foreach (var e in entities)
            {
                if (e is IAuditableCreateUpdate)
                {
                    var audit = (IAuditableCreateUpdate)e;
                    audit.DateUpdated = timestamp;
                    //audit.UserAdded = db.UserId;
                }

                _ctx.Entry(e).State = EntityState.Modified;
            }
        }

        public void PartialUpdate(T t, params Expression<Func<T, object>>[] properties)
        {
            var entry = _ctx.Entry(t);
            foreach (var p in properties) entry.Property(p).IsModified = true;
        }
        #endregion

        public IEnumerable<T> SqlQuery(string query, params dynamic[] parameters)
        {
            return _ctx.Set<T>().FromSqlRaw(query, parameters);
        }

        public int ExecuteSqlCommand(string query, params dynamic[] parameters)
        {
            return _ctx.Database.ExecuteSqlRaw(query, parameters);
        }



    }
}
