using Core.Abstractions;
using System.Linq.Expressions;

namespace Origin.Business.Service
{
    public class Service<T> : IService<T> where T : class, Core.Abstractions.IEntity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public T Find(int id)
        {
            return _repository.Find(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
        /*
        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _repository.Filter(where);
        }*/

        public IEnumerable<T> Filter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.Filter(where, includeProperties);
        }

        public T Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.Find(where, includeProperties);
        }
    }
}
