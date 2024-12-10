namespace VivaAerobus.Domain.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetByIds(IEnumerable<int> ids);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetByDate(DateTime fromDate, DateTime toDate);
    }
}
