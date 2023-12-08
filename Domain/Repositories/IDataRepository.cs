using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        T GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        void Remove(T entity);
        void Update(T entity);
    }
}
