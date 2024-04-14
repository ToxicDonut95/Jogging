namespace Jogging.Contracts.Interfaces.RepoInterfaces
{
    public interface IGenericRepo<T> where T : class
    {
        //crud
        void Add(T item);
        Task<T> AddAsync(T item);

        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        void Update(T item);

        void Delete(T item);
    }
}