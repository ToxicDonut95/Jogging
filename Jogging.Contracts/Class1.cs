namespace Jogging.Contracts;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();

    T Get(int id);

    void Update(T entity);

    void Delete(T entity);

    void Create(T entity);
}