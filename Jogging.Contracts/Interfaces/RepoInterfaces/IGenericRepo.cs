namespace Jogging.Contracts.Interfaces.RepoInterfaces
{
    public interface IGenericRepo<T> where T : class
    {
        //crud
        void Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T item);
        void Delete(T item);

    }
}
