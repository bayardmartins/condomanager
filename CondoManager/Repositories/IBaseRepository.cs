using CondoManager.Models;

namespace CondoManager.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        Task Delete(int id);
        Task Update(T item);
    }
}