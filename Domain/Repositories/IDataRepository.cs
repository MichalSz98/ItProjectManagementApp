namespace Domain.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Remove(T entity);
        void Update(T entity);
    }
}
