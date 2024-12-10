namespace VivaAerobus.Domain.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(int id);

        void Delete(IEnumerable<string> ids);
    }
}
