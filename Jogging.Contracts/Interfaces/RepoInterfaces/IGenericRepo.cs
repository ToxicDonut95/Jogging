namespace Jogging.Contracts.Interfaces.RepoInterfaces
{
    public interface IGenericRepo<T> where T : class
    {
        //crud
        void Add(T item);
        void AddAsync(T item);

        Task<IEnumerable<T>> GetAllAsync();

        T Get(int id);

        void Update(T item);

        void Delete(T item);
    }
}